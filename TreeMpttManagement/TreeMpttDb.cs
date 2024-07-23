using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System.Collections.Generic;
using System.Data.Common;

namespace gamon.TreeMptt
{
    internal abstract class TreeMpttDb
    {
        internal DataLayer dl;
        internal DbConnection localConnection;

        internal TreeMpttDb(DataLayer dataLayer)
        {
            dl = dataLayer;
        }
        internal abstract void SaveTreeToDb(List<Topic> ListTopicsAfter, List<Topic> ListTopicsDeleted,
            bool MustSaveLeftAndRight, bool CloseWhenEnding);
        internal abstract void SaveLeftRightConsistent(bool IsConsistent);
        internal abstract bool AreLeftAndRightConsistent();
        internal abstract List<Topic> GetNodesMpttFromDatabase(int? LeftNode, int? RightNode);
        //internal abstract List<Topic> GetNodesByParent();
        //internal abstract List<Topic> GetNodesByParentFromDatabase();
        internal abstract void SaveLeftAndRightToDbMptt();
        internal abstract void UdpateMpttNodeLeftAndRight(int? IdTopic, int? LeftNode, int? RightNode);
        internal abstract List<Topic> GetNodesRoots(bool CloseConnectionEnding);
        internal abstract List<Topic> GetNodesChildsByParent(Topic ParentNode, bool CloseConnectionWhenEnding);
        internal abstract List<Topic> GetNodesAncestors(int? LeftNode, int? RightNode);
        internal abstract string GetNodePath(int? LeftNode, int? RightNode);
        internal abstract string GetNodePath(int? idTopic);
        internal abstract List<Topic> FindNodesLike(string SearchText, bool SearchInDescriptions,
            bool SearchWholeWord, bool SearchCaseInsensitive, bool SearchVerbatimString);
        internal abstract void SaveNodesFromScratch(List<Topic> ListTopics);
        internal abstract int? CreateNewTopic(Topic ct);
        internal abstract void CloseConnection(bool Close);
        internal abstract void CreateTableTreeMpttDb();
        internal abstract void AddTopic(Topic topic);
        internal abstract bool TopicExists(int? topicId);
        internal abstract void GetTopics(int? numberOfTopics);
        internal void UdpateMpttNodeLeftAndRight(int? IdTopic, int? LeftNode, int? RightNode,
            DbConnection conn, bool leaveConnectionOpen)
        {
            // updates only left & right; the rest of the record remains the same
            dl.CreateOrOpenConnection(ref conn);
            using (conn = dl.Connect())
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
            if (!leaveConnectionOpen)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        private void InsertTreeNodeParent(Topic t, DbConnection conn, bool leaveConnectionOpen)
        {
            // updates all fields, except left & right
            dl.CreateOrOpenConnection(ref conn);
            using (conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                int? nextId = dl.NextKey("StudentsAnnotations", "IdAnnotation");
                t.Id = nextId;
                string query = "INSERT INTO Topics " +
                "(idTopic, name, desc,parentNode,childNumber)";
                query += "(";
                query += dl.SqlInt(t.Id);
                query += "," + dl.SqlInt(t.Name);
                query += "," + dl.SqlInt(t.Desc);
                query += "," + dl.SqlInt(t.ParentNodeNew);
                query += "," + dl.SqlInt(t.ChildNumberNew);
                query += ");";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            if (!leaveConnectionOpen)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        private void UpdateTreeNodeParent(Topic t, DbConnection conn, bool leaveConnectionOpen)
        {
            // updates all fields, except left & right
            dl.CreateOrOpenConnection(ref conn);
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Topics" +
                " SET" +
                " name=" + dl.SqlString(t.Name) +
                ",desc=" + dl.SqlString(t.Desc) +
                ",parentNode=" + dl.SqlInt(t.ParentNodeNew) +
                ",childNumber=" + dl.SqlInt(t.ChildNumberNew) +
                " WHERE idTopic=" + dl.SqlInt(t.Id) +
                ";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (!leaveConnectionOpen)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        private void DeleteTreeNodeParent(Topic t, DbConnection conn, bool leaveConnectionOpen)
        {
            // updates all fields, except left & right
            dl.CreateOrOpenConnection(ref conn);
            using (conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Topics" +
                    " WHERE idTopic=" + t.Id +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            if (!leaveConnectionOpen)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        internal void UpdateTreeNode(Topic t)
        {
            UpdateTreeNodeParent(t, localConnection, true);
        }
        internal void InsertTreeNode(Topic t)
        {
            UpdateTreeNodeParent(t, localConnection, true);
        }
        internal void DeleteTreeNode(Topic t)
        {
            DeleteTreeNodeParent(t, localConnection, true);
        }
    }
}
