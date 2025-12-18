using SchoolGrades;
using SchoolGrades.BusinessObjects;
using SchoolGrades.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

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

        System.Windows.Forms.DragDropEffects typeOfDragAndDrop;
        #endregion

        #region lists used to detect changes, to have less accesses to the database 
        List<Topic> listItemsBefore; // !!!! this list should be non influent now. Code revision should eliminate it!!!!
        List<Topic> listItemsAfter;
        List<Topic> listItemsDeleted;
        #endregion

        // a stack used to remember the father node in some part of the code  
        Stack<TreeNode> stack = new Stack<TreeNode>();

        string previousSearch = "";
        int indexDone = 0;
        List<Topic> found = null;

        #region internal object variables for controls passed from outside
        // Winforms control that is manipulated by this class
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
        private Color colorOfHighlightedItem = Color.Khaki;
        private Color colorOfFoundItem = Color.Lime;
        private Color colorOfBeheadedColor = Color.Orange;
        #endregion

        // if true the backcolor of nodes will be cleared when the user clicks on one node 
        bool clearBackColorOnClick = true;
        internal bool ClearBackColorOnClick { get => clearBackColorOnClick; set => clearBackColorOnClick = value; }
        // Name of the object
        internal string Name { get; set; }
        // TreeView control from the calling code
        internal TreeView TreeView { get => shownTreeView; }

        bool functionKeysEnabled = false;  // Inizializzato a false per permettere la prima registrazione degli eventi
        private bool bulkChangeOfChecks;

        internal bool FunctionKeysEnabled
        {
            get
            {
                return functionKeysEnabled;
            }
            set
            {
                // Avoid registering events multiple times
                if (value && !functionKeysEnabled)
                {
                    // NOTE: BeforeLabelEdit and AfterLabelEdit are NO LONGER registered
                    // because LabelEdit is permanently disabled (see constructor).
                    // Editing is handled only via the external txtNodeName TextBox.
                    
                    shownTreeView.AfterCheck += ShownTreeView_AfterCheck;
                    shownTreeView.AfterSelect += shownTreeView_AfterSelect;
                    shownTreeView.Click += ShownTreeView_Click;
                    shownTreeView.KeyDown += ShownTreeView_KeyDown;
                    txtNodeName.Leave += TxtNodeName_Leave;
                    // NOTE: txtNodeName.TextChanged is NOT registered
                    // Name changes are handled on Leave event to avoid
                    // recursion that could cause ExecutionEngineException in .NET 10
                    txtNodeDescription.Leave += TxtNodeDescription_Leave;
                    if (chkSearchInDescriptions != null)
                        chkSearchInDescriptions.CheckedChanged += SearchCheckBoxes_CheckedChanged;
                    if (chkAllWord != null)
                        chkAllWord.CheckedChanged += SearchCheckBoxes_CheckedChanged;
                    if (chkCaseInsensitive != null)
                        chkCaseInsensitive.CheckedChanged += SearchCheckBoxes_CheckedChanged;
                    if (chkMarkAllNodesFound != null)
                        chkMarkAllNodesFound.CheckedChanged += chkMarkAllNodesFound_CheckedChanged;
                    if (chkVerbatimString != null)
                        chkVerbatimString.CheckedChanged += chkVerbatimString_CheckedChanged;
                }
                functionKeysEnabled = value;
            }
        }
        internal bool HasChanges { get => hasChanges; set => hasChanges = value; }
        // New: read-only flag, set only via constructor
        private readonly bool _isReadOnly;
        internal bool IsReadOnly { get => _isReadOnly; }
        internal TreeMptt(TreeView TreeViewControl, string FullNameOfDatabase,
            TextBox TxtNodeName, TextBox TxtNodeDescription, TextBox TxtNodeSearchString,
            TextBox TxtNodeDigest, TextBox TxtIdNode,
            PictureBox LedPictureBox, CheckBox ChkSearchInDescriptions, CheckBox ChkVerbatimString,
            CheckBox ChkAllWord, CheckBox ChkCaseInsensitive, CheckBox ChkMarkAllNodesFound,
            System.Windows.Forms.DragDropEffects TypeOfDragAndDrop = System.Windows.Forms.DragDropEffects.Move,
            bool IsReadOnly = false)
        // ???? what about PutCheckSignsOnNodes ????
        {
            fullNameOfDatabase = FullNameOfDatabase;
            // !!!! TODO !!!! eliminate the dependency of this class from Business Layer
            bl = Commons.bl;
            dbMptt = TreeMptt.SetDataLayer(fullNameOfDatabase);

            shownTreeView = TreeViewControl;
            //listTopicsBefore = InitialListOfTopics;
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

            // set readonly flag
            _isReadOnly = IsReadOnly;

            if (shownTreeView != null)
            {
                // If read-only, avoid registering function keys handlers; still allow AfterSelect
                FunctionKeysEnabled = !_isReadOnly;

                // DECISIONE ARCHITETTURALE FORTE: Blocchiamo COMPLETAMENTE l'editing inline
                // per evitare ExecutionEngineException in .NET 10 causato da corruzione del message pump.
                // L'editing dei nodi avviene SOLO tramite la TextBox esterna (txtNodeName).
                shownTreeView.LabelEdit = false;

                // for drag & drop - only enable when not read-only
                shownTreeView.AllowDrop = !_isReadOnly;
                if (!_isReadOnly)
                {
                    shownTreeView.ItemDrag += TreeView_ItemDrag;
                    shownTreeView.DragDrop += TreeView_DragDrop;
                    shownTreeView.DragEnter += TreeView_DragEnter;
                    shownTreeView.DragLeave += TreeView_DragLeave;
                }

                // Always attach AfterSelect so selection updates can populate textboxes even in read-only mode
                shownTreeView.AfterSelect += shownTreeView_AfterSelect;
                shownTreeView.Click += ShownTreeView_Click;

                txtNodeName.LostFocus += txtNodeName_LostFocus;
                txtNodeDescription.LostFocus += txtNodeDescription_LostFocus;

                // If this TreeMptt is read-only, set associated controls to read-only / disabled
                if (_isReadOnly)
                {
                    if (txtNodeName != null) txtNodeName.ReadOnly = true;
                    if (txtNodeDescription != null) txtNodeDescription.ReadOnly = true;
                    // search box is left editable even in read-only mode
                    //if (txtSearchString != null) txtSearchString.ReadOnly = true;
                    if (txtNodeDigest != null) txtNodeDigest.ReadOnly = true;
                    if (txtCodNode != null) txtCodNode.ReadOnly = true;

                    // checkbox regaarding search are left editable
                    //if (chkSearchInDescriptions != null) chkSearchInDescriptions.Enabled = false;
                    //if (chkVerbatimString != null) chkVerbatimString.Enabled = false;
                    //if (chkAllWord != null) chkAllWord.Enabled = false;
                    //if (chkCaseInsensitive != null) chkCaseInsensitive.Enabled = false;
                    //if (chkMarkAllNodesFound != null) chkMarkAllNodesFound.Enabled = false;
                }
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
            GenerateNewListOfNodesFromTreeViewControl_Recursive(shownTreeView.Nodes[0],
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
                        shownTreeView.Nodes[0],
                        ref nodeCount, ref listItemsAfter);

                    listItemsDeleted = new List<Topic>();
                    if (listItemsBefore != null)
                    {
                        foreach (Topic tOld in listItemsBefore)
                        {
                            if (FindNodeById_Recursive(shownTreeView.Nodes[0], tOld) == null)
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
                    
                    // ✅ NUOVO: Usa TreeMpttLeftRight invece di GenerateNewListOfNodesFromDatabase
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
                            // ✅ NEW: Save ONLY leftNode and rightNode (optimized for background)
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
            shownTreeView.Nodes[0].Expand();
            // re-set the possibility of background saving
            Commons.StartOperationsOnBackgroudSavingThread();
        }
        internal void AddNodesToTreeViewWithMptt()
        {
            // avoid modifications by background saver by stopping it
            Commons.StopOperationsOnBackgroundThread();
            if (shownTreeView == null)
                shownTreeView = new();
            shownTreeView.Nodes.Clear();
            listItemsBefore = dbMptt.GetNodesByMpttFromDatabase(0, int.MaxValue);
            //if (!Commons.MethodCanContinue())
            //  return;
            if (listItemsBefore != null && listItemsBefore.Count > 0)
            {
                // put first node in treeview 
                Topic previousNode = listItemsBefore[0];
                TreeNode previousUiNode = CreateTreeViewItem(previousNode);
                shownTreeView.Nodes.Add(previousUiNode); // first node of the tree
                for (int listIndex = 1; listIndex < listItemsBefore.Count; listIndex++)
                {
                    //if (!Commons.MethodCanContinue())
                    //  return;
                    Topic currentNode = listItemsBefore[listIndex];
                    TreeNode currentUiNode = CreateTreeViewItem(currentNode);
                    if (currentNode.RightNodeOld < previousNode.RightNodeOld)
                    {
                        // if is in new level, adds the node to the next level
                        previousUiNode.Nodes.Add(currentUiNode);
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
                            previousUiNode = (TreeNode)stack.Pop();
                            previousNode = (Topic)(previousUiNode.Tag);
                        } while (currentNode.RightNodeOld > previousNode.RightNodeOld);
                        // if same level, son of the same father
                        previousUiNode.Nodes.Add(currentUiNode);
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
            PassedTreeView.Nodes.Clear();
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
                TreeNode rootNode = CreateTreeViewItem(t);
                PassedTreeView.Nodes.Add(rootNode);
                AddChildrenNodesToTreeViewFromDatabase(rootNode, 0);
            }
            // close the db connection
            dbMptt.CloseLocalConnectionIfWasFoundClosed();
            // at the end of operations, the background thread is re-enabled
            Commons.StartOperationsOnBackgroudSavingThread();
        }
        internal void GetSubtree_Recursive(TreeNode NodeStart, List<TreeNode> List) // (passes List for recursion) 
        {
            List.Add(NodeStart);
            foreach (TreeNode tn in NodeStart.Nodes)
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
                //return "";
            }
            ImportFreeMindSubtreeUnderNode(TextFromClipboard, TreeView.SelectedNode);
            //return TextFromClipboard;
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
                    // TODO: fix !!!! the following doesn't work. Highlights only a few of the results.
                    // Probably this "found" list of found items is not in Mptt order
                    // Check if adding a ORDER BY leftNode ASC in FindTopicsLike() has cured this issue !!!! 
                    HighlightNodesInList(shownTreeView.Nodes[0], found, ref dummy, ref bDummy);
                    ClearBackColorOnClick = false;
                }
            }
            else
            {
                // same search, find the next occurence of the same string 
                indexDone++;
                if (!markAllInSearch)
                {
                    shownTreeView.Nodes[0].Collapse(); // selection will expand
                }
                // if the results are finished: bring back to the first 
                if (found == null)
                    return;
                if (indexDone >= found.Count)
                    indexDone = 0;
            }
            TreeNode f = null;
            if (found.Count > 0)
            {
                f = FindNodeById_Recursive(shownTreeView.Nodes[0], found[indexDone]);
                if (f != null)
                {
                    shownTreeView.Select();
                    shownTreeView.SelectedNode = f;
                    f.BackColor = colorOfFoundItem;
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
            //markAllInSearch = MarkAllFound;
            //if (previousSearch != TextToFind)
            //{
            //    // first search: find all the occurencies of the string 
            //    found = dbMptt.FindTopicsLike(TextToFind);

            //    indexDone = 0;
            //    previousSearch = TextToFind;

            //    if (markAllInSearch)
            //    {
            //        int dummy = 0; bool bDummy = false;
            //        // !!!! the following doesn't work. Highlight only a few of the results. Probably this "found" list of found is noo in Mptt order !!!! 
            //        HighlightTopicsInList(shownTreeView.Nodes[0], found, ref dummy, ref bDummy);
            //        ClearBackColorOnClick = false;
            //    }
            //}
            //else
            //{
            //    // same search, find the next occurence of the same string 
            //    indexDone++;
            //    if (!markAllInSearch)
            //    {
            //        shownTreeView.Nodes[0].Collapse(); // selection will expand
            //    }
            //    // if the results are finished: bring back to the first 
            //    if (found == null)
            //        return;
            //    if (indexDone >= found.Count)
            //        indexDone = 0;
            //}
            //TreeNode f = null;
            //if (found.Count > 0)
            //{
            //    f = FindNodeRecursivelyById(shownTreeView.Nodes[0], found[indexDone]);
            //    if (f != null)
            //    {
            //        shownTreeView.Select();
            //        shownTreeView.SelectedNode = f;
            //        f.BackColor = colorOfFoundItem;
            //    }
            //    else
            //        MessageBox.Show("Non trovato");
            //}
            //else
            //{
            //    MessageBox.Show("Non trovato");
            //}
        }
        internal TreeNode FindNodeById(int? IdItem)
        {
            Topic t = new Topic();
            t.Id = IdItem;
            TreeNode f = null;
            f = FindNodeById_Recursive(shownTreeView.Nodes[0], t);
            if (f != null)
            {
                shownTreeView.SelectedNode = f;
                f.BackColor = colorOfFoundItem;
                f.EnsureVisible();
            }
            return f;
        }
        private TreeNode FindNodeById_Recursive(TreeNode treeNode, Topic Topic)
        {
            if (!Commons.MethodCanContinue())
            {
                return null;
            }
            if (((Topic)treeNode.Tag).Id == Topic.Id)
                return treeNode;
            foreach (TreeNode tn in treeNode.Nodes)
            {
                TreeNode t = FindNodeById_Recursive(tn, Topic);
                if (t != null)
                    return t;
            }
            return null;
        }
        internal void FindCheckedItems_Recursive(TreeNode currentNode,
            List<Topic> checkedTopicsFound, ref int ListIndex)
        {
            // visits all the childrens of CurrentNode, adding to the list those 
            // that are checked in the treeview 
            foreach (TreeNode sonNode in currentNode.Nodes)
            {
                if (sonNode.Checked)
                {
                    Topic newTopic = (Topic)sonNode.Tag;
                    checkedTopicsFound.Add(newTopic);
                }
                FindCheckedItems_Recursive(sonNode, checkedTopicsFound, ref ListIndex);
            }
            return;
        }
        #endregion
        #region methods that color nodes 
        internal void ColorAllBeheadedNodes()
        {
            TreeNodeCollection nodes = shownTreeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                ColorAllBeheadedNodes_Recursive(n);
            }
        }
        private void ColorAllBeheadedNodes_Recursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Parent == null)
                    tn.BackColor = colorOfBeheadedColor;
                else
                    tn.BackColor = Color.White;
                ColorAllBeheadedNodes_Recursive(tn);
            }
        }
        internal void ImportFreeMindSubtreeUnderNode(string TextWithSubtree, TreeNode ParentNodeOfImportedSubtree)
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
            ParentNodeOfImportedSubtree.Text = subTopics[0];
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
                    //if (nIndentators < fields.Length && fields[nIndentators] != "")
                    //    t.Desc = fields[nIndentators];  // with FreeMind we shouldn't have Descriptions

                    ListTopics.Add(t);
                }
            }
            ImportToTreewiewFromList(ListTopics, ParentNodeOfImportedSubtree);
        }
        internal void ImportToTreewiewFromList(List<Topic> ListToImport,
            TreeNode ParentNodeOfImportedSubtree)
        {
            // ParentNode contiene il numero di indents di ogni nodo! 
            try
            {
                // fill the treeview adding the list's items to the tag property of each node
                TreeNode node = new TreeNode();
                int startNodeIndex;
                if (ParentNodeOfImportedSubtree == null)
                {
                    // remakes the tree from scratch
                    shownTreeView.Nodes.Clear();
                    node = CreateTreeViewItem(ListToImport[0]);
                    shownTreeView.Nodes.Add(node);
                    startNodeIndex = 1;
                }
                else
                {
                    // add to passed node the list of those we have to add 
                    node = ParentNodeOfImportedSubtree;
                    startNodeIndex = 0;
                }

                int level = 0;
                TreeNode previousNode = node;
                Stack<TreeNode> stack = new Stack<TreeNode>();
                for (int i = startNodeIndex; i < ListToImport.Count; i++)
                {
                    Topic t = ListToImport[i];
                    TreeNode currentNode = CreateTreeViewItem(t);
                    // just in this part of the code ParentNodeNew contiene il livello di indentazione di ogni nodo del tree
                    if (level < t.ParentNodeNew)
                    {
                        level++;
                        stack.Push(previousNode);
                        previousNode.Nodes.Add(currentNode);
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
                        previousNode.Nodes.Add(currentNode);
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
            TreeNodeCollection nodes = shownTreeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                ClearBackColor_Recursive(n);
            }
        }
        private void ClearBackColor_Recursive(TreeNode treeNode)
        {
            // called by ClearBackColor function
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.BackColor = Color.White;
                ClearBackColor_Recursive(tn);
            }
        }
        internal void HighlightNodesInList(TreeNode startNode, List<Topic> ItemsToHighlight,
            ref int ListIndex, ref bool foundInThisBranch, Color? HighlightColor = null)
        {
            Color highlightColor = HighlightColor ?? colorOfHighlightedItem;

            startNode.Collapse();
            // !! list ItemsToHighlight must be given in Tree Traversal order !!
            if (ItemsToHighlight.Count == 0)
                return;
            foreach (TreeNode sonNode in startNode.Nodes)
            {
                // when going down, it doesnt' expand the tree
                foundInThisBranch = false;
                if (ListIndex == ItemsToHighlight.Count)
                    return;
                if (ItemsToHighlight[ListIndex].Id == ((Topic)sonNode.Tag).Id)
                {   // found item to highlight 
                    sonNode.BackColor = highlightColor;
                    sonNode.EnsureVisible();
                    foundInThisBranch = true;
                    ListIndex++;
                }
                // recursion 
                HighlightNodesInList(sonNode, ItemsToHighlight,
                    ref ListIndex, ref foundInThisBranch);
                if (foundInThisBranch)
                    sonNode.EnsureVisible();
            }
            return;
        }
        internal void HighlightNode(TreeNode Node, Color? HighlightColor = null)
        {
            Color highlightColor = HighlightColor ?? colorOfHighlightedItem;
            Node.BackColor = highlightColor;
            Node.Expand();
            return;
        }
        internal void ColorNodeFoundById(int Id, Color? HighlightColor = null)
        {
            Color highlightColor = HighlightColor ?? colorOfFoundItem;
            TreeNode f = FindNodeById(Id);
            f.BackColor = highlightColor;
            f.Expand();
            return;
        }
        #endregion
        #region manage the treeview nodes' checking
        internal void UncheckAllItemsUnderNode(TreeNode currentNode)
        {
            bulkChangeOfChecks = true;
            UncheckAllItemsUnderNode_Recursive(currentNode);
            bulkChangeOfChecks = false;
            return;
        }
        private void UncheckAllItemsUnderNode_Recursive(TreeNode currentNode)
        {
            currentNode.Checked = false;
            foreach (TreeNode sonNode in currentNode.Nodes)
            {
                // recursion 
                UncheckAllItemsUnderNode_Recursive(sonNode);
            }
            return;
        }
        internal void CheckItemsInList(TreeNode startNode,
                List<Topic> ItemsToCheck, ref int ListIndex, ref bool foundInThisBranch)
        {
            bulkChangeOfChecks = true;
            CheckItemsInList_Recursive(startNode, ItemsToCheck, ref ListIndex, ref foundInThisBranch);
            bulkChangeOfChecks = false;
            return;
        }
        private void CheckItemsInList_Recursive(TreeNode startNode,
            List<Topic> ItemsToCheck, ref int ListIndex, ref bool foundInThisBranch)
        {
            // Recursive method that puts the check signs in the items included in the list
            startNode.Collapse();
            // !! list must be given in Tree Traversal order !!
            if (ItemsToCheck == null || ItemsToCheck.Count == 0)
                return;
            foreach (TreeNode sonNode in startNode.Nodes)
            {
                // when going down, it doesnt' expand the tree
                foundInThisBranch = false;
                if (ListIndex == ItemsToCheck.Count)
                    return;
                if (ItemsToCheck[ListIndex].Id == ((Topic)sonNode.Tag).Id)
                {   // found item to check 
                    sonNode.Checked = true;
                    //sonNode.Expand();
                    sonNode.EnsureVisible();
                    foundInThisBranch = true;
                    ListIndex++;
                }
                // recursion 
                CheckItemsInList_Recursive(sonNode, ItemsToCheck, ref ListIndex, ref foundInThisBranch);
                if (foundInThisBranch)
                    sonNode.EnsureVisible();
                //currentNode.Expand();
            }
            return;
        }
        #endregion
        // recursively move through the subtree nodes
        // deleting node Id
        internal TreeNode AddNewNode(string Text, bool isSonNode)
        {
            hasChanges = true;
            if (shownTreeView.SelectedNode == null)
            {
                MessageBox.Show(Loc.Get("Tree_SelectNodeToAddChild"));
                return null;
            }
            TreeNode fatherNode = null;
            TreeNode UiNode = null;
            Topic nodeParent = null;
            Topic nodeNew = null;

            if (isSonNode)
            {   // the new node must be the son of the current
                fatherNode = shownTreeView.SelectedNode;
                nodeParent = (Topic)(shownTreeView.SelectedNode.Tag);
            }
            else
            {   // the new node must be the brother of the current
                fatherNode = shownTreeView.SelectedNode.Parent;
                nodeParent = (Topic)(shownTreeView.SelectedNode.Parent.Tag);
            }
            nodeNew = new Topic();
            nodeNew.Name = Text;
            nodeNew.LeftNodeOld = nodeNew.RightNodeOld = -1;
            UiNode = new TreeNode(nodeNew.Name);
            UiNode.Tag = nodeNew;

            if (shownTreeView.SelectedNode == null)
            {
                shownTreeView.Nodes.Add(UiNode);
            }
            else
            {
                fatherNode.Nodes.Add(UiNode);
            }
            
            // IMPORTANTE: Imposta il flag PRIMA di selezionare il nuovo nodo
            // perché SelectedNode scatena AfterSelect che aggiorna la UI
            isUpdatingUiFromCode = true;
            try
            {
                shownTreeView.SelectedNode = UiNode;
                txtNodeName.Text = nodeNew.Name;
                txtNodeDescription.Text = "";
                if (txtCodNode != null)
                    txtCodNode.Text = nodeNew.Id.ToString();
                
                // Sposta il focus sulla TextBox per permettere l'editing immediato
                // (non usiamo più BeginEdit perché LabelEdit è disabilitato)
                if (txtNodeName != null && txtNodeName.CanFocus)
                {
                    txtNodeName.Focus();
                    txtNodeName.SelectAll();
                }
            }
            finally
            {
                isUpdatingUiFromCode = false;
            }
            
            // flag the change in the tree
            hasChanges = true;
            return UiNode;
        }
        internal void DeleteNodeById_Recursive(TreeNode ParentNode)
        {
            ((Topic)ParentNode.Tag).Id = null;
            TreeNodeCollection nodes = ParentNode.Nodes;
            foreach (TreeNode n in nodes)
            {
                DeleteNodeById_Recursive(n);
            }
            hasChanges = true;
        }
        internal void DeleteNodeSelected()
        {
            try
            {
                TreeNode te = shownTreeView?.SelectedNode;
                
                // Guard: check if a node is selected
                if (te == null)
                {
                    MessageBox.Show(
                        GetLocalizedOrFallback("Tree_SelectNodeToDelete",
                            "Selezionare un nodo da eliminare", 
                            "Select a node to delete."),
                        GetLocalizedOrFallback("Tree_ConfirmDeleteTitle",
                            "Attenzione!", 
                            "Warning!"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                
                // Guard: prevent deletion of root node
                if (te.Parent == null)
                {
                    MessageBox.Show(
                        GetLocalizedOrFallback("Tree_CannotDeleteRoot", 
                            "Non è possibile eliminare il nodo radice.", 
                            "The root node cannot be deleted."),
                        GetLocalizedOrFallback("Tree_ConfirmDeleteTitle", 
                            "Attenzione!", 
                            "Warning!"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                
                // if the topic has already been saved in the database, we have to ask for 
                // confirmation if it has already been checked in the past
                if (((Topic)te.Tag).Id != null)
                {
                    if (bl.IsTopicAlreadyTaught((Topic)te.Tag))
                    {
                        if (MessageBox.Show(Loc.Get("Tree_TopicAlreadyTaught"),
                            Loc.Get("Tree_ConfirmDeleteTitle"),
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                    }
                }
                
                // remove node from the control (when saving will be also deleted from the database) 
                te.Parent.Nodes.Remove(te);
                hasChanges = true;
            }
            catch (Exception ex)
            {
                string err = "TopicTreeMptt|DeleteNode: Errore nella rimozione del nodo " +
                    ex.Message;
                Commons.ErrorLog(err);
                throw new Exception(err);
            }
        }
        
        internal void DeleteNodeFromButton()
        {
            // Reuse the same logic with all guards
            DeleteNodeSelected();
        }
        
        /// <summary>
        /// Helper method to get localized string with fallback support
        /// </summary>
        private string GetLocalizedOrFallback(string key, string fallbackIt, string fallbackEn)
        {
            string localized = Loc.Get(key);
            
            // Check if the key is missing (returns [key] format)
            bool isMissing = string.IsNullOrWhiteSpace(localized) || 
                           (localized.StartsWith("[") && localized.EndsWith("]"));
            
            if (!isMissing)
                return localized;
            
            // Fallback to language-specific default
            bool isItalian = LocalizationManager.CurrentLanguage.StartsWith("it", 
                StringComparison.OrdinalIgnoreCase);
            
            return isItalian ? fallbackIt : fallbackEn;
        }
        internal void CheckGeneralKeysForTree(KeyEventArgs e, string ToFind)
        {
            if (e.KeyCode == Keys.F3)
                FindNodes(ToFind, markAllInSearch, true, false, false, false);
            if (e.KeyCode == Keys.F5)
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
        // >>> NUOVA STRATEGIA DEFINITIVA: Editing SOLO tramite TextBox esterna <<<
        //
        // DECISIONE ARCHITETTURALE:
        // - LabelEdit è PERMANENTEMENTE disabilitato nel TreeView
        // - L'editing dei nodi avviene ESCLUSIVAMENTE tramite txtNodeName (TextBox esterna)
        // - Questo elimina completamente il rischio di ExecutionEngineException causato
        //   dalla corruzione del message pump in .NET 10
        //
        // PATTERN:
        // 1. AfterSelect → popola txtNodeName con il nome del nodo selezionato
        // 2. L'utente modifica txtNodeName
        // 3. TxtNodeName_Leave → salva la modifica nel Topic e aggiorna il TreeNode.Text
        //
        // VANTAGGI:
        // - Nessun conflitto tra eventi di editing inline e aggiornamenti UI
        // - Flusso di dati unidirezionale e prevedibile
        // - Eliminazione completa di race condition nel message pump
        // - Codice più semplice e manutenibile

        // Contatore di rientranza invece di un semplice flag booleano
        // per gestire chiamate annidate (es. AddNewNode → AfterSelect)
        private int _uiUpdateDepth = 0;
        private bool isUpdatingUiFromCode 
        { 
            get => _uiUpdateDepth > 0;
            set
            {
                if (value)
                    _uiUpdateDepth++;
                else
                {
                    _uiUpdateDepth--;
                    if (_uiUpdateDepth < 0) _uiUpdateDepth = 0; // Safety check
                }
            }
        }
        private bool isSavingTree = false;

        /// <summary>
        /// UNICO COMPITO: Popolare le TextBox quando un nodo viene selezionato.
        /// </summary>
        internal void shownTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            // Imposta il flag per indicare che stiamo aggiornando le TextBox dal codice.
            isUpdatingUiFromCode = true;
            try
            {
                if (e.Node.Tag is Topic sourceTopic)
                {
                    currentTopic = sourceTopic;
                    txtNodeName.Text = currentTopic.Name ?? string.Empty;
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
        private void TxtNodeName_Leave(object sender, EventArgs e)
        {
            // Se stiamo aggiornando da codice, non fare nulla.
            if (isUpdatingUiFromCode) return;
            if (shownTreeView.SelectedNode == null) return;
            if (shownTreeView.SelectedNode.Tag is not Topic t) return;

            try
            {
                string newName = txtNodeName.Text ?? string.Empty;
                // Se il nome è cambiato, aggiorna il Topic e il TreeNode.
                if (t.Name != newName)
                {
                    t.Name = newName;
                    t.Changed = true;
                    hasChanges = true;
                    
                    // IMPORTANTE: Disabilita LabelEdit prima di aggiornare il testo
                    // per evitare che venga scatenato AfterLabelEdit
                    bool wasLabelEditEnabled = shownTreeView.LabelEdit;
                    shownTreeView.LabelEdit = false;
                    try
                    {
                        shownTreeView.SelectedNode.Text = newName; // Aggiorna il testo nel TreeView
                    }
                    finally
                    {
                        shownTreeView.LabelEdit = wasLabelEditEnabled;
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
        private void TxtNodeDescription_Leave(object sender, EventArgs e)
        {
            if (isUpdatingUiFromCode) return;
            if (shownTreeView.SelectedNode == null) return;
            if (shownTreeView.SelectedNode.Tag is not Topic t) return;

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

        // --- Metodi di supporto e altri eventi (semplificati e resi più sicuri) ---

        /// <summary>
        /// Gestisce l'inizio dell'editing inline di un nodo
        /// </summary>
        internal void shownTreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            // IMPORTANTE: Imposta il flag durante l'editing per bloccare
            // tutti gli aggiornamenti della UI che potrebbero interferire
            isUpdatingUiFromCode = true;
            
            // Il flag verrà resettato automaticamente in AfterLabelEdit
            // o quando l'utente cancella l'editing
        }

        internal void shownTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            // IMPORTANTE: Resetta SEMPRE il flag alla fine dell'editing
            try
            {
                if (e.Label == null) return; // L'utente ha annullato la modifica
                if (e.Node?.Tag is not Topic t) return;
                
                if (t.Name != e.Label)
                {
                    t.Name = e.Label;
                    t.Changed = true;
                    hasChanges = true;
                    
                    // Aggiorna la textbox se il nodo modificato è quello correntemente selezionato
                    if (e.Node == shownTreeView.SelectedNode && txtNodeName != null)
                    {
                        txtNodeName.Text = t.Name;
                    }
                }
            }
            finally
            {
                // SEMPRE resetta il flag alla fine dell'editing
                isUpdatingUiFromCode = false;
            }
        }

        internal void ShownTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && shownTreeView.SelectedNode != null)
            {
                // F2 ora sposta il focus sulla TextBox esterna invece di fare editing inline
                if (txtNodeName != null && txtNodeName.CanFocus)
                {
                    txtNodeName.Focus();
                    txtNodeName.SelectAll();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Insert)
            {
                // Insert aggiunge un nuovo nodo e sposta il focus sulla TextBox
                TreeNode newNode = AddNewNode("Nuovo argomento", (Control.ModifierKeys & Keys.Shift) != Keys.Shift);
                if (newNode != null && txtNodeName != null && txtNodeName.CanFocus)
                {
                    txtNodeName.Focus();
                    txtNodeName.SelectAll();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteNodeSelected();
                e.Handled = true;
            }
        }

        // Gli eventi LostFocus sono ora ridondanti a causa di Leave, ma li manteniamo per sicurezza
        // con la stessa logica di protezione.
        private void txtNodeName_LostFocus(object sender, EventArgs e)
        {
            TxtNodeName_Leave(sender, e);
        }
        private void txtNodeDescription_LostFocus(object sender, EventArgs e)
        {
            TxtNodeDescription_Leave(sender, e);
        }

        // Altri eventi rimangono invariati se non direttamente correlati a questo ciclo
        internal void ShownTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is Topic t)
            {
                if (e.Node.Checked && txtSearchString != null && txtNodeDigest != null)
                {
                    string path = dbMptt.GetNodePath(t.LeftNodeOld, t.RightNodeOld);
                    txtNodeDigest.Text += GetStringOfJustSomeNodesOfPath(path);
                }
                if (!bulkChangeOfChecks)
                {
                    t.Changed = true;
                    hasChanges = true;
                }
            }
        }
        internal void ShownTreeView_Click(object sender, EventArgs e)
        {
            if (ClearBackColorOnClick) ClearBackColor();
        }
        internal void TreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            dragSourceControlHash = e.Item.GetHashCode();
            shownTreeView.DoDragDrop(e.Item, typeOfDragAndDrop);
        }
        internal void TreeView_DragEnter(object sender, DragEventArgs e) { e.Effect = typeOfDragAndDrop; }
        private void TreeView_DragLeave(object sender, EventArgs e) { }
        internal void TreeView_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = shownTreeView.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = shownTreeView.GetNodeAt(targetPoint);
            if (e.Data.GetData(typeof(TreeNode)) is not TreeNode draggedNode) return;

            if (targetNode == null)
            {
                draggedNode.Remove();
                shownTreeView.Nodes.Add(draggedNode);
                draggedNode.Expand();
            }
            else if (!draggedNode.Equals(targetNode))
            {
                bool canDrop = true;
                TreeNode parentNode = targetNode;
                while (canDrop && parentNode != null)
                {
                    canDrop = !ReferenceEquals(draggedNode, parentNode);
                    parentNode = parentNode.Parent;
                }
                if (canDrop)
                {
                    draggedNode.Remove();
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control && targetNode.Parent != null)
                    {
                        targetNode.Parent.Nodes.Insert(targetNode.Index, draggedNode);
                        targetNode.Parent.Expand();
                    }
                    else
                    {
                        targetNode.Nodes.Add(draggedNode);
                        targetNode.Expand();
                    }
                    hasChanges = true;
                }
            }
            if (dragSourceControlHash != draggedNode.GetHashCode())
                DeleteNodeById_Recursive(draggedNode);
            shownTreeView.SelectedNode = draggedNode;
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
        private void SearchCheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            ResetSearch();
            if (txtSearchString != null)
                FindNodes(txtSearchString.Text,
                    chkMarkAllNodesFound?.Checked == true,
                    chkSearchInDescriptions?.Checked == true,
                    chkAllWord?.Checked == true,
                    chkCaseInsensitive?.Checked == true,
                    chkVerbatimString?.Checked == true);
        }
        private void chkMarkAllNodesFound_CheckedChanged(object sender, EventArgs e) { ResetSearch(); }
        private void chkVerbatimString_CheckedChanged(object sender, EventArgs e) { ResetSearch(); }
        internal void AddChildrenNodesToTreeViewFromDatabase(TreeNode ParentNode, int Level)
        {
            GetChildren_Recursive(ParentNode, Level);
        }
        private void GetChildren_Recursive(TreeNode ParentNode, int Level)
        {
            List<Topic> lt = dbMptt.GetNodesChildsByParent(((Topic)ParentNode.Tag), false);
            foreach (Topic t in lt.OrderBy(o => o.ChildNumberOld))
            {
                if (!Commons.MethodCanContinue()) return;
                TreeNode n = CreateTreeViewItem(t);
                ParentNode.Nodes.Add(n);
                GetChildren_Recursive(n, Level + 1);
            }
        }
        internal void SaveTreeFromScratch(TreeNode CurrentNode, List<Topic> generatedList)
        {
            int nodeCount = 1;
            GenerateNewListOfNodesFromTreeViewControl_Recursive(CurrentNode, ref nodeCount, ref generatedList);
            bl.SaveTopicsFromScratch(generatedList);
        }
        internal void GenerateNewListOfNodesFromTreeViewControl_Recursive(TreeNode CurrentNode, ref int nodeCount,
            ref List<Topic> generatedList)
        {
            if (!Commons.MethodCanContinue()) return;
            Topic ct = (Topic)CurrentNode.Tag;
            ct.LeftNodeNew = nodeCount++;
            generatedList.Add(ct);
            if (ct.Id == null || ct.Id == 0)
                ct.Id = dbMptt.CreateNewTopic(ct);
            int brotherNo = 1;
            foreach (TreeNode sonNode in CurrentNode.Nodes)
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
        private TreeNode CreateTreeViewItem(Topic Node)
        {
            return new TreeNode { Tag = Node, Text = Node.Name };
        }
        // ---------------------- End Utility Methods ----------------------
    }
}
