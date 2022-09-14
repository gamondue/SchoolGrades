using System;
using System.Collections.Generic;
using SchoolGrades.BusinessObjects;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal Lesson GetLessonFromRow(DbDataReader dRead)
        {
            Lesson l = new Lesson();
            l.IdLesson = Safe.Int(dRead["IdLesson"]);
            l.Date = Safe.DateTime(dRead["Date"]);
            l.IdClass = Safe.Int(dRead["IdClass"]);
            l.IdSchoolSubject = Safe.String(dRead["IdSchoolSubject"]);
            l.IdSchoolYear = Safe.String(dRead["IdSchoolYear"]);
            l.Note = Safe.String(dRead["Note"]);

            return l;
        }
        internal int NewLesson(Lesson Lesson)
        {
            int key;
            using (DbConnection conn = Connect())
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
                "," + SqlDate(Lesson.Date) + "" +
                "," + Lesson.IdClass + "" +
                ",'" + Lesson.IdSchoolSubject + "'" +
                ",'" + Lesson.IdSchoolYear + "'" +
                "," + SqlString(Lesson.Note) + "" +
                ");";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return key;
        }
        internal void SaveLesson(Lesson Lesson)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Lessons" +
                " SET" +
                " date=" + SqlDate(Lesson.Date) + "," +
                " idClass=" + Lesson.IdClass + "," +
                " idSchoolSubject='" + Lesson.IdSchoolSubject + "'," +
                " idSchoolYear='" + Lesson.IdSchoolYear + "'," +
                " note=" + SqlString(Lesson.Note) + 
                " WHERE idLesson=" + Lesson.IdLesson +
                ";";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
        }
        internal DataTable GetTopicsOfOneLessonOfClass(Class Class, Lesson Lesson)
        {
            DataTable t;
            using (DbConnection conn = Connect())
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
            using (DbConnection conn = Connect())
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
        internal List<Lesson> GetLessonsOfClass(Class Class, string IdSchoolSubject, 
            bool OrderByAscendingDate)
        {
            List<Lesson> lessons = new List<Lesson>();
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                Lesson l;
                string query = "SELECT * FROM Lessons" +
                    " WHERE idSchoolSubject='" + IdSchoolSubject + "'" +
                    " AND Lessons.idClass='" + Class.IdClass + "'" +
                    " ORDER BY Lessons.date";
                if (OrderByAscendingDate)
                    query += " ASC";
                else
                    query += " DESC";
                query += ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                l = new Lesson();
                while (dRead.Read())
                {
                    l = GetLessonFromRow(dRead);
                    lessons.Add(l);
                }
                cmd.Dispose();
                dRead.Dispose();
            }
            return lessons;
        }
        internal Lesson GetLastLesson(Lesson CurrentLesson)
        {
            using (DbConnection conn = Connect())
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
                    l = GetLessonFromRow(dRead);
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
            Lesson l = new Lesson();
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query;
                query = "SELECT * FROM Lessons" +
                        " WHERE idClass=" + Class.IdClass.ToString() +
                        " AND idSchoolSubject='" + IdSubject + "'" +
                        " AND date BETWEEN " + SqlDate(Date.ToString("yyyy-MM-dd")) +
                        " AND " + SqlDate(Date.AddDays(1).ToString("yyyy-MM-dd")) +
                        " LIMIT 1;";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    l = GetLessonFromRow(dRead);
                    break; // there should be only one record in the query result 
                }
                cmd.Dispose();
                dRead.Dispose();
            }
            return l;
        }
        internal void EraseLesson(int? IdLesson, bool AlsoEraseImageFiles)
        {
            using (DbConnection conn = Connect())
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
        internal List<Topic> GetTopicsOfLesson(int? IdLesson)
        {
            List<Topic> topicsOfTheLesson = new List<Topic>();
            if (IdLesson == null)
            {
                return null;
            }
            // order by ensures that the order of the result is the order of insertion 
            // in the database (that was the same of the tree traversal) 
            using (DbConnection conn = Connect())
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
        internal void SaveTopicsOfLesson(int? IdLesson, List<Topic> topicsOfTheLesson)
        {
            using (DbConnection conn = Connect())
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
        internal List<Image> GetLessonsImagesList(Lesson Lesson)
        {
            if (Lesson.IdLesson == null)
                return null;

            List<Image> imagesOfTheLesson = new List<Image>();

            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                DbDataReader dRead;
                string query;
                query = "SELECT * FROM Images" +
                        " JOIN Lessons_Images ON Images.idImage=Lessons_Images.idImage" +
                        " WHERE Lessons_Images.idLesson=" + Lesson.IdLesson +
                        ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Image i = new Image();
                    i.IdImage = (int)dRead["IdImage"];
                    i.Caption = (string)dRead["Caption"];
                    i.RelativePathAndFilename = (string)dRead["ImagePath"];

                    imagesOfTheLesson.Add(i);
                }
                cmd.Dispose();
                dRead.Dispose();
            }
            return imagesOfTheLesson;
        }
        /// <summary>
        /// Creates a new Image in Images and links it to the lesson
        /// If the image has an id != 0, it exists and is not created 
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="Lesson"></param>
        /// <returns></returns>
        internal int? LinkOneImageToLesson(Image Image, Lesson Lesson)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query;
                if (Image.IdImage == 0)
                {
                    Image.IdImage = NextKey("Images", "IdImage");
                    query = "INSERT INTO Images" +
                    " (idImage, imagePath, caption)" +
                    " Values (" + Image.IdImage + "," +
                    SqlString(Image.RelativePathAndFilename) + "," +
                    SqlString(Image.Caption) + "" +
                    ");";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    query = "UPDATE Images" +
                        " SET " +
                        " imagePath="+ SqlString(Image.RelativePathAndFilename) + "," +
                        " caption=" + SqlString(Image.Caption) + "" +
                        " WHERE idImage="+ Image.IdImage + 
                        ";";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                query = "INSERT INTO Lessons_Images" +
                    " (idImage, idLesson)" +
                    " Values (" + Image.IdImage + "," + Lesson.IdLesson + "" +
                    ");";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return Image.IdImage;
        }
        internal List<Topic> GetTopicsDoneInClassInPeriod(Class Class,
            SchoolSubject Subject,
            DateTime? DateStart, DateTime? DateFinish)
        {
            // node order according to Modified Preorder Tree Traversal algorithm
            List<Topic> l = new List<Topic>();
            using (DbConnection conn = Connect())
            {
                // find topics that are done in a lesson of given class about and given subject 
                //DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " JOIN Lessons_Topics ON Lessons_Topics.idTopic = Topics.idTopic " +
                    " JOIN Lessons ON Lessons_Topics.idLesson = Lessons.idLesson" +
                    " JOIN Classes ON Classes.idClass = Lessons.idClass" +
                    " WHERE Lessons.idClass = " + Class.IdClass +
                    " AND Lessons.idSchoolSubject ='" + Subject.IdSchoolSubject + "'";
                if (DateStart != null && DateFinish != null)
                    query += " AND Lessons.date BETWEEN " +
                    SqlDate(DateStart) + " AND " + SqlDate(DateFinish);
                query += " ORDER BY Lessons.date ASC;";
                DbCommand cmd = new SQLiteCommand(query);
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
    }
}
