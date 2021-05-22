using System;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using gamon;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades.DataLayer
{
    //Andrea Siboni, Francesco Citarella, Cesare Colella, Riccardo Brunelli 4°L
    class TopicData
    {
        DataLayer dl = new DataLayer();
        private int NextKey(string Table, string Id)
        {
            int nextId;
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT MAX(" + Id + ") FROM " + Table + ";";
                var firstColumn = cmd.ExecuteScalar();
                if (firstColumn != DBNull.Value)
                {
                    nextId = int.Parse(firstColumn.ToString()) + 1;
                }
                else
                {
                    nextId = 1;
                }
                cmd.Dispose();
            }
            return nextId;
        }

        internal int CreateNewTopic(Topic NewTopic)
        {
            int nextId;
            using (DbConnection conn = dl.Connect())
            {
                nextId = NextKey("Topics", "idTopic");

                DbCommand cmd = conn.CreateCommand();
                // aggiunge la foto alle foto (cartella relativa, cui verrà aggiunta la path delle foto)
                cmd.CommandText = "INSERT INTO Topics " +
                "(idTopic,name,desc,leftNode,rightNode,parentNode,childNumber)" +
                "Values " +
                "(" + nextId + ",'" + SqlVal.SqlString(NewTopic.Name) + "','" +
                SqlVal.SqlString(NewTopic.Desc) + "'," + SqlVal.SqlInt(NewTopic.LeftNodeNew.ToString()) + "," +
                 SqlVal.SqlInt(NewTopic.RightNodeNew.ToString()) + "," + SqlVal.SqlInt(NewTopic.ParentNodeNew.ToString()) +
                "," + SqlVal.SqlInt(NewTopic.ChildNumberNew.ToString()) +
                ");";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return nextId;
        }
        internal void EraseAllTopics()
        {
            using (DbConnection conn = dl.Connect())
            {   // erase all the topics
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Topics;";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        /// <summary>
        /// Gets the record of the Topic from the database, 
        /// </summary>
        /// <param name="dRead"></param>
        /// <returns></returns>
        internal Topic GetTopicFromRow(DbDataReader dRead)
        {
            Topic t = new Topic();
            t.Id = SafeDb.SafeInt(dRead["IdTopic"]);
            t.Name = SafeDb.SafeString(dRead["name"]);
            t.Desc = SafeDb.SafeString(dRead["desc"]);
            t.LeftNodeOld = SafeDb.SafeInt(dRead["leftNode"]);
            t.LeftNodeNew = -1;
            t.RightNodeOld = SafeDb.SafeInt(dRead["rightNode"]);
            t.RightNodeNew = -1;
            t.ParentNodeOld = SafeDb.SafeInt(dRead["parentNode"]);
            t.ParentNodeNew = -1;
            t.ChildNumberOld = SafeDb.SafeInt(dRead["childNumber"]);
            t.ChildNumberNew = -1;
            t.Changed = false;

            return t;
        }
        internal Topic GetTopicById(int? idTopic)
        {
            Topic t = new Topic();
            using (DbConnection conn = dl.Connect())
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
            using (DbConnection conn = dl.Connect())
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
        internal List<Topic> GetTopicsNotDoneFromThisTopic(Class Class, Topic Topic,
            SchoolSubject Subject)
        {
            // node numbering according to Modified Preorder Tree Traversal algorithm
            List<Topic> l = new List<Topic>();
            using (DbConnection conn = dl.Connect())
            {
                // find descendant topics that aren't done  
                DbCommand cmd = conn.CreateCommand();
                //!!!! TODO aggiustare la logica
                string query = "SELECT *" +
                    " FROM Topics" +
                    " LEFT JOIN Lessons_Topics ON Lessons_Topics.idTopic = Topics.idTopic" +
                    " JOIN Lessons ON Lessons_Topics.idLesson = Lessons.IdLesson" +
                    " WHERE leftNode BETWEEN " + Topic.LeftNodeOld +
                    " AND " + Topic.RightNodeOld +
                    " AND Lessons_Topics.idLesson IS null" +
                    " AND Lessons.idClass = " + Class.IdClass +
                    " AND Lessons.idSchoolSubject ='" + Subject.IdSchoolSubject + "'" +
                    " ORDER BY leftNode ASC;";
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
        internal List<Topic> GetTopicsDoneFromThisTopic(Class Class, Topic StartTopic,
            SchoolSubject Subject)
        {
            // node order according to Modified Preorder Tree Traversal algorithm
            List<Topic> l = new List<Topic>();
            if (Class == null)
                return l;
            using (DbConnection conn = dl.Connect())
            {
                // find descendant topics that are done  
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " JOIN Lessons_Topics ON Lessons_Topics.idTopic = Topics.idTopic " +
                    " JOIN Lessons ON Lessons_Topics.idLesson = Lessons.idLesson" +
                    " WHERE leftNode BETWEEN " + StartTopic.LeftNodeOld +
                    " AND " + StartTopic.RightNodeOld;
                if (Class != null)
                    query += " AND Lessons.idClass = " + Class.IdClass;
                if (Subject != null)
                    query += " AND Lessons.idSchoolSubject ='" + Subject.IdSchoolSubject + "'" +
                    " ORDER BY leftNode ASC;";
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
        internal List<Topic> GetAllTopicsDoneInClassAndSubject(Class Class,
            SchoolSubject Subject,
            DateTime DateStart = default(DateTime), DateTime DateFinish = default(DateTime))
        {
            // node order according to Modified Preorder Tree Traversal algorithm
            List<Topic> l = new List<Topic>();
            using (DbConnection conn = dl.Connect())
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
                    SqlVal.SqlDate(DateStart) + " AND " + SqlVal.SqlDate(DateFinish);
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
            using (DbConnection conn = dl.Connect())
            {
                DateTo = DateTo.AddDays(1); // add one day for lesson after 0 and to midnight 
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT Topics.idTopic,Topics.name,Topics.desc,Topics.LeftNode,Topics.RightNode," +
                    "Topics.ParentNode, Topics.childNumber, Lessons.date,Lessons.idSchoolSubject" +
                    " FROM Topics" +
                    " JOIN Lessons_Topics ON Lessons_Topics.IdTopic=Topics.IdTopic" +
                    " JOIN Lessons ON Lessons_Topics.IdLesson=Lessons.IdLesson" +
                    " WHERE Lessons.IdClass=" + currentClass.IdClass +
                    " AND Lessons.idSchoolSubject='" + currentSubject.IdSchoolSubject + "'";
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
                    t.Desc = (string)dRead["desc"];
                    //t.LeftNodeNew = -1;
                    //t.RightNodeNew = -1;
                    t.Date = (DateTime)dRead["date"]; // taken fron the Lessons table 

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
                conn = dl.Connect();
                leaveConnectionOpen = false;
            }
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Topics" +
                " SET" +
                " name='" + SqlVal.SqlString(t.Name) + "'" +
                ",desc='" + SqlVal.SqlString(t.Desc) + "'" +
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
                    Conn = dl.Connect();
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
                    ",'" + SqlVal.SqlString(t.Name) + "'" +
                    ",'" + SqlVal.SqlString(t.Desc) + "'" +
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
        internal void SaveTopicsFromScratch(List<Topic> ListTopics)
        {
            ////////BackgroundCanStillSaveTopicsTree = true;
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
                            ",'" + SqlVal.SqlString(t.Name) + "'" +
                            ",'" + SqlVal.SqlString(t.Desc) + "'" +
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

        internal void SaveTopicsOfLesson(int? IdLesson, List<Topic> topicsOfTheLesson)
        {
            using (DbConnection conn = dl.Connect())
            {
                // erase existing links topic-lesson
                DbCommand cmd = conn.CreateCommand();
                string query = "DELETE FROM Lessons_Topics" +
                        " WHERE idLesson=" + IdLesson.ToString() +
                        ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                int insertionOrder = 1;
                foreach (Topic t in topicsOfTheLesson)
                {
                    // insert links topic-lesson, one at a time 
                    cmd.CommandText = "INSERT INTO Lessons_Topics" +
                    " (idLesson, idTopic, insertionOrder)" +
                    " Values (" +
                    "" + IdLesson + "" +
                    "," + t.Id +
                    "," + insertionOrder++ +
                    ");";
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {
                        {
                            // if it isn't UNIQUE, then it is error (to cure!!!!)
                            // but actually it doesn't matter too much, because
                            // the lesson is already linked to the topic anyway.. 


                        }
                    }
                }
                cmd.Dispose();
            }
        }
        internal List<Topic> GetTopicsOfLesson(int? IdLesson, List<Topic> topicsOfTheLesson)
        {
            if (IdLesson == null)
            {
                return null;
            }
            // order by ensures that the order of the result is the order of insertion 
            // in the database (that was the same of the tree traversal) 
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                DbDataReader dRead;
                string query;
                query = "SELECT * FROM Topics" +
                        " JOIN Lessons_Topics ON Topics.idTopic=Lessons_Topics.idTopic" +
                        " WHERE Lessons_Topics.idLesson=" + IdLesson +
                        " ORDER BY insertionOrder" +
                        ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    topicsOfTheLesson.Add(t);
                }
                cmd.Dispose();
                dRead.Dispose();
            }
            return topicsOfTheLesson;
        }

    }
}
