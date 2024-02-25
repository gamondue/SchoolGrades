using SchoolGrades;
using SchoolGrades.BusinessObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

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

        // class that encapsulates the data access to the tree nodes 
        TreeMpttDb_SqLite dbMptt;

        private bool hasChanges = false;
        bool markAllInSearch = false;
        private bool putCheckSignsOnNodes;

        BusinessLayer bl = Commons.bl;

        //private object value;
        //private Image globalPicLed;
        //private CheckBox chkSearchInDescriptions;
        //private CheckBox chkVerbatimString;
        //private CheckBox chkAllWord;
        //private CheckBox chkCaseInsensitive;
        //private CheckBox chkMarkAllNodesFound;
        //private DragDropEffects copy;

        //public TreeMptt(TextBox trwTopics, TextBox txtTopicName, TextBox txtTopicDescription, TextBox txtTopicSearchString, TextBox txtTopicsDigest, object value, Image globalPicLed, CheckBox chkSearchInDescriptions, CheckBox chkVerbatimString, CheckBox chkAllWord, CheckBox chkCaseInsensitive, CheckBox chkMarkAllNodesFound, DragDropEffects copy)
        //{
        //    this.trwTopics = trwTopics;
        //    this.txtTopicSearchString = txtTopicSearchString;
        //    this.txtTopicsDigest = txtTopicsDigest;
        //    this.value = value;
        //    this.globalPicLed = globalPicLed;
        //    this.chkSearchInDescriptions = chkSearchInDescriptions;
        //    this.chkVerbatimString = chkVerbatimString;
        //    this.chkAllWord = chkAllWord;
        //    this.chkCaseInsensitive = chkCaseInsensitive;
        //    this.chkMarkAllNodesFound = chkMarkAllNodesFound;
        //    this.copy = copy;
        //}

        #region fields used for drag and drop 
        // identification of the Treeview control from which the drag starts
        private int dragSourceControlHash;
        private bool hasNodeBeenSelectedFromTree = false;

        private Topic currentTopic = null;

        System.Windows.DragDropEffects typeOfDragAndDrop;
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
        Stack<TreeViewItem> stack = new Stack<TreeViewItem>();

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
        private Brush colorOfHighlightedItem = Brushes.Khaki;
        private Brush colorOfFoundItem = Brushes.Lime;
        private Brush colorOfBeheadedColor = Brushes.Orange;
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
                shownTreeView.LostFocus += shownTreeView_AfterLabelEdit;
                //shownTreeView.????? += shownTreeView_AfterCheck;
                shownTreeView.SelectedItemChanged += shownTreeView_AfterSelect;
                shownTreeView.PreviewMouseLeftButtonDown += shownTreeView_Click;
                shownTreeView.KeyDown += shownTreeView_KeyDown;
                txtNodeName.LostFocus += TxtNodeName_Leave;
                txtNodeName.TextChanged += TxtNodeName_TextChanged;
                txtNodeDescription.LostFocus += TxtNodeDescription_Leave;
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
                    chkMarkAllNodesFound.Checked += chkMarkAllTopicsFound_CheckedChanged;
                    chkMarkAllNodesFound.Unchecked += chkMarkAllTopicsFound_CheckedChanged;
                }
                if (chkVerbatimString != null)
                {
                    chkVerbatimString.Checked += chkVerbatimString_CheckedChanged;
                    chkVerbatimString.Unchecked += chkVerbatimString_CheckedChanged;
                }
                //}
                //else
                //{
                //    // un-hook the events
                //    // !!!! TODO !!!! rethink the event we should unhook
                //    // since the functioning involving the following events 
                //    // was akward, the unhook has been disabled 
                //    //shownTreeView.CellEditEnding -= TreeView_AfterLabelEdit;
                //    //shownTreeView.AfterCheck -= TreeView_AfterCheck;
                //    //shownTreeView.AfterSelect -= TreeView_AfterSelect;
                //    //shownTreeView.Click -= TreeView_Click;
                //    //shownTreeView.KeyDown -= TreeView_KeyDown;
                //    //txtNodeName.LostFocus -= TxtNodeName_Leave;
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
            Rectangle LedImage, CheckBox ChkSearchInDescriptions, CheckBox ChkVerbatimString,
            CheckBox ChkAllWord, CheckBox ChkCaseInsensitive, CheckBox ChkMarkAllNodesFound,
            System.Windows.DragDropEffects TypeOfDragAndDrop = System.Windows.DragDropEffects.Move,
            bool PutCheckSignsOnNodes = true)
        {
            bl = Commons.bl;
#if SQL_SERVER
            TreeMpttDb_SqlServer dbMptt = new TreeMpttDb_SqLite();
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
            chkMarkAllNodesFound = ChkMarkAllNodesFound;

            if (shownTreeView != null)
            {
                FunctionKeysEnabled = true;

                //////shownTreeView.LabelEdit = false;
                //////// for drag & drop 
                //////shownTreeView.AllowDrop = true;
                //////shownTreeView.ItemDrag += TreeView_ItemDrag;
                //////shownTreeView.DragDrop += TreeView_DragDrop;
                //////shownTreeView.DragEnter += TreeView_DragEnter;
                //////shownTreeView.DragLeave += TreeView_DragLeave;
                ////////for object that will be dragged:
                //////shownTreeView.MouseDown += (sender, args) => DoDragDrop(TheSampleLabel.Text, DragDropEffects.Copy);

                txtNodeName.LostFocus += txtNodeName_LostFocus;
                txtNodeDescription.LostFocus += txtNodeDescription_LostFocus;
            }
            typeOfDragAndDrop = TypeOfDragAndDrop;
            putCheckSignsOnNodes = PutCheckSignsOnNodes;
        }
        #region methods that save the tree
        internal void SaveTreeFromScratch()
        {
            int nodeCount = 1;
            List<Topic> listTopicsAfter = new List<Topic>();
            // recursive function
            GenerateNewListOfNodesFromTreeViewControl_Recursive(
                (TreeViewItem)shownTreeView.Items[0], ref nodeCount, ref listTopicsAfter);
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
                GenerateNewListOfNodesFromTreeViewControl_Recursive(
                    (TreeViewItem)shownTreeView.Items[0], ref nodeCount, ref listItemsAfter);
                // now in listTopicsAfter we have the list of all current nodes, with correct 
                // "new" and "old" pointers (included Left and Right) 

                // find deleted topics. After they will be deleted from database
                listItemsDeleted = new List<Topic>();
                // ???? this is expensive! We can do better !!!!! (TODO !!!! manage deletion list directly on delete from the treeview)
                foreach (Topic tOld in listItemsBefore)
                {
                    if (FindNodeById_Recursive((TreeViewItem)shownTreeView.Items[0], tOld) == null)
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
                GenerateNewListOfNodesFromTreeViewControl_Recursive((TreeViewItem)shownTreeView.Items[0],
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
                        CommonsWpf.SwitchPicLed(true);
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
                            GenerateNewListOfNodesFromTreeViewControl_Recursive(
                                (TreeViewItem)(hiddenTree.Items[0]), ref nodeCount, ref listNodes);
                        if (Commons.BackgroundSavingEnabled)
                            // not executed if saving is aborted 
                            // in this point delete list cannot have any entry
                            dbMptt.SaveTreeToDb(listNodes, null, true, true);
                        if (Commons.BackgroundSavingEnabled)
                            // not executed if saving is aborted 
                            dbMptt.SaveLeftRightConsistent(true);

                        Commons.BackgroundTaskIsSaving = false;
                    }
                    CommonsWpf.SwitchPicLed(false);
                }
            }
        }
        #endregion
        #region methods that read nodes and put them in the Treeview
        internal void AddNodesToTreeviewByBestMethod()
        {
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
            ((TreeViewItem)(shownTreeView.Items[0])).IsExpanded = true;

            //Connection.Close();
            //Connection.Dispose();
        }
        internal void AddNodesToTreeViewWithMptt()
        {
            shownTreeView.Items.Clear();
            listItemsBefore = dbMptt.GetNodesMpttFromDatabase(0, int.MaxValue);
            if (!Commons.ProcessingCanContinue()) return;
            if (listItemsBefore != null && listItemsBefore.Count > 0)
            {
                // put first node in treeview 
                Topic previousNode = listItemsBefore[0];
                TreeViewItem previousUiNode = CreateTreeViewItem(previousNode);
                shownTreeView.Items.Add(previousUiNode); // first node of the tree
                for (int listIndex = 1; listIndex < listItemsBefore.Count; listIndex++)
                {
                    if (!Commons.ProcessingCanContinue()) return;
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
                        do
                        {
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
        internal void AddNodesToTreeViewByParent(TreeView CurrentTreeView)
        {
            CurrentTreeView.Items.Clear();

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
                TreeViewItem rootNode = CreateTreeViewItem(t);
                CurrentTreeView.Items.Add(rootNode);
                AddChildrenNodesToTreeViewFromDatabase(rootNode, 0);
            }
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
        public void ImportSubtreeFromText(string TextFromClipboard)
        {
            if (TextFromClipboard == "")
            {
                Console.Beep();
                //return "";
            }
            ImportFreeMindSubtreeUnderNode(TextFromClipboard, (TreeViewItem)TreeView.SelectedItem);
            //return TextFromClipboard;
        }
        #endregion
        #region methods that search in the tree
        internal void FindNodes(string TextToFind)
        {
            bool ColorAllNodesFound = (bool)chkMarkAllNodesFound.IsChecked;
            bool SearchInDescriptions = (bool)chkSearchInDescriptions.IsChecked;
            bool SearchWholeWord = (bool)chkAllWord.IsChecked;
            bool SearchCaseInsensitive = (bool)chkCaseInsensitive.IsChecked;
            bool SearchVerbatimString = (bool)chkVerbatimString.IsChecked;
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
                    HighlightNodesInList((TreeViewItem)shownTreeView.Items[0], found, ref dummy, ref bDummy);
                    ClearBackColorOnClick = false;
                }
            }
            else
            {
                // same search, find the next occurence of the same string 
                indexDone++;
                //if (!markAllInSearch)
                //{
                //    ((TreeViewItem)shownTreeView.Items[0]).IsExpanded = false;
                //}
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
                    f.IsExpanded = true;
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
        internal void FindNodeUnderNode(string TextToFind)
        {
            // TODO!!!! make this option!!!!          
            //////////markAllInSearch = (bool)chkMarkAllNodesFound.IsChecked;
            //////////if (previousSearch != TextToFind)
            //////////{
            //////////    // first search: find all the occurencies of the string 
            //////////    found = dbMptt.FindNodesLike(TextToFind, (bool)chkSearchInDescriptions.IsChecked,
            //////////        (bool)chkAllWord.IsChecked, (bool)chkCaseInsensitive.IsChecked,
            //////////        (bool)chkVerbatimString.IsChecked);
            //////////    indexDone = 0;
            //////////    previousSearch = TextToFind;

            //////////    if (markAllInSearch)
            //////////    {
            //////////        int dummy = 0; bool bDummy = false;
            //////////        // !!!! the following doesn't work. Highlight only a few of the results. Probably this "found" list of found is noo in Mptt order !!!! 
            //////////        HighlightTopicsInList(shownTreeView.Items[0], found, ref dummy, ref bDummy);
            //////////        ClearBackColorOnClick = false;
            //////////    }
            //////////}
            //////////else
            //////////{
            //////////    // same search, find the next occurence of the same string 
            //////////    indexDone++;
            //////////    if (!markAllInSearch)
            //////////    {
            //////////        shownTreeView.Items[0].Collapse(); // selection will expand
            //////////    }
            //////////    // if the results are finished: bring back to the first 
            //////////    if (found == null)
            //////////        return;
            //////////    if (indexDone >= found.Count)
            //////////        indexDone = 0;
            //////////}
            //////////TreeViewItem f = null;
            //////////if (found.Count > 0)
            //////////{
            //////////    f = FindNodeById_Recursive((TreeViewItem)shownTreeView.Items[0],
            //////////        found[indexDone]);
            //////////    if (f != null)
            //////////    {
            //////////        //shownTreeView.Select();
            //////////        shownTreeView.SelectedItem = f;
            //////////        f.Background = colorOfFoundItem;
            //////////    }
            //////////    else
            //////////        MessageBox.Show("Non trovato");
            //////////}
            //////////else
            //////////{
            //////////    MessageBox.Show("Non trovato");
            //////////}
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
        private TreeViewItem FindNodeById_Recursive(TreeViewItem TreeViewItem, Topic Topic)
        {
            if (!Commons.ProcessingCanContinue())
            {
                return null;
            }
            if (((Topic)TreeViewItem.Tag).Id == Topic.Id)
                return TreeViewItem;
            foreach (TreeViewItem tn in TreeViewItem.Items)
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
            if (!putCheckSignsOnNodes)
                return;
            // visits all the childrens of CurrentNode, adding to the list those 
            // that are checked in the treeview 
            foreach (TreeViewItem sonNode in currentNode.Items)
            {
                StackPanel s = (StackPanel)sonNode.Header;
                if ((bool)((CheckBox)s.Children[0]).IsChecked)
                {
                    checkedTopicsFound.Add((Topic)sonNode.Tag);
                }
                FindCheckedItems_Recursive(sonNode, checkedTopicsFound, ref ListIndex);
            }
            return;
        }
        #endregion
        #region methods that color nodes 
        internal void ColorAllBeheadedNodes()
        {
            ////TreeViewItemCollection nodes = shownTreeView.Items;
            foreach (TreeViewItem n in shownTreeView.Items)
            {
                ColorAllBeheadedNodes_Recursive(n);
            }
        }
        private void ColorAllBeheadedNodes_Recursive(TreeViewItem TreeViewItem)
        {
            foreach (TreeViewItem tn in TreeViewItem.Items)
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
            ParentNodeOfImportedSubtree.Header = subTopics[0];
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
            TreeViewItem ParentNodeOfImportedSubtree)
        {
            // ParentNode contains the number of indents of the node! 
            try
            {
                // fill the treeview adding the list's items to the tag property of each node
                int startNodeIndex;
                TreeViewItem node;
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
                    // just in this part of the code ParentNodeNew contains the level of indentation of each tree node
                    if (level < t.ParentNodeNew)
                    {
                        // level + 1
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
            //TreeViewItemCollection nodes = shownTreeView.Items;
            foreach (TreeViewItem n in shownTreeView.Items)
            {
                ClearBackColor_Recursive(n);
            }
        }
        private void ClearBackColor_Recursive(TreeViewItem TreeViewItem)
        {
            // called by ClearBackColor function
            foreach (TreeViewItem tn in TreeViewItem.Items)
            {
                tn.Background = Brushes.White;
                ClearBackColor_Recursive(tn);
            }
        }
        internal void HighlightNodesInList(TreeViewItem startNode, List<Topic> ItemsToHighlight,
            ref int ListIndex, ref bool foundInThisBranch, Brush? HighlightColor = null)
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
                    ref ListIndex, ref foundInThisBranch);
                if (foundInThisBranch)
                    sonNode.BringIntoView();
            }
            return;
        }
        internal void HighlightNode(TreeViewItem Node, Brush? HighlightColor = null)
        {
            Brush highlightColor = HighlightColor ?? colorOfHighlightedItem;
            Node.Background = highlightColor;
            Node.IsExpanded = true;
            return;
        }
        internal void ColorNodeFoundById(int Id, Brush? HighlightColor = null)
        {
            Brush highlightColor = HighlightColor ?? colorOfFoundItem;
            TreeViewItem f = FindNodeById(Id);
            f.Background = highlightColor;
            f.IsExpanded = true;
            return;
        }
        #endregion
        #region manage the treeview nodes' checking 
        internal void UncheckAllItemsUnderNode_Recursive(TreeViewItem currentNode)
        {
            StackPanel s = currentNode.Header as StackPanel;
            ((CheckBox)(s.Children[0])).IsChecked = false;
            foreach (TreeViewItem sonNode in currentNode.Items)
            {
                // recursion 
                UncheckAllItemsUnderNode_Recursive(sonNode);
            }
            return;
        }
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
                Topic nodeContent = (Topic)sonNode.Tag;
                if (ItemsToCheck[ListIndex].Id == nodeContent.Id)
                {   // found item to check 
                    StackPanel s = (StackPanel)sonNode.Header;
                    ((CheckBox)s.Children[0]).IsChecked = true;
                    sonNode.IsExpanded = true;
                    sonNode.BringIntoView();
                    foundInThisBranch = true;
                    ListIndex++;
                }
                // recursion 
                CheckItemsInList_Recursive(sonNode, ItemsToCheck, ref ListIndex, ref foundInThisBranch);
                if (foundInThisBranch)
                    sonNode.BringIntoView();
                //currentNode.IsExpanded = true;
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
            UiNode = new TreeViewItem();
            UiNode.Header = nodeNew.Name;
            UiNode.Tag = nodeNew;

            if (shownTreeView.SelectedItem == null)
            {
                shownTreeView.Items.Add(UiNode);
            }
            else
            {
                fatherNode.Items.Add(UiNode);
            }
            UiNode.IsSelected = true;
            txtNodeName.Text = nodeNew.Name;
            txtNodeDescription.Text = "";
            txtNodeName.SelectionLength = txtNodeName.Text.Length;
            if (txtCodNode != null)
                txtCodNode.Text = nodeNew.Id.ToString();
            // start edit in the selected node
            txtNodeName.Focus();
            return UiNode;
        }
        internal void DeleteNodeById_Recursive(TreeViewItem ParentNode)
        {
            ((Topic)ParentNode.Tag).Id = null;
            //TreeViewItemCollection nodes = ParentNode.Items;
            foreach (TreeViewItem n in shownTreeView.Items)
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
                if (((Topic)te.Tag).Id != null)
                    if (bl.IsTopicAlreadyTaught((Topic)te.Tag))
                    {
                        //if (MessageBox.Show("Questo argomento è già stato fatto in qualche lezione\n" +
                        //    "Lo cancello lo stesso?", "Attenzione!", MessageBoxButton.YesNo,
                        //    MessageBoxImage.Information, MessageBoxDefaultButton.Button2) ==
                        //    MessageBoxResult.No)
                        if (MessageBox.Show("Questo argomento è già stato fatto in qualche lezione\n" +
                            "Lo cancello lo stesso?", "Attenzione!") ==
                            MessageBoxResult.No)
                            return;
                    }
                // remove node from the control (when saving will be also deleted from the database) 
                ((TreeViewItem)(te.Parent)).Items.Remove(te);
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
            //////////if (e.KeyCode == Keys.F3)
            //////////    FindNodes(ToFind, markAllInSearch, true, false, false, false);
            //////////if (e.KeyCode == Keys.F5)
            //////////{
            //////////    SaveTreeFromTreeViewByParent();
            //////////}
            //////////hasChanges = true;
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
        private void txtNodeDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            if (currentTopic == null) return;
            if (((TextBox)sender).Text != currentTopic.Desc)
                hasChanges = true;
        }
        private void txtNodeName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (currentTopic == null) return;
            if (((TextBox)sender).Text != currentTopic.Name)
                hasChanges = true;
        }
        internal void shownTreeView_AfterSelect(object sender, RoutedEventArgs e)
        {
            hasNodeBeenSelectedFromTree = true;
            if (shownTreeView.SelectedItem != null)
            {
                currentTopic = (Topic)((TreeViewItem)shownTreeView.SelectedItem).Tag;
                txtNodeDescription.Text = currentTopic.Desc;
                txtNodeName.Text = currentTopic.Name;
                if (txtCodNode != null)
                    txtCodNode.Text = currentTopic.Id.ToString();
            }
        }
        internal void shownTreeView_AfterLabelEdit(object sender, RoutedEventArgs e)
        {
            ////////if (!(e.Label == null))
            ////////{
            ////////    TreeViewItem n = (TreeViewItem)shownTreeView.SelectedItem;
            ////////    Topic t = (Topic)(n.Tag);
            ////////    if (e.Label != n.Header)
            ////////    {
            ////////        hasChanges = true;
            ////////        t.Changed = true;
            ////////    }
            ////////    t.Name = e.Label;
            ////////    txtNodeName.Text = e.Label;
            ////////}
        }
        internal void TreeView_DragEnter(object sender, RoutedEventArgs e)
        {
            ////////e.Effect = typeOfDragAndDrop;
        }
        internal void TreeView_ItemDrag(object sender, RoutedEventArgs e)
        {
            ////////// remember the control from which the drag was initiated
            ////////dragSourceControlHash = e.Item.GetHashCode();
            ////////shownTreeView.DoDragDrop(e.Item, typeOfDragAndDrop);
        }
        private void TreeView_DragLeave(object sender, RoutedEventArgs e)
        {
            // feedback to user 
        }
        internal void TreeView_DragDrop(object sender, RoutedEventArgs e)
        {
            //////////// Retrieve the client coordinates of the drop location.
            //////////Point targetPoint = shownTreeView.PointToClient(new Point(e.X, e.Y));
            //////////// Retrieve the node at the drop location.
            //////////TreeViewItem targetNode = shownTreeView.GetNodeAt(targetPoint);
            //////////// Retrieve the node that was dragged.
            //////////TreeViewItem draggedNode = (TreeViewItem)e.Data.GetData(typeof(TreeViewItem));
            ////////////TreeViewItem  dn = (TreeViewItem)sender;

            //////////// Sanity check
            //////////if (draggedNode == null)
            //////////{
            //////////    return;
            //////////}

            //////////// Did the user drop on a valid target node?
            //////////if (targetNode == null)
            //////////{
            //////////    // The user dropped the node on the treeview control instead
            //////////    // of another node so lets place the node at the bottom of the tree.
            //////////    draggedNode.Remove();
            //////////    shownTreeView.Items.Add(draggedNode);
            //////////    draggedNode.IsExpanded = true;
            //////////}
            //////////else
            //////////{
            //////////    TreeViewItem parentNode = targetNode;
            //////////    // Confirm that the node at the drop location is not 
            //////////    // the dragged node and that target node isn't null
            //////////    // (for example if you drag outside the control)
            //////////    if (!draggedNode.Equals(targetNode) && targetNode != null)
            //////////    {
            //////////        bool canDrop = true;

            //////////        // Crawl our way up from the node we dropped on to find out if
            //////////        // if the target node is our parent. 
            //////////        while (canDrop && (parentNode != null))
            //////////        {
            //////////            canDrop = !Object.ReferenceEquals(draggedNode, parentNode);
            //////////            parentNode = (TreeViewItem)parentNode.Parent;
            //////////        }

            //////////        // Is this a valid drop location?
            //////////        if (canDrop)
            //////////        {
            //////////            // Yes. Move the node, expand it, and select it.
            //////////            draggedNode.Remove();
            //////////            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            //////////            {
            //////////                // if dragged with the control key pushed, 
            //////////                // connect to the brother of the target node 
            //////////                (targetNode.Parent).Items.Insert(targetNode.Index, draggedNode);
            //////////                ((TreeViewItem)(targetNode.Parent)).IsExpanded = true;
            //////////                hasChanges = true;
            //////////            }
            //////////            else
            //////////            {
            //////////                // if dragged with no key connect to the parent 
            //////////                targetNode.Items.Add(draggedNode);
            //////////                targetNode.IsExpanded = true;
            //////////                hasChanges = true;
            //////////            }
            //////////        }
            //////////    }
            //////////}
            //////////if (dragSourceControlHash != draggedNode.GetHashCode())
            //////////{
            //////////    // if the control has been dropped into a different treeview control
            //////////    // delete all the Ids in the subtree that I have copied here
            //////////    // so the new subtree will be considered as new
            //////////    DeleteNodeById_Recursive(draggedNode);
            //////////}
            //////////// Optional: Select the dropped node and navigate (however you do it)
            //////////draggedNode.IsSelected = true;
            //////////// NavigateToContent(draggedNode.Tag);  
        }
        internal void shownTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            //////////// editing of nodes is now forbidden
            //////////if (e.KeyCode == Keys.F2)
            //////////{
            //////////    if ((TreeViewItem)shownTreeView.SelectedItem != null)
            //////////    {
            //////////        // start edit the selected node
            //////////        shownTreeView.LabelEdit = true;
            //////////        shownTreeView.SelectedItem.BeginEdit();
            //////////    }
            //////////    else
            //////////        MessageBox.Show("Select the node");
            //////////}
            //////////if (e.KeyCode == Keys.Insert)
            //////////{
            //////////    if (Control.ModifierKeys == Keys.Shift)
            //////////    {
            //////////        shownTreeView.SelectedItem = AddNewNode("Nuovo argomento", false);
            //////////        // start edit the selected node
            //////////        shownTreeView.LabelEdit = true;
            //////////        shownTreeView.SelectedItem.BeginEdit();
            //////////    }
            //////////    else
            //////////    {  // shift is not pressed
            //////////        shownTreeView.SelectedItem = AddNewNode("Nuovo argomento", true);
            //////////        // start edit the selected node
            //////////        shownTreeView.LabelEdit = true;
            //////////        shownTreeView.SelectedItem.BeginEdit();
            //////////    }
            //////////}
            //////////if (e.KeyCode == Keys.Delete)
            //////////{
            //////////    DeleteNodeSelected();
            //////////}
        }
        internal void shownTreeView_AfterCheck(object sender, RoutedEventArgs e)
        {
            //////////if (e.Node.IsChecked)
            //////////{
            //////////    if (txtSearchString != null)
            //////////    {
            //////////        Topic t = (Topic)((TreeViewItem)e).Tag;
            //////////        string path = dbMptt.GetNodePath(t.LeftNodeOld, t.RightNodeOld);
            //////////        string stringToAdd = GetStringOfJustSomeNodesOfPath(path);
            //////////        txtNodeDigest.Text += stringToAdd;
            //////////    }
            //////////}
        }
        internal void shownTreeView_Click(object sender, RoutedEventArgs e)
        {
            if (ClearBackColorOnClick)
                ClearBackColor();
        }
        private void TxtNodeName_Leave(object sender, RoutedEventArgs e)
        {
            if (TreeView.SelectedItem != null)
            {
                try
                {
                    Topic t = (Topic)((TreeViewItem)TreeView.SelectedItem).Tag;
                    if (txtNodeName.Text != t.Name)
                    {
                        hasChanges = true;
                        t.Changed = true;
                    }
                    t.Name = txtNodeName.Text;
                    ((TreeViewItem)TreeView.SelectedItem).Header = txtNodeName.Text;
                }
                catch (Exception ex)
                {

                }
            }
        }
        string previousText = "";
        private void TxtNodeName_TextChanged(object sender, RoutedEventArgs e)
        {
            // if the change is due to selection in the tree, don't change
            if (hasNodeBeenSelectedFromTree)
            {
                hasNodeBeenSelectedFromTree = false;
                return;
            }
            if (shownTreeView.SelectedItem == null)
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
                //if (MessageBox.Show("Testo formattato come un albero di FreeMind.\nDevo importare un sottoalbero in questo punto?",
                //    "", MessageBoxButton.YesNo, MessageBoxImage.Question,
                //    MessageBoxDefaultButton.Button1)
                //    == MessageBoxResult.Yes)
                if (MessageBox.Show("Testo formattato come un albero di FreeMind.\nDevo importare un sottoalbero in questo punto?")
                    == MessageBoxResult.Yes)
                {
                    ImportSubtreeFromText(txtNodeName.Text);
                    int positionOfTab = txtNodeName.Text.IndexOf("\r\n");
                    ((TreeViewItem)shownTreeView.SelectedItem).Header = txtNodeName.Text.Substring(0, positionOfTab);
                    ((Topic)((TreeViewItem)shownTreeView.SelectedItem).Tag).Name = txtNodeName.Text.Substring(0, positionOfTab);
                }
                else
                {
                    ((TreeViewItem)(shownTreeView.SelectedItem)).Header = txtNodeName.Text;
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
                    //Topic t = (Topic)(shownTreeView.SelectedItem.Tag);
                    //t.Name = txtNodeName.Text;
                    //t.Changed = true;
                }
            }
        }
        private void TxtNodeDescription_Leave(object sender, RoutedEventArgs e)
        {
            if (hasNodeBeenSelectedFromTree)
                return;
            Topic t = (Topic)((TreeViewItem)shownTreeView.SelectedItem).Tag;
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
        private void SearchCheckBoxes_CheckedChanged(object sender, RoutedEventArgs e)
        {
            // event fired when any of the checkboxes related to search is changed 

            // command a new search for the next search 
            ResetSearch();
            FindNodes(txtSearchString.Text);
        }
        private void chkMarkAllTopicsFound_CheckedChanged(object sender, RoutedEventArgs e)
        {
            // command a new search for the next search 
            ResetSearch();
        }
        private void chkVerbatimString_CheckedChanged(object sender, RoutedEventArgs e)
        {
            // command a new search for the next search 
            ResetSearch();
        }
        internal void AddChildrenNodesToTreeViewFromDatabase(TreeViewItem ParentNode, int Level)
        {
            GetChildren_Recursive(ParentNode, Level);
        }
        private void GetChildren_Recursive(TreeViewItem ParentNode, int Level)
        {
            // connection can come from outside to avoid opening and closing it every time 
            // if it is null, the connection must be opened locally 

            // recursively retrieve all direct children of ParentNode  
            // get childs keeping the connection open
            List<Topic> lt = dbMptt.GetNodesChildsByParent(((Topic)ParentNode.Tag), false);
            List<Topic> SortedList = lt.OrderBy(o => o.ChildNumberOld).ToList();
            foreach (Topic t in SortedList)
            {
                if (!Commons.ProcessingCanContinue()) return;
                TreeViewItem n = CreateTreeViewItem(t);
                ParentNode.Items.Add(n);
                GetChildren_Recursive(n, Level++);
            }
        }
        internal void SaveTreeFromScratch(TreeViewItem CurrentNode, List<Topic> generatedList)
        {
            // TODO !!!! the refactor of this function must be tested !!!!
            //DbConnection Connection = dl.Connect();
            int nodeCount = 1;
            // recursive function
            GenerateNewListOfNodesFromTreeViewControl_Recursive(CurrentNode,
                ref nodeCount, ref generatedList);
            bl.SaveTopicsFromScratch(generatedList);
        }
        internal void GenerateNewListOfNodesFromTreeViewControl_Recursive(TreeViewItem CurrentNode, ref int nodeCount,
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
            foreach (TreeViewItem sonNode in CurrentNode.Items)
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
        private TreeViewItem CreateTreeViewItem(Topic Node)
        {
            TreeViewItem item = new TreeViewItem();
            // Create a new StackPanel for text and checkbox 
            StackPanel stackPanel = new StackPanel();
            stackPanel.Name = "NodeUi";
            stackPanel.Orientation = Orientation.Horizontal;
            if (putCheckSignsOnNodes)
            {
                CheckBox CheckBox = new CheckBox();
                CheckBox.IsChecked = false;
                // Children[0] is the CheckBox
                stackPanel.Children.Add(CheckBox);
            }
            TextBlock TextBlock = new();
            TextBlock.Text = Node.Name;
            // Children[1] is the TextBlock
            stackPanel.Children.Add(TextBlock);
            //Debug.Print(((TextBlock)stackPanel.Children[0]).Text);
            item.Header = stackPanel;
            item.Tag = Node;
            return item;
        }
        public void ExportSubtreeToClipboard()
        {
            TreeViewItem item = (TreeViewItem)(shownTreeView.SelectedItem);
            if (item.Tag == null)
            {
                MessageBox.Show("Scegliere un argomento.\r\n" +
                    "Verranno messi in clipboard gli argomenti dell'albero sotto l'argomento scelto");
                return;
            }
            string tree = null;
            Topic InitialNode = (Topic)item.Tag;

            ExportSubtreeToText(InitialNode);

            Clipboard.SetText(tree);

            MessageBox.Show("Albero copiato nella clipboard");
        }
    }
}
