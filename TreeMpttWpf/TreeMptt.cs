using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CheckBox = System.Windows.Controls.CheckBox;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;
using TreeView = System.Windows.Controls.TreeView;

namespace gamon.TreeMptt
{
    internal class TreeMptt
    {
        private string fullNameOfDatabase;

        /// <summary>
        /// Takes a TreeView control and adds to it, and to some ancillary TextBoxes and CheckBoxes, 
        /// the capability of storing and retrieving the tree in a database, memorizing it both 
        /// by the reference to the parent node of each node ("ByParent") 
        /// and by the use of a right and left nodes reference in a 
        /// Modified Preorder Traversal Tree organization ("Mptt"). 
        /// The saving of the tree in a MPTT fashion can be accomplished asynchronously
        /// in a separate thread. Consistency of the tree is preserved when the program exits. 
        /// (!! proved NOT TRUE is some cases, must be cured.. !!)
        /// Some events of the controls, re-driven to this class, are treated. 
        /// 
        /// An MPTT tree loads more quickly in a single DBMS query but saves much more 
        /// slowly, with one DBMS query for each change in the left and right node. 
        /// Almost all left and right nodes could be changed if the change in the tree is very "up", 
        /// near the root of the tree.
        /// With MPTT we can use single queries to retrive subtrees. 
        /// With MPTT we can have all the nodes that stay under a given node with just two tests.
        /// 
        ///  made by Gabriele MONTI - Forlì - Italia
        /// </summary>
        /// 

        // inspiration for the MPTT code comes from: 
        // https://www.sitepoint.com/hierarchical-data-database/, by Gijs Van Tulder

        // Business Logic Layer
        BusinessLayer bl;
        // class that encapsulates the data access to the tree nodes 
        TreeMpttDb dbMptt;

        private bool hasChanges = false;
        bool markAllInSearch = false;

        #region fields used for drag and drop
        // identification of the Treeview control from which the drag starts
        private int dragSourceControlHash;
        private bool hasNodeBeenSelectedFromTree = false;

        private Topic currentTopic = null;

        System.Windows.DragDropEffects typeOfDragAndDrop;
        #endregion

        #region lists used to detect changes, to have less accesses to the database 
        List<Topic> listItemsBefore; // !!!! this list should be non influent now. Code revision should eliminate it!!!!
        List<Topic> listItemsAfter;
        List<Topic> listItemsDeleted;
        #endregion

        // a stack used to remember the father node in some part of the code  
        Stack<TreeViewItem> stack = new Stack<TreeViewItem>();

        string previousSearch = "";
        int indexDone = 0;
        List<Topic> found = null;

        #region internal object variables for controls passed from outside
        // WPF control that is manipulated by this class
        private TreeView shownTreeView;
        TextBox txtNodeName;
        TextBox txtNodeDescription;
        TextBox txtSearchString;
        TextBox txtNodeDigest;
        TextBox txtCodNode;

        CheckBox chkSearchInDescriptions;
        CheckBox chkVerbatimString;
        CheckBox chkAllWord;
        CheckBox chkCaseInsensitive;
        CheckBox chkMarkAllNodesFound;
        #endregion

        #region coloring of the nodes
        private Brush colorOfHighlightedItem = Brushes.Khaki;
        private Brush colorOfFoundItem = Brushes.Lime;
        private Brush colorOfBeheadedColor = Brushes.Orange;
        #endregion

        // if true the backcolor of nodes will be cleared when the user clicks on one node 
        bool clearBackColorOnClick = true;
        internal bool ClearBackColorOnClick { get => clearBackColorOnClick; set => clearBackColorOnClick = value; }
        // Name of the object
        internal string Name { get; set; }
        // TreeView control from the calling code
        internal TreeView TreeView { get => shownTreeView; }

        bool functionKeysEnabled = true;
        private bool bulkChangeOfChecks;

        internal bool FunctionKeysEnabled
        {
            get
            {
                return functionKeysEnabled;
            }
            set
            {
                // Hook WPF events (equivalents to WinForms events)
                shownTreeView.SelectedItemChanged += shownTreeView_AfterSelect;
                shownTreeView.PreviewMouseLeftButtonDown += ShownTreeView_Click;
                shownTreeView.KeyDown += ShownTreeView_KeyDown;
                
                if (txtNodeName != null)
                {
                    txtNodeName.LostFocus += TxtNodeName_Leave;
                    txtNodeName.TextChanged += TxtNodeName_TextChanged;
                    txtNodeName.LostFocus += txtNodeName_LostFocus;
                }
                
                if (txtNodeDescription != null)
                {
                    txtNodeDescription.LostFocus += TxtNodeDescription_Leave;
                    txtNodeDescription.LostFocus += txtNodeDescription_LostFocus;
                }
                
                if (chkSearchInDescriptions != null)
                {
                    chkSearchInDescriptions.Checked += SearchCheckBoxes_CheckedChanged;
                    chkSearchInDescriptions.Unchecked += SearchCheckBoxes_CheckedChanged;
                }
                if (chkAllWord != null)
                {
                    chkAllWord.Checked += SearchCheckBoxes_CheckedChanged;
                    chkAllWord.Unchecked += SearchCheckBoxes_CheckedChanged;
                }
                if (chkCaseInsensitive != null)
                {
                    chkCaseInsensitive.Checked += SearchCheckBoxes_CheckedChanged;
                    chkCaseInsensitive.Unchecked += SearchCheckBoxes_CheckedChanged;
                }
                if (chkMarkAllNodesFound != null)
                {
                    chkMarkAllNodesFound.Checked += chkMarkAllNodesFound_CheckedChanged;
                    chkMarkAllNodesFound.Unchecked += chkMarkAllNodesFound_CheckedChanged;
                }
                if (chkVerbatimString != null)
                {
                    chkVerbatimString.Checked += chkVerbatimString_CheckedChanged;
                    chkVerbatimString.Unchecked += chkVerbatimString_CheckedChanged;
                }
                functionKeysEnabled = value;
            }
        }
        internal bool HasChanges { get => hasChanges; set => hasChanges = value; }
        
        // Constructor identico a WinForms, ma con tipi WPF
        internal TreeMptt(TreeView TreeViewControl, string FullNameOfDatabase,
            TextBox TxtNodeName, TextBox TxtNodeDescription, TextBox TxtNodeSearchString,
            TextBox TxtNodeDigest, TextBox TxtIdNode,
            System.Windows.Shapes.Rectangle LedRectangle, CheckBox ChkSearchInDescriptions, CheckBox ChkVerbatimString,
            CheckBox ChkAllWord, CheckBox ChkCaseInsensitive, CheckBox ChkMarkAllNodesFound,
            System.Windows.DragDropEffects TypeOfDragAndDrop = System.Windows.DragDropEffects.Move,
            bool PutCheckSignsOnNodes = true)
        {
            fullNameOfDatabase = FullNameOfDatabase;
            // !!!! TODO !!!! eliminate the dependency of this class from Business Layer
            bl = Commons.bl;
            dbMptt = TreeMptt.SetDataLayer(fullNameOfDatabase);

            shownTreeView = TreeViewControl;
            txtNodeName = TxtNodeName;
            txtNodeDescription = TxtNodeDescription;
            txtSearchString = TxtNodeSearchString;
            txtNodeDigest = TxtNodeDigest;
            txtCodNode = TxtIdNode;

            chkSearchInDescriptions = ChkSearchInDescriptions;
            chkAllWord = ChkAllWord;
            chkCaseInsensitive = ChkCaseInsensitive;
            chkVerbatimString = ChkVerbatimString;
            chkMarkAllNodesFound = ChkMarkAllNodesFound;

            if (shownTreeView != null)
            {
                FunctionKeysEnabled = true;
                // for drag & drop 
                shownTreeView.AllowDrop = true;
                shownTreeView.DragEnter += TreeView_DragEnter;
                shownTreeView.DragLeave += TreeView_DragLeave;
            }
            typeOfDragAndDrop = TypeOfDragAndDrop;
        }
        
        internal static TreeMpttDb SetDataLayer(string fullNameOfDatabase)
        {
#if SQL_SERVER
            return new TreeMpttDb_SqlServer("Dummy string. It is to be decided");
#else
            return new TreeMpttDb_SqLite(fullNameOfDatabase);
#endif
        }
        
        #region methods that save the tree
        internal void SaveTreeFromScratch()
        {
            int nodeCount = 1;
            List<Topic> listTopicsAfter = new List<Topic>();
            // recursive function
            GenerateNewListOfNodesFromTreeViewControl_Recursive((TreeViewItem)shownTreeView.Items[0],
                ref nodeCount, ref listTopicsAfter);
            dbMptt.SaveNodesFromScratch(listTopicsAfter);
            hasChanges = false;
        }
        
        internal void SaveTreeFromTreeViewByParent()
        {
            isSavingTree = true;
            try
            {
                Commons.StopOperationsOnBackgroundThread();
                Commons.SwitchPicLed(false);

                lock (Commons.LockSavingCriticalSections)
                {
                    dbMptt.SaveLeftRightConsistency(false);
                    listItemsAfter = new List<Topic>();
                    int nodeCount = 1;
                    GenerateNewListOfNodesFromTreeViewControl_Recursive(
                        (TreeViewItem)shownTreeView.Items[0],
                        ref nodeCount, ref listItemsAfter);

                    listItemsDeleted = new List<Topic>();
                    if (listItemsBefore != null)
                    {
                        foreach (Topic tOld in listItemsBefore)
                        {
                            if (FindNodeById_Recursive((TreeViewItem)shownTreeView.Items[0], tOld) == null)
                            {
                                if (tOld.ParentNodeOld > 0)
                                    listItemsDeleted.Add(tOld);
                            }
                        }
                    }
                    dbMptt.SaveTreeToDb(listItemsAfter, listItemsDeleted, false, true);
                    dbMptt.SaveLeftRightConsistency(false);
                }
                Commons.StartOperationsOnBackgroudSavingThread();
                hasChanges = false;
            }
            finally
            {
                isSavingTree = false;
            }
        }
        
        internal void SaveTreeMpttBackground()
        {
            // updates leftNode and rightNode of every node in the tree
            // works in background in a thread of its own
            // this method is the background thread

            // Starts a loop that finishes when we want to close the thread.
            // Closing will be fired from external, by setting to true BackgroundCanStillSaveTopicsTree
            while (!Commons.BackgroundTaskClose)  // closes task when the program is finishig 
            {
                // since we aren't saving, switch off the LED
                Commons.SwitchPicLed(false);
                // waits BackgroundThreadSleepTime seconds, watching every second if it must exit the loop 
                DateTime endTime = DateTime.Now.AddSeconds(Commons.BackgroundThreadSleepSeconds);
                while (DateTime.Now < endTime)
                {
                    Thread.Sleep(1000);
                    if (Commons.BackgroundTaskClose)
                        return;
                }
                // check if RightNode & LeftNode are already consistent, if they are, this task 
                // has nothing to do, so we will skip the modification, then wait again
                if (!dbMptt.AreLeftAndRightConsistent() && Commons.MethodCanContinue())
                {
                    // start saving in background, in locked condition
                    // other tasks can signal this to abort operation by setting 
                    // Commons.BackgroundTaskCanSave to false

                    // signal that the background thread is saving 
                    Commons.BackgroundThreadIsSaving = true;
                    // light up the saving LED
                    Commons.SwitchPicLed(true);

                    List<Topic> listNodes = null;
                    
                    // ? NUOVO: Usa TreeMpttLeftRight invece di GenerateNewListOfNodesFromDatabase
                    // Questo evita completamente la dipendenza da TreeView
                    try
                    {
                        TreeMpttLeftRight calculator = new TreeMpttLeftRight(dbMptt);
                        listNodes = calculator.CalculateLeftRightFromDatabase();
                    }
                    catch (Exception ex)
                    {
                        Commons.ErrorLog($"SaveTreeMpttBackground: Errore nel calcolo MPTT: {ex.Message}");
                        Commons.BackgroundThreadIsSaving = false;
                        Commons.SwitchPicLed(false);
                        continue;
                    }

                    // abort if cancelled or nothing to save
                    if (!Commons.MethodCanContinue() || Commons.BackgroundTaskClose || listNodes == null || listNodes.Count == 0)
                    {
                        Commons.BackgroundThreadIsSaving = false;
                        Commons.SwitchPicLed(false);
                        continue;
                    }

                    // Acquire lock only for the write operation
                    bool didSave = false;
                    lock (Commons.LockSavingCriticalSections)
                    {
                        // Respect background-save flag
                        if (!Commons.BackgroundTaskCanSave)
                        {
                            // do nothing here; saving skipped
                        }
                        else
                        {
                            // ? NEW: Save ONLY leftNode and rightNode (optimized for background)
                            // This avoids touching Name, Desc, Parent which the UI might be modifying
                            dbMptt.SaveOnlyLeftAndRightNodes(listNodes);
                            dbMptt.SaveLeftRightConsistency(true);
                            didSave = true;
                        }
                    }

                    // Release the lock BEFORE invoking UI/thread-affine operations
                    Commons.BackgroundThreadIsSaving = false;
                    Commons.SwitchPicLed(false);

                    if (!didSave)
                    {
                        // saving was skipped because BackgroundTaskCanSave == false
                        continue;
                    }
                }
            }
        }
        #endregion
        
        #region methods that read nodes and put them in the Treeview
        internal void AddNodesToTreeviewByBestMethod()
        {
            Commons.StopOperationsOnBackgroundThread();
            if (dbMptt.AreLeftAndRightConsistent())
            {
                // load using leftNode and rightNode values 
                // (database was left consistent, with correct values for 
                // leftNode and rightNode for every node)
                listItemsBefore = dbMptt.GetNodesByMpttFromDatabase(0, int.MaxValue);
                AddNodesToTreeViewWithMptt();
            }
            else
            {
                // load by parentNode value
                listItemsBefore = dbMptt.GetNodesByParentFromDatabase(); // is this useful ? 
                AddNodesToTreeViewByParent(shownTreeView, false);
            }
            ((TreeViewItem)shownTreeView.Items[0]).IsExpanded = true;
            // re-set the possibility of background saving
            Commons.StartOperationsOnBackgroudSavingThread();
        }
        
        internal void AddNodesToTreeViewWithMptt()
        {
            // avoid modifications by background saver by stopping it
            Commons.StopOperationsOnBackgroundThread();
            if (shownTreeView == null)
                shownTreeView = new TreeView();
            shownTreeView.Items.Clear();
            listItemsBefore = dbMptt.GetNodesByMpttFromDatabase(0, int.MaxValue);
            
            if (listItemsBefore != null && listItemsBefore.Count > 0)
            {
                // put first node in treeview 
                Topic previousNode = listItemsBefore[0];
                TreeViewItem previousUiNode = CreateTreeViewItem(previousNode);
                shownTreeView.Items.Add(previousUiNode); // first node of the tree
                for (int listIndex = 1; listIndex < listItemsBefore.Count; listIndex++)
                {
                    Topic currentNode = listItemsBefore[listIndex];
                    TreeViewItem currentUiNode = CreateTreeViewItem(currentNode);
                    if (currentNode.RightNodeOld < previousNode.RightNodeOld)
                    {
                        // if is in new level, adds the node to the next level
                        previousUiNode.Items.Add(currentUiNode);
                        // remember father node
                        stack.Push(previousUiNode);
                        previousUiNode = currentUiNode;
                        previousNode = (Topic)currentUiNode.Tag;
                    }
                    else
                    {
                        if (stack.Count == 0)
                             return;
                        do {
                            previousUiNode = (TreeViewItem)stack.Pop();
                            previousNode = (Topic)(previousUiNode.Tag);
                        } while (currentNode.RightNodeOld > previousNode.RightNodeOld);
                        // if same level, son of the same father
                        previousUiNode.Items.Add(currentUiNode);
                        stack.Push(previousUiNode);
                        previousUiNode = currentUiNode;
                        previousNode = (Topic)(previousUiNode.Tag);
                    }
                }
            } 
        }
        
        internal void AddNodesToTreeViewByParent(TreeView PassedTreeView, bool isCalledFromBackground)
        {
            // avoid modifications by background saver by stopping it
            // (only if the method in NOT called by the background saver itself)
            if (!isCalledFromBackground)
                Commons.StopOperationsOnBackgroundThread();
            PassedTreeView.Items.Clear();
            // open the Db connection, that will be taken open all throughout the saving
            dbMptt.OpenLocalConnectionIfClosed();
            // put all the roots in the Treeview
            // finds all the nodes that don't have a parent
            // so you can fit the Treeview of a Win Form program, that is multiroot
            // NOT DONE! 
            // (this program treats only one root node because with MPTT having more than one root 
            // would complicate the database, hence this list must have only one node 
            List<Topic> lt = dbMptt.GetNodesRoots(false);
            // if a connection is passed, keep the connection open during the tree traversal, 
            // in order to increase the performance 
            foreach (Topic t in lt)
            {
                if (!Commons.MethodCanContinue()) 
                    return;
                // first level nodes
                TreeViewItem rootNode = CreateTreeViewItem(t);
                PassedTreeView.Items.Add(rootNode);
                AddChildrenNodesToTreeViewFromDatabase(rootNode, 0);
            }
            // close the db connection
            dbMptt.CloseLocalConnectionIfWasFoundClosed();
            // at the end of operations, the background thread is re-enabled
            Commons.StartOperationsOnBackgroudSavingThread();
        }
        
        internal void GetSubtree_Recursive(TreeViewItem NodeStart, List<TreeViewItem> List) // (passes List for recursion) 
        {
            List.Add(NodeStart);
            foreach (TreeViewItem tn in NodeStart.Items)
            {
                GetSubtree_Recursive(tn, List);
            }
        }
        #endregion
        
        #region imports and exports
        internal string ExportSubtreeToText(Topic InitialNode)
        {
            string tree = CreateTextTreeOfDescendants
                (InitialNode.LeftNodeOld, InitialNode.RightNodeOld, false);
            return tree;
        }
        
        internal void ImportSubtreeFromText(string TextFromClipboard)
        {
            if (TextFromClipboard == "")
            {
                Console.Beep();
            }
            ImportFreeMindSubtreeUnderNode(TextFromClipboard, (TreeViewItem)TreeView.SelectedItem);
        }
        #endregion
        
        #region methods that search in the tree
        internal void FindNodes(string TextToFind, bool ColorAllNodesFound, bool SearchInDescriptions,
            bool SearchWholeWord, bool SearchCaseInsensitive, bool SearchVerbatimString)
        {
            markAllInSearch = ColorAllNodesFound;
            if (previousSearch != TextToFind)
            {
                found = dbMptt.FindNodesLike(TextToFind, SearchInDescriptions, SearchWholeWord,
                    SearchCaseInsensitive, SearchVerbatimString);
                indexDone = 0;
                if (markAllInSearch)
                {
                    int dummy = 0; bool bDummy = false;
                    HighlightNodesInList((TreeViewItem)shownTreeView.Items[0], found, ref dummy, ref bDummy);
                    ClearBackColorOnClick = false;
                }
            }
            else
            {
                // same search, find the next occurence of the same string 
                indexDone++;
                if (!markAllInSearch)
                {
                    ((TreeViewItem)shownTreeView.Items[0]).IsExpanded = false; // selection will expand
                }
                // if the results are finished: bring back to the first 
                if (found == null)
                    return;
                if (indexDone >= found.Count)
                    indexDone = 0;
            }
            TreeViewItem f = null;
            if (found.Count > 0)
            {
                f = FindNodeById_Recursive((TreeViewItem)shownTreeView.Items[0], found[indexDone]);
                if (f != null)
                {
                    f.IsSelected = true;
                    f.Background = colorOfFoundItem;
                    f.BringIntoView();
                }
                else
                    MessageBox.Show("Non trovato");
            }
            else
            {
                MessageBox.Show("Non trovato");
            }
            previousSearch = TextToFind;
        }
        
        internal void FindNodeUnderNode(string TextToFind, bool ColorAllNodesFound)
        {
            // TODO !!!! make this option !!!!
        }
        
        internal TreeViewItem FindNodeById(int? IdItem)
        {
            Topic t = new Topic();
            t.Id = IdItem;
            TreeViewItem f = null;
            f = FindNodeById_Recursive((TreeViewItem)shownTreeView.Items[0], t);
            if (f != null)
            {
                f.IsSelected = true;
                f.Background = colorOfFoundItem;
                f.BringIntoView();
            }
            return f;
        }
        
        private TreeViewItem FindNodeById_Recursive(TreeViewItem treeViewItem, Topic Topic)
        {
            if (!Commons.MethodCanContinue())
            {
                return null;
            }
            if (((Topic)treeViewItem.Tag).Id == Topic.Id)
                return treeViewItem;
            foreach (TreeViewItem tn in treeViewItem.Items)
            {
                TreeViewItem t = FindNodeById_Recursive(tn, Topic);
                if (t != null)
                    return t;
            }
            return null;
        }
        
        internal void FindCheckedItems_Recursive(TreeViewItem currentNode,
            List<Topic> checkedTopicsFound, ref int ListIndex)
        {
            // visits all the childrens of CurrentNode, adding to the list those 
            // that are checked in the treeview 
            foreach (TreeViewItem sonNode in currentNode.Items)
            {
                // WPF: Get checkbox from header
                if (sonNode.Header is StackPanel sp && sp.Children.Count > 0 && sp.Children[0] is CheckBox chk)
                {
                    if (chk.IsChecked == true)
                    {
                        Topic newTopic = (Topic)sonNode.Tag;
                        checkedTopicsFound.Add(newTopic);
                    }
                }
                FindCheckedItems_Recursive(sonNode, checkedTopicsFound, ref ListIndex);
            }
            return;
        }
        #endregion
        
        #region methods that color nodes 
        internal void ColorAllBeheadedNodes()
        {
            foreach (TreeViewItem n in shownTreeView.Items)
            {
                ColorAllBeheadedNodes_Recursive(n);
            }
        }
        
        private void ColorAllBeheadedNodes_Recursive(TreeViewItem treeViewItem)
        {
            foreach (TreeViewItem tn in treeViewItem.Items)
            {
                if (tn.Parent == null)
                    tn.Background = colorOfBeheadedColor;
                else
                    tn.Background = Brushes.White;
                ColorAllBeheadedNodes_Recursive(tn);
            }
        }
        
        internal void ImportFreeMindSubtreeUnderNode(string TextWithSubtree, TreeViewItem ParentNodeOfImportedSubtree)
        {
            string indentator;
            string[] subTopics = Regex.Split(TextWithSubtree, "\r\n");

            if (TextWithSubtree.Contains("    "))
            {
                indentator = "    ";
            }
            else
            {
                indentator = "\t";
            }
            
            // WPF: Set Header (not Text)
            if (ParentNodeOfImportedSubtree.Header is StackPanel sp && sp.Children.Count > 1 && sp.Children[1] is TextBlock tb)
            {
                tb.Text = subTopics[0];
            }
            
            List<Topic> ListTopics = new List<Topic>();

            for (int i = 1; i < subTopics.Length; i++)
            {
                string line = subTopics[i];

                Topic t = new Topic();
                string[] fields = Regex.Split(line, indentator);
                // count indentators in the beginning of the line
                int nIndentators = 0;
                while (fields[nIndentators] == "" && nIndentators < fields.Length - 1)
                {
                    nIndentators++;
                }

                if (fields[nIndentators] != "")
                {
                    // store temporarily the level number in field Parent node ID 
                    // (not used for other in this phase)
                    t.ParentNodeNew = nIndentators;  // here this is the level count 
                    t.Name = fields[nIndentators++];

                    ListTopics.Add(t);
                }
            }
            ImportToTreewiewFromList(ListTopics, ParentNodeOfImportedSubtree);
        }
        
        internal void ImportToTreewiewFromList(List<Topic> ListToImport,
            TreeViewItem ParentNodeOfImportedSubtree)
        {
            // ParentNode contains the number of indents of the node! 
            try
            {
                // fill the treeview adding the list's items to the tag property of each node
                TreeViewItem node = new TreeViewItem();
                int startNodeIndex;
                if (ParentNodeOfImportedSubtree == null)
                {
                    // remakes the tree from scratch
                    shownTreeView.Items.Clear();
                    node = CreateTreeViewItem(ListToImport[0]);
                    shownTreeView.Items.Add(node);
                    startNodeIndex = 1;
                }
                else
                {
                    // add to passed node the list of those we have to add 
                    node = ParentNodeOfImportedSubtree;
                    startNodeIndex = 0;
                }

                int level = 0;
                TreeViewItem previousNode = node;
                Stack<TreeViewItem> stack = new Stack<TreeViewItem>();
                for (int i = startNodeIndex; i < ListToImport.Count; i++)
                {
                    Topic t = ListToImport[i];
                    TreeViewItem currentNode = CreateTreeViewItem(t);
                    // just in this part of the code ParentNodeNew contiene il livello di indentazione di ogni nodo del tree
                    if (level < t.ParentNodeNew)
                    {
                        level++;
                        stack.Push(previousNode);
                        previousNode.Items.Add(currentNode);
                        previousNode = currentNode;
                    }
                    else
                    {
                        // level - x (also same level)
                        // always pop to bring to the father of the same level
                        previousNode = stack.Pop();
                        // pop if we have to go up of x levels 
                        while (level > t.ParentNodeNew)
                        // just in this part of the code ParentNodeNew contains the level of indentation of each tree node
                        {
                            previousNode = stack.Pop();
                            level--;
                        }
                        previousNode.Items.Add(currentNode);
                        stack.Push(previousNode); // 
                        previousNode = currentNode;
                    }
                }
                // since the program adds the last node's Topic also to the first, 
                // (we don't understand why..) we repair by re-associating the Topic
                // of the first node to its Tag 
                node.Tag = ListToImport[0];
                // adjust the first node of imported subtree 
            }
            catch (Exception e)
            {
                string errT = "Error in tree creation: " + e.Message;
                Commons.ErrorLog(errT);
                throw new Exception(errT);
            }
        }
        
        internal void ClearBackColor()
        {
            // move through the treeview nodes
            // and reset backcolors to white
            foreach (TreeViewItem n in shownTreeView.Items)
            {
                ClearBackColor_Recursive(n);
            }
        }
        
        private void ClearBackColor_Recursive(TreeViewItem treeViewItem)
        {
            // called by ClearBackColor function
            foreach (TreeViewItem tn in treeViewItem.Items)
            {
                tn.Background = Brushes.White;
                ClearBackColor_Recursive(tn);
            }
        }
        
        internal void HighlightNodesInList(TreeViewItem startNode, List<Topic> ItemsToHighlight,
            ref int ListIndex, ref bool foundInThisBranch, Brush HighlightColor = null)
        {
            Brush highlightColor = HighlightColor ?? colorOfHighlightedItem;

            startNode.IsExpanded = false;
            // !! list ItemsToHighlight must be given in Tree Traversal order !!
            if (ItemsToHighlight.Count == 0)
                return;
            foreach (TreeViewItem sonNode in startNode.Items)
            {
                // when going down, it doesnt' expand the tree
                foundInThisBranch = false;
                if (ListIndex == ItemsToHighlight.Count)
                    return;
                if (ItemsToHighlight[ListIndex].Id == ((Topic)sonNode.Tag).Id)
                {   // found item to highlight 
                    sonNode.Background = highlightColor;
                    sonNode.BringIntoView();
                    foundInThisBranch = true;
                    ListIndex++;
                }
                // recursion 
                HighlightNodesInList(sonNode, ItemsToHighlight,
                    ref ListIndex, ref foundInThisBranch, highlightColor);
                if (foundInThisBranch)
                    sonNode.BringIntoView();
            }
            return;
        }
        
        internal void HighlightNode(TreeViewItem Node, Brush HighlightColor = null)
        {
            Brush highlightColor = HighlightColor ?? colorOfHighlightedItem;
            Node.Background = highlightColor;
            Node.IsExpanded = true;
            return;
        }
        
        internal void ColorNodeFoundById(int Id, Brush HighlightColor = null)
        {
            Brush highlightColor = HighlightColor ?? colorOfFoundItem;
            TreeViewItem f = FindNodeById(Id);
            f.Background = highlightColor;
            f.IsExpanded = true;
            return;
        }
        #endregion
        
        #region manage the treeview nodes' checking
        internal void UncheckAllItemsUnderNode(TreeViewItem currentNode)
        {
            bulkChangeOfChecks = true;
            UncheckAllItemsUnderNode_Recursive(currentNode);
            bulkChangeOfChecks = false;
            return;
        }
        
        // CAMBIATO DA private A internal per WPF
        internal void UncheckAllItemsUnderNode_Recursive(TreeViewItem currentNode)
        {
            // WPF: Get checkbox from header
            if (currentNode.Header is StackPanel sp && sp.Children.Count > 0 && sp.Children[0] is CheckBox chk)
            {
                chk.IsChecked = false;
            }
            foreach (TreeViewItem sonNode in currentNode.Items)
            {
                // recursion 
                UncheckAllItemsUnderNode_Recursive(sonNode);
            }
            return;
        }
        
        internal void CheckItemsInList(TreeViewItem startNode,
                List<Topic> ItemsToCheck, ref int ListIndex, ref bool foundInThisBranch)
        {
            bulkChangeOfChecks = true;
            CheckItemsInList_Recursive(startNode, ItemsToCheck, ref ListIndex, ref foundInThisBranch);
            bulkChangeOfChecks = false;
            return;
        }
        
        // CAMBIATO DA private A internal per WPF
        internal void CheckItemsInList_Recursive(TreeViewItem startNode,
            List<Topic> ItemsToCheck, ref int ListIndex, ref bool foundInThisBranch)
        {
            // Recursive method that puts the check signs in the items included in the list
            startNode.IsExpanded = false;
            // !! list must be given in Tree Traversal order !!
            if (ItemsToCheck == null || ItemsToCheck.Count == 0)
                return;
            foreach (TreeViewItem sonNode in startNode.Items)
            {
                // when going down, it doesnt' expand the tree
                foundInThisBranch = false;
                if (ListIndex == ItemsToCheck.Count)
                    return;
                if (ItemsToCheck[ListIndex].Id == ((Topic)sonNode.Tag).Id)
                {   // found item to check 
                    // WPF: Get checkbox from header
                    if (sonNode.Header is StackPanel sp && sp.Children.Count > 0 && sp.Children[0] is CheckBox chk)
                    {
                        chk.IsChecked = true;
                    }
                    sonNode.BringIntoView();
                    foundInThisBranch = true;
                    ListIndex++;
                }
                // recursion 
                CheckItemsInList_Recursive(sonNode, ItemsToCheck, ref ListIndex, ref foundInThisBranch);
                if (foundInThisBranch)
                    sonNode.BringIntoView();
            }
            return;
        }
        #endregion
        
        // recursively move through the subtree nodes
        // deleting node Id
        internal TreeViewItem AddNewNode(string Text, bool isSonNode)
        {
            hasChanges = true;
            if (shownTreeView.SelectedItem == null)
            {
                MessageBox.Show("Scegliere un nodo cui aggiungere un nodo ad un sottoalbero");
                return null;
            }
            TreeViewItem fatherNode = null;
            TreeViewItem UiNode = null;
            Topic nodeParent = null;
            Topic nodeNew = null;

            if (isSonNode)
            {   // the new node must be the son of the currennt
                fatherNode = (TreeViewItem)shownTreeView.SelectedItem;
                nodeParent = (Topic)((TreeViewItem)shownTreeView.SelectedItem).Tag;
            }
            else
            {   // the new node must be the brother of the current
                fatherNode = (TreeViewItem)((TreeViewItem)shownTreeView.SelectedItem).Parent;
                nodeParent = (Topic)((TreeViewItem)((TreeViewItem)shownTreeView.SelectedItem).Parent).Tag;
            }
            nodeNew = new Topic();
            nodeNew.Name = Text;
            nodeNew.LeftNodeOld = nodeNew.RightNodeOld = -1;
            UiNode = CreateTreeViewItem(nodeNew);

            if (shownTreeView.SelectedItem == null)
            {
                shownTreeView.Items.Add(UiNode);
            }
            else
            {
                fatherNode.Items.Add(UiNode);
            }
            UiNode.IsSelected = true;

            if (txtNodeName != null)
            {
                txtNodeName.Text = nodeNew.Name;
                txtNodeName.Focus();
            }
            if (txtNodeDescription != null)
                txtNodeDescription.Text = "";
            if (txtCodNode != null)
                txtCodNode.Text = nodeNew.Id.ToString();
            // flag the cahnge in the tree
            hasChanges = true;
            return UiNode;
        }
        
        internal void DeleteNodeById_Recursive(TreeViewItem ParentNode)
        {
            ((Topic)ParentNode.Tag).Id = null;
            foreach (TreeViewItem n in ParentNode.Items)
            {
                DeleteNodeById_Recursive(n);
            }
            hasChanges = true;
        }
        
        internal void DeleteNodeSelected()
        {
            try
            {
                TreeViewItem te = (TreeViewItem)shownTreeView.SelectedItem;
                // if the topic has already been saved in the database, we have to ask for 
                // confirmation if it has already been checked in the past
                if (te != null && ((Topic)te.Tag).Id != null)
                    if (bl.IsTopicAlreadyTaught((Topic)te.Tag))
                    {
                        if (MessageBox.Show("Almeno uno degli argomenti scelti è già stato fatto in qualche lezione\n" +
                            "Cancello lo stesso tutti gli argomenti selezionati?", "Attenzione!", 
                            MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No)
                            == MessageBoxResult.No)
                            return;
                    }
                // remove node from the control (when saving will be also deleted from the database) 
                ((TreeViewItem)te.Parent).Items.Remove(te);
                hasChanges = true;
            }
            catch (Exception ex)
            {
                string err = "TopicTreeMptt|DeleteNode: Errore nella rimozione del nodo " +
                    ex.Message;
                Commons.ErrorLog(err);
                throw new Exception(err);
            }
            hasChanges = true;
        }
        
        internal void DeleteNodeFromButton()
        {
            TreeViewItem te = (TreeViewItem)shownTreeView.SelectedItem;
            ((TreeViewItem)te.Parent).Items.Remove(te);
            hasChanges = true;
        }
        
        internal void CheckGeneralKeysForTree(KeyEventArgs e, string ToFind)
        {
            if (e.Key == Key.F3)
                FindNodes(ToFind, markAllInSearch, true, false, false, false);
            if (e.Key == Key.F5)
            {
                SaveTreeFromTreeViewByParent();
            }
            hasChanges = true;
        }
        
        private string GetStringOfJustSomeNodesOfPath(string Path)
        {
            if (Path == null)
                return null;
            string[] AllNodes = Path.Split('|');
            string stringToAdd = " ";
            // take the last topics of the topics tree 
            for (int i = AllNodes.Length - 2, j = 0; i > 0 && j < 2; i--, j++)
            {
                stringToAdd = (AllNodes[i] + ": " + stringToAdd).Trim();
            }
            return stringToAdd += ". ";
        }
        
        #region events
        // >>> NUOVA STRATEGIA: Gestione eventi semplificata per eliminare ricorsioni <<<

        // Flag per indicare che un aggiornamento proviene dal codice e non dall'utente.
        private bool isUpdatingUiFromCode = false;
        private bool isSavingTree = false;

        /// <summary>
        /// UNICO COMPITO: Popolare le TextBox quando un nodo viene selezionato.
        /// </summary>
        internal void shownTreeView_AfterSelect(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null || !(e.NewValue is TreeViewItem)) return;

            TreeViewItem selectedNode = (TreeViewItem)e.NewValue;
            
            // Imposta il flag per indicare che stiamo aggiornando le TextBox dal codice.
            isUpdatingUiFromCode = true;
            try
            {
                if (selectedNode.Tag is Topic sourceTopic)
                {
                    currentTopic = sourceTopic;
                    if (txtNodeName != null)
                        txtNodeName.Text = currentTopic.Name ?? string.Empty;
                    if (txtNodeDescription != null)
                        txtNodeDescription.Text = currentTopic.Desc ?? string.Empty;
                    if (txtCodNode != null)
                    {
                        txtCodNode.Text = currentTopic.Id?.ToString() ?? string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"[shownTreeView_AfterSelect] Exception: {ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                // Resetta sempre il flag.
                isUpdatingUiFromCode = false;
            }
        }

        /// <summary>
        /// UNICO COMPITO: Finalizzare la modifica del nome quando l'utente lascia la TextBox.
        /// </summary>
        private void TxtNodeName_Leave(object sender, RoutedEventArgs e)
        {
            // Se stiamo aggiornando da codice, non fare nulla.
            if (isUpdatingUiFromCode) return;
            if (shownTreeView.SelectedItem == null) return;
            if (!((shownTreeView.SelectedItem is TreeViewItem selectedNode) && selectedNode.Tag is Topic t)) return;

            try
            {
                string newName = txtNodeName.Text ?? string.Empty;
                // Se il nome è cambiato, aggiorna il Topic e il TreeNode.
                if (t.Name != newName)
                {
                    t.Name = newName;
                    t.Changed = true;
                    hasChanges = true;
                    // Aggiorna il testo nel TreeView (WPF usa Header con StackPanel)
                    if (selectedNode.Header is StackPanel sp && sp.Children.Count > 1 && sp.Children[1] is TextBlock tb)
                    {
                        tb.Text = newName;
                    }
                }
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"[TxtNodeName_Leave] Exception: {ex.Message}\n{ex.StackTrace}");
            }
        }

        /// <summary>
        /// UNICO COMPITO: Finalizzare la modifica della descrizione quando l'utente lascia la TextBox.
        /// </summary>
        private void TxtNodeDescription_Leave(object sender, RoutedEventArgs e)
        {
            if (isUpdatingUiFromCode) return;
            if (shownTreeView.SelectedItem == null) return;
            if (!((shownTreeView.SelectedItem is TreeViewItem selectedNode) && selectedNode.Tag is Topic t)) return;

            try
            {
                string newDesc = txtNodeDescription.Text ?? string.Empty;
                if (t.Desc != newDesc)
                {
                    t.Desc = newDesc;
                    t.Changed = true;
                    hasChanges = true;
                }
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"[TxtNodeDescription_Leave] Exception: {ex.Message}\n{ex.StackTrace}");
            }
        }

        /// <summary>
        /// USATO SOLO PER LOGICA SPECIALE (Import FreeMind). NON aggiorna più il TreeView.
        /// </summary>
        private void TxtNodeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Ignora le modifiche programmatiche.
            if (isUpdatingUiFromCode) return;

            // Rilevamento importazione da FreeMind (copia-incolla di testo strutturato)
            string txt = txtNodeName.Text;
            bool looksLikeTree = txt.Contains("\r\n") && (txt.Contains("\t") || txt.Contains("    "));

            if (looksLikeTree)
            {
                // Disabilita temporaneamente l'evento per evitare che si scateni di nuovo
                txtNodeName.TextChanged -= TxtNodeName_TextChanged;
                try
                {
                    var dr = MessageBox.Show("Testo formattato come albero (FreeMind). Importare qui il sottoalbero?",
                        "Importazione", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (dr == MessageBoxResult.Yes)
                    {
                        ImportSubtreeFromText(txt);
                        // Dopo l'importazione, il nodo selezionato potrebbe essere cambiato.
                        // L'evento AfterSelect si occuperà di aggiornare correttamente le TextBox.
                        if (shownTreeView.SelectedItem != null && shownTreeView.SelectedItem is TreeViewItem selectedItem)
                        {
                            selectedItem.IsExpanded = true;
                            // Forziamo un aggiornamento delle textbox basato sul nodo corrente
                            shownTreeView_AfterSelect(shownTreeView, 
                                new RoutedPropertyChangedEventArgs<object>(null, selectedItem));
                        }
                    }
                    else
                    {
                        // L'utente ha annullato, ripristina il testo originale del nodo corrente.
                        if (currentTopic != null)
                        {
                            txtNodeName.Text = currentTopic.Name ?? string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Commons.ErrorLog($"[TxtNodeName_TextChanged|Import] {ex.Message}\n{ex.StackTrace}");
                }
                finally
                {
                    // Riabilita sempre l'evento.
                    txtNodeName.TextChanged += TxtNodeName_TextChanged;
                }
            }
        }

        // Gli eventi LostFocus sono ora ridondanti a causa di Leave, ma li manteniamo per sicurezza
        // con la stessa logica di protezione.
        private void txtNodeName_LostFocus(object sender, RoutedEventArgs e)
        {
            TxtNodeName_Leave(sender, e);
        }
        private void txtNodeDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            TxtNodeDescription_Leave(sender, e);
        }

        internal void ShownTreeView_Click(object sender, RoutedEventArgs e)
        {
            if (ClearBackColorOnClick) ClearBackColor();
        }
        
        internal void ShownTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2 && shownTreeView.SelectedItem != null)
            {
                // WPF doesn't have BeginEdit like WinForms
                e.Handled = true;
            }
            else if (e.Key == Key.Insert)
            {
                bool isSonNode = (Keyboard.Modifiers & ModifierKeys.Shift) != ModifierKeys.Shift;
                TreeViewItem newNode = AddNewNode("Nuovo argomento", isSonNode);
                if (newNode != null)
                {
                    newNode.IsSelected = true;
                }
                e.Handled = true;
            }
            else if (e.Key == Key.Delete)
            {
                DeleteNodeSelected();
                e.Handled = true;
            }
        }
        
        internal void TreeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = typeOfDragAndDrop;
        }
        
        private void TreeView_DragLeave(object sender, DragEventArgs e)
        {
        }
        #endregion // events
        
        // ---------------------- Utility & Tree Generation Methods (restored) ----------------------
        internal string CreateTextTreeOfDescendants(int? LeftNode, int? RightNode, bool? IncludeTopicsIds)
        {
            string indentString = "\t";
            string currentIndentation = "";
            string file = "";
            Stack<Topic> stack = new Stack<Topic>();
            List<Topic> listTopics = dbMptt.GetNodesByMpttFromDatabase(LeftNode, RightNode);
            if (listTopics == null || listTopics.Count == 0) return file;
            Topic previousTopic = listTopics[0];
            file += previousTopic.Name + "\t" + previousTopic.Desc;
            if (IncludeTopicsIds == true) file += "\t" + previousTopic.Id;
            file += "\r\n";
            stack.Push(previousTopic);
            for (int i = 1; i < listTopics.Count; i++)
            {
                Topic currentTopicLocal = listTopics[i];
                if (currentTopicLocal.RightNodeOld < previousTopic.RightNodeOld)
                {
                    currentIndentation += indentString;
                    file += currentIndentation + currentTopicLocal.Name + "\t" + currentTopicLocal.Desc;
                    if (IncludeTopicsIds == true) file += "\t" + currentTopicLocal.Id;
                    file += "\r\n";
                    stack.Push(previousTopic);
                    previousTopic = currentTopicLocal;
                }
                else
                {
                    previousTopic = stack.Pop();
                    while (currentTopicLocal.RightNodeOld > previousTopic.RightNodeOld)
                    {
                        if (stack.Count > 0)
                        {
                            previousTopic = stack.Pop();
                            if (currentIndentation.Length > 0)
                                currentIndentation = currentIndentation.Substring(0, currentIndentation.Length - 1);
                        }
                        else break;
                    }
                    file += currentIndentation + currentTopicLocal.Name + "\t" + currentTopicLocal.Desc;
                    if (IncludeTopicsIds == true) file += "\t" + currentTopicLocal.Id;
                    file += "\r\n";
                    stack.Push(previousTopic);
                    previousTopic = currentTopicLocal;
                }
            }
            return file;
        }
        
        internal void ResetSearch() { previousSearch = string.Empty; }
        
        private void SearchCheckBoxes_CheckedChanged(object sender, RoutedEventArgs e)
        {
            ResetSearch();
            if (txtSearchString != null)
                FindNodes(txtSearchString.Text,
                    chkMarkAllNodesFound?.IsChecked == true,
                    chkSearchInDescriptions?.IsChecked == true,
                    chkAllWord?.IsChecked == true,
                    chkCaseInsensitive?.IsChecked == true,
                    chkVerbatimString?.IsChecked == true);
        }
        
        private void chkMarkAllNodesFound_CheckedChanged(object sender, RoutedEventArgs e) { ResetSearch(); }
        private void chkVerbatimString_CheckedChanged(object sender, RoutedEventArgs e) { ResetSearch(); }
        
        internal void AddChildrenNodesToTreeViewFromDatabase(TreeViewItem ParentNode, int Level)
        {
            GetChildren_Recursive(ParentNode, Level);
        }
        
        internal void GetChildren_Recursive(TreeViewItem ParentNode, int Level)
        {
            List<Topic> lt = dbMptt.GetNodesChildsByParent(((Topic)ParentNode.Tag), false);
            foreach (Topic t in lt.OrderBy(o => o.ChildNumberOld))
            {
                if (!Commons.MethodCanContinue()) return;
                TreeViewItem n = CreateTreeViewItem(t);
                ParentNode.Items.Add(n);
                GetChildren_Recursive(n, Level + 1);
            }
        }
        
        internal void SaveTreeFromScratch(TreeViewItem CurrentNode, List<Topic> generatedList)
        {
            int nodeCount = 1;
            GenerateNewListOfNodesFromTreeViewControl_Recursive(CurrentNode, ref nodeCount, ref generatedList);
            bl.SaveTopicsFromScratch(generatedList);
        }
        
        internal void GenerateNewListOfNodesFromTreeViewControl_Recursive(TreeViewItem CurrentNode, ref int nodeCount,
            ref List<Topic> generatedList)
        {
            if (!Commons.MethodCanContinue()) return;
            Topic ct = (Topic)CurrentNode.Tag;
            ct.LeftNodeNew = nodeCount++;
            generatedList.Add(ct);
            if (ct.Id == null || ct.Id == 0)
                ct.Id = dbMptt.CreateNewTopic(ct);
            int brotherNo = 1;
            foreach (TreeViewItem sonNode in CurrentNode.Items)
            {
                if (!Commons.MethodCanContinue()) return;
                GenerateNewListOfNodesFromTreeViewControl_Recursive(sonNode, ref nodeCount, ref generatedList);
                Topic sonT = (Topic)sonNode.Tag;
                sonT.ParentNodeNew = ct.Id;
                sonT.ChildNumberNew = brotherNo++;
            }
            ct.RightNodeNew = nodeCount++;
        }
        
        internal void GenerateNewListOfNodesFromDatabase(Topic CurrentNode, ref int nodeCount,
            ref List<Topic> generatedList)
        {
            CurrentNode.LeftNodeNew = nodeCount++;
            generatedList.Add(CurrentNode);
            int brotherNo = 1;
            List<Topic> listChilds = dbMptt.GetNodesChildsByParent(CurrentNode, true);
            foreach (Topic sonNode in listChilds)
            {
                if (!Commons.MethodCanContinue()) return;
                GenerateNewListOfNodesFromDatabase(sonNode, ref nodeCount, ref generatedList);
                sonNode.ParentNodeNew = CurrentNode.Id;
                sonNode.ChildNumberNew = brotherNo++;
            }
            CurrentNode.RightNodeNew = nodeCount++;
        }
        
        private TreeViewItem CreateTreeViewItem(Topic Node)
        {
            TreeViewItem item = new TreeViewItem();
            // Create a new StackPanel for text and optional checkbox 
            StackPanel stackPanel = new StackPanel();
            stackPanel.Name = "NodeUi";
            stackPanel.Orientation = Orientation.Horizontal;
            
            // Children[0] is the CheckBox (if enabled)
            CheckBox checkBox = new CheckBox();
            checkBox.IsChecked = false;
            stackPanel.Children.Add(checkBox);
            
            // Children[1] is the TextBlock
            TextBlock textBlock = new TextBlock();
            textBlock.Text = Node.Name;
            stackPanel.Children.Add(textBlock);
            
            item.Header = stackPanel;
            item.Tag = Node;
            return item;
        }
        // ---------------------- End Utility Methods ----------------------
    }
}
