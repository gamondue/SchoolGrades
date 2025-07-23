using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TreeMpttBlazor.Extensions;

namespace gamon.TreeMptt
{
    public class TreeMptt
    {
        private BusinessLayer bl;
        private TreeMpttDb dbMptt;
        private IJSRuntime? jsRuntime;
        
        // Eventi per notificare i cambiamenti ai componenti Blazor
        public event Action? OnTreeChanged;
        public event Action? OnNodeSelected;
        public event Action<bool>? OnLedStatusChanged;
        
        // Proprietà per gestire lo stato del tree
        public List<Topic> Nodes { get; private set; } = new();
        public Topic? SelectedNode { get; private set; }
        public bool HasChanges { get; private set; }
        
        // Proprietà per la ricerca
        public string SearchText { get; set; } = "";
        public bool SearchInDescriptions { get; set; } = false;
        public bool SearchWholeWord { get; set; } = false;
        public bool SearchCaseInsensitive { get; set; } = true;
        public bool SearchVerbatimString { get; set; } = false;
        public bool MarkAllTopicsFound { get; set; } = false;

        public TreeMptt(IJSRuntime? jsRuntime = null)
        {
            this.jsRuntime = jsRuntime;
            bl = Commons.bl;
            dbMptt = TreeMptt.SetDataLayer();
        }

        internal static TreeMpttDb SetDataLayer()
        {
#if SQL_SERVER
            return new TreeMpttDb_SqlServer();
#else
            return new TreeMpttDb_SqLite();
#endif
        }

        // Metodi async per Blazor
        public async Task<List<Topic>> GetNodesByParentAsync()
        {
            return await Task.Run(() => dbMptt.GetNodesByParentFromDatabase());
        }

        public async Task<List<Topic>> GetNodesByMpttAsync(int leftNode, int rightNode)
        {
            return await Task.Run(() => dbMptt.GetNodesByMpttFromDatabase(leftNode, rightNode));
        }

        public async Task LoadTreeAsync()
        {
            try
            {
                OnLedStatusChanged?.Invoke(true);
                Nodes = await GetNodesByParentAsync();
                OnTreeChanged?.Invoke();
            }
            finally
            {
                OnLedStatusChanged?.Invoke(false);
            }
        }

        public async Task SaveTreeAsync()
        {
            try
            {
                OnLedStatusChanged?.Invoke(true);
                await Task.Run(() => dbMptt.SaveNodesFromScratch(Nodes));
                HasChanges = false;
                OnTreeChanged?.Invoke();
            }
            finally
            {
                OnLedStatusChanged?.Invoke(false);
            }
        }

        public async Task<List<Topic>> FindNodesAsync(string searchText, bool searchInDescriptions, 
            bool searchWholeWord, bool searchCaseInsensitive, bool searchVerbatimString)
        {
            return await Task.Run(() => dbMptt.FindNodesLike(searchText, searchInDescriptions, 
                searchWholeWord, searchCaseInsensitive, searchVerbatimString));
        }

        // Metodi per gestire i nodi
        public void SelectNode(Topic topic)
        {
            SelectedNode = topic;
            OnNodeSelected?.Invoke();
        }

        public void AddNewNode(string name, bool asChild = true)
        {
            var newTopic = new Topic
            {
                Id = GenerateNewId(),
                Name = name,
                Desc = "",
                ParentNodeNew = asChild ? SelectedNode?.Id : SelectedNode?.ParentNodeNew
            };

            Nodes.Add(newTopic);
            HasChanges = true;
            OnTreeChanged?.Invoke();
        }

        public void DeleteSelectedNode()
        {
            if (SelectedNode != null && SelectedNode.Id.HasValue)
            {
                RemoveNodeAndChildren(SelectedNode.Id.Value);
                SelectedNode = null;
                HasChanges = true;
                OnTreeChanged?.Invoke();
                OnNodeSelected?.Invoke();
            }
        }

        private void RemoveNodeAndChildren(int nodeId)
        {
            var nodesToRemove = Nodes.Where(n => n.Id == nodeId || IsDescendantOf(n, nodeId)).ToList();
            foreach (var node in nodesToRemove)
            {
                Nodes.Remove(node);
            }
        }

        private bool IsDescendantOf(Topic node, int ancestorId)
        {
            var current = node;
            while (current?.ParentNodeNew != null)
            {
                if (current.ParentNodeNew == ancestorId)
                    return true;
                current = Nodes.FirstOrDefault(n => n.Id == current.ParentNodeNew);
            }
            return false;
        }

        public void UpdateSelectedNode(string name, string description)
        {
            if (SelectedNode != null)
            {
                SelectedNode.Name = name;
                SelectedNode.Desc = description;
                HasChanges = true;
                OnTreeChanged?.Invoke();
            }
        }

        // Metodi per la gestione delle checkbox (per lezioni)
        public void CheckNode(Topic topic, bool isChecked)
        {
            topic.SetChecked(isChecked);
            OnTreeChanged?.Invoke();
        }

        public List<Topic> GetCheckedNodes()
        {
            return Nodes.Where(n => n.IsChecked()).ToList();
        }

        public void UncheckAllNodes()
        {
            foreach (var node in Nodes)
            {
                node.SetChecked(false);
            }
            OnTreeChanged?.Invoke();
        }

        public void CheckNodesInList(List<Topic> topicsToCheck)
        {
            // Prima deseleziona tutti
            UncheckAllNodes();
            
            // Poi seleziona solo quelli nella lista
            foreach (var topic in topicsToCheck)
            {
                var nodeToCheck = Nodes.FirstOrDefault(n => n.Id == topic.Id);
                if (nodeToCheck != null)
                {
                    nodeToCheck.SetChecked(true);
                }
            }
            OnTreeChanged?.Invoke();
        }

        // Metodi per la ricerca
        public async Task<List<Topic>> PerformSearchAsync()
        {
            var results = await FindNodesAsync(SearchText, SearchInDescriptions, 
                SearchWholeWord, SearchCaseInsensitive, SearchVerbatimString);
            
            if (MarkAllTopicsFound)
            {
                HighlightNodes(results);
            }
            
            return results;
        }

        public void HighlightNodes(List<Topic> nodesToHighlight)
        {
            // Reset previous highlights
            foreach (var node in Nodes)
            {
                node.SetHighlighted(false);
            }

            // Highlight found nodes
            foreach (var foundNode in nodesToHighlight)
            {
                var nodeToHighlight = Nodes.FirstOrDefault(n => n.Id == foundNode.Id);
                if (nodeToHighlight != null)
                {
                    nodeToHighlight.SetHighlighted(true);
                }
            }
            
            OnTreeChanged?.Invoke();
        }

        public void ResetSearch()
        {
            foreach (var node in Nodes)
            {
                node.SetHighlighted(false);
            }
            OnTreeChanged?.Invoke();
        }

        // Export/Import
        public string ExportSubtreeToText(Topic initialNode)
        {
            if (initialNode.LeftNodeOld == null || initialNode.RightNodeOld == null)
                return "";
                
            return CreateTextTreeOfDescendants(initialNode.LeftNodeOld, initialNode.RightNodeOld, false);
        }

        private string CreateTextTreeOfDescendants(int? leftNode, int? rightNode, bool? includeTopicsIds)
        {
            string indentString = "\t";
            string currentIndentation = "";
            string file = "";
            Stack<Topic> stack = new Stack<Topic>();
            List<Topic> listTopics = dbMptt.GetNodesByMpttFromDatabase(leftNode, rightNode);

            if (listTopics != null && listTopics.Count > 0)
            {
                Topic previousTopic = listTopics[0];
                file += previousTopic.Name + "\t" + previousTopic.Desc;
                if ((bool)includeTopicsIds)
                    file += "\t" + previousTopic.Id;
                file += "\r\n";
                stack.Push(previousTopic);

                for (int i = 1; i < listTopics.Count; i++)
                {
                    Topic currentTopic = listTopics[i];
                    if (currentTopic.RightNodeOld < previousTopic.RightNodeOld)
                    {
                        currentIndentation += indentString;
                        file += currentIndentation + currentTopic.Name + "\t" + currentTopic.Desc;
                        if ((bool)includeTopicsIds)
                            file += "\t" + currentTopic.Id;
                        file += "\r\n";
                        stack.Push(previousTopic);
                        previousTopic = currentTopic;
                    }
                    else
                    {
                        previousTopic = stack.Pop();
                        while (currentTopic.RightNodeOld > previousTopic.RightNodeOld)
                        {
                            if (stack.Count > 0)
                            {
                                previousTopic = stack.Pop();
                                currentIndentation = currentIndentation.Substring(0, Math.Max(0, currentIndentation.Length - 1));
                            }
                        }
                        file += currentIndentation + currentTopic.Name + "\t" + currentTopic.Desc;
                        if ((bool)includeTopicsIds)
                            file += "\t" + currentTopic.Id;
                        file += "\r\n";
                        stack.Push(previousTopic);
                        previousTopic = currentTopic;
                    }
                }
            }
            return file;
        }

        // Metodi di utility
        private int GenerateNewId()
        {
            return Nodes.Count > 0 ? (Nodes.Max(n => n.Id) ?? 0) + 1 : 1;
        }

        // Background saving (per compatibilità)
        public void SaveTreeMpttBackground()
        {
            while (!Commons.BackgroundTaskClose)
            {
                if (Commons.BackgroundTaskCanSave && HasChanges)
                {
                    try
                    {
                        Commons.BackgroundThreadIsSaving = true;
                        dbMptt.SaveLeftAndRightToDbMptt();
                        HasChanges = false;
                    }
                    catch (Exception ex)
                    {
                        Commons.ErrorLog("Errore nel salvataggio in background: " + ex.Message);
                    }
                    finally
                    {
                        Commons.BackgroundThreadIsSaving = false;
                    }
                }
                Thread.Sleep(Commons.BackgroundThreadSleepSeconds * 1000);
            }
        }

        // Metodi per interagire con JavaScript (se necessario)
        public async Task ScrollToNodeAsync(string nodeId)
        {
            if (jsRuntime != null)
            {
                await jsRuntime.InvokeVoidAsync("scrollToElement", nodeId);
            }
        }

        public async Task CopyToClipboardAsync(string text)
        {
            if (jsRuntime != null)
            {
                await jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
            }
        }
    }
}