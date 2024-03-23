using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
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
        /// <summary>
        /// Takes a TreeView control and adds to it, and to some ancillary TextBoxes and CheckBoxes, 
        /// the capability of storing and retriving the tree in a database, memorizing it both 
        /// by the reference to the parent node of each node ("ByParent") 
        /// and by the use of a right and left nodes reference in a 
        /// Modified Preorder Traversal Tree organization ("Mptt"). 
        /// The saving of the tree in a MPTT fashion can be accomplished asyncronuosly
        /// in a separate thread. Consistency of the tree is preserved when the program exits. 
        /// (!! proved NOT TRUE is some cases, must be cured.. !!)
        /// Some events of the controls, redriven to this class, are treated. 
        /// 
        /// An MPTT tree loads more quickly in a single DBMS query but saves much more 
        /// slowly, with one DBMS query for each change in the left and right node. 
        /// Almost all left and right nodes could be changed if the change in the tree is very "up", near the root
        /// With MPTT we can use single queries to retrive subtrees. 
        /// With MPTT we can have all the nodes that stay under a given node with just two tests
        /// 
        ///  made by Gabriele MONTI - Forlì - Italia
        /// </summary>
        /// 
        // inspiration for the MPTT code comes from: 
        // https://www.sitepoint.com/hierarchical-data-database/, by Gijs Van Tulder


        // Business Logic Layer
        BusinessLayer bl;
        // class that encapsulates the data access to the tree nodes 
        TreeMpttDb_SqLite dbMptt;

        private bool hasChanges = false;
        bool markAllInSearch = false;

        #region fields used for drag and drop 
        // identification of the Treeview control from which the drag starts
        private int dragSourceControlHash;
        private bool hasNodeBeenSelectedFromTree = false;

        private Topic currentTopic = null;

        System.Windows.Forms.DragDropEffects typeOfDragAndDrop;
        #endregion

        #region fields used for saving the Mptt tree (also concurrently)
        private static bool isSavingTreeMptt;

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
        CheckBox chkMarkAllTopicsFound;
        #endregion

        #region coloring of the nodes
        private Color colorOfHighlightedItem = Color.Khaki;
        private Color colorOfFoundItem = Color.Lime;
        private Color colorOfBeheadedColor = Color.Orange;
        #endregion

        // if true the backcolor of nodes will be cleared when the user clicks on one node 
        bool clearBackColorOnClick = true;
        public bool ClearBackColorOnClick { get => clearBackColorOnClick; set => clearBackColorOnClick = value; }
        // Name of the object
        public string Name { get; set; }
        // TreeView control from the calling code
        public TreeView TreeView { get => shownTreeView; }

        bool functionKeysEnabled = true;
        public bool FunctionKeysEnabled
        {
            get
            {
                return functionKeysEnabled;
            }
            set
            {
                shownTreeView.AfterLabelEdit += shownTreeView_AfterLabelEdit;
                shownTreeView.AfterCheck += shownTreeView_AfterCheck;
                shownTreeView.AfterSelect += shownTreeView_AfterSelect;
                shownTreeView.Click += shownTreeView_Click;
                shownTreeView.KeyDown += shownTreeView_KeyDown;
                txtNodeName.Leave += TxtNodeName_Leave;
                txtNodeName.TextChanged += TxtNodeName_TextChanged;
                txtNodeDescription.Leave += TxtNodeDescription_Leave;
                if (chkSearchInDescriptions != null)
                    chkSearchInDescriptions.CheckedChanged += SearchCheckBoxes_CheckedChanged;
                if (chkAllWord != null)
                    chkAllWord.CheckedChanged += SearchCheckBoxes_CheckedChanged;
                if (chkCaseInsensitive != null)
                    chkCaseInsensitive.CheckedChanged += SearchCheckBoxes_CheckedChanged;
                if (chkMarkAllTopicsFound != null)
                    chkMarkAllTopicsFound.CheckedChanged += chkMarkAllTopicsFound_CheckedChanged;
                if (chkVerbatimString != null)
                    chkVerbatimString.CheckedChanged += chkVerbatimString_CheckedChanged;
                //}
                //else
                //{
                //    // un-hook the events
                //    // !!!! TODO !!!! rethink the event we should unhook
                //    // since the functioning involving the following events 
                //    // was akward, the unhook has been disabled 
                //    //shownTreeView.AfterLabelEdit -= TreeView_AfterLabelEdit;
                //    //shownTreeView.AfterCheck -= TreeView_AfterCheck;
                //    //shownTreeView.AfterSelect -= TreeView_AfterSelect;
                //    //shownTreeView.Click -= TreeView_Click;
                //    //shownTreeView.KeyDown -= TreeView_KeyDown;
                //    //txtNodeName.Leave -= TxtNodeName_Leave;
                //    //txtNodeName.TextChanged -= TxtNodeName_TextChanged;
                //    //txtNodeDescription.TextChanged -= TxtNodeDescription_TextChanged;
                //}
                functionKeysEnabled = value;
            }
        }
        public bool HasChanges { get => hasChanges; set => hasChanges = value; }
        internal TreeMptt(TreeView TreeViewControl,
            TextBox TxtNodeName, TextBox TxtNodeDescription, TextBox TxtNodeSearchString,
            TextBox TxtNodeDigest, TextBox TxtIdNode,
            PictureBox LedPictureBox, CheckBox ChkSearchInDescriptions, CheckBox ChkVerbatimString,
            CheckBox ChkAllWord, CheckBox ChkCaseInsensitive, CheckBox ChkMarkAllNodesFound,
            System.Windows.Forms.DragDropEffects TypeOfDragAndDrop = System.Windows.Forms.DragDropEffects.Move
           )
        {
            bl = Commons.bl;
#if SQL_SERVER
            TreeMpttDb_SqlServer dbMptt = new();
#else
            TreeMpttDb_SqLite dbMptt = new TreeMpttDb_SqLite();
#endif
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
            chkMarkAllTopicsFound = ChkMarkAllNodesFound;

            if (shownTreeView != null)
            {
                FunctionKeysEnabled = true;

                shownTreeView.LabelEdit = false;
                // for drag & drop 
                shownTreeView.AllowDrop = true;
                shownTreeView.ItemDrag += TreeView_ItemDrag;
                shownTreeView.DragDrop += TreeView_DragDrop;
                shownTreeView.DragEnter += TreeView_DragEnter;
                shownTreeView.DragLeave += TreeView_DragLeave;
                // for object that will be dragged:
                //////shownTreeView.MouseDown += (sender, args) => DoDragDrop(TheSampleLabel.Text, DragDropEffects.Copy);

                txtNodeName.LostFocus += txtNodeName_LostFocus;
                txtNodeDescription.LostFocus += txtNodeDescription_LostFocus;
            }
            typeOfDragAndDrop = TypeOfDragAndDrop;
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
            // syncronously save the nodes that have changed data or parentNode
            // (shorter operation) 

            //DbConnection Connection = dl.Connect();
            // disable the background saving task. When disabled, the concurrent
            // thread will stop modifying the database 
            lock (Commons.LockBackgroundSavingVariables)
            {
                // locks the concurrent modification of synchronizing variables 
                Commons.BackgroundSavingEnabled = false;
                Commons.BackgroundTaskClose = true;
            }
            // all the saving happens under a lock from other tasks
            // this saving waits here until the background task hasn't finished finishing 
            lock (Commons.LockSavingCriticalSections)
            {
                dbMptt.SaveLeftRightConsistent(false);
                // save the nodes that have changed any field, except RightNode & Left Node (optional) 
                // (saving RightNode & Left Node changes would be too slow, 
                // so it is done in the background Thread, that we will restart at the end of this method
                listItemsAfter = new List<Topic>();
                int nodeCount = 1;
                // recursive function using ONE single root node of Treeview 
                GenerateNewListOfNodesFromTreeViewControl_Recursive(shownTreeView.Nodes[0],
                    ref nodeCount, ref listItemsAfter);
                // now in listTopicsAfter we have the list of all current nodes, with correct 
                // "new" and "old" pointers (included Left and Right) 

                // find deleted topics. After they will be deleted from database
                listItemsDeleted = new List<Topic>();
                // ???? this is expensive! We can do better !!!!! (TODO !!!! manage deletion list directly on delete from the treeview)
                foreach (Topic tOld in listItemsBefore)
                {
                    if (FindNodeById_Recursive(shownTreeView.Nodes[0], tOld) == null)
                    {
                        // not found, has been deleted 
                        if (tOld.ParentNodeOld > 0)
                        {
                            // don't delete possible other root nodes (for future features and for error emersion) 
                            listItemsDeleted.Add(tOld);
                        }
                    }
                }
                // UPDATE THE DATABASE
                // save the items in the database (modified nodes will be saved 
                // according to the difference between old and new values, new 
                // nodes are empty, so they will save. Left and Right will be 
                // saved by a concurrent Thread, so here the third parameter is false
                dbMptt.SaveTreeToDb(listItemsAfter, listItemsDeleted, false, true);
                // Left-Right status left on "inconsistent" if we were NOT saving leftNode and rightNode
                // or if we quit this method breaking the loops. 
                // Update listTopicsBefore by taking it from the treeview 
                nodeCount = 1;
                listItemsBefore.Clear();
                // recursive function
                GenerateNewListOfNodesFromTreeViewControl_Recursive(shownTreeView.Nodes[0],
                    ref nodeCount, ref listItemsBefore);
                // copy New fields in Old  
                foreach (Topic t in listItemsBefore)
                {
                    t.ChildNumberOld = t.ChildNumberNew;
                    t.ParentNodeOld = t.ParentNodeNew;
                }
                dbMptt.SaveLeftRightConsistent(false);
            }
            lock (Commons.LockBackgroundSavingVariables)
            {
                Commons.BackgroundSavingEnabled = true;
            }
            hasChanges = false;
        }
        internal void SaveTreeMpttBackground()
        {
            // updates leftNode and right node of every node in the tree 
            // works in background in a thread of its own 

            // Starts a loop that finishes when we want to close the thread.
            // Closing will be fired from external, by setting to true BackgroundCanStillSaveTopicsTree
            while (!Commons.BackgroundTaskClose)  // closes task when can't run anymore 
            {
                // waits BackgroundThreadSleepTime seconds, watching periodically if it must exit the loop 
                DateTime endTime = DateTime.Now.AddSeconds(Commons.BackgroundThreadSleepSeconds);
                while (DateTime.Now < endTime)
                {
                    if (Commons.BackgroundTaskClose)
                        return;
                    Thread.Sleep(1000);
                }
                // check if RightNode & LeftNode are already consistent, if they are, this task 
                // has nothing to do, so we will skip the modification, then wait again
                if (!dbMptt.AreLeftAndRightConsistent() && Commons.BackgroundSavingEnabled)
                {
                    // start saving in background, in locked condition
                    // other tasks can signal this to abort operation by setting 
                    // Commons.BackgroundSavingEnabled to false
                    lock (Commons.LockSavingCriticalSections)
                    {
                        //Commons.BackgroundSavingEnabled = true;
                        Commons.BackgroundTaskIsSaving = true;
                        CommonsWinForms.SwitchPicLed(true);
                        // read the tree by Parent into a new TreeView control
                        // that we aren't showing 
                        TreeView hiddenTree = new TreeView();
                        AddNodesToTreeViewByParent(hiddenTree);
                        // traverse the tree with Mptt, saving Left and Right and quitting if  
                        // someone else modifies BackgroundSavingEnabled
                        List<Topic> listNodes = new List<Topic>();
                        int nodeCount = 1;
                        if (Commons.BackgroundSavingEnabled)
                            // not executed if saving is aborted 
                            GenerateNewListOfNodesFromTreeViewControl_Recursive(hiddenTree.Nodes[0],
                                ref nodeCount, ref listNodes);
                        if (Commons.BackgroundSavingEnabled)
                            // not executed if saving is aborted 
                            // in this point delete list cannot have any entry
                            dbMptt.SaveTreeToDb(listNodes, null, true, false);
                        if (Commons.BackgroundSavingEnabled)
                            // not executed if saving is aborted 
                            dbMptt.SaveLeftRightConsistent(true);

                        Commons.BackgroundTaskIsSaving = false;
                    }
                    CommonsWinForms.SwitchPicLed(false);
                }
            }
        }
        #endregion
        #region methods that read nodes and put them in the Treeview
        internal void AddNodesToTreeviewByBestMethod()
        {
            //DbConnection Connection = dl.Connect();
            if (dbMptt.AreLeftAndRightConsistent())
            {
                // load using leftNode and rightNode values 
                // (database was left consistent, with correct values for 
                // leftNode and rightNode for every node)
                listItemsBefore = dbMptt.GetNodesMpttFromDatabase(0, int.MaxValue);
                AddNodesToTreeViewWithMptt();
            }
            else
            {
                // load by parentNode value
                listItemsBefore = dbMptt.GetNodesByParentFromDatabase(); // is this useful ? 
                AddNodesToTreeViewByParent(shownTreeView);
            }
            shownTreeView.Nodes[0].Expand();

            //Connection.Close();
            //Connection.Dispose();
        }
        internal void AddNodesToTreeViewWithMptt()
        {
            shownTreeView.Nodes.Clear();
            listItemsBefore = dbMptt.GetNodesMpttFromDatabase(0, int.MaxValue);
            if (!Commons.ProcessingCanContinue()) return;
            if (listItemsBefore != null && listItemsBefore.Count > 0)
            {
                // put first node in treeview 
                Topic previousNode = listItemsBefore[0];
                TreeNode previousUiNode = CreateTreeViewItem(previousNode);
                shownTreeView.Nodes.Add(previousUiNode); // first node of the tree
                for (int listIndex = 1; listIndex < listItemsBefore.Count; listIndex++)
                {
                    if (!Commons.ProcessingCanContinue()) return;
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
                        do
                        {
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
        internal void AddNodesToTreeViewByParent(TreeView CurrentTreeView)
        {
            CurrentTreeView.Nodes.Clear();

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
                if (!Commons.ProcessingCanContinue()) return;
                // first level nodes
                TreeNode rootNode = CreateTreeViewItem(t);
                CurrentTreeView.Nodes.Add(rootNode);
                AddChildrenNodesToTreeViewFromDatabase(rootNode, 0);
            }
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
        public void ImportSubtreeFromText(string TextFromClipboard)
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
            if (!Commons.ProcessingCanContinue())
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
            // ParentNode contains the number of indents of the node! 
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
                    // just in this part of the code ParentNodeNew contains the level of indentation of each tree node
                    if (level < t.ParentNodeNew)
                    {
                        // level + 1
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
        internal void UncheckAllItemsUnderNode_Recursive(TreeNode currentNode)
        {
            currentNode.Checked = false;
            foreach (TreeNode sonNode in currentNode.Nodes)
            {
                // recursion 
                UncheckAllItemsUnderNode_Recursive(sonNode);
            }
            return;
        }
        internal void CheckItemsInList_Recursive(TreeNode startNode,
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
                MessageBox.Show("Scegliere un nodo cui aggiungere un nodo ad un sottoalbero");
                return null;
            }
            TreeNode fatherNode = null;
            TreeNode UiNode = null;
            Topic nodeParent = null;
            Topic nodeNew = null;

            if (isSonNode)
            {   // the new node must be the son of the currennt
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
            shownTreeView.SelectedNode = UiNode;

            txtNodeName.Text = nodeNew.Name;
            //txtNodeName.Focus();
            txtNodeDescription.Text = "";
            txtNodeName.SelectionLength = txtNodeName.Text.Length;
            if (txtCodNode != null)
                txtCodNode.Text = nodeNew.Id.ToString();
            // start edit in the selected node
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
                TreeNode te = shownTreeView.SelectedNode;
                // if the topic has already been saved in the database, we have to ask for 
                // confirmation if it has already been checked in the past
                if (((Topic)te.Tag).Id != null)
                    if (bl.IsTopicAlreadyTaught((Topic)te.Tag))
                    {
                        if (MessageBox.Show("Questo argomento è già stato fatto in qualche lezione\n" +
                            "Lo cancello lo stesso?", "Attenzione!", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) ==
                            DialogResult.No)
                            return;
                    }
                // remove node from the control (when saving will be also deleted from the database) 
                te.Parent.Nodes.Remove(te);
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
            TreeNode te = shownTreeView.SelectedNode;
            te.Parent.Nodes.Remove(te);
            hasChanges = true;
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
        private void txtNodeDescription_LostFocus(object sender, EventArgs e)
        {
            if (currentTopic == null) return;
            if (((TextBox)sender).Text != currentTopic.Desc)
                hasChanges = true;
        }
        private void txtNodeName_LostFocus(object sender, EventArgs e)
        {
            if (currentTopic == null) return;
            if (((TextBox)sender).Text != currentTopic.Name)
                hasChanges = true;
        }
        internal void shownTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            hasNodeBeenSelectedFromTree = true;
            if (shownTreeView.SelectedNode != null)
            {
                currentTopic = (Topic)e.Node.Tag;
                txtNodeDescription.Text = currentTopic.Desc;
                txtNodeName.Text = currentTopic.Name;
                if (txtCodNode != null)
                    txtCodNode.Text = currentTopic.Id.ToString();
            }
        }
        internal void shownTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!(e.Label == null))
            {
                TreeNode n = shownTreeView.SelectedNode;
                Topic t = (Topic)(n.Tag);
                if (e.Label != n.Text)
                {
                    hasChanges = true;
                    t.Changed = true;
                }
                t.Name = e.Label;
                txtNodeName.Text = e.Label;
            }
        }
        internal void TreeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = typeOfDragAndDrop;
        }
        internal void TreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // remember the control from which the drag was initiated
            dragSourceControlHash = e.Item.GetHashCode();
            shownTreeView.DoDragDrop(e.Item, typeOfDragAndDrop);
        }
        private void TreeView_DragLeave(object sender, EventArgs e)
        {
            // feedback to user 
        }
        internal void TreeView_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = shownTreeView.PointToClient(new Point(e.X, e.Y));
            // Retrieve the node at the drop location.
            TreeNode targetNode = shownTreeView.GetNodeAt(targetPoint);
            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            //TreeNode  dn = (TreeNode)sender;

            // Sanity check
            if (draggedNode == null)
            {
                return;
            }

            // Did the user drop on a valid target node?
            if (targetNode == null)
            {
                // The user dropped the node on the treeview control instead
                // of another node so lets place the node at the bottom of the tree.
                draggedNode.Remove();
                shownTreeView.Nodes.Add(draggedNode);
                draggedNode.Expand();
            }
            else
            {
                TreeNode parentNode = targetNode;
                // Confirm that the node at the drop location is not 
                // the dragged node and that target node isn't null
                // (for example if you drag outside the control)
                if (!draggedNode.Equals(targetNode) && targetNode != null)
                {
                    bool canDrop = true;

                    // Crawl our way up from the node we dropped on to find out if
                    // if the target node is our parent. 
                    while (canDrop && (parentNode != null))
                    {
                        canDrop = !Object.ReferenceEquals(draggedNode, parentNode);
                        parentNode = parentNode.Parent;
                    }

                    // Is this a valid drop location?
                    if (canDrop)
                    {
                        // Yes. Move the node, expand it, and select it.
                        draggedNode.Remove();
                        if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                        {
                            // if dragged with the control key pushed, 
                            // connect to the brother of the target node 
                            (targetNode.Parent).Nodes.Insert(targetNode.Index, draggedNode);
                            (targetNode.Parent).Expand();
                            hasChanges = true;
                        }
                        else
                        {
                            // if dragged with no key connect to the parent 
                            targetNode.Nodes.Add(draggedNode);
                            targetNode.Expand();
                            hasChanges = true;
                        }
                    }
                }
            }
            if (dragSourceControlHash != draggedNode.GetHashCode())
            {
                // if the control has been dropped into a different treeview control
                // delete all the Ids in the subtree that I have copied here
                // so the new subtree will be considered as new
                DeleteNodeById_Recursive(draggedNode);
            }
            // Optional: Select the dropped node and navigate (however you do it)
            shownTreeView.SelectedNode = draggedNode;
            // NavigateToContent(draggedNode.Tag);  
        }
        internal void shownTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            // editing of nodes is now forbidden
            if (e.KeyCode == Keys.F2)
            {
                if (shownTreeView.SelectedNode != null)
                {
                    // start edit the selected node
                    shownTreeView.LabelEdit = true;
                    shownTreeView.SelectedNode.BeginEdit();
                }
                else
                    MessageBox.Show("Select the node");
            }
            if (e.KeyCode == Keys.Insert)
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    shownTreeView.SelectedNode = AddNewNode("Nuovo argomento", false);
                    // start edit the selected node
                    shownTreeView.LabelEdit = true;
                    shownTreeView.SelectedNode.BeginEdit();
                }
                else
                {  // shift is not pressed
                    shownTreeView.SelectedNode = AddNewNode("Nuovo argomento", true);
                    // start edit the selected node
                    shownTreeView.LabelEdit = true;
                    shownTreeView.SelectedNode.BeginEdit();
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                DeleteNodeSelected();
            }
        }
        internal void shownTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                if (txtSearchString != null)
                {
                    Topic t = (Topic)e.Node.Tag;
                    string path = dbMptt.GetNodePath(t.LeftNodeOld, t.RightNodeOld);
                    string stringToAdd = GetStringOfJustSomeNodesOfPath(path);
                    txtNodeDigest.Text += stringToAdd;
                }
            }
        }
        internal void shownTreeView_Click(object sender, EventArgs e)
        {
            if (ClearBackColorOnClick)
                ClearBackColor();
        }
        private void TxtNodeName_Leave(object sender, EventArgs e)
        {
            if (TreeView.SelectedNode != null)
            {
                try
                {
                    Topic t = (Topic)(TreeView.SelectedNode.Tag);
                    if (txtNodeName.Text != t.Name)
                    {
                        hasChanges = true;
                        t.Changed = true;
                    }
                    t.Name = txtNodeName.Text;
                    TreeView.SelectedNode.Text = txtNodeName.Text;
                }
                catch (Exception ex)
                {

                }
            }
        }
        string previousText = "";
        private void TxtNodeName_TextChanged(object sender, EventArgs e)
        {
            // if the change is due to selection in the tree, don't change
            if (hasNodeBeenSelectedFromTree)
            {
                hasNodeBeenSelectedFromTree = false;
                return;
            }
            if (shownTreeView.SelectedNode == null)
            {
                MessageBox.Show("Aggiungere il primo argomento o selezionarne uno");
                return;
            }
            // if the text is multiline and at the beginning of the new line there is 
            // an indentation: ask to import a subtree, if yes then create subtree
            if (txtNodeName.Text.Contains("\r\n")
                && (txtNodeName.Text.Contains("    ") || txtNodeName.Text.Contains("\t"))
                )
            {
                if (MessageBox.Show("Testo formattato come un albero di FreeMind.\nDevo importare un sottoalbero in questo punto?",
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    ImportSubtreeFromText(txtNodeName.Text);
                    int positionOfTab = txtNodeName.Text.IndexOf("\r\n");
                    shownTreeView.SelectedNode.Text = txtNodeName.Text.Substring(0, positionOfTab);
                    ((Topic)(shownTreeView.SelectedNode.Tag)).Name = txtNodeName.Text.Substring(0, positionOfTab);
                }
                else
                {
                    shownTreeView.SelectedNode.Text = txtNodeName.Text;
                }
            }
            else
            {
                if (txtNodeName.Text.Length > 0)
                {
                    string lastCharEntered = txtNodeName.Text.Substring(txtNodeName.Text.Length - 1, 1);
                    if (lastCharEntered != "\n")
                    {

                    }
                    else
                    {   // if user pushed Enter key
                        txtNodeName.Text = txtNodeName.Text.Substring(0, txtNodeName.Text.Length - 2);
                    }
                    //Topic t = (Topic)(shownTreeView.SelectedNode.Tag);
                    //t.Name = txtNodeName.Text;
                    //t.Changed = true;
                }
            }
        }
        private void TxtNodeDescription_Leave(object sender, EventArgs e)
        {
            if (hasNodeBeenSelectedFromTree)
                return;
            Topic t = (Topic)(shownTreeView.SelectedNode.Tag);
            if (t.Desc != txtNodeDescription.Text)
            {
                hasChanges = true;
                t.Changed = true;
            }
            t.Desc = txtNodeDescription.Text;
        }
        #endregion
        internal string CreateTextTreeOfDescendants(int? LeftNode, int? RightNode, bool? IncludeTopicsIds)
        {
            // TODO: mettere le descrizioni nell'albero (con un : prima) 
            string indentString = "\t";
            string currentIndentation = "";
            string file = "";
            Stack<Topic> stack = new Stack<Topic>();
            //DbAndBusiness db = new  DbAndBusiness(); 
            List<Topic> ListTopics = dbMptt.GetNodesMpttFromDatabase(LeftNode, RightNode);
            if (ListTopics != null && ListTopics.Count > 0)
            {
                // first node in file 
                Topic previousTopic = ListTopics[0];
                file += previousTopic.Name + "\t" + previousTopic.Desc;
                if ((bool)IncludeTopicsIds)
                    file += "\t" + previousTopic.Id;
                file += "\r\n";
                stack.Push(previousTopic);

                for (int i = 1; i < ListTopics.Count; i++)
                {
                    // for every son topic of this 
                    Topic currentTopic = ListTopics[i];
                    if (currentTopic.RightNodeOld < previousTopic.RightNodeOld)
                    {
                        // if is in new level, adds the node to the next level
                        currentIndentation += indentString;
                        file += currentIndentation + currentTopic.Name
                            + "\t" + currentTopic.Desc;
                        if ((bool)IncludeTopicsIds)
                            file += "\t" + currentTopic.Id;
                        file += "\r\n";
                        // remember father node
                        stack.Push(previousTopic);
                        previousTopic = currentTopic;
                    }
                    else
                    {
                        // one is always popped, to bring to the father of the same level 
                        previousTopic = stack.Pop();
                        while (currentTopic.RightNodeOld > previousTopic.RightNodeOld)
                        {
                            if (stack.Count > 0)
                            {
                                previousTopic = stack.Pop();
                                // less indentation 
                                currentIndentation =
                                    currentIndentation.Substring(0, currentIndentation.Length - 1);
                            }
                        };
                        file += currentIndentation + currentTopic.Name + "\t" +
                            currentTopic.Desc;
                        if ((bool)IncludeTopicsIds)
                            file += "\t" + currentTopic.Id;
                        file += "\r\n";
                        stack.Push(previousTopic);
                        previousTopic = currentTopic;
                    }
                }
            }
            return file;
        }
        internal void ResetSearch()
        {
            // deleting previousSearch the next search will be done from scratch 
            previousSearch = "";
        }
        private void SearchCheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            // event fired when any of the checkboxes related to search is changed 

            // command a new search for the next search 
            ResetSearch();
            FindNodes(txtSearchString.Text, chkMarkAllTopicsFound.Checked, chkSearchInDescriptions.Checked,
                chkAllWord.Checked, chkCaseInsensitive.Checked, chkVerbatimString.Checked);
        }
        private void chkMarkAllTopicsFound_CheckedChanged(object sender, EventArgs e)
        {
            // command a new search for the next search 
            ResetSearch();
        }
        private void chkVerbatimString_CheckedChanged(object sender, EventArgs e)
        {
            // command a new search for the next search 
            ResetSearch();
        }
        internal void AddChildrenNodesToTreeViewFromDatabase(TreeNode ParentNode, int Level)
        {
            GetChildren_Recursive(ParentNode, Level);
        }
        private void GetChildren_Recursive(TreeNode ParentNode, int Level)
        {
            // recursively retrieve all direct children of ParentNode  
            // get childs keeping the connection open
            List<Topic> lt = dbMptt.GetNodesChildsByParent(((Topic)ParentNode.Tag), false);
            List<Topic> SortedList = lt.OrderBy(o => o.ChildNumberOld).ToList();
            foreach (Topic t in SortedList)
            {
                if (!Commons.ProcessingCanContinue()) return;
                TreeNode n = CreateTreeViewItem(t);
                ParentNode.Nodes.Add(n);
                GetChildren_Recursive(n, Level++);
            }
        }
        internal void SaveTreeFromScratch(TreeNode CurrentNode, List<Topic> generatedList)
        {
            // TODO !!!! the refactor of this function must be tested !!!!
            //DbConnection Connection = dl.Connect();
            int nodeCount = 1;
            // recursive function
            GenerateNewListOfNodesFromTreeViewControl_Recursive(CurrentNode,
                ref nodeCount, ref generatedList);
            bl.SaveTopicsFromScratch(generatedList);
        }
        internal void GenerateNewListOfNodesFromTreeViewControl_Recursive(TreeNode CurrentNode, ref int nodeCount,
            ref List<Topic> generatedList) // the 2 ref parameters must be passed for recursion
        {
            if (!Commons.BackgroundSavingEnabled && Commons.BackgroundTaskIsSaving) return;
            // visits all the childrens of CurrentNode in the Treeview. 
            // with the Modified Tree Traversal algorithm 

            // add a new element for the List that we will save to the database
            Topic ct = ((Topic)CurrentNode.Tag);
            ct.LeftNodeNew = nodeCount++;
            // manages left node number
            generatedList.Add((Topic)CurrentNode.Tag);
            if (ct.Id == null || ct.Id == 0)
            {
                // if CurrentNode is a new node, then we create it in the database, 
                // so that it will have its Id. It will be saved with correct data 
                // in the following because new and old values will differ 
                ct.Id = dbMptt.CreateNewTopic(ct);
            }
            int brotherNo = 1;
            foreach (TreeNode sonNode in CurrentNode.Nodes)
            {
                if (!Commons.ProcessingCanContinue()) return;
                // calls passing the updated count and the list under construction 
                GenerateNewListOfNodesFromTreeViewControl_Recursive(sonNode,
                    ref nodeCount, ref generatedList);
                ((Topic)sonNode.Tag).ParentNodeNew = ct.Id;
                ((Topic)sonNode.Tag).ChildNumberNew = brotherNo++;
            }
            // If brothers are finished saves data of itself and returns.
            // right node management
            ((Topic)CurrentNode.Tag).RightNodeNew = nodeCount++;
        }
        internal void GenerateNewListOfNodesFromDatabase(Topic CurrentNode, ref int nodeCount,
            ref List<Topic> generatedList) // the 2 ref parameters must be passed in such way for recursion
        {
            // visits all the childrens of CurrentNode in the Treeview. 
            // with the Modified Tree Traversal algorithm 

            // add a new element to the List 
            CurrentNode.LeftNodeNew = nodeCount++;
            // manages left node number
            generatedList.Add(CurrentNode);
            int brotherNo = 1;
            // find all son nodes of current node (list is ordered by childNumber) 
            List<Topic> listChilds = dbMptt.GetNodesChildsByParent(CurrentNode, false);
            foreach (Topic sonNode in listChilds)
            {
                if (!Commons.ProcessingCanContinue()) return;
                // calls passing the updated count and the list under construction 
                GenerateNewListOfNodesFromDatabase(sonNode, ref nodeCount, ref generatedList);
                sonNode.ParentNodeNew = CurrentNode.Id;
                sonNode.ChildNumberNew = brotherNo++;
            }
            // If brothers are finished saves data of itself and returns.
            // right node management
            CurrentNode.RightNodeNew = nodeCount++;
        }
        private TreeNode CreateTreeViewItem(Topic Node)
        {
            TreeNode item = new TreeNode
            {
                Tag = Node,
                Text = Node.Name,
            };
            return item;
        }
    }
}
