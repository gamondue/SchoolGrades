using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using SchoolGrades;
using SchoolGrades.DbClasses;
using SharedWinForms;

namespace gamon.TreeMptt
{
    internal class TreeMpttDb
    {
        DbAndBusiness db;
        DataLayer dl; 

        string dbName = Commons.PathAndFileDatabase;

        public TreeMpttDb(DbAndBusiness DatabaseAndBusinessLayer)
        { 
            db = DatabaseAndBusinessLayer;
            dl = new DataLayer(DatabaseAndBusinessLayer.DatabaseName);
        }
        // TODO: finish to encapsulate in this class all the code to access the DBMS with TreeMptt

        internal void SaveTreeToDb(List<Topic> ListTopicsAfter, List<Topic> ListTopicsDeleted,
            bool MustSaveLeftAndRight)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();

                SaveLeftRightConsistent(false);

                if (ListTopicsDeleted != null)
                {
                    foreach (Topic t in ListTopicsDeleted)
                    {
                        cmd.CommandText = "DELETE FROM Topics" +
                                " WHERE IdTopic =" + t.Id +
                                ";";
                        cmd.ExecuteNonQuery();
                        if (!CommonsWinForms.BackgroundCanStillSaveTopicsTree)
                            return;
                    }
                }
                foreach (Topic t in ListTopicsAfter)
                {
                    // this cures a behaviour of the program, not proper functioning on root node's parent node
                    if (t.ParentNodeNew < 0)
                        t.ParentNodeNew = 0;
                    bool changed;
                    if (t.Changed == null)
                        changed = false;
                    else
                        changed = (bool)t.Changed; 
                    // update modified nodes 
                    if (changed
                        || t.ParentNodeNew != t.ParentNodeOld || t.ChildNumberNew != t.ChildNumberOld
                        || MustSaveLeftAndRight &&
                            (t.LeftNodeNew != t.LeftNodeOld || t.RightNodeNew != t.RightNodeOld)
                        )
                    {
                        if (t.Id != null && t.Id > 1)
                        {
                            db.UpdateTopic(t, conn);
                        }
                        else
                        {
                            db.InsertTopic(t, conn);
                        }
                    }
                    if (!CommonsWinForms.BackgroundCanStillSaveTopicsTree)
                        break;
                }
                cmd.Dispose();
            }
            // Left-Right status left on "inconsistent" if we were NOT saving leftNode and rightNode
            // or if we quit this method breaking the loops. 
            if (MustSaveLeftAndRight && CommonsWinForms.BackgroundCanStillSaveTopicsTree)
                SaveLeftRightConsistent(true); 
        }
        internal void SaveLeftRightConsistent(bool SetConsistent)
        {
            // SQL operation serial
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Flags" +
                    " SET areLeftRightConsistent=" + SetConsistent.ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal bool AreLeftAndRightConsistent()
        {
            using (DbConnection conn = dl.Connect())
            {
                try
                {
                    DbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT areLeftRightConsistent" +
                        " FROM Flags";
                    int consistent = (int)cmd.ExecuteScalar();
                    cmd.Dispose();
                    return consistent != 0;
                }
                catch (Exception e)
                {
                    // if the table "Flags" doesn't exist (old version of database) 
                    // return true (those versions where working only with MPTT tree)
                    if (e.Message.Contains("no such"))
                        return true;
                    else
                        throw e;
                }
            }
        }
        internal List<Topic> GetTopicsMpttFromDatabase(int? LeftNode, int? RightNode)
        {
            // node numbering according to Modified Preorder Tree Traversal algorithm
            // ("descending" phase)
            List<Topic> l = new List<Topic>();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " WHERE leftNode BETWEEN " + LeftNode +
                    " AND " + RightNode +
                    " ORDER BY leftNode ASC;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = db.GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal List<Topic> GetTopicsByParent()
        {
            // node order according to siblings' order (parentNode and childNumber)
            List<Topic> l = new List<Topic>();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " ORDER BY parentNode ASC, childNumber ASC;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = db.GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal void SaveLeftAndRightToDbMptt()
        {
            // read the first topic of the tree
            // in this program this list should have just one element 
            List<Topic> firstNodes = GetTopicsRoots();
            // traverse the tree in list from database, numbering according to Modified Preorder Tree Traversal algorithm
            // if the numbers of right or left nodes are different from those written in the database, then update the database

            // recursive call that does all: 
            int nodeCount = 0;
            // recursive function starts from just one root node
            SetRightAndLeftInOneLevel(firstNodes[0], ref nodeCount); 
            // since the initial node has not been read from the database, 
            // then we save left and right anyway 
            UdpateTopicMptt(firstNodes[0].Id, 0, nodeCount);
            // restore status of "consistent" flag
           SaveLeftRightConsistent(true);
        }
        private void SetRightAndLeftInOneLevel(Topic ParentNode, ref int NodeCount)
        {
            // if requested externally by setting BackgroundCanStillSaveTopicsTree to false, 
            // abort tree update by exiting method 
            if (!CommonsWinForms.BackgroundCanStillSaveTopicsTree)
                return; 
            // visits all the childrens of CurrentNode in the Treeview. 
            // with the Modified Tree Traversal algorithm 
            // calculates Right and Left node and update the database in case they are different
            // ParentNode was taken from the database, NodeCount has been calculated here 
            bool isLeftDifferent = false;
            int NewLeft = 0; 
            if (ParentNode.LeftNodeNew != NodeCount++)
            {
                isLeftDifferent = true;
                NewLeft = NodeCount - 1; 
            }
            // find all son nodes of current node (list is ordered by childNumber) 
            // takes from the database, which could be unmodified 
            // !!!! TODO: keep the connection open !!!!
            List<Topic> listChilds = GetTopicChildsByParent(ParentNode, null); 
            foreach (Topic sonNode in listChilds)  // list Childs are taken from the database 
            {
                // recurse the function for every son node
                // calls passing the updated count 
                SetRightAndLeftInOneLevel(sonNode, ref NodeCount);
            }
            // If brothers are finished, updates if it is necessary and returns 
            // ParentNode was taken from the database, NodeCount has been calculated here 
            if (isLeftDifferent || ParentNode.RightNodeNew != NodeCount++)
                // !!!! TODO: keep the connection open !!!!
                UdpateTopicMptt(ParentNode.Id, NewLeft, NodeCount - 1); // those found different are saved
        }
        internal void UdpateTopicMptt(int? IdTopic, int? LeftNode, int? RightNode)
        {
            // !!!! TODO: keep the connection open !!!!
            // updates only left & right; the rest of the record remains the same
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Topics" +
                    " SET" +
                    " leftNode=" + LeftNode +
                    ",rightNode=" + RightNode +
                    " WHERE idTopic=" + IdTopic +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal List<Topic> GetTopicsRoots()
        {
            // finds all the nodes that don't have a parent
            // so you can fit the Treeview of a Win Form program, that is multiroot
            // this program treats only one root because with MPTT having more than one root 
            // would complicate the database 
            List<Topic> lt = new List<Topic>();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " WHERE parentNode<=0" +
                    " ORDER BY childNumber;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    Topic t = db.GetTopicFromRow(dRead);
                    lt.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return lt;
        }
        internal void AddChildrenNodesToTreeViewFromDatabase(TreeNode ParentNode, int Level)
        {
            DbConnection Connection = dl.Connect();
            GetAllChildren(ParentNode, Level, Connection);
            Connection.Close();
            Connection.Dispose();
            //if (!Commons.BackgroundCanStillSaveTopicsTree)
            //    return; 
        }
        internal void GenerateNewListOfNodesFromTreeViewControl(TreeNode CurrentNode, ref int nodeCount,
            ref List<Topic> generatedList) // the 2 ref parameters must be passed for recursion
        {
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
                ct.Id = db.CreateNewTopic(ct);
            }
            int brotherNo = 1;
            foreach (TreeNode sonNode in CurrentNode.Nodes)
            {
                // calls passing the updated count and the list under construction 
                GenerateNewListOfNodesFromTreeViewControl(sonNode, ref nodeCount, ref generatedList);
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
            List<Topic> listChilds = GetTopicChildsByParent(CurrentNode, null);
            foreach (Topic sonNode in listChilds)
            {
                // calls passing the updated count and the list under construction 
                GenerateNewListOfNodesFromDatabase(sonNode, ref nodeCount, ref generatedList);
                sonNode.ParentNodeNew = CurrentNode.Id;
                sonNode.ChildNumberNew = brotherNo++;
            }
            // If brothers are finished saves data of itself and returns.
            // right node management
            CurrentNode.RightNodeNew = nodeCount++;
        }
        private void GetAllChildren(TreeNode ParentNode, int Level, DbConnection Connection)
        {
            // recursively retrieve all direct children of ParentNode  
            List<Topic> lt = GetTopicChildsByParent(((Topic)ParentNode.Tag), Connection);
            List<Topic> SortedList = lt.OrderBy(o => o.ChildNumberOld).ToList();
            foreach (Topic t in SortedList)
            {
                TreeNode n = new TreeNode(t.Name);
                n.Tag = t;
                n.Text = t.Name;
                ParentNode.Nodes.Add(n);
                GetAllChildren(n, Level++, Connection);
                if (!CommonsWinForms.BackgroundCanStillSaveTopicsTree)
                    return;
            }
        }
        internal List<Topic> GetTopicChildsByParent(Topic ParentTopic, DbConnection Connection)
        {
            bool locallyOpened = false;
            if (Connection == null)
            {
                locallyOpened = true;
                Connection = dl.Connect();
            }
            List<Topic> lt = new List<Topic>();
            DbCommand cmd = Connection.CreateCommand();
            string query = "SELECT *" +
                " FROM Topics" +
                " WHERE parentNode=" + ParentTopic.Id + 
                " ORDER BY childNumber";
            cmd = new SQLiteCommand(query);
            cmd.Connection = Connection;
            DbDataReader dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                Topic t = db.GetTopicFromRow(dRead);
                lt.Add(t);
            }
            dRead.Dispose();
            cmd.Dispose();
            if (locallyOpened)
            {
                Connection.Close();
            }
            return lt;
        }
        internal List<Topic> GetTopicAncestors(int? LeftNode, int? RightNode)
        {
            if (LeftNode == null || RightNode == null)
            {
                Console.Beep();
                return null;
            }
            List<Topic> l = new List<Topic>();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " WHERE leftNode <=" + LeftNode +
                    " AND rightNode >=" + RightNode +
                    " ORDER BY LeftNode ASC;)";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = db.GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal string GetTopicPath(int? LeftNode, int? RightNode)
        {
            // node numbering according to Modified Preorder Tree Traversal algorithm
            List<Topic> l = GetTopicAncestors(LeftNode, RightNode);
            string path = "";
            for (int i = 0; i < l.Count; i++)
            {
                path += l[i].Name + "|";
            }
            return path;
        }
        internal string GetTopicPath(int? idTopic)
        {
            string t;
            if (idTopic == 0)
                return null;
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT leftNode, rightNode FROM Topics" +
                    " WHERE idTopic=" + idTopic + ";";
                dRead = cmd.ExecuteReader();
                dRead.Read();
                t = GetTopicPath((int)dRead["leftNode"], (int)dRead["rightNode"]);

                dRead.Dispose();
                cmd.Dispose();
            }
            return t;
        }
        internal List<Topic> FindTopicsLike(string SearchText)
        {
            List<Topic> found = new List<Topic>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Topics" +
                    " WHERE name LIKE '%" + SearchText + "%';";
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = db.GetTopicFromRow(dRead);
                    found.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return found;
        }
        //internal static string CreateTextTreeOfDescendants (int LeftNode, int RightNode, 
        //    bool IncludeTopicsIds, bool SelectedTopicsOnly // !!!! TODO: expand to manage creation of text tree with only the selected nodes
    }
}
