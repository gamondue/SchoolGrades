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

        // WARNING: document with evidence if a method will leave open the connection that has personally opened, 
        //          or if it will close the connection even if it was not opened by itself

        // !!!! TODO ????; turn to generic this class, such that it can contain any class and not just Topic instances !!!!

        internal DbConnection localDbConnection;
        protected string fullNameOfDatabase;

        internal TreeMpttDb(string FullNameOfDatabase)
        {
            fullNameOfDatabase = FullNameOfDatabase;
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
            using (DbCommand cmd = localDbConnection.CreateCommand())
            {
                cmd.CommandText = "UPDATE Flags SET areLeftRightConsistent = @value";
                var p = cmd.CreateParameter(); p.ParameterName = "@value"; p.Value = IsConsistent ? 1 : 0; cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
            }
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
            using (DbDataReader dRead = cmd.ExecuteReader())
            {
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    lt.Add(t);
                }
            }
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
            return lt;
        }
        internal List<Topic> GetNodesChildsByParent(Topic ParentNode, bool CloseConnectionWhenEnding)
        {
            OpenLocalConnectionIfClosed();
            List<Topic> lt = new List<Topic>();
            using (DbCommand cmd = localDbConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Topics WHERE parentNode = @parent ORDER BY childNumber";
                var p = cmd.CreateParameter(); p.ParameterName = "@parent"; p.Value = ParentNode.Id ?? (object)DBNull.Value; cmd.Parameters.Add(p);
                using (DbDataReader dRead = cmd.ExecuteReader())
                {
                    while (dRead.Read())
                    {
                        Topic t = GetTopicFromRow(dRead);
                        lt.Add(t);
                    }
                }
            }
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
            using (DbCommand cmd = localDbConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Topics WHERE leftNode <= @left AND rightNode >= @right ORDER BY leftNode ASC;";
                var pL = cmd.CreateParameter(); pL.ParameterName = "@left"; pL.Value = LeftNode.Value; cmd.Parameters.Add(pL);
                var pR = cmd.CreateParameter(); pR.ParameterName = "@right"; pR.Value = RightNode.Value; cmd.Parameters.Add(pR);
                using (DbDataReader dRead = cmd.ExecuteReader())
                {
                    while (dRead.Read())
                    {
                        Topic t = GetTopicFromRow(dRead);
                        l.Add(t);
                    }
                }
            }
            CloseLocalConnectionIfWasFoundClosed();
            return l;
        }
        internal string GetNodePath(int? LeftNode, int? RightNode)
        {
            // node numbering according to Modified Preorder Tree Traversal algorithm
            string path = string.Empty;
            try
            {
                List<Topic> l = GetNodesAncestors(LeftNode, RightNode);
                if (l != null)
                {
                    for (int i = 0; i < l.Count; i++)
                    {
                        path += l[i].Name + "|";
                    }
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
            if (idTopic == null || idTopic == 0)
                return null;
            OpenLocalConnectionIfClosed();
            using (DbCommand cmd = localDbConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT leftNode, rightNode FROM Topics WHERE idTopic = @id;";
                var p = cmd.CreateParameter(); p.ParameterName = "@id"; p.Value = idTopic ?? (object)DBNull.Value; cmd.Parameters.Add(p);
                using (DbDataReader dRead = cmd.ExecuteReader())
                {
                    if (!dRead.Read())
                        return null;
                    int? left = Safe.Int(dRead["leftNode"]);
                    int? right = Safe.Int(dRead["rightNode"]);
                    t = GetNodePath(left, right);
                }
            }
            CloseLocalConnectionIfWasFoundClosed();
            return t;
        }
        internal List<Topic> GetNodesByMpttFromDatabase(int? LeftNode, int? RightNode)
        {
            // node numbering according to Modified Preorder Tree Traversal algorithm
            // ("descending" phase)
            List<Topic> l = new List<Topic>();
            OpenLocalConnectionIfClosed();
            using (DbCommand cmd = localDbConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Topics WHERE leftNode BETWEEN @left AND @right ORDER BY leftNode ASC;";
                var pL = cmd.CreateParameter(); pL.ParameterName = "@left"; pL.Value = LeftNode ?? (object)DBNull.Value; cmd.Parameters.Add(pL);
                var pR = cmd.CreateParameter(); pR.ParameterName = "@right"; pR.Value = RightNode ?? (object)DBNull.Value; cmd.Parameters.Add(pR);
                using (DbDataReader dRead = cmd.ExecuteReader())
                {
                    while (dRead.Read())
                    {
                        Topic t = GetTopicFromRow(dRead);
                        l.Add(t);
                    }
                }
            }
            CloseLocalConnectionIfWasFoundClosed();
            return l;
        }
        internal List<Topic> GetNodesByParentFromDatabase()
        {
            // node order according to siblings' order (parentNode and childNumber)
            List<Topic> l = new List<Topic>();
            OpenLocalConnectionIfClosed();
            DbCommand cmd = localDbConnection.CreateCommand();
            string query = "SELECT * FROM Topics ORDER BY parentNode ASC, childNumber ASC;";
            cmd = new SqliteCommand(query);
            cmd.Connection = localDbConnection;
            using (DbDataReader dRead = cmd.ExecuteReader())
            {
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    l.Add(t);
                }
            }
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
            return l;
        }
        internal List<Topic> FindNodesLike(string SearchText, bool SearchInDescriptions,
            bool SearchWholeWord, bool SearchCaseInsensitive, bool SearchVerbatimString)
        {
            List<Topic> found = new List<Topic>();
            OpenLocalConnectionIfClosed();

            // set PRAGMA for case sensitivity
            using (DbCommand pragmaCmd = localDbConnection.CreateCommand())
            {
                pragmaCmd.CommandText = SearchCaseInsensitive ? "PRAGMA case_sensitive_like=OFF;" : "PRAGMA case_sensitive_like=ON;";
                try { pragmaCmd.ExecuteNonQuery(); } catch { }
            }

            using (DbCommand cmd = localDbConnection.CreateCommand())
            {
                if (SearchText == null)
                    return found;

                if (SearchVerbatimString)
                {
                    cmd.CommandText = "SELECT * FROM Topics WHERE name = @s" + (SearchInDescriptions ? " OR desc = @s" : "") + " ORDER BY leftNode ASC;";
                    var p = cmd.CreateParameter(); p.ParameterName = "@s"; p.Value = SearchText; cmd.Parameters.Add(p);
                }
                else if (SearchWholeWord)
                {
                    // patterns for whole word search
                    string p1 = SearchText + " %";
                    string p2 = "% " + SearchText;
                    string p3 = "% " + SearchText + " %";
                    cmd.CommandText = "SELECT * FROM Topics WHERE (name LIKE @p1 OR name LIKE @p2 OR name LIKE @p3 OR name = @s)" + (SearchInDescriptions ? " OR (desc LIKE @p1 OR desc LIKE @p2 OR desc LIKE @p3 OR desc = @s)" : "") + " ORDER BY leftNode ASC;";
                    var pp1 = cmd.CreateParameter(); pp1.ParameterName = "@p1"; pp1.Value = p1; cmd.Parameters.Add(pp1);
                    var pp2 = cmd.CreateParameter(); pp2.ParameterName = "@p2"; pp2.Value = p2; cmd.Parameters.Add(pp2);
                    var pp3 = cmd.CreateParameter(); pp3.ParameterName = "@p3"; pp3.Value = p3; cmd.Parameters.Add(pp3);
                    var ps = cmd.CreateParameter(); ps.ParameterName = "@s"; ps.Value = SearchText; cmd.Parameters.Add(ps);
                }
                else
                {
                    string pattern = "%" + SearchText + "%";
                    cmd.CommandText = "SELECT * FROM Topics WHERE name LIKE @pat" + (SearchInDescriptions ? " OR desc LIKE @pat" : "") + " ORDER BY leftNode ASC;";
                    var p = cmd.CreateParameter(); p.ParameterName = "@pat"; p.Value = pattern; cmd.Parameters.Add(p);
                }

                using (DbDataReader dRead = cmd.ExecuteReader())
                {
                    while (dRead.Read())
                    {
                        Topic t = GetTopicFromRow(dRead);
                        found.Add(t);
                    }
                }
            }

            CloseLocalConnectionIfWasFoundClosed();
            return found;
        }
        internal bool TopicExists(int? topicId)
        {
            OpenLocalConnectionIfClosed();
            using (DbCommand cmd = localDbConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT1 FROM Topics WHERE idTopic = @id LIMIT1;";
                var p = cmd.CreateParameter(); p.ParameterName = "@id"; p.Value = topicId ?? (object)DBNull.Value; cmd.Parameters.Add(p);
                var result = cmd.ExecuteScalar();
                CloseLocalConnectionIfWasFoundClosed();
                return (result != null);
            }
        }
        #endregion

        #region methods that write to the database
        internal void SaveTreeToDb(List<Topic> ListTopicsAfter, List<Topic> ListTopicsDeleted,
                 bool MustSaveLeftAndRight, bool CloseWhenEnding)
        {
            OpenLocalConnectionIfClosed();

            DbTransaction tx = null;
            try
            {
                tx = localDbConnection.BeginTransaction();

                // Use a single command object within the transaction
                using (DbCommand cmd = localDbConnection.CreateCommand())
                {
                    cmd.Transaction = tx;

                    // mark consistency flag false within the same transaction
                    cmd.CommandText = "UPDATE Flags SET areLeftRightConsistent = @value";
                    var pFlag = cmd.CreateParameter(); pFlag.ParameterName = "@value"; pFlag.Value = 0; cmd.Parameters.Add(pFlag);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    // perform deletions inside the transaction
                    if (ListTopicsDeleted != null && ListTopicsDeleted.Count > 0)
                    {
                        foreach (Topic t in ListTopicsDeleted)
                        {
                            // if the saving must finish and the task saving in background, we quit the function 
                            if (!Commons.BackgroundTaskCanSave && Commons.BackgroundThreadIsSaving)
                            {
                                tx.Rollback();
                                CloseLocalConnectionIfWasFoundClosed();
                                return;
                            }

                            using (DbCommand delCmd = localDbConnection.CreateCommand())
                            {
                                delCmd.Transaction = tx;
                                delCmd.CommandText = "DELETE FROM Topics WHERE idTopic = @id";
                                var p = delCmd.CreateParameter(); p.ParameterName = "@id"; p.Value = t.Id ?? (object)DBNull.Value; delCmd.Parameters.Add(p);
                                delCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // process updates/inserts
                    foreach (Topic t in ListTopicsAfter)
                    {
                        // if the saving must finish and the task saving in background, we quit the function 
                        if (!Commons.BackgroundTaskCanSave && MustSaveLeftAndRight)
                        {
                            tx.Rollback();
                            CloseLocalConnectionIfWasFoundClosed();
                            return;
                        }

                        // cure behaviour of the program, not proper functioning on root node's parent node
                        if (t.ParentNodeNew < 0)
                            t.ParentNodeNew = 0;

                        bool changed;
                        if (t.Changed == null)
                            changed = false;
                        else
                            changed = (bool)t.Changed;

                        if (changed
                        || t.ParentNodeNew != t.ParentNodeOld || t.ChildNumberNew != t.ChildNumberOld
                        || (MustSaveLeftAndRight &&
                        (t.LeftNodeNew != t.LeftNodeOld || t.RightNodeNew != t.RightNodeOld))
                        )
                        {
                            // Use the same command object and transaction for inserts/updates
                            cmd.Parameters.Clear();
                            if (t.Id != null && t.Id > 1)
                            {
                                cmd.CommandText = "UPDATE Topics SET name=@name, desc=@desc, parentNode=@parent" +
                                    ", leftNode=@left, rightNode=@right, childNumber=@child WHERE idTopic=@id;";
                                AddTopicParameters(cmd, t.Id, t.Name, t.Desc, t.LeftNodeNew, t.RightNodeNew
                                    , t.ParentNodeNew, t.ChildNumberNew);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                // get new id
                                cmd.CommandText = "SELECT MAX(IdTopic) FROM Topics;";
                                var temp = cmd.ExecuteScalar();
                                if (!(temp is DBNull) && temp != null)
                                    t.Id = Convert.ToInt32(temp) + 1;
                                else
                                    t.Id = 1;

                                cmd.Parameters.Clear();
                                cmd.CommandText = "INSERT INTO Topics (idTopic,name,desc,leftNode,rightNode,parentNode,childNumber) VALUES (@id,@name,@desc,@left,@right,@parent,@child);";
                                AddTopicParameters(cmd, t.Id, t.Name, t.Desc, t.LeftNodeNew, t.RightNodeNew, t.ParentNodeNew, t.ChildNumberNew);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // At this point all modifications succeeded, set consistency true and commit
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Flags SET areLeftRightConsistent = @value";
                    var pTrue = cmd.CreateParameter(); pTrue.ParameterName = "@value"; pTrue.Value = 1; cmd.Parameters.Add(pTrue);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch
            {
                try
                {
                    tx?.Rollback();
                }
                catch { }
                throw;
            }
            finally
            {
                CloseLocalConnectionIfWasFoundClosed();
            }
        }
        internal void AddTopic(Topic newTopic)
        {
            OpenLocalConnectionIfClosed();
            using (DbCommand cmd = localDbConnection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Topics (idTopic,name,desc,leftNode,rightNode,parentNode,childNumber)" +
                    " VALUES (@id,@name,@desc,@left,@right,@parent,@child);";
                AddTopicParameters(cmd, newTopic.Id, newTopic.Name, newTopic.Desc, newTopic.LeftNodeNew, newTopic.RightNodeNew, newTopic.ParentNodeNew, newTopic.ChildNumberNew);
                cmd.ExecuteNonQuery();
            }
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
            foreach (Topic sonNode in listChilds) // list Childs are taken from the database 
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
        /// assigns left and right values to each node according to the MPTT algorithm. If the left or right values in the
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
	               desc	VARCHAR(255),
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

            // Use parameterized query for better performance and security
            cmd.CommandText = "UPDATE Topics SET leftNode = @leftNode, rightNode = @rightNode WHERE idTopic = @idTopic";

            // Add parameters
            var paramLeft = cmd.CreateParameter();
            paramLeft.ParameterName = "@leftNode";
            paramLeft.Value = LeftNode ?? (object)DBNull.Value;
            cmd.Parameters.Add(paramLeft);

            var paramRight = cmd.CreateParameter();
            paramRight.ParameterName = "@rightNode";
            paramRight.Value = RightNode ?? (object)DBNull.Value;
            cmd.Parameters.Add(paramRight);

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@idTopic";
            paramId.Value = IdTopic ?? (object)DBNull.Value;
            cmd.Parameters.Add(paramId);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            CloseLocalConnectionIfWasFoundClosed();
        }
        /// <summary>
        /// Updates ONLY the leftNode and rightNode fields in the database for a list of topics.
        /// This is optimized for background MPTT tree updates without interfering with UI data.
        /// </summary>
        internal void SaveOnlyLeftAndRightNodes(List<Topic> listTopics)
        {
            if (listTopics == null || listTopics.Count == 0)
                return;

            OpenLocalConnectionIfClosed();
            DbTransaction tx = null;
            
            try
            {
                tx = localDbConnection.BeginTransaction();
                
                using (DbCommand cmd = localDbConnection.CreateCommand())
                {
                    cmd.Transaction = tx;
                    
                    // Prepare parameterized UPDATE statement
                    cmd.CommandText = "UPDATE Topics SET leftNode = @left, rightNode = @right WHERE idTopic = @id";
                    
                    var paramId = cmd.CreateParameter();
                    paramId.ParameterName = "@id";
                    cmd.Parameters.Add(paramId);
                    
                    var paramLeft = cmd.CreateParameter();
                    paramLeft.ParameterName = "@left";
                    cmd.Parameters.Add(paramLeft);
                    
                    var paramRight = cmd.CreateParameter();
                    paramRight.ParameterName = "@right";
                    cmd.Parameters.Add(paramRight);
                    
                    // Execute batch updates
                    foreach (Topic t in listTopics)
                    {
                        // Check if we should abort
                        if (!Commons.BackgroundTaskCanSave || Commons.BackgroundTaskClose)
                        {
                            tx.Rollback();
                            CloseLocalConnectionIfWasFoundClosed();
                            return;
                        }
                        
                        paramId.Value = t.Id ?? (object)DBNull.Value;
                        paramLeft.Value = t.LeftNodeNew ?? (object)DBNull.Value;
                        paramRight.Value = t.RightNodeNew ?? (object)DBNull.Value;
                        
                        cmd.ExecuteNonQuery();
                    }
                }
                
                tx.Commit();
            }
            catch
            {
                try
                {
                    tx?.Rollback();
                }
                catch { }
                throw;
            }
            finally
            {
                CloseLocalConnectionIfWasFoundClosed();
            }
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
        internal void UpdateTopic(Topic t, DbCommand cmd)
        {
            // for performance, the DbCommand cmd must be created and disposed outside this method
            try
            {
                // ensure no leftover parameters
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE Topics SET name=@name, desc=@desc, parentNode=@parent, leftNode=@left, rightNode=@right, childNumber=@child WHERE idTopic=@id;";
                AddTopicParameters(cmd, t.Id, t.Name, t.Desc, t.LeftNodeNew, t.RightNodeNew, t.ParentNodeNew, t.ChildNumberNew);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        internal void InsertTopic(Topic t, DbCommand cmd)
        {
            // for performance, the DbCommand cmd must be created and disposed outside this method
            try
            {
                if (t.Id == null || t.Id == 0)
                {
                    cmd.CommandText = "SELECT MAX(IdTopic) FROM Topics;";
                    var temp = cmd.ExecuteScalar();
                    if (!(temp is DBNull) && temp != null)
                        t.Id = Convert.ToInt32(temp) + 1;
                    else
                        t.Id = 1;
                }
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO Topics (idTopic,name,desc,leftNode,rightNode,parentNode,childNumber)" +
                    " VALUES (@id,@name,@desc,@left,@right,@parent,@child);";
                AddTopicParameters(cmd, t.Id, t.Name, t.Desc, t.LeftNodeNew, t.RightNodeNew, t.ParentNodeNew, t.ChildNumberNew);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void AddTopicParameters(DbCommand cmd, int? id, string name, string desc, int? left, int? right, int? parent, int? child)
        {
            // Aggiungere i parametri utilizzando i nomi dei parametri definiti nella query
            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id ?? (object)DBNull.Value;
            cmd.Parameters.Add(paramId);

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@name";
            paramName.Value = name ?? (object)DBNull.Value;
            cmd.Parameters.Add(paramName);

            var paramDesc = cmd.CreateParameter();
            paramDesc.ParameterName = "@desc";
            paramDesc.Value = desc ?? (object)DBNull.Value;
            cmd.Parameters.Add(paramDesc);

            var paramLeft = cmd.CreateParameter();
            paramLeft.ParameterName = "@left";
            paramLeft.Value = left ?? (object)DBNull.Value;
            cmd.Parameters.Add(paramLeft);

            var paramRight = cmd.CreateParameter();
            paramRight.ParameterName = "@right";
            paramRight.Value = right ?? (object)DBNull.Value;
            cmd.Parameters.Add(paramRight);

            var paramParent = cmd.CreateParameter();
            paramParent.ParameterName = "@parent";
            paramParent.Value = parent ?? (object)DBNull.Value;
            cmd.Parameters.Add(paramParent);

            var paramChild = cmd.CreateParameter();
            paramChild.ParameterName = "@child";
            paramChild.Value = child ?? (object)DBNull.Value;
            cmd.Parameters.Add(paramChild);
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
