using SchoolGrades;
using SchoolGrades.BusinessObjects;
using SharedWinForms;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace gamon.TreeMptt
{
    internal class TreeMpttDb
    {
        DataLayer dl;
        // !!!! TODO; turn to generic this tree, such that it can contain any class and not just Topic instances !!!!
        public TreeMpttDb(DataLayer DataAccessLayer)
        {
            dl = DataAccessLayer;
        }
        internal void SaveTreeToDb(List<Topic> ListTopicsAfter, List<Topic> ListTopicsDeleted,
            bool MustSaveLeftAndRight, DbConnection Connection)
        {
            // connection can come from outside to avoid opening and closing it every time 
            // if Connection is null, the connection must be opened and closed locally 
            bool locallyOpened = false;
            if (Connection == null)
            {
                locallyOpened = true;
                Connection = dl.Connect();
            }
            DbCommand cmd = Connection.CreateCommand();

            SaveLeftRightConsistent(false, Connection);

            if (ListTopicsDeleted != null)
            {
                foreach (Topic t in ListTopicsDeleted)
                {
                    // if the saving must finish and the task saving in background, we quit the function 
                    if (Commons.ProcessingCanContinue()) return;
                    cmd.CommandText = "DELETE FROM Topics" +
                            " WHERE IdTopic =" + t.Id +
                            ";";
                    cmd.ExecuteNonQuery();
                }
            }
            foreach (Topic t in ListTopicsAfter)
            {
                if (!Commons.ProcessingCanContinue()) return;

                // if the saving must finish and the task saving in background, we quit the function 
                if (!CommonsWinForms.BackgroundSavingEnabled && MustSaveLeftAndRight)
                    return;
                // this cures a behaviour of the program,
                // not proper functioning on root node's parent node
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
                        dl.UpdateTopic(t, Connection);
                    }
                    else
                    {
                        dl.InsertTopic(t, Connection);
                    }
                }
            }
            cmd.Dispose();
            if (locallyOpened)
            {
                Connection.Close();
            }
        }
        internal void SaveLeftRightConsistent(bool IsConsistent, DbConnection Connection)
        {
            // connection can come from outside to avoid opening and closing it every time 
            // if Connection is null, the connection must be opened and closed locally 
            bool locallyOpened = false;
            if (Connection == null)
            {
                locallyOpened = true;
                Connection = dl.Connect();
            }
            // SQL operation serial
            DbCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "UPDATE Flags" +
                " SET areLeftRightConsistent=" + IsConsistent.ToString();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (locallyOpened)
            {
                Connection.Close();
            }
        }
        internal bool AreLeftAndRightConsistent()
        {
            // reads in the db if the pointers to right and left node of all the nodes are
            // considered to be consistent 
            // the connection must be explicitly passed from the outside, to speed up the program 
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = null;
                try
                {
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT areLeftRightConsistent" +
                        " FROM Flags";
                    int consistent = (int)cmd.ExecuteScalar();
                    cmd.Dispose();
                    return consistent != 0;
                }
                catch (Exception e)
                {
                    if (cmd != null)
                        cmd.Dispose();
                    // if the table "Flags" doesn't exist (old version of database) 
                    // return true (those versions where working only with MPTT tree)
                    if (e.Message.Contains("no such"))
                        return true;
                    else
                        throw e;
                }
            }
        }
        internal List<Topic> GetNodesMpttFromDatabase(int? LeftNode, int? RightNode)
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
                    Topic t = dl.GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal List<Topic> GetNodesByParent()
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
                    Topic t = dl.GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal void SaveLeftAndRightToDbMptt()
        {
            DbConnection Connection = dl.Connect();
            // read the first topic of the tree
            // in this program this list should have just one element 
            List<Topic> firstNodes = GetNodesRoots(null);
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
            SaveLeftRightConsistent(true, Connection);
        }
        private void SetRightAndLeftInOneLevel(Topic ParentNode, ref int NodeCount)
        {
            // if it is requested externally by setting BackgroundSavingEnabled to false, 
            // abort tree update by exiting the method 
            if (!Commons.ProcessingCanContinue()) return;
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
            List<Topic> listChilds = GetNodesChildsByParent(ParentNode, null);
            foreach (Topic sonNode in listChilds)  // list Childs are taken from the database 
            {
                if (!Commons.ProcessingCanContinue()) return;
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
        internal List<Topic> GetNodesRoots(DbConnection Connection)
        {
            // connection can come from outside to avoid opening and closing it every time 
            // if Connection is null, the connection must be opened and closed locally 
            bool locallyOpened = false;
            if (Connection == null)
            {
                locallyOpened = true;
                Connection = dl.Connect();
            }
            // finds all the nodes that don't have a parent
            // so you can fit the Treeview of a Win Form program, that is multiroot
            // this program treats only one root because with MPTT having more than one root 
            // would complicate the database 
            List<Topic> lt = new List<Topic>();

            DbCommand cmd = Connection.CreateCommand();
            string query = "SELECT *" +
                " FROM Topics" +
                " WHERE parentNode<=0" +
                " ORDER BY childNumber;";
            cmd = new SQLiteCommand(query);
            cmd.Connection = Connection;
            DbDataReader dRead = cmd.ExecuteReader();

            while (dRead.Read())
            {
                Topic t = dl.GetTopicFromRow(dRead);
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
        internal void AddChildrenNodesToTreeViewFromDatabase(TreeNode ParentNode, int Level, DbConnection Connection)
        {
            GetChildren_Recursive(ParentNode, Level, Connection);
        }
        internal void GenerateNewListOfNodesFromTreeViewControl_Recursive(TreeNode CurrentNode, ref int nodeCount,
            ref List<Topic> generatedList, DbConnection Connection) // the 2 ref parameters must be passed for recursion
        {
            if (!CommonsWinForms.BackgroundSavingEnabled && CommonsWinForms.BackgroundTaskIsSaving) return;
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
                ct.Id = dl.CreateNewTopic(ct);
            }
            int brotherNo = 1;
            foreach (TreeNode sonNode in CurrentNode.Nodes)
            {
                if (!Commons.ProcessingCanContinue()) return;
                // calls passing the updated count and the list under construction 
                GenerateNewListOfNodesFromTreeViewControl_Recursive(sonNode,
                    ref nodeCount, ref generatedList, Connection);
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
            List<Topic> listChilds = GetNodesChildsByParent(CurrentNode, null);
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
        internal void SaveTreeFromScratch(TreeNode CurrentNode, List<Topic> generatedList)
        {
            // TODO !!!! the refactor of this function must be tested !!!!
            DbConnection Connection = dl.Connect();
            int nodeCount = 1;
            // recursive function
            GenerateNewListOfNodesFromTreeViewControl_Recursive(CurrentNode,
                ref nodeCount, ref generatedList, Connection);
            dl.SaveTopicsFromScratch(generatedList);
        }
        private void GetChildren_Recursive(TreeNode ParentNode, int Level, DbConnection Connection)
        {
            // connection can come from outside to avoid opening and closing it every time 
            // if it is null, the connection must be opened locally 

            // recursively retrieve all direct children of ParentNode  
            List<Topic> lt = GetNodesChildsByParent(((Topic)ParentNode.Tag), Connection);
            List<Topic> SortedList = lt.OrderBy(o => o.ChildNumberOld).ToList();
            foreach (Topic t in SortedList)
            {
                if (!Commons.ProcessingCanContinue()) return;
                TreeNode n = new TreeNode(t.Name);
                n.Tag = t;
                n.Text = t.Name;
                ParentNode.Nodes.Add(n);
                GetChildren_Recursive(n, Level++, Connection);
            }
        }
        internal List<Topic> GetNodesChildsByParent(Topic ParentNode, DbConnection Connection = null)
        {
            // connection can come from outside to avoid opening and closing it every time 
            // if Connection is null, the connection must be opened and closed locally 
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
                " WHERE parentNode=" + ParentNode.Id +
                " ORDER BY childNumber";
            cmd = new SQLiteCommand(query);
            cmd.Connection = Connection;
            DbDataReader dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                Topic t = dl.GetTopicFromRow(dRead);
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
        internal List<Topic> GetNodesAncestors(int? LeftNode, int? RightNode)
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
                    Topic t = dl.GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal string GetNodePath(int? LeftNode, int? RightNode)
        {
            // node numbering according to Modified Preorder Tree Traversal algorithm
            string path = "";
            try
            {
                List<Topic> l = GetNodesAncestors(LeftNode, RightNode);
                for (int i = 0; i < l.Count; i++)
                {
                    path += l[i].Name + "|";
                }
            }
            catch
            {
                return path;
            }
            return path;
        }
        internal string GetNodePath(int? idTopic)
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
                t = GetNodePath((int)dRead["leftNode"], (int)dRead["rightNode"]);

                dRead.Dispose();
                cmd.Dispose();
            }
            return t;
        }
        internal List<Topic> FindNodesLike(string SearchText, bool SearchInDescriptions,
            bool SearchWholeWord, bool SearchCaseInsensitive)
        {
            List<Topic> found = new List<Topic>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query;
                if (SearchCaseInsensitive)
                    query = "PRAGMA case_sensitive_like=OFF;";
                else
                    query = "PRAGMA case_sensitive_like=ON;";
                if (!SearchInDescriptions)
                    query += "SELECT * FROM Topics" +
                        " WHERE " + dl.SqlLikeStatementWithOptions("name", SearchText, SearchWholeWord) + ";";
                else
                    query += "SELECT * FROM Topics" +
                        " WHERE " + dl.SqlLikeStatementWithOptions("name", SearchText, SearchWholeWord) +
                        " OR " + dl.SqlLikeStatementWithOptions("desc", SearchText, SearchWholeWord);
                query += " ORDER BY leftNode ASC;";
                cmd.CommandText += query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = dl.GetTopicFromRow(dRead);
                    found.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return found;
        }
        internal void SaveNodesFromScratch(List<Topic> ListTopics)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Topics;";
                cmd.ExecuteNonQuery();
                int key;
                cmd.CommandText = "SELECT MAX(IdTopic) FROM Topics;";
                var temp = cmd.ExecuteScalar();
                if (temp is DBNull)
                    key = 0;
                else
                    key = (int)temp;
                foreach (Topic t in ListTopics)
                {   // insert new nodes
                    {
                        cmd.CommandText = "INSERT INTO Topics" +
                           " (idTopic,name,desc,parentNode,leftNode,rightNode,parentNode)" +
                           " Values (" +
                           (++key).ToString() +
                            "," + dl.SqlString(t.Name) + "" +
                            "," + dl.SqlString(t.Desc) + "" +
                            "," + t.ParentNodeNew + "" +
                            "," + t.LeftNodeNew + "" +
                            "," + t.RightNodeNew + "" +
                            "," + t.ParentNodeNew + "" +
                            ");";
                        cmd.ExecuteNonQuery();
                    }
                }
                cmd.Dispose();
            }
        }
    }
}
