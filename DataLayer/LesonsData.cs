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
    class LesonsData
    {
        DataLayer dl = new DataLayer();

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

        internal List<Image> GetLessonsImagesList(Lesson Lesson)
        {
            if (Lesson.IdLesson == null)
                return null;

            List<Image> imagesOfTheLesson = new List<Image>();

            using (DbConnection conn = dl.Connect())
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
        internal int? LinkOneImage(Image Image, Lesson Lesson)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query;
                if (Image.IdImage == 0)
                {
                    Image.IdImage = NextKey("Images", "IdImage");
                    query = "INSERT INTO Images" +
                    " (idImage, imagePath, caption)" +
                    " Values (" + Image.IdImage + ",'" +
                    SqlVal.SqlString(Image.RelativePathAndFilename) + "','" +
                    SqlVal.SqlString(Image.Caption) + "'" +
                    ");";
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

        internal void RemoveImageFromLesson(Lesson Lesson, Image Image,
            bool AlsoEraseImageFile)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query;
                query = "DELETE FROM Lessons_Images" +
                    " WHERE idImage=" +
                    Image.IdImage +
                    ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                if (AlsoEraseImageFile)
                {

                    query = "DELETE FROM Images" +
                        " WHERE idImage=" +
                        Image.IdImage +
                        ";";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    try
                    {
                        File.Delete(Commons.PathImages + "\\" + Image.RelativePathAndFilename);
                    }
                    catch (Exception ex)
                    {
                        Commons.ErrorLog("DbLayer|RemoveImageFromLesson|" +
                            Commons.PathImages + "\\" + Image.RelativePathAndFilename +
                            ".\r\n" + ex.Message + ex.StackTrace, true);
                    }
                }
                cmd.Dispose();
            }
        }

    }
}
