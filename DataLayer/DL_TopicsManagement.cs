using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        /// <summary>
        /// Gets the record of the Topic from the database, 
        /// </summary>
        /// <param name="dRead"></param>
        /// <returns></returns>
        internal Topic GetTopicFromRow(DbDataReader dRead)
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
            int nextId;
            using (DbConnection conn = Connect())
            {
                nextId = NextKey("Topics", "idTopic");

                DbCommand cmd = conn.CreateCommand();
                // aggiunge la foto alle foto (cartella relativa, cui verrà aggiunta la path delle foto)
                cmd.CommandText = "INSERT INTO Topics " +
                "(idTopic,name,desc,leftNode,rightNode,parentNode,childNumber)" +
                "Values " +
                "(" + nextId + "," + SqlString(NewTopic.Name) + "," +
                SqlString(NewTopic.Desc) + "," + SqlInt(NewTopic.LeftNodeNew.ToString()) + "," +
                 SqlInt(NewTopic.RightNodeNew.ToString()) + "," + SqlInt(NewTopic.ParentNodeNew.ToString()) +
                "," + SqlInt(NewTopic.ChildNumberNew.ToString()) +
                ");";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return nextId;
        }
        internal void EraseAllTopics()
        {
            using (DbConnection conn = Connect())
            {   // erase all the topics
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Topics;";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal Topic GetTopicById(int? idTopic)
        {
            Topic t = new Topic();
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " WHERE idTopic=" + idTopic;
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    t = GetTopicFromRow(dRead);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return t;
        }
        internal List<Topic> GetTopics()
        {
            List<Topic> lt = new List<Topic>();
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " ORDER BY IdTopic;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    lt.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return lt;
        }
        internal bool IsTopicAlreadyTaught(Topic Topic)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idLesson" +
                    " FROM Lessons_Topics" +
                    " WHERE idTopic=" + Topic.Id +
                    " AND idTopic<>0" +
                    " LIMIT 1; ";
                var result = cmd.ExecuteScalar();
                return (result != null);
            }
        }
        internal List<Topic> GetTopicsDoneFromThisTopic(Class Class, Topic StartTopic,
            SchoolSubject Subject)
        {
            // node numbering according to Modified Preorder Tree Traversal algorithm
            List<Topic> l = new List<Topic>();
            if (Class == null)
                return l;
            using (DbConnection conn = Connect())
            {
                // find descendant topics that are done  
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT DISTINCT Topics.idTopic, Topics.name, Topics.desc" +
                    ",Topics.leftNode, Topics.rightNode, Topics.parentNode, Topics.childNumber" +
                    " FROM Topics" +
                    " JOIN Lessons_Topics ON Lessons_Topics.idTopic = Topics.idTopic" +
                    " JOIN Lessons ON Lessons_Topics.idLesson = Lessons.idLesson" +
                    " WHERE leftNode BETWEEN " + StartTopic.LeftNodeOld +
                    " AND " + StartTopic.RightNodeOld;
                if (Class != null)
                    query += " AND Lessons.idClass = " + Class.IdClass;
                if (Subject != null)
                    query += " AND Lessons.idSchoolSubject ='" + Subject.IdSchoolSubject + "'";
                query += " ORDER BY leftNode ASC;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal List<Topic> GetTopicsNotDoneFromThisTopic(Class Class, Topic StartTopic,
            SchoolSubject Subject)
        {
            // node numbering according to Modified Preorder Tree Traversal algorithm
            List<Topic> l = new List<Topic>();
            if (Class == null)
                return l;
            using (DbConnection conn = Connect())
            {
                // find descendant topics that aren't done  
                DbCommand cmd = conn.CreateCommand();
                // query that gets the Ids of topics done
                string queryDone = "SELECT DISTINCT Topics.idTopic" +
                    " FROM Topics" +
                    " JOIN Lessons_Topics ON Lessons_Topics.idTopic = Topics.idTopic" +
                    " JOIN Lessons ON Lessons_Topics.idLesson = Lessons.idLesson" +
                    " WHERE leftNode BETWEEN " + StartTopic.LeftNodeOld +
                    " AND " + StartTopic.RightNodeOld;
                if (Class != null)
                    queryDone += " AND Lessons.idClass = " + Class.IdClass;
                if (Subject != null)
                    queryDone += " AND Lessons.idSchoolSubject ='" + Subject.IdSchoolSubject + "'";

                string queryNotDone = "SELECT DISTINCT Topics.idTopic, Topics.name, Topics.desc" +
                    ",Topics.leftNode, Topics.rightNode, Topics.parentNode, Topics.childNumber" +
                    " FROM Topics" +
                    " WHERE leftNode BETWEEN " + StartTopic.LeftNodeOld +
                    " AND " + StartTopic.RightNodeOld +
                    " AND Topics.idTopic NOT IN (" + queryDone + ")";  
                queryNotDone += " ORDER BY leftNode ASC;";
                cmd = new SQLiteCommand(queryNotDone);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal List<Topic> GetAllTopicsDoneInClassAndSubject(Class Class,
            SchoolSubject Subject,
            DateTime DateStart = default(DateTime), DateTime DateFinish = default(DateTime))
        {
            // node order according to Modified Preorder Tree Traversal algorithm
            List<Topic> l = new List<Topic>();
            using (DbConnection conn = Connect())
            {
                // find topics that are done in a lesson of given class about and given subject 
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " JOIN Lessons_Topics ON Lessons_Topics.idTopic = Topics.idTopic " +
                    " JOIN Lessons ON Lessons_Topics.idLesson = Lessons.idLesson" +
                    " JOIN Classes ON Classes.idClass = Lessons.idClass" +
                    " WHERE Lessons.idClass = " + Class.IdClass +
                    " AND Lessons.idSchoolSubject ='" + Subject.IdSchoolSubject + "'";
                if (DateStart != default(DateTime) && DateFinish != default(DateTime))
                    query += " AND Lessons.date BETWEEN " +
                    SqlDate(DateStart) + " AND " + SqlDate(DateFinish);
                query += " ORDER BY Lessons.date ASC;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal List<Topic> GetTopicsDoneInPeriod(Class currentClass, SchoolSubject currentSubject,
            DateTime DateFrom, DateTime DateTo)
        {
            List<Topic> lt = new List<Topic>();
            using (DbConnection conn = Connect())
            {
                DateTo = DateTo.AddDays(1); // add one day for lesson after 0 and to midnight 
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT Topics.idTopic,Topics.name,Topics.desc,Topics.LeftNode,Topics.RightNode," +
                    "Topics.ParentNode, Topics.childNumber, Lessons.date,Lessons.idSchoolSubject" +
                    " FROM Topics" +
                    " JOIN Lessons_Topics ON Lessons_Topics.IdTopic=Topics.IdTopic" +
                    " JOIN Lessons ON Lessons_Topics.IdLesson=Lessons.IdLesson" +
                    " WHERE Lessons.IdClass=" + currentClass.IdClass; 
                if (currentSubject != null && currentSubject.IdSchoolSubject != null && currentSubject.IdSchoolSubject != "")
                    query += " AND Lessons.idSchoolSubject='" + currentSubject.IdSchoolSubject + "'";
                if (DateFrom == Commons.DateNull)
                {
                    query += " AND (Lessons.Date BETWEEN '" + DateFrom.ToString("yyyy-MM-dd") + "'" +
                        " AND '" + DateTo.ToString("yyyy-MM-dd") + "')";
                }
                query += " ORDER BY Lessons.date DESC" +
                ";";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    t.Id = (int)dRead["IdTopic"];
                    t.Name = (string)dRead["name"];
                    t.Desc = Safe.String(dRead["desc"]);
                    //t.LeftNodeNew = -1;
                    //t.RightNodeNew = -1;
                    t.Date = (DateTime)dRead["date"]; // taken fron the Lessons taSafee 

                    // determine the path while still in the database
                    // if we don't, determination from the outside would be too costly 
                    query = "SELECT idTopic, name, desc, leftNode, rightNode" +
                        " FROM Topics" +
                        " WHERE leftNode <=" + t.LeftNodeOld +
                        " AND rightNode >=" + t.RightNodeOld +
                        " ORDER BY leftNode ASC;)";
                    cmd = new SQLiteCommand(query);
                    cmd.Connection = conn;
                    DbDataReader dRead1 = cmd.ExecuteReader();
                    string path = "";
                    while (dRead1.Read())
                    {
                        path += ((string)dRead1["name"]).Trim() + "|";
                    }
                    //t.Path = path;
                    t.Changed = false;
                    lt.Add(t);
                    dRead1.Dispose();
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return lt;
        }
        internal int GetTopicDescendantsNumber(int? LeftNode, int? RightNode)
        {
            // node numbering according to Modified Preorder Tree Traversal algorithm
            return ((int)RightNode - (int)LeftNode - 1) / 2;
        }
        internal void UpdateTopic(Topic t, DbConnection conn)
        {
            bool leaveConnectionOpen = true;
            if (conn == null)
            {
                conn = Connect();
                leaveConnectionOpen = false;
            }
            DbCommand cmd = conn.CreateCommand();
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
            if (!leaveConnectionOpen)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        internal void InsertTopic(Topic t, DbConnection Conn)
        {
            if (t.Id == null || t.Id == 0)
            {
                bool leaveConnectionOpen = true;
                if (Conn == null)
                {
                    Conn = Connect();
                    leaveConnectionOpen = false;
                }
                DbCommand cmd = Conn.CreateCommand();

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
                if (!leaveConnectionOpen)
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }
        internal List<Topic> GetNodesByParentFromDatabase()
        {
            // node order according to parents' order (parentNode and childNumber)
            List<Topic> l = new List<Topic>();
            using (DbConnection conn = Connect())
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
                    Topic t = GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal void SaveTopicsFromScratch(List<Topic> ListTopics)
        {
            using (DbConnection conn = Connect())
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
                            "," + SqlString(t.Name) + "" +
                            "," + SqlString(t.Desc) + "" +
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
