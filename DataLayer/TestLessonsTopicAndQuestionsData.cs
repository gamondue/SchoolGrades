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
    class TestLessonsTopicAndQuestionsData
    {
        DataLayer dl = new DataLayer();
        public TestLessonsTopicAndQuestionsData() { }
        public TestLessonsTopicAndQuestionsData(string PathAndFile)
        {
            dl = new DataLayer(PathAndFile);
        }
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
        internal Test GetTestFromRow(DbDataReader Row)
        {
            Test t = new Test();
            t.IdTest = SafeDb.SafeInt(Row["idTest"]);
            t.Name = SafeDb.SafeString(Row["name"]);
            t.Desc = SafeDb.SafeString(Row["desc"]);
            t.IdSchoolSubject = SafeDb.SafeString(Row["IdSchoolSubject"]);
            t.IdTestType = SafeDb.SafeString(Row["IdTestType"]);
            t.IdSchoolSubject = SafeDb.SafeString(Row["IdSchoolSubject"]);
            t.IdTopic = SafeDb.SafeInt(Row["IdTopic"]);

            return t;
        }
        internal Test GetTest(int? IdTest)
        {
            Test t = new Test();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM Tests " +
                    "WHERE IdTest=" + IdTest +
                    ";";
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    t = GetTestFromRow(dRead);
                }
            }
            return t;
        }
        internal List<Test> GetTests()
        {
            List<Test> list = new List<Test>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM Tests " +
                    //"WHERE idSchoolYear=" + IdSchoolYear +
                    //" OR IdSchoolYear IS null OR IdSchoolYear=''" +
                    ";";
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    Test t = GetTestFromRow(dRead);
                    list.Add(t);
                }
            }
            return list;
        }

        internal void SaveTest(Test TestToSave)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                if (TestToSave.IdTest == 0 || TestToSave.IdTest == null)
                {   // create new record
                    int nextId = NextKey("Tests", "idTest");

                    cmd.CommandText = "INSERT INTO Tests " +
                    "(idTest,name,desc,IdSchoolSubject,IdTestType,IdTopic" +
                    ")" +
                    "Values " +
                    "(" + nextId + ",'" + SqlVal.SqlString(TestToSave.Name) + "','" +
                    SqlVal.SqlString(TestToSave.Desc) + "','" + SqlVal.SqlString(TestToSave.IdSchoolSubject) + "'," +
                     SqlVal.SqlInt(TestToSave.IdTestType) + "," + SqlVal.SqlInt(TestToSave.IdTopic) +
                    ");";
                }
                else
                {   // update old record
                    cmd.CommandText = "UPDATE Tests" +
                    " SET name='" + SqlVal.SqlString(TestToSave.Name) + "'," +
                    "desc='" + SqlVal.SqlString(TestToSave.Desc) + "'" +
                    ",IdSchoolSubject=" + SqlVal.SqlString(TestToSave.IdSchoolSubject) +
                    ",IdTestType=" + SqlVal.SqlInt(TestToSave.IdTestType) +
                    ",IdTopic=" + SqlVal.SqlInt(TestToSave.IdTopic) +
                    ")" +
                    " WHERE idTest=" + TestToSave.IdTest +
                    ";";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal List<Question> GetAllQuestionsOfATest(int? IdTest)
        {
            List<Question> lq = new List<Question>();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *" +
                    " FROM Questions" +
                    " JOIN Tests_Questions ON Tests_Questions.IdQuestion=Questions.IdQuestion" +
                    " WHERE Tests_Questions.idTest=" + IdTest +
                    ";";
                DbDataReader dRead;
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    Question q = GetQuestionFromRow(dRead);
                    lq.Add(q);
                }
            }
            return lq;
        }
        internal void AddQuestionToTest(Test Test, Question Question)
        {
            using (DbConnection conn = dl.Connect())
            {
                // get the code of the previous photo
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Tests_Questions" +
                    " (IdTest, IdQuestion)" +
                    " Values" +
                    " (" + Test.IdTest + "," + Question.IdQuestion + ")" +
                    "; ";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal List<QuestionType> GetListQuestionTypes(bool IncludeANullObject)
        {
            List<QuestionType> l = new List<QuestionType>();
            if (IncludeANullObject)
            {
                QuestionType qt = new QuestionType();
                qt.IdQuestionType = "";
                l.Add(qt);
            }
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM QuestionTypes;";
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    QuestionType o = new QuestionType();
                    o.Name = (string)dRead["Name"];
                    o.IdQuestionType = (string)dRead["IdQuestionType"];
                    o.Desc = (string)dRead["Desc"];
                    o.IdQuestionType = (string)dRead["IdQuestionType"];
                    l.Add(o);
                }
                dRead.Dispose();
                cmd.Dispose();
                return l;
            }
        }

        internal int NewLesson(Lesson Lesson)
        {
            int key;
            using (DbConnection conn = dl.Connect())
            {
                key = NextKey("Lessons", "idLesson");
                Lesson.IdLesson = key;
                // add new record to Lessons table
                DbCommand cmd = conn.CreateCommand();
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Lessons" +
                " (idLesson, date, idClass, idSchoolSubject, idSchoolYear, note) " +
                "Values (" +
                "" + Lesson.IdLesson + "" +
                "," + SqlVal.SqlDate(Lesson.Date) + "" +
                "," + Lesson.IdClass + "" +
                ",'" + Lesson.IdSchoolSubject + "'" +
                ",'" + Lesson.IdSchoolYear + "'" +
                ",'" + SqlVal.SqlString(Lesson.Note) + "'" +
                ");";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return key;
        }
        internal void SaveLesson(Lesson Lesson)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Lessons" +
                " SET" +
                " date=" + SqlVal.SqlDate(Lesson.Date) + "," +
                " idClass=" + Lesson.IdClass + "," +
                " idSchoolSubject='" + Lesson.IdSchoolSubject + "'," +
                " idSchoolYear='" + Lesson.IdSchoolYear + "'," +
                " note='" + SqlVal.SqlString(Lesson.Note) + "'" +
                " WHERE idLesson=" + Lesson.IdLesson +
                ";";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
        }
        internal object GetTopicsOfOneLessonOfClass(Class Class, Lesson Lesson)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter dAdapt;
                DataSet dSet = new DataSet();
                string query = "SELECT Topics.* FROM Lessons" +
                    " LEFT JOIN Lessons_Topics ON Lessons.IdLesson = Lessons_Topics.idLesson" +
                    " LEFT JOIN Topics ON Topics.idTopic = Lessons_Topics.idTopic" +
                    " WHERE idSchoolSubject='" + Lesson.IdSchoolSubject + "'" +
                    " AND Lessons.idSchoolYear='" + Lesson.IdSchoolYear + "'" +
                    " AND Lessons.idClass='" + Class.IdClass + "'" +
                    " AND Lessons.idLesson='" + Lesson.IdLesson + "'" +
                    //" GROUP BY Lessons.idLesson" +
                    " ORDER BY Lessons.date DESC" +
                    ";";
                dAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                dSet = new DataSet("GetOnLessonOfClass");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                dAdapt.Dispose();
                dSet.Dispose();
            }
            return t;
        }
        internal DataTable GetLessonsOfClass(Class Class, Lesson Lesson)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter dAdapt;
                DataSet dSet = new DataSet();
                string query = "SELECT * FROM Lessons" +
                    " WHERE idSchoolSubject='" + Lesson.IdSchoolSubject + "'" +
                    " AND Lessons.idSchoolYear='" + Lesson.IdSchoolYear + "'" +
                    " AND Lessons.idClass='" + Class.IdClass + "'" +
                    //" GROUP BY Lessons.idLesson" +
                    " ORDER BY Lessons.date DESC" +
                    ";";
                dAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                dSet = new DataSet("GetLessonsOfClass");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                dAdapt.Dispose();
                dSet.Dispose();
            }
            return t;
        }
        internal Lesson GetLastLesson(Lesson CurrentLesson)
        {
            using (DbConnection conn = dl.Connect())
            {
                List<Couple> couples = new List<Couple>();
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                Lesson l;
                string query;
                query = "SELECT * FROM Lessons" +
                        " WHERE idClass=" + CurrentLesson.IdClass.ToString() +
                        " AND idSchoolSubject='" + CurrentLesson.IdSchoolSubject + "'" +
                        " AND idSchoolYear='" + CurrentLesson.IdSchoolYear + "'" +
                        " ORDER BY Date DESC LIMIT 1;";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                l = new Lesson();
                while (dRead.Read())
                {
                    l.IdLesson = (int)dRead["idLesson"];
                    l.Date = (DateTime)dRead["Date"];
                    l.IdClass = (int)dRead["idClass"];
                    l.IdSchoolSubject = (string)dRead["idSchoolSubject"];
                    l.Note = (string)dRead["note"];

                    break;
                }
                cmd.Dispose();
                dRead.Dispose();
                return l;
            }
        }
        internal Lesson GetLessonInDate(Class Class, string IdSubject,
            DateTime Date)
        {
            Lesson less = new Lesson();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query;
                query = "SELECT * FROM Lessons" +
                        " WHERE idClass=" + Class.IdClass.ToString() +
                        " AND idSchoolSubject='" + IdSubject + "'" +
                        " AND date BETWEEN " + SqlVal.SqlDate(Date.ToString("yyyy-MM-dd")) +
                        " AND " + SqlVal.SqlDate(Date.AddDays(1).ToString("yyyy-MM-dd")) +
                        " LIMIT 1;";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    less.IdLesson = (int)dRead["idLesson"];
                    less.Date = (DateTime)dRead["Date"];
                    less.IdClass = (int)dRead["idClass"];
                    less.IdSchoolSubject = (string)dRead["idSchoolSubject"];
                    less.Note = (string)dRead["note"];

                    break; // there should be only one record in the query result 
                }
                cmd.Dispose();
                dRead.Dispose();
            }
            return less;
        }
        internal void EraseLesson(int? IdLesson, bool AlsoEraseImageFiles)
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

                // erase images' files if permitted
                if (AlsoEraseImageFiles)
                {
                    // !! TODO !! find the images that aren't linked to another lesson and delete
                    // the files if EraseImageFiles is set 
                    throw new NotImplementedException();
                }

                // erase existing links images-lesson
                cmd = conn.CreateCommand();
                query = "DELETE FROM Lessons_Images" +
                        " WHERE idLesson=" + IdLesson.ToString() +
                        ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                // erase the lesson's row from lessons
                cmd = conn.CreateCommand();
                query = "DELETE FROM Lessons" +
                        " WHERE idLesson=" + IdLesson.ToString() +
                        ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
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

                    catch (Exception e)
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
        internal void FixQuestionInGrade(int? IdGrade)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Grades" +
                           " Set" +
                           " isFixed=TRUE" +
                           " WHERE idGrade=" + IdGrade +
                           ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal void RemoveQuestionFromTest(int? IdQuestion, int? IdTest)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Tests_Questions " +
                    "WHERE IdQuestion=" + IdQuestion +
                    " AND IdTest='" + IdTest + "'" +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal DataTable GetGradesWeightsOfClassOnOpenGrades(Class Class,
                string IdGradeType, string IdSchoolSubject, DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                // find the macro grade type of the micro grade
                // TODO take it from a Grade passed as parameter 
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idGradeTypeParent " +
                    "FROM GradeTypes " +
                    "WHERE idGradeType='" + IdGradeType + "'; ";
                string idGradeTypeParent = (string)cmd.ExecuteScalar();

                string query = "SELECT Grades.idGrade,Students.idStudent,lastName,firstName" +
                ",SUM(Grades.weight)/100 AS 'GradesFraction', 1 - SUM(Grades.weight)/100 AS LeftToCloseAssesments" +
                ",COUNT() AS 'GradesCount'" +
                " FROM Grades, Grades AS Parents " +
                " JOIN Classes_Students ON Students.idStudent=Grades.idStudent" +
                " JOIN Students ON Classes_Students.idStudent=Students.idStudent" +
                " WHERE Classes_Students.idClass =" + Class.IdClass +
                " AND Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                " AND (Grades.idGradeType='" + IdGradeType + "'" +
                " OR Grades.idGradeType IS NULL)" +
                " AND Grades.idSchoolSubject='" + IdSchoolSubject + "'" +
                " AND Grades.value IS NOT NULL AND Grades.value <> 0" +
                " AND Grades.Timestamp BETWEEN " + SqlVal.SqlDate(DateFrom) + " AND " + SqlVal.SqlDate(DateTo) +
                " AND Parents.idGradeType = '" + idGradeTypeParent + "'" +
                " AND Grades.idGradeParent = Parents.idGrade" +
                " AND (Parents.Value is null or Parents.Value = 0)" +
                " AND NOT Students.disabled" +
                " GROUP BY Students.idStudent" +
                " ORDER BY GradesFraction ASC, lastName, firstName, Students.idStudent;";

                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("ClosedMicroGrades");

                DAdapt.Fill(DSet);
                t = DSet.Tables[0];

                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }
        internal bool IsTopicAlreadyTaught(Topic Topic)
        {
            using (DbConnection conn = dl.Connect())
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
        internal Question GetQuestionById(int? IdQuestion)
        {
            Question question = new Question();
            if (IdQuestion == 0)
            {
                question.IdQuestion = 0;
                question.Text = "";
                return question;
            }
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM Questions " +
                    "WHERE idQuestion=" + IdQuestion.ToString() +
                    ";";
                dRead = cmd.ExecuteReader();
                while (dRead.Read()) // we cycle even if we need just a row, to check if it exists
                {
                    question.IdQuestion = (int)dRead["idQuestion"];
                    question.IdQuestionType = dRead["idQuestionType"].ToString();
                    question.Text = dRead["text"].ToString();
                    question.QuestionImage = dRead["image"].ToString();
                    question.Difficulty = (int)dRead["difficulty"];
                    question.Duration = (int)dRead["duration"];
                    question.IdSchoolSubject = dRead["idSchoolSubject"].ToString();
                    question.IdTopic = (int)dRead["idTopic"];
                    question.Image = dRead["image"].ToString();
                    question.Weight = (double)dRead["weight"];
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return question;
        }
        internal void SaveQuestion(Question Question)
        {
            using (DbConnection conn = dl.Connect())
            {
                string imageNoHome = Question.Image;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Questions " +
                    "SET idQuestionType='" + SqlVal.SqlString(Question.IdQuestionType) + "' " +
                     ", idSchoolSubject='" + SqlVal.SqlString(Question.IdSchoolSubject) + "' " +
                     //", idSubject=" + Question.IdSubject + " " +
                     ", idSchoolSubject='" + Question.IdSchoolSubject + "'" +
                     ", idTopic=" + Question.IdTopic + " " +
                     ", duration=" + Question.Duration + " " +
                     ", difficulty=" + Question.Difficulty + " " +
                     ", text='" + SqlVal.SqlString(Question.Text) + "' " +
                     ", image='" + SqlVal.SqlString(imageNoHome) + "' " +
                     ", weight=" + SqlVal.SqlDouble(Question.Weight.ToString()) + " " +
                    "WHERE idQuestion=" + Question.IdQuestion +
                    ";";
                cmd.ExecuteNonQuery();
                // !!!!TODO sistemare le risposte
                // !!!!TODO gestire i tag
                cmd.Dispose();
            }
        }
        internal DataTable GetFilteredQuestions(List<Tag> Tags, string IdSchoolSubject,
            string IdQuestionType, Topic QuestionsTopic, bool QueryManyTopics, bool TagsAnd)
        {
            DataTable t;

            string subquery = MakeStringForFilteredQuestionsQuery(Tags, IdSchoolSubject, IdQuestionType, QuestionsTopic, QueryManyTopics, TagsAnd);
            string query = "SELECT Questions.IdQuestion,Questions.text,Questions.idSchoolSubject,Questions.idQuestionType" +
                            ",Questions.weight,Questions.duration,Questions.difficulty,Questions.image,Questions.idTopic" +
                            " FROM Questions" +
                            " WHERE Questions.IdQuestion IN(" + subquery + ")" +
                            " ORDER BY Questions.IdQuestion;";
            DataSet DSet;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DSet = new DataSet("FilteredQuestions");
                DAdapt.Fill(DSet);
                DAdapt.Dispose();
                t = DSet.Tables[0];
                DSet.Dispose();
            }
            return t;
        }
        /// <summary>
        /// gets the questions regarding the topics taught to the class that 
        /// haven't been made to the student yet. 
        /// Includes also the questions tha do not have a topic 
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Student"></param>
        /// <param name="Subject"></param>
        /// <returns></returns>
        internal List<Question> GetFilteredQuestionsNotAsked(Student Student, Class Class,
            SchoolSubject Subject, string IdQuestionType, List<Tag> Tags, Topic Topic,
            bool QueryManyTopics, bool TagsAnd, string SearchString,
            DateTime DateFrom, DateTime DateTo)
        {
            List<Question> lq = new List<Question>();
            string filteredQuestions;

            // first part of the query: selection of the interesting fields in Questions
            string query = "SELECT Questions.IdQuestion,Questions.text,Questions.idSchoolSubject,Questions.idQuestionType" +
                ",Questions.weight,Questions.duration,Questions.difficulty,Questions.image,Questions.idTopic" +
                " FROM Questions";
            // add the WHERE clauses
            // if the search string is present, then it must be in the searched field 
            if (SearchString != "")
            {
                query += " WHERE Questions.text LIKE('%" + SqlVal.SqlString(SearchString) + "%')" +
                    "AND (";
            }
            if (Subject != null)
                filteredQuestions = MakeStringForFilteredQuestionsQuery(Tags, Subject.IdSchoolSubject, IdQuestionType,
                    Topic, QueryManyTopics, TagsAnd);
            else
                filteredQuestions = MakeStringForFilteredQuestionsQuery(Tags, "", IdQuestionType,
                    Topic, QueryManyTopics, TagsAnd);

            string questionsAlreadyMade = "";
            if (Student != null)
            {
                questionsAlreadyMade = "SELECT Questions.idQuestion" +
                    " FROM Questions" +
                    " JOIN Grades ON Questions.idQuestion=Grades.idQuestion" +
                    " JOIN Students ON Students.idStudent=Grades.IdStudent" +
                    " WHERE Students.idStudent=" + Student.IdStudent +
                    " AND Grades.idSchoolYear='" + Class.SchoolYear + "'";
            }
            string questionsTopicsMade = "";
            if (Class != null && Subject != null)
            {
                // questions made to the class in every time ever 
                questionsTopicsMade = "SELECT Questions.idQuestion" +
                    " FROM Questions" +
                    " JOIN Lessons_Topics ON Questions.idTopic=Lessons_Topics.idTopic" +
                    " JOIN Lessons ON Lessons_Topics.idLesson=Lessons.idLesson" +
                    " JOIN Classes ON Classes.idClass=Lessons.idClass" +
                    " WHERE Classes.idClass=" + Class.IdClass +
                    " AND (Questions.idSchoolSubject='" + Subject.IdSchoolSubject + "'" +
                    " OR Questions.idSchoolSubject='' OR Questions.idSchoolSubject=NULL)";
                if (DateFrom != Commons.DateNull)
                    questionsTopicsMade += " AND (Lessons.Date BETWEEN " + SqlVal.SqlDate(DateFrom) + " AND " + SqlVal.SqlDate(DateTo) + ")";
                // PART of the final query that extracts the Ids of the questions already made 
                questionsTopicsMade = " Questions.idQuestion IN(" + questionsTopicsMade + ")";
            }

            if (questionsAlreadyMade != "")
            {
                // take only questions already made 
                if (SearchString == "")
                {
                    query += " WHERE Questions.idQuestion NOT IN(" + questionsAlreadyMade + ")";
                }
                else
                {
                    query += " Questions.idQuestion NOT IN(" + questionsAlreadyMade + ")";
                }
            }
            if (filteredQuestions != "")
            {
                if (questionsAlreadyMade != "" || SearchString != "")
                {
                    query += " AND Questions.idQuestion IN(" + filteredQuestions + ")";
                }
                else
                {
                    query += " WHERE Questions.idQuestion IN(" + filteredQuestions + ")";
                }
            }
            query += " OR Questions.idTopic IS NULL OR Questions.idTopic = ''";
            if (SearchString != "")
                query += ")";

            query += " ORDER BY Questions.weight;";

            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = query;

                dRead = cmd.ExecuteReader();
                while (dRead.Read()) // 
                {
                    Question questionForList = new Question();

                    questionForList.Difficulty = (int)dRead["difficulty"];
                    questionForList.Duration = (int)dRead["duration"];
                    questionForList.IdQuestion = (int)dRead["idQuestion"];
                    questionForList.IdQuestionType = dRead["idQuestionType"].ToString();
                    questionForList.IdSchoolSubject = dRead["idSchoolSubject"].ToString();
                    //q.idSubject = (int)dRead["idSubject"];
                    questionForList.IdTopic = (int)dRead["idTopic"];
                    questionForList.Image = dRead["image"].ToString();
                    questionForList.QuestionImage = dRead["image"].ToString();
                    questionForList.Text = dRead["text"].ToString();
                    questionForList.Weight = (double)dRead["weight"];

                    lq.Add(questionForList);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return lq;
        }
        private string MakeStringForFilteredQuestionsQuery(List<Tag> Tags, string IdSchoolSubject,
            string IdQuestionType, Topic QuestionsTopic, bool QueryManyTopics, bool TagsAnd)
        {
            string query = "SELECT DISTINCT Questions.idQuestion" +
                            " FROM Questions";
            if (Tags != null && Tags.Count > 0)
            {
                // must join info from table Questions_Tags
                string queryTags = " JOIN Questions_Tags ON Questions.idQuestion=Questions_Tags.idQuestion";

                // make an IN clause, useful for both queries
                string InClause = " WHERE Questions_Tags.idTag IN(";
                foreach (Tag tag in Tags)
                {
                    InClause += "" + tag.IdTag.ToString() + ",";
                }
                InClause = InClause.Substring(0, InClause.Length - 1);
                InClause += ")";

                // (se http://howto.philippkeller.com/2005/04/24/Tags-Database-schemas/, "Toxi" solution)
                if (!TagsAnd)
                {
                    // The tags are evaluated in Union (OR) 
                    // limits the query only to those questions that have been associated to at least one of the tags in the list
                    queryTags += InClause;
                }
                else
                {
                    // The tags are in intersection (AND) 
                    queryTags += InClause;
                    queryTags += " GROUP BY Questions.idQuestion";
                    queryTags += " HAVING COUNT(Questions.idQuestion)=" + Tags.Count;
                }
                query += queryTags;
            }
            if (IdSchoolSubject != "")
            {
                // if we have already added the SQL for tags, we don't need a where
                if (Tags != null && Tags.Count > 0)
                    query += " AND idSchoolSubject ='" + SqlVal.SqlString(IdSchoolSubject) + "'";
                else
                    query += " WHERE idSchoolSubject ='" + SqlVal.SqlString(IdSchoolSubject) + "'";
            }
            if (IdQuestionType != null && IdQuestionType != "")
            {
                if (IdSchoolSubject != "" || Tags.Count > 0)
                    query += " AND idQuestionType ='" + SqlVal.SqlString(IdQuestionType) + "'";
                else
                    query += " WHERE idQuestionType ='" + SqlVal.SqlString(IdQuestionType) + "'";
            }
            if (QuestionsTopic != null)
            {
                if (!QueryManyTopics)
                {
                    if (IdSchoolSubject != "" || Tags.Count > 0 || IdQuestionType != "")
                        query += " AND idTopic=" + QuestionsTopic.Id + "";
                    else
                        query += " WHERE idTopic=" + QuestionsTopic.Id + "";
                }
                else
                {
                    string queryApplicableTopics = "SELECT idTopic FROM Topics" +
                        " WHERE Topics.leftNode BETWEEN " + QuestionsTopic.LeftNodeOld +
                        " AND " + QuestionsTopic.RightNodeOld;
                    // query the passed Topic, plus all its descendants in the tree
                    if (IdSchoolSubject != "" || Tags.Count > 0 || IdQuestionType != "")
                        query += " AND Questions.IdTopic IN (" + queryApplicableTopics + ")";
                    else
                        query += " WHERE Questions.IdTopic IN (" + queryApplicableTopics + ")";
                }
            }
            return query;
        }
        internal Question CreateNewVoidQuestion()
        {
            // trova una chiave da assegnare alla nuova domanda
            Question q = new Question();
            q.IdQuestion = NextKey("Questions", "idQuestion");
            using (DbConnection conn = dl.Connect())
            {
                string imageSenzaHome = q.Image;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Questions " +
                    "(idQuestion) " +
                    "Values (" + q.IdQuestion + ")" +
                     ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            SaveQuestion(q);
            return q;
        }
        private Question GetQuestionFromRow(DbDataReader Row)
        {
            Question q = new Question();
            q.Difficulty = SafeDb.SafeInt(Row["Difficulty"]);
            q.IdImage = SafeDb.SafeInt(Row["IdImage"]);
            q.Duration = SafeDb.SafeInt(Row["Duration"]);
            q.IdQuestion = SafeDb.SafeInt(Row["IdQuestion"]);
            q.IdQuestionType = SafeDb.SafeString(Row["IdQuestionType"]);
            q.IdSchoolSubject = SafeDb.SafeString(Row["IdSchoolSubject"]);
            //q.IdSubject = SafeDb.SafeInt(Row["IdSubject"]);
            q.IdTopic = SafeDb.SafeInt(Row["IdTopic"]);
            q.Image = SafeDb.SafeString(Row["Image"]);
            q.Text = SafeDb.SafeString(Row["Text"]);
            q.Weight = SafeDb.SafeDouble(Row["Weight"]);
            q.NRows = SafeDb.SafeInt(Row["nRows"]);
            q.IsParamount = SafeDb.SafeInt(Row["isParamount"]);
            ////////q.IsFixed = SafeDb.SafeBool(Row["isFixed"]);

            return q;
        }
    }
}
