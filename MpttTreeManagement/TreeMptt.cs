using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using SchoolGrades;
using SchoolGrades.DbClasses;
using SharedWinForms;

namespace gamon.TreeMptt
{
    internal class TreeMptt
    {
        /// <summary>
        /// Takes a TreeView control and adds to it and to some ancillary TextBoxes, 
        /// the capability of storing and retreiving the tree in a database, memorizing it both 
        /// by the reference to the parent node of each node ("ByParent") 
        /// and by the use of a right and left nodes referece in a 
        /// Modified Preorder Traversal Tree organization ("Mptt"). 
        /// The saving of the tree in a MPTT fashion can be accomplished asyncronuosly
        /// in a separate thread. Consistency of the tree is preserved. (!! NOT TRUE, must be cured.. !!)
        /// Some events of the controls, redriven to this class, are treated. 
        /// 
        /// An MPTT tree loads more quickly in a single DBMS query but saves much more 
        /// slowly, with many DBMS queries. 
        /// With MPTT we can use single queries to retreive subtrees. 
        /// With MPTT we can have in the results of the queries all the nodes that 
        /// stay under a given node with just two tests
        /// 
        ///  made by Gabriele MONTI - Forlì - Italia
        /// </summary>
        /// 
        // inspiration for the MPTT code comes from: 
        // https://www.sitepoint.com/hierarchical-data-database/, by Gijs Van Tulder

        // !!!! TODO some more events of the TextBoxes should be encapsulated in this class 

        //DbAndBusiness db = new DbAndBusiness();
        DbAndBusiness db;
        TreeMpttDb dbMptt;

        // identification of the Treeview control from which the drag starts
        int dragSourceControlHash; 
        System.Windows.Forms.DragDropEffects typeOfDragAndDrop;

        // parameters for saving the Mptt tree concurrently 
        // variable that can be set from the external to stop the background 
        // task that saves the nodes' tree as a Mptt tree

        List<Topic> listItemsBefore; // !!!!!!!!!!! forse non serve più !!!!!!!!
        List<Topic> listItemsAfter;
        List<Topic> listItemsDeleted;

        private TreeView shownTreeView;
        public TreeView TreeView { get => shownTreeView; set => shownTreeView = value; }

        Stack<TreeNode> stack = new Stack<TreeNode>();

        string previousSearch = "";
        int indexDone = 0;
        List<Topic> found = null;
        TextBox txtNodeName;
        TextBox txtNodeDescription;
        TextBox txtTopicsSearchString;
        TextBox txtCodTopic;

        private static bool isSavingTreeMptt;
        private Color colorOfHighlightedItem = Color.Khaki;
        private Color colorOfFoundItem = Color.Lime;
        private Color colorOfBeheadedColor = Color.Orange;

        bool clearBackColorOnClick = true;
        public bool ClearBackColorOnClick { get => clearBackColorOnClick; set => clearBackColorOnClick = value; }

        bool areLeftAndRightConsistent = true;
        public bool AreLeftAndRightConsistent { get => areLeftAndRightConsistent; }

        private static bool hasNodeBeenSelectedFromTree;

        /// <summary>
        /// Flag that helps in the behaviour of the treeview control when a selection of 
        /// a node is done by the user. 
        /// !!!! TODO Should be private, because some of the TextBoxes' events should be 
        /// encapsulated in this class. !!!!
        /// </summary>
        public static bool HasNodeBeenSelectedFromTree { get => hasNodeBeenSelectedFromTree; set => hasNodeBeenSelectedFromTree = value; }
        public static bool IsThreadSavingTreeMptt { get => isSavingTreeMptt; set => isSavingTreeMptt = value; }
        public string Name { get; set; }

        // enum to be used yet
        enum TypeOfSearch
        {
            StringSearch,
            AndSearch,
            OrSearch
        }

        //internal TreeMptt(DbAndBusiness DB, TreeView TreeViewControl,
        //    TextBox TxtNodeName, TextBox TxtNodeDescription, TextBox TxtTopicFind,
        //    TextBox TxtTopicsDigest, TextBox TxtCodTopic,
        //    PictureBox LedPictureBox,
        //    System.Windows.Forms.DragDropEffects TypeOfDragAndDrop = System.Windows.Forms.DragDropEffects.Move)
        internal TreeMptt(DbAndBusiness DataAndBusinessLayer, TreeView TreeViewControl,
            TextBox TxtNodeName, TextBox TxtNodeDescription, TextBox TxtTopicFind,
            TextBox TxtTopicsDigest, TextBox TxtCodTopic,
            PictureBox LedPictureBox,
            System.Windows.Forms.DragDropEffects TypeOfDragAndDrop = System.Windows.Forms.DragDropEffects.Move)
        {
            db = DataAndBusinessLayer;
            dbMptt = new TreeMpttDb(db);
            
            shownTreeView = TreeViewControl;
            //listTopicsBefore = InitialListOfTopics;

            txtNodeName = TxtNodeName;
            txtNodeDescription = TxtNodeDescription;
            txtTopicsSearchString = TxtTopicsDigest;
            txtCodTopic = TxtCodTopic;

            if (shownTreeView != null)
            {
                // hook the events
                shownTreeView.AfterLabelEdit += TreeView_AfterLabelEdit;
                shownTreeView.AfterCheck += TreeView_AfterCheck;
                shownTreeView.AfterSelect += TreeView_AfterSelect;
                shownTreeView.Click += TreeView_Click;
                shownTreeView.KeyDown += TreeView_KeyDown;
                txtNodeName.Leave += TxtNodeName_Leave;

                // for drag & drop 
                shownTreeView.AllowDrop = true;
                shownTreeView.ItemDrag += TreeView_ItemDrag;
                shownTreeView.DragDrop += TreeView_DragDrop;
                shownTreeView.DragEnter += TreeView_DragEnter;
                shownTreeView.DragLeave += TreeView_DragLeave;
                // for object that will be dragged:
                //////TrwTopics.MouseDown += (sender, args) => DoDragDrop(TheSampleLabel.Text, DragDropEffects.Copy);
            }

            typeOfDragAndDrop = TypeOfDragAndDrop;
        }
        internal void GetAllNodesOfSubtree(TreeNode NodeStart, List<TreeNode> List) // (passes List for recursion) 
        {
            List.Add(NodeStart);
            foreach (TreeNode tn in NodeStart.Nodes)
            {
                GetAllNodesOfSubtree(tn, List);
            }
        }
        internal void AddNodesToTreeviewByBestMethod()
        {
            if (dbMptt.AreLeftAndRightConsistent())
            {
                // load by leftNode and rightNode values 
                // (database was left consistent, with correct values for 
                // leftNode and rightNode for every node)
                listItemsBefore = dbMptt.GetTopicsMpttFromDatabase(0, int.MaxValue);
                AddNodesToTreeViewWithMptt();
            }
            else
            {
                // load by parentNode value
                listItemsBefore = dbMptt.GetTopicsByParent(); // this is quite unuseful..
                AddNodesToTreeViewByParent(shownTreeView);
            }
            shownTreeView.Nodes[0].Expand();
        }
        internal void AddNodesToTreeViewWithMptt()
        {
            shownTreeView.Nodes.Clear();
            listItemsBefore = dbMptt.GetTopicsMpttFromDatabase(0, int.MaxValue);
            if (listItemsBefore != null && listItemsBefore.Count > 0)
            {
                // put first node in treeview 
                Topic previousTopic = listItemsBefore[0];
                TreeNode previousUiNode = new TreeNode(previousTopic.Name);
                previousUiNode.Tag = previousTopic;
                shownTreeView.Nodes.Add(previousUiNode); // first node of the tree
                for (int listIndex = 1; listIndex < listItemsBefore.Count; listIndex++)
                {
                    Topic currentTopic = listItemsBefore[listIndex];
                    TreeNode currentUiNode = new TreeNode(currentTopic.Name);
                    currentUiNode.Tag = currentTopic;

                    if (currentTopic.RightNodeOld < previousTopic.RightNodeOld)
                    {
                        // if is in new level, adds the node to the next level
                        previousUiNode.Nodes.Add(currentUiNode);
                        // remember father node
                        stack.Push(previousUiNode);
                        previousUiNode = currentUiNode;
                        previousTopic = (Topic)currentUiNode.Tag;
                    }
                    else
                    {
                        do
                        {
                            previousUiNode = (TreeNode)stack.Pop();
                            previousTopic = (Topic)(previousUiNode.Tag);
                        } while (currentTopic.RightNodeOld > previousTopic.RightNodeOld);
                        // if same level, son of the same father
                        previousUiNode.Nodes.Add(currentUiNode);
                        stack.Push(previousUiNode);
                        previousUiNode = currentUiNode;
                        previousTopic = (Topic)(previousUiNode.Tag);
                    }
                }
            }
        }
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
        internal void AddNodesToTreeViewByParent(TreeView CurrentTreeView)
        {
            CurrentTreeView.Nodes.Clear();

            // put all the roots in the Treeview
            // finds all the nodes that don't have a parent
            // so you can fit the Treeview of a Win Form program, that is multiroot
            // NOT DONE! 
            // (this program treats only one root node because with MPTT having more than one root 
            // would complicate the database) 
            List<Topic> lt = dbMptt.GetTopicsRoots();

            // keep the connection open during the tree traversal
            // in order to increase the performance 
            foreach (Topic t in lt)
            {
                // first level nodes
                TreeNode rootNode = new TreeNode(t.Name);
                rootNode.Tag = t;
                rootNode.Text = t.Name;
                CurrentTreeView.Nodes.Add(rootNode);

                dbMptt.AddChildrenNodesToTreeViewFromDatabase(rootNode, 0);
            }
        }
        // !! TODO !! add options to the search. Currently it is only a substing search
        //internal void FindItem(string TextToFind, TypeOfSearch Type, bool WholeWordSearch)
        internal void FindItem(string TextToFind)
        {
            if (previousSearch != TextToFind)
            {
                // first search: find all the occurencies of the string 
                found = dbMptt.FindTopicsLike(TextToFind);
                //if (found.Count == 0)
                //    MessageBox.Show("Non trovato");
                indexDone = 0;
                previousSearch = TextToFind;
            }
            else
            {
                // same search, find the next occurence of the same string 
                indexDone++;
                shownTreeView.Nodes[0].Collapse(); // selection will expand
                // if the results are finished: bring back to the first 
                if (found == null)
                    return;
                if (indexDone >= found.Count)
                    indexDone = 0;
            }
            TreeNode f = null;
            if (found.Count > 0)
            {
                f = FindNodeRecursivelyById(shownTreeView.Nodes[0], found[indexDone]);
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
        }
        /// <summary>
        /// Finds a tree node, searching by its Id
        /// </summary>
        /// <param name="IdItem">Item's Id
        /// </param>
        /// <returns></returns>
        internal TreeNode FindItemById(int? IdItem)
        {
            Topic t = new Topic();
            t.Id = IdItem;
            TreeNode f = null;
            f = FindNodeRecursivelyById(shownTreeView.Nodes[0], t);
            if (f != null)
            {
                shownTreeView.SelectedNode = f;
                f.BackColor = colorOfFoundItem;
                f.EnsureVisible();
            }
            return f;
        }
        private TreeNode FindNodeRecursivelyById(TreeNode treeNode, Topic Topic)
        {
            if (((Topic)treeNode.Tag).Id == Topic.Id)
                return treeNode;
            foreach (TreeNode tn in treeNode.Nodes)
            {
                TreeNode t = FindNodeRecursivelyById(tn, Topic);
                if (t != null)
                    return t;
            }
            return null;
        }
        internal void SaveTreeFromScratch()
        {
            int nodeCount = 1;
            List<Topic> listTopicsAfter = new List<Topic>();
            // recursive function
            dbMptt.GenerateNewListOfNodesFromTreeViewControl(shownTreeView.Nodes[0], ref nodeCount, ref listTopicsAfter);
            db.SaveTopicsFromScratch(listTopicsAfter);
        }
        internal void UpdateLeftAndRightInDatabaseTreeMptt()
        {
            // recursive function
            dbMptt.SaveLeftAndRightToDbMptt();
        }

        /// <summary>
        /// Saves Left and Right nodes according to MPTT trtraversal 
        /// To store the topology uses a hidden Treeview, which we will never show to the user
        /// !!!! TODO: probably this might be much more quick !!!!
        /// </summary>
        internal void SaveMpttBackground()
        {
            // Starts a loop that finishes when we want to close the thread.
            // Closing will be fired from external, by resetting to false BackgroundCanStillSaveTopicsTree
            while (CommonsWinForms.BackgroundCanStillSaveTopicsTree)
            {
                // waits BackgroundThreadSleepTime seconds, watching periodically if it must exit
                DateTime endTime = DateTime.Now.AddSeconds(CommonsWinForms.BackgroundThreadSleepSeconds);
                while (DateTime.Now < endTime)
                {
                    if (!CommonsWinForms.BackgroundCanStillSaveTopicsTree)
                        // thread finishes! (main saving thread has started)
                        // when main thread has finished saving, it will start this thread once again
                        return; 
                    Thread.Sleep(1000);
                }
                // check if RightNode & LeftNode are already consistent, if they are, this task 
                // has nothing to do, so we will skip the modification, then wait 
                if (!dbMptt.AreLeftAndRightConsistent())
                {
                    // start saving in background, signalling to the main program 
                    // locks a concurrent modification of Commons.BackgroundCanStillSaveTopicsTree 
                    lock (CommonsWinForms.LockBackgroundCanStillSaveTopicsTree)
                    {
                        CommonsWinForms.BackgroundCanStillSaveTopicsTree = true;
                    }
                    CommonsWinForms.SwitchPicLedOn(true);
                    // read the tree by Parent into a new TreeView control
                    TreeView hiddenTree = new TreeView();
                    AddNodesToTreeViewByParent(hiddenTree);
                    // traverse the tree with Mptt, saving Left and Right and quitting if 
                    // someone else modifies BackgroundCanStillSaveItemsTree
                    List<Topic> listNodes = new List<Topic>();
                    int nodeCount = 1;
                    // recursive function using ONE single root node of Treeview 
                    dbMptt.GenerateNewListOfNodesFromTreeViewControl(hiddenTree.Nodes[0], ref nodeCount, ref listNodes);
                    // in this point delete list cannot have any entry
                    dbMptt.SaveTreeToDb(listNodes, null, true);
                    
                    if (CommonsWinForms.BackgroundCanStillSaveTopicsTree)
                        dbMptt.SaveLeftRightConsistent(true);
                    CommonsWinForms.SwitchPicLedOn(false);
                }
            }
        }
        internal void ShowAllBeheadedNodes()
        {
            TreeNodeCollection nodes = shownTreeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                ShowAllBeheadedNodesRecursive(n);
            }
        }
        private void ShowAllBeheadedNodesRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Parent == null)
                    tn.BackColor = colorOfBeheadedColor;
                else
                    tn.BackColor = Color.White;
                ShowAllBeheadedNodesRecursive(tn);
            }
        }
        internal void EraseTree()
        {

        }

        // next version of the previous method left commented. Different idea, but not working! Adjusting might require being too slow
        // so the method has been re-written storing the topology into a hidden Treevie
        //internal void SaveMpttBackground()
        //{
        //    // Starts a loop that finishes when we want to close the thread.
        //    // Closing will be fired from external, by resetting to false BackgroundCanStillSaveTopicsTree
        //    while (Commons.BackgroundCanStillSaveTopicsTree)
        //    {
        //        // waits BackgroundThreadSleepTime seconds, watching periodically if it must exit
        //        DateTime endTime = DateTime.Now.AddSeconds(Commons.BackgroundThreadSleepSeconds);
        //        while (DateTime.Now < endTime)
        //        {
        //            if (!BackgroundCanStillSaveItemsTree)
        //                return;
        //            Thread.Sleep(1000);
        //        }
        //        // check if RightNode & LeftNode are already consistent, if they are, this task 
        //        // has nothing to do, so we will wait 
        //        if (!dbMptt.AreLeftAndRightConsistent())
        //        {
        //            // if they aren't, start the update of all the RightNode & LeftNode pointers. 
        //            // This code reads nodes from the database, NOT from the TreeView control 
        //            // and can be aborted by an external program by setting BackgroundCanStillSaveItemsTree
        //            // to false 
        //            Commons.SwitchPicLedOn(true);
        //            // Read list of topics from database
        //            //List<Topic> list = dbMptt.GetTopicsByParent();

        //            // save the nodes that have changed any field, except RightNode & Left Node (optional) 
        //            // (saving RightNode & Left Node changes would be too slow, so it will be made in a 
        //            // background Thread) 
        //            // update of the database
        //            // save the items' rightNode and leftNode in the database

        //            // update the items in the database (modified nodes will be saved 
        //            // according to the difference between old and new values, new 
        //            // nodes are empty, so they will save. Left and Right will be 
        //            // saved according to the last parameter of the function) 
        //            // save the nodes that have changed data or parent node
        //            // if mustSaveTreeAsMptt is set, salve also topics that have changed rightNode or leftNode
        //            dbMptt.SaveLeftAndRightToDbMptt();
        //            //int nodeCount = 1;
        //            //List<Topic> listTopicsBefore = new List<Topic>();

        //            //foreach (Topic t in listTopicsBefore)
        //            //{
        //            //    t.ChildNumberOld = t.ChildNumberNew;
        //            //    t.ParentNodeOld = t.ParentNodeNew;
        //            //}

        //            //IsThreadSavingTreeMptt = false;
        //            //foreach (Topic t in listTopicsBefore)
        //            //{
        //            //    t.LeftNodeOld = t.LeftNodeNew;
        //            //    t.RightNodeOld = t.RightNodeNew;
        //            //}

        //            if (BackgroundCanStillSaveItemsTree)
        //                dbMptt.SaveLeftRightConsistent(true); 

        //            Commons.SwitchPicLedOn(false);
        //        }
        //    }
        //}
        internal void 
            SaveTreeFromTreeViewControlByParent()
        {
            // syncronously save the nodes that have changed data or parentNode
            // (shorter operation) 

            // if a background process is saving the tree, we stop it
            if (IsThreadSavingTreeMptt)
            {
                // locks a concurrent modification of Commons.BackgroundCanStillSaveTopicsTree 
                lock (CommonsWinForms.LockBackgroundCanStillSaveTopicsTree)
                {
                    CommonsWinForms.BackgroundCanStillSaveTopicsTree = false;
                }
                // we wait for the saving Thread to finish
                // (it aborts in a point in which status is preserved)  
                CommonsWinForms.BackgroundSaveThread.Join(30000); // enormous timeout just for big problems
            }
            // save the nodes that have changed any field, except RightNode & Left Node (optional) 
            // (saving RightNode & Left Node changes would be too slow, 
            // so it is done in the background Thread, that we will restart at the end of this method
            listItemsAfter = new List<Topic>();
            int nodeCount = 1;
            // recursive function using ONE single root node of Treeview 
            dbMptt.GenerateNewListOfNodesFromTreeViewControl(shownTreeView.Nodes[0], ref nodeCount, ref listItemsAfter);
            // now in listTopicsAfter we have the list of all current nodes, with correct 
            // "new" and "old" pointers (included Left and Right) 

            // find deleted topics. After they will be deleted from database
            listItemsDeleted = new List<Topic>();
            // ???? this is expensive! We can do better !!!!! (TODO !!!! manage deletion list directly on delete from the treeview)
            foreach (Topic tOld in listItemsBefore)
            {
                if (FindNodeRecursivelyById(shownTreeView.Nodes[0], tOld) == null)
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

             
            
            
            
            dbMptt.SaveTreeToDb(listItemsAfter, listItemsDeleted, false);

            // Update listTopicsBefore by taking it from the treeview 
            nodeCount = 1;
            listItemsBefore.Clear();
            // recursive function
            dbMptt.GenerateNewListOfNodesFromTreeViewControl(shownTreeView.Nodes[0], ref nodeCount, ref listItemsBefore);
            // copy New fields in Old  
            foreach (Topic t in listItemsBefore)
            {
                t.ChildNumberOld = t.ChildNumberNew;
                t.ParentNodeOld = t.ParentNodeNew;
            }
            try
            {
                CommonsWinForms.SwitchPicLedOn(false);
            }
            catch { }
            // restart the Thread 
            // re-create and run the Thread that concurrently saves the Topics tree
            CommonsWinForms.BackgroundSaveThread = new Thread(CommonsWinForms.SaveTreeMptt.SaveMpttBackground);
            CommonsWinForms.BackgroundSaveThread.Start();
        }
        internal TreeNode AddNewNode(string Text)
        {
            if (shownTreeView.SelectedNode == null)
            {
                MessageBox.Show("Scegliere un nodo cui aggiungere un sottoalbero");
                return null; 
            }
            Topic tParent = (Topic)(shownTreeView.SelectedNode.Tag);
            int? idParentNew = (int?)tParent.Id;
            Topic t = new Topic();
            t.Name = Text;
            t.LeftNodeOld = t.RightNodeOld = -1;
            TreeNode UiNode = new TreeNode(t.Name);
            UiNode.Tag = t;
            if (shownTreeView.SelectedNode == null)
            {
                shownTreeView.Nodes.Add(UiNode);
            }
            else
            {
                shownTreeView.SelectedNode.Nodes.Add(UiNode);
            }
            shownTreeView.SelectedNode = UiNode;

            txtNodeName.Text = t.Name;
            //txtNodeName.Focus();
            txtNodeDescription.Text = "";
            txtNodeName.SelectionLength = txtNodeName.Text.Length;
            if (txtCodTopic != null)
                txtCodTopic.Text = t.Id.ToString();
            // start edit in the selected node
            return UiNode;
        }
        internal void FindCheckedItems(TreeNode currentNode,
            List<Topic> checkedTopicsFound, ref int ListIndex)
        {
            // visits all the childrens of CurrentNode, addind to the list those 
            // that are checked in the treeview 
            foreach (TreeNode sonNode in currentNode.Nodes)
            {
                if (sonNode.Checked)
                {
                    Topic newTopic = (Topic)sonNode.Tag;
                    checkedTopicsFound.Add(newTopic);
                }
                FindCheckedItems(sonNode, checkedTopicsFound, ref ListIndex);
            }

            return;
        }
        internal void UncheckAllItemsUnderNode(TreeNode currentNode)
        {
            currentNode.Checked = false;
            foreach (TreeNode sonNode in currentNode.Nodes)
            {
                // recursion 
                UncheckAllItemsUnderNode(sonNode);
            }
            return;
        }
        /// <summary>
        /// Recursive method that puts the check signs in the items included in the list
        /// </summary>
        /// <param name="startNode">The node under which we search</param>
        /// <param name="ItemsToCheck">List of ityemes to check</param>
        /// <param name="ListIndex">Index in the list</param>
        /// <param name="foundInThisBranch">True if the item has been found</param>
        internal void CheckItemsInList(TreeNode startNode,
            List<Topic> ItemsToCheck, ref int ListIndex, ref bool foundInThisBranch)
        {
            startNode.Collapse();
            // !! list must be given in Tree Traversal order !!
            if (ItemsToCheck.Count == 0)
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
                CheckItemsInList(sonNode, ItemsToCheck, ref ListIndex, ref foundInThisBranch);
                if (foundInThisBranch)
                    sonNode.EnsureVisible();
                //currentNode.Expand();
            }
            return;
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
                    node = new TreeNode(ListToImport[0].Name);
                    node.Tag = ListToImport[0];
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
                    TreeNode currentNode = new TreeNode(t.Name);
                    currentNode.Tag = t;
                    node.Tag = t;
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
        // recursively move through the treeview nodes
        // and reset backcolors to white
        internal void ClearBackColor()
        {
            TreeNodeCollection nodes = shownTreeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                ClearBackColorRecursive(n);
            }
        }
        // called by ClearBackColor function
        private void ClearBackColorRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.BackColor = Color.White;
                ClearBackColorRecursive(tn);
            }
        }
        // recursively move through the subtree nodes
        // deleting node Id
        internal void DeleteIdInSubTree(TreeNode ParentNode)
        {
            ((Topic)ParentNode.Tag).Id = null; 
            TreeNodeCollection nodes = ParentNode.Nodes;
            foreach (TreeNode n in nodes)
            {
                DeleteIdInSubTree(n);
            }
        }
        internal void HighlightTopicsInList(TreeNode startNode, List<Topic> ItemsToHighlight,
            ref int ListIndex, ref bool foundInThisBranch, Color? HighlightColor = null)
        {
            Color highlightColor  = HighlightColor ?? colorOfHighlightedItem; 

            startNode.Collapse();
            // !! list must be given in Tree Traversal order !!
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
                HighlightTopicsInList(sonNode, ItemsToHighlight,
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
        internal void ColorNodeAsFoundById(int Id, Color? HighlightColor = null)
        {
            Color highlightColor = HighlightColor ?? colorOfFoundItem;
            TreeNode f = FindItemById(Id);
            f.BackColor = highlightColor;
            f.Expand(); 
            return;
        }
        internal void DeleteNode()
        {
            try
            {
                TreeNode te = shownTreeView.SelectedNode;
                // if the topic has already been saved in the database, we have to ask for 
                // confirmation if it has already been cheched in the past
                if (((Topic)te.Tag).Id != null) 
                    if (db.IsTopicAlreadyTaught((Topic)te.Tag))
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
        }
        internal void DeleteNodeClick()
        {
            TreeNode te = shownTreeView.SelectedNode;
            te.Parent.Nodes.Remove(te);
        }
        internal void checkGeneralKeysForTopicsTree(KeyEventArgs e, string ToFind)
        {
            if (e.KeyCode == Keys.F3)
                FindItem(ToFind);
            if (e.KeyCode == Keys.F5)
            {
                SaveTreeFromTreeViewControlByParent();
            }
        }
        private string JustSomeNodesOfPath(string Path)
        {
            if (Path == null)
                return null;
            string[] AllNodes = Path.Split('|');
            string stringToAdd = "";
            // take the last topics of the topics tree 
            for (int i = AllNodes.Length - 2, j = 0; i > 0 && j < 2; i--, j++)
            {
                stringToAdd = (AllNodes[i] + ":" + stringToAdd).Trim();
            }
            return stringToAdd += ". ";
        }
        #region events
        internal void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            hasNodeBeenSelectedFromTree = true;
            if (shownTreeView.SelectedNode != null)
            {
                Topic t = (Topic)(shownTreeView.SelectedNode.Tag);
                txtNodeDescription.Text = t.Desc;
                txtNodeName.Text = t.Name;
                if (txtCodTopic != null)
                    txtCodTopic.Text = t.Id.ToString();
            }
        }
        internal void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!(e.Label == null))
            {
                //// stop edit selected node
                //treeView.LabelEdit = false;
                txtNodeName.Text = e.Label;
                TreeNode n = shownTreeView.SelectedNode;
                Topic t = (Topic)(n.Tag);
                t.Name = e.Label;
                t.Changed = true;
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
                        }
                        else
                        {
                            // if dragged with no key connect to the parent 
                            targetNode.Nodes.Add(draggedNode);
                            targetNode.Expand();
                        }
                    }
                }
            }
            if (dragSourceControlHash != draggedNode.GetHashCode())
            {
                // if the control has been dropped into a different treeview control
                // delete all the Ids in the subtree that I have copied here
                // so the new subtree will be considered as new
                DeleteIdInSubTree(draggedNode); 
            }
            // Optional: Select the dropped node and navigate (however you do it)
            shownTreeView.SelectedNode = draggedNode;
            // NavigateToContent(draggedNode.Tag);  
        }

        internal void TreeView_KeyDown(object sender, KeyEventArgs e)
        {
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
                shownTreeView.SelectedNode = AddNewNode("Nuovo argomento");
                // start edit the selected node
                shownTreeView.LabelEdit = true;
                shownTreeView.SelectedNode.BeginEdit();
            }
            if (e.KeyCode == Keys.Delete)
            {
                DeleteNode();
            }
        }
        internal void TreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                if (txtTopicsSearchString != null)
                {
                    Topic t = (Topic)e.Node.Tag;
                    string path = dbMptt.GetTopicPath(t.LeftNodeOld, t.RightNodeOld);
                    string stringToAdd = JustSomeNodesOfPath(path);
                     txtTopicsSearchString.Text += stringToAdd;
                }
            }
        }
        internal void TreeView_Click(object sender, EventArgs e)
        {
            if (ClearBackColorOnClick)
                ClearBackColor();
        }
        private void TxtNodeName_Leave(object sender, EventArgs e)
        {
            try
            {
                Topic t = (Topic)(TreeView.SelectedNode.Tag);
                t.Name = txtNodeName.Text;
                TreeView.SelectedNode.Text = txtNodeName.Text;
            }
            catch (Exception ex)
            {

            }
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
            List<Topic> ListTopics = dbMptt.GetTopicsMpttFromDatabase(LeftNode, RightNode);
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
    }
}
