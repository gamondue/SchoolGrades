using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Xml.Linq;

namespace gamon.TreeMptt
{
    internal abstract class TreeMpttDb
    {
        // This class is the base class for all MPTT database management classes.
        // It contains the common methods and properties that are used by all the db specific classes.
        // It is independent from the normal DataLayer
        // It contains an internal DbConnection object that is used according to the follwing behaviour:
        // - if the internal connection is open, the method that uses the database will use the existing connection
        // - if the internal connection is closed, the method will create a new connection, use it and close it at the end

        // methods that have a fairly standard SQL are implementedi here, tested with SQLite.
        // Make them abstract if they are found as DBMS specific in the future implementation with SQL Server or other DBMS.

        // WARNING: document with evidence if a method will leave open the connection that ha personally opened, 
        //          or if it will close the connection even if it was not opened by itself

        // !!!! TODO ????; turn to generic this class, such that it can contain any class and not just Topic instances !!!!

        internal DbConnection localDbConnection;
        
        internal TreeMpttDb()
        {

        }
        /// <summary>
        /// Ensures that the local database connection is open, establishing it if necessary.
        /// </summary>
        /// <remarks>This method checks the state of the local database connection and opens it if it is not already open.
        /// If the connection is null, a new connection is created and opened.</remarks>
        /// <returns><see langword="true"/> if the connection was opened by this method; otherwise, <see langword="false"/>.</returns>
        // opening of a Db connection is DBMS specific, so the method is abstract,
        // implemented in the derived classes
        #region methods that manage the connection
        internal abstract bool OpenLocalConnectionIfClosed();
        // closing of a Db connection is general, so the method is not abstract
        internal void CloseLocalConnectionIfWasFoundClosed(bool WasFoundClosed = false)
        {
            if (WasFoundClosed)
            {
                localDbConnection.Close();
            }
        }
        #endregion

        #region methods that read from the database        
        internal bool AreLeftAndRightConsistent()
        {
            // reads in the db if the pointers to right and left node of all the nodes are
            // considered to be consistent 

            // the connection can be already establisched, to avoid opening and closing it every time 
            // if localDbConnection is null, the connection must be opened and closed locally 
            bool closeAtTheEnd = OpenLocalConnectionIfClosed();
            DbCommand cmd = localDbConnection.CreateCommand();
            try
            {
                cmd.CommandText = "SELECT areLeftRightConsistent" +
                    " FROM Flags";
                int consistent = Convert.ToInt32(cmd.ExecuteScalar());
                CloseLocalConnectionIfWasFoundClosed();
                //cmd.Dispose();
                return consistent != 0;
            }
            catch (Exception e)
            {
                if (cmd != null)
                    cmd.Dispose();
                // code for compatibility with past versions. Today could be removed
                // if the table "Flags" doesn't exist (old version of database) 
                // return true (those versions where working only with MPTT tree)
                if (e.Message.Contains("no such"))
                {
                    CloseLocalConnectionIfWasFoundClosed(closeAtTheEnd);
                    return true;
                }
                else
                    throw e;
            }
        }
        internal void SaveLeftRightConsistency(bool IsConsistent)
        {
            OpenLocalConnectionIfClosed();
            // SQL operation serial
            DbCommand cmd = localDbConnection.CreateCommand();
            cmd.CommandText = "UPDATE Flags" +
                " SET areLeftRightConsistent=" + IsConsistent.ToString();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
        }
        internal List<Topic> GetNodesRoots(bool CloseConnectionEnding)
        {
            OpenLocalConnectionIfClosed();
            // finds all the nodes that don't have a parent
            // so you can fit the Treeview of a Win Form program, that is multiroot
            // this program treats only one root because with MPTT having more than one root 
            // would complicate the database 
            List<Topic> lt = new List<Topic>();

            DbCommand cmd = localDbConnection.CreateCommand();
            string query = "SELECT *" +
                " FROM Topics" +
                " WHERE parentNode<=0" +
                " ORDER BY childNumber;";
            cmd = new SqliteCommand(query);
            cmd.Connection = localDbConnection;
            DbDataReader dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                Topic t = GetTopicFromRow(dRead);
                lt.Add(t);
            }
            dRead.Dispose();
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
            return lt;
        }
        internal List<Topic> GetNodesChildsByParent(Topic ParentNode, bool CloseConnectionWhenEnding)
        {
            OpenLocalConnectionIfClosed();
            List<Topic> lt = new List<Topic>();
            DbCommand cmd = localDbConnection.CreateCommand();
            string query = "SELECT *" +
                " FROM Topics" +
                " WHERE parentNode=" + ParentNode.Id +
                " ORDER BY childNumber";
            cmd = new SqliteCommand(query);
            cmd.Connection = localDbConnection;
            DbDataReader dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                Topic t = GetTopicFromRow(dRead);
                lt.Add(t);
            }
            dRead.Dispose();
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
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
            OpenLocalConnectionIfClosed();
            DbCommand cmd = localDbConnection.CreateCommand();
            string query = "SELECT *" +
                " FROM Topics" +
                " WHERE leftNode <=" + LeftNode +
                " AND rightNode >=" + RightNode +
                " ORDER BY LeftNode ASC;)";
            cmd = new SqliteCommand(query);
            cmd.Connection = localDbConnection;
            DbDataReader dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                Topic t = GetTopicFromRow(dRead);
                l.Add(t);
            }
            dRead.Dispose();
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
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
            OpenLocalConnectionIfClosed();
            DbDataReader dRead;
            DbCommand cmd = localDbConnection.CreateCommand();
            cmd.CommandText = "SELECT leftNode, rightNode FROM Topics" +
                " WHERE idTopic=" + idTopic + ";";
            dRead = cmd.ExecuteReader();
            dRead.Read();
            t = GetNodePath((int)dRead["leftNode"], (int)dRead["rightNode"]);

            dRead.Dispose();
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
            return t;
        }
        internal List<Topic> GetNodesByMpttFromDatabase(int? LeftNode, int? RightNode)
        {
            // node numbering according to Modified Preorder Tree Traversal algorithm
            // ("descending" phase)
            List<Topic> l = new List<Topic>();
            OpenLocalConnectionIfClosed();
            DbCommand cmd = localDbConnection.CreateCommand();
            string query = "SELECT *" +
                " FROM Topics" +
                " WHERE leftNode BETWEEN " + LeftNode +
                " AND " + RightNode +
                " ORDER BY leftNode ASC;";
            cmd = new SqliteCommand(query);
            cmd.Connection = localDbConnection;
            DbDataReader dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                Topic t = GetTopicFromRow(dRead);
                l.Add(t);
            }
            dRead.Dispose();
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
            return l;
        }
        internal List<Topic> GetNodesByParentFromDatabase()
        {
            // node order according to siblings' order (parentNode and childNumber)
            List<Topic> l = new List<Topic>();
            OpenLocalConnectionIfClosed();
            DbCommand cmd = localDbConnection.CreateCommand();
            string query = "SELECT *" +
                " FROM Topics" +
                " ORDER BY parentNode ASC, childNumber ASC;";
            cmd = new SqliteCommand(query);
            cmd.Connection = localDbConnection;
            DbDataReader dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                Topic t = GetTopicFromRow(dRead);
                l.Add(t);
            }
            dRead.Dispose();
            cmd.Dispose();
            return l;
        }
        internal List<Topic> FindNodesLike(string SearchText, bool SearchInDescriptions,
            bool SearchWholeWord, bool SearchCaseInsensitive, bool SearchVerbatimString)
        {
            List<Topic> found = new List<Topic>();
            OpenLocalConnectionIfClosed();
            DbDataReader dRead;
            DbCommand cmd = localDbConnection.CreateCommand();
            string query;
            if (SearchCaseInsensitive)
                query = "PRAGMA case_sensitive_like=OFF;";
            else
                query = "PRAGMA case_sensitive_like=ON;";
            if (!SearchInDescriptions)
                query += "SELECT * FROM Topics" +
                    " WHERE " + SqlLikeStatementWithOptions("name", SearchText, SearchWholeWord, SearchVerbatimString);
            else
                query += "SELECT * FROM Topics" +
                    " WHERE " + SqlLikeStatementWithOptions("name", SearchText, SearchWholeWord, SearchVerbatimString) +
                    " OR " + SqlLikeStatementWithOptions("desc", SearchText, SearchWholeWord, SearchVerbatimString);
            query += " ORDER BY leftNode ASC;";
            cmd.CommandText += query;
            dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                Topic t = GetTopicFromRow(dRead);
                found.Add(t);
            }
            dRead.Dispose();
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
            return found;
        }
        internal bool TopicExists(int? topicId)
        {
            OpenLocalConnectionIfClosed();
            DbCommand cmd = localDbConnection.CreateCommand();
            cmd.CommandText = "SELECT  1 idTopic" +
                " FROM Topics" +
                " WHERE idTopic='" + topicId.ToString() + "'" +
                ";";
            var result = cmd.ExecuteScalar();
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
            return (result != null);
        }
        #endregion

        #region methods that write to the database
        internal void SaveTreeToDb(List<Topic> ListTopicsAfter, List<Topic> ListTopicsDeleted,
                bool MustSaveLeftAndRight, bool CloseWhenEnding)
        {
            OpenLocalConnectionIfClosed();
            SaveLeftRightConsistency(false);
            DbCommand cmd = localDbConnection.CreateCommand();
            if (ListTopicsDeleted != null && ListTopicsDeleted.Count > 0)
            {
                foreach (Topic t in ListTopicsDeleted)
                {
                    // if the saving must finish and the task saving in background, we quit the function 
                    if (!Commons.MethodCanContinue())
                        return;
                    cmd.CommandText = "DELETE FROM Topics" +
                            " WHERE IdTopic =" + t.Id +
                            ";";
                    cmd.ExecuteNonQuery();
                }
            }
            foreach (Topic t in ListTopicsAfter)
            {
                // if the saving must finish and the task saving in background, we quit the function 
                if (!Commons.BackgroundTaskCanSave && MustSaveLeftAndRight)
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
                    || (MustSaveLeftAndRight &&
                        (t.LeftNodeNew != t.LeftNodeOld || t.RightNodeNew != t.RightNodeOld))
                    )
                {
                    if (t.Id != null && t.Id > 1)
                    {
                        UpdateTopic(t);
                    }
                    else
                    {
                        InsertTopic(t);
                    }
                }
            }
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
        }
        internal void AddTopic(Topic newTopic)
        {
            OpenLocalConnectionIfClosed();
            DbCommand cmd = localDbConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO Topics" +
                " (Id,Name,Date)" +
                " Values (" +
                SqlString(newTopic.Id.ToString()) +
                "," + SqlString(newTopic.Name) + "" +
                "," + SqlString(newTopic.Date.ToString()) + "" +
                ");";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
        }
        internal void SaveLeftAndRightToDbMptt()
        {
            // read the first topic of the tree
            // in this program this list should have just one element 
            List<Topic> firstNodes = GetNodesRoots(false);
            // traverse the tree in list from database, numbering according to Modified Preorder Tree Traversal algorithm
            // if the numbers of right or left nodes are different from those written in the database, then update the database

            // recursive call that does all: 
            int nodeCount = 0;
            // recursive function starts from just one root node
            SetLeftAndRightInOneLevel(firstNodes[0], ref nodeCount);
            // since the initial node has not been read from the database, 
            // then we save left and right anyway 
            UdpateMpttNodeLeftAndRight(firstNodes[0].Id, 0, nodeCount);
            // at the end of saving, restore the status of the "consistent" flag
            SaveLeftRightConsistency(true);
        }
        private void SetLeftAndRightInOneLevel(Topic ParentNode, ref int NodeCount)
        {
            // if it is requested externally by setting BackgroundSavingEnabled to false, 
            // abort tree update by exiting the method 
            if (!Commons.BackgroundTaskCanSave)
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
            List<Topic> listChilds = GetNodesChildsByParent(ParentNode, false);
            foreach (Topic sonNode in listChilds)  // list Childs are taken from the database 
            {
                if (!Commons.BackgroundTaskCanSave)
                    return;
                // recurse the function for every son node
                // calls passing the updated count 
                SetLeftAndRightInOneLevel(sonNode, ref NodeCount);
            }
            // If brothers are finished, updates if it is necessary and returns 
            // ParentNode was taken from the database, NodeCount has been calculated here 
            if (isLeftDifferent || ParentNode.RightNodeNew != NodeCount++)
                UdpateMpttNodeLeftAndRight(ParentNode.Id, NewLeft, NodeCount - 1); // those found different are saved
        }
        /// <summary>
        /// Updates the left and right values of nodes in the database using the Modified Preorder Tree Traversal (MPTT)
        /// algorithm.
        /// </summary>
        /// <remarks>This method processes the tree structure stored in the database, starting from the root node, and
        /// assigns left and right values to each node according to the MPTT algorithm. If the left or  right values in the
        /// database differ from the calculated values, the database is updated to ensure consistency.</remarks>
        internal void SaveNodesFromScratch(List<Topic> ListTopics)
        {
            OpenLocalConnectionIfClosed();
            DbCommand cmd = localDbConnection.CreateCommand();
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
                        "," + SqlString(t.Name) + "" +
                        "," + SqlString(t.Desc) + "" +
                        "," + t.ParentNodeNew + "" +
                        "," + t.LeftNodeNew + "" +
                        "," + t.RightNodeNew + "" +
                        "," + t.ParentNodeNew + "" +
                        ");";
                    cmd.ExecuteNonQuery();
                }
                CloseLocalConnectionIfWasFoundClosed();
            }
            cmd.Dispose();
        }
        //internal override void CloseDbConnection(bool Close)
        //{
        //    if (localDbConnection != null && !(localDbConnection.State == System.Data.ConnectionState.Closed) && Close)
        //    {
        //        localDbConnection.Close();
        //        localDbConnection.Dispose();
        //    }
        //}
        internal void CreateTableTreeMpttDb()
        {
            try
            {
                OpenLocalConnectionIfClosed();
                DbCommand cmd = localDbConnection.CreateCommand();
                // Topics table creation
                cmd.CommandText = @"CREATE TABLE Topics (
	                idTopic	INT NOT NULL,
	                name	VARCHAR(20) NOT NULL,
	                descr	VARCHAR(255),
	                leftNode	INT,
	                rightNode	INT,
	                parentNode	INT,
	                childNumber	INT,
	                PRIMARY KEY(idTopic)
                );";
                cmd.ExecuteNonQuery();
                CloseLocalConnectionIfWasFoundClosed();
            }
            catch (Exception ex)
            {


            }
        }
        //internal abstract void CloseDbConnection(bool Close);
        // this is fairly independent of the DBMS, so it implemented here (to check with SQL server!)
        internal void UdpateMpttNodeLeftAndRight(int? IdTopic, int? LeftNode, int? RightNode)
        {
            // updates only left & right; the rest of the record remains the same
            OpenLocalConnectionIfClosed();
            DbCommand cmd = localDbConnection.CreateCommand();
            cmd.CommandText = "UPDATE Topics" +
                " SET" +
                " leftNode=" + LeftNode +
                ",rightNode=" + RightNode +
                " WHERE idTopic=" + IdTopic +
                ";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
        }
        #endregion

        #region methods copied from DataLayer, to avoid the dependancy of this class to DataLayer
        // WARNING: the next methods are copied from DataLayer, to avoid the dependancy of this class to DataLayer
        // keep it updated with the DataLayer methods of the same name
        private Topic GetTopicFromRow(DbDataReader dRead)
        {
            Topic t = new Topic();
            t.Id = Safe.Int(dRead["IdTopic"]);
            t.Name = Safe.String(dRead["name"]);
            t.Desc = Safe.String(dRead["desc"]);
            t.LeftNodeOld = Safe.Int(dRead["leftNode"]);
            t.LeftNodeNew = -1;
            t.RightNodeOld = Safe.Int(dRead["rightNode"]);
            t.RightNodeNew = -1;
            t.ParentNodeOld = Safe.Int(dRead["parentNode"]);
            t.ParentNodeNew = -1;
            t.ChildNumberOld = Safe.Int(dRead["childNumber"]);
            t.ChildNumberNew = -1;
            t.Changed = false;
            return t;
        }
        internal int CreateNewTopic(Topic NewTopic)
        {
            int nextId = -1;
            OpenLocalConnectionIfClosed();
            DbCommand cmd = localDbConnection.CreateCommand();
            cmd.CommandText = "SELECT MAX(IdTopic) FROM Topics;";
            var temp = cmd.ExecuteScalar();
            if (!(temp is DBNull))
                nextId = Convert.ToInt32(temp) + 1;
            // aggiunge la foto alle foto (cartella relativa, cui verrà aggiunta la path delle foto)
            cmd.CommandText = "INSERT INTO Topics " +
                "(idTopic,name,desc,leftNode,rightNode,parentNode,childNumber)" +
                "Values " +
                "(" + nextId.ToString() + "," + SqlString(NewTopic.Name) + "," +
                    SqlString(NewTopic.Desc) + "," + SqlInt(NewTopic.LeftNodeNew.ToString()) + "," +
                    SqlInt(NewTopic.RightNodeNew.ToString()) + "," + SqlInt(NewTopic.ParentNodeNew.ToString()) +
                "," + SqlInt(NewTopic.ChildNumberNew.ToString()) +
                ");";
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
            return nextId;
        }
        internal void UpdateTopic(Topic t)
        {
            try
            {
                OpenLocalConnectionIfClosed();
                DbCommand cmd = localDbConnection.CreateCommand();
                cmd.CommandText = "UPDATE Topics" +
                    " SET" +
                    " name=" + SqlString(t.Name) + "" +
                    ",desc=" + SqlString(t.Desc) + "" +
                    ",parentNode=" + t.ParentNodeNew +
                    ",leftNode=" + t.LeftNodeNew +
                    ",rightNode=" + t.RightNodeNew +
                    ",childNumber=" + t.ChildNumberNew +
                    " WHERE idTopic=" + t.Id +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                CloseLocalConnectionIfWasFoundClosed();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        internal void InsertTopic(Topic t)
        {
            try
            {
                if (t.Id == null || t.Id == 0)
                {
                    OpenLocalConnectionIfClosed();
                    DbCommand cmd = localDbConnection.CreateCommand();
                    cmd.CommandText = "SELECT MAX(IdTopic) FROM Topics;";
                    var temp = cmd.ExecuteScalar();
                    if (!(temp is DBNull))
                        t.Id = Convert.ToInt32(temp) + 1;
                    cmd.CommandText = "INSERT INTO Topics" +
                        " (idTopic,name,desc,leftNode,rightNode,parentNode,childNumber)" +
                        " Values (" +
                        t.Id.ToString() +
                        "," + SqlString(t.Name) + "" +
                        "," + SqlString(t.Desc) + "" +
                        "," + t.LeftNodeNew + "" +
                        "," + t.RightNodeNew + "" +
                        "," + t.ParentNodeNew + "" +
                        "," + t.ChildNumberNew + "" +
                        ");";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    CloseLocalConnectionIfWasFoundClosed();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region methods copied from DataLayer that require refactoring in DataLayer to take them out of there
        // these methods have been copied here but could stay out of DataLayer
        internal string SqlLikeStatementWithOptions(string FieldName, string SearchText,
                bool SearchWholeWord = false, bool SearchVerbatimString = false)
        {
            if (SearchText == null) return "null";
            SearchText = SearchText.Replace("'", "''");
            string statement;

            if (SearchVerbatimString)
            {
                statement = FieldName + "='" + SearchText + "'";
                return statement;
            }
            if (SearchWholeWord)
            {   // search words separated by " " with all the possibilities
                statement = FieldName + " LIKE '" + SearchText + " %'"; // word at the beginning 
                statement += " OR " + FieldName + " LIKE '% " + SearchText + "'"; // word at the end 
                statement += " OR " + FieldName + " LIKE '% " + SearchText + " %'"; // word in the middle 
                statement += " OR " + FieldName + " = '" + SearchText + "'"; // word as the whole string 
            }
            else
                // search with any substring also in the middle of the "word" searched  
                statement = FieldName + " LIKE '%" + SearchText + "%'";
            return statement;
        }
        internal string SqlString(string String)
        {
            if (String == null) return "null";
            string temp;
            if (!(String == null))
            {
                temp = String;
                temp = temp.Replace("'", "''");
            }
            else
                temp = "";
            temp = "'" + temp + "'";
            return temp;
        }
        internal string SqlString(string String, int MaxLenght)
        {
            if (String == null) return "null";
            string temp;
            if (!(String == null))
            {
                temp = String;

                temp = temp.Replace("'", "''");
            }
            else
                temp = "";
            if (MaxLenght > 0 && temp.Length > MaxLenght)
                temp = temp.Substring(0, MaxLenght);
            temp = "'" + temp + "'";
            return temp;
        }
        internal string SqlInt(string Number)
        {
            try
            {
                if (Number != null)
                    return int.Parse(Number).ToString();
                else
                    return "null";
            }
            catch
            {
                return "null";
            }
        }
        internal string SqlInt(int? Number)
        {
            if (Number == null) return "null";
            try
            {
                return Number.ToString();
            }
            catch
            {
                return "null";
            }
        }
        #endregion
    }
}
