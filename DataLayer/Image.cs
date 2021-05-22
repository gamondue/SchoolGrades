﻿using System;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using gamon;
using System.Windows.Forms;
using SchoolGrades;
using SchoolGrades.DbClasses;

namespace SchoolGrades.DataLayer
{
    class Image
    {
        DataLayer dl = new DataLayer();

        int? idImage;
        string imagePath;
        string caption;
        public string Caption { get => caption; set => caption = value; }
        public string RelativePathAndFilename { get => imagePath; set => imagePath = value; }
        public int? IdImage { get => idImage; set => idImage = value; }

        internal List<Image> GetAllImagesShownToAClassDuringLessons(Class Class, SchoolSubject Subject,
                        DateTime DateStart = default(DateTime), DateTime DateFinish = default(DateTime))
        {
            List<Image> images = new List<Image>();

            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = dl.Connect())
            {
                cmd = conn.CreateCommand();
                string query;
                query = "SELECT * FROM Images" +
                        " JOIN Lessons_Images ON Images.idImage=Lessons_Images.idImage" +
                        " JOIN Lessons ON Lessons.idLesson=Lessons_Images.idLesson" +
                        " WHERE Lessons.idClass=" + Class.IdClass +
                        " AND Lessons.idSchoolSubject='" + Subject.IdSchoolSubject + "'";
                if (DateStart != default(DateTime) && DateFinish != default(DateTime))
                    query += " AND Lessons.date BETWEEN " +
                    SqlVal.SqlDate(DateStart) + " AND " + SqlVal.SqlDate(DateFinish);
                query += ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Image i = new Image();
                    i.IdImage = (int)dRead["IdImage"];
                    i.Caption = (string)dRead["Caption"];
                    i.RelativePathAndFilename = (string)dRead["ImagePath"];

                    images.Add(i);
                }
                cmd.Dispose();
                dRead.Dispose();
            }
            return images;
        }

        internal List<string> GetCaptionsOfThisImage(string FileName)
        {
            List<string> captions = new List<string>();

            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = dl.Connect())
            {
                cmd = conn.CreateCommand();
                string query;
                query = "SELECT Caption FROM Images" +
                        " WHERE imagePath LIKE '%" + FileName + "%'";
                query += ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    captions.Add((string)dRead["Caption"]);
                }
                cmd.Dispose();
                dRead.Dispose();
            }
            return captions;
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

        internal void SaveImage(Image Image)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query;
                query = "UPDATE Images" +
                    " SET caption='" + SqlVal.SqlString(Image.Caption) + "'" +
                    " WHERE idImage=" +
                    Image.IdImage +
                    ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
        }

        internal Image FindImageWithGivenFile(string PathAndFileNameOfImage)
        {
            Image i = new Image();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                DbDataReader dRead;
                string query;
                query = "SELECT * FROM Images" +
                        " WHERE Images.imagePath='" +
                        SqlVal.SqlString(PathAndFileNameOfImage.Remove(0, Commons.PathImages.Length + 1)) +
                        "';";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                dRead.Read(); // just one record ! 
                if (!dRead.HasRows)
                    return null;
                i.IdImage = (int)dRead["IdImage"];
                i.Caption = (string)dRead["Caption"];
                i.RelativePathAndFilename = (string)dRead["ImagePath"];
                cmd.Dispose();
                dRead.Dispose();
            }
            return i;
        }

        private void ChangeImagesPath(Class Class, DbConnection conn)
        {
            DbDataReader dRead;
            DbCommand cmd = conn.CreateCommand();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Images.idImage, Images.imagePath" +
                " FROM Images" +
                " JOIN Lessons_Images ON Images.idImage=Lessons_Images.idImage" +
                " JOIN Lessons ON Lessons.idLesson = Lessons_Images.idLesson" +
                " WHERE Lessons.idClass=" + Class.IdClass +
            ";";
            dRead = cmd.ExecuteReader();
            string newFolder = Class.SchoolYear + Class.Abbreviation;
            while (dRead.Read())
            {
                string path = SafeDb.SafeString(dRead["imagePath"]);
                int? id = SafeDb.SafeInt(dRead["idImage"]);
                string partToReplace = path.Substring(0, path.IndexOf("\\"));
                path = path.Replace(partToReplace, newFolder);
                SaveImagePath(id, path, conn);
            }
            cmd.Dispose();
        }

        private void SaveImagePath(int? id, string path, DbConnection conn)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Images" +
            " SET imagePath='" + SqlVal.SqlString(path) + "'" +
            " WHERE idImage=" + id +
            ";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }
}
