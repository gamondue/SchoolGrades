using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal List<Image> GetAllImagesShownToAClassDuringLessons(Class Class, SchoolSubject Subject,
            DateTime DateStart = default(DateTime), DateTime DateFinish = default(DateTime))
        {
            List<Image> images = new List<Image>();

            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = Connect())
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
                    SqlDate(DateStart) + " AND " + SqlDate(DateFinish);
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
            using (DbConnection conn = Connect())
            {
                cmd = conn.CreateCommand();
                string query;
                query = "SELECT Caption FROM Images" +
                        " WHERE imagePath " + SqlLikeStatement(FileName) + "";
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
        internal void EraseStudentsPhoto(int? IdStudent, string SchoolYear)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsPhotos_Students" +
                    " WHERE idStudent=" + IdStudent +
                    " AND idSchoolYear='" + SchoolYear + "'" +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal string GetFilePhoto(int? IdStudent, string SchoolYear)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT StudentsPhotos.photoPath" +
                    " FROM StudentsPhotos_Students, StudentsPhotos" +
                    " WHERE StudentsPhotos_Students.idStudentsPhoto = StudentsPhotos.idStudentsPhoto";
                if (SchoolYear != null && SchoolYear != "")
                {
                    query += " AND (StudentsPhotos_Students.idSchoolYear='" + SchoolYear + "'" +
                        " OR StudentsPhotos_Students.idSchoolYear = '" + SchoolYear.Replace("-", "") + "'" + // !!!! temporary !!!!
                        ")";
                }
                query += " AND StudentsPhotos_Students.idStudent = " + IdStudent + "; ";
                string NamePath = null;
                try
                {
                    cmd.CommandText = query;
                    NamePath = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {

                }
                cmd.Dispose();
                return NamePath;
            }
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
            string newFolder = Class.SchoolYear + "_" + Class.Abbreviation;
            while (dRead.Read())
            {
                string path = Safe.String(dRead["imagePath"]);
                int? id = Safe.Int(dRead["idImage"]);
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
            " SET imagePath=" + SqlString(path) + "" +
            " WHERE idImage=" + id +
            ";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        private void SaveStudentsPhotosPath(int? id, string path, DbConnection conn)
        {
            if (id != null)
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE StudentsPhotos" +
                " SET photoPath=" + SqlString(path) + "" +
                " WHERE idStudentsPhoto=" + id +
                ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal void RemoveImageFromLesson(Lesson Lesson, Image Image, bool AlsoEraseImageFile)
        {
            // delete from the link table
            string query;
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                query = "DELETE FROM Lessons_Images" +
                    " WHERE idImage=" +
                    Image.IdImage +
                    ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                if (AlsoEraseImageFile)
                {
                    // delete from the Images table 
                    query = "DELETE FROM Images" +
                        " WHERE idImage=" +
                        Image.IdImage +
                        ";";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                cmd.Dispose();
            }

        }
        internal void SaveImage(Image Image)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query;
                query = "UPDATE Images" +
                    " SET caption=" + SqlString(Image.Caption) + "" + 
                    ", imagePath=" + SqlString(Image.RelativePathAndFilename) + "" +
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
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                DbDataReader dRead;
                string query;
                query = "SELECT * FROM Images" +
                        " WHERE Images.imagePath=" +
                        SqlString(PathAndFileNameOfImage.Remove(0, Commons.PathImages.Length + 1)) +
                        ";";
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
        /// <summary>
        /// Creates a new Image in Images and links it to the lesson
        /// If the image has an id != 0, it exists and is not created 
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="Lesson"></param>
        /// <returns></returns>
        internal int? LinkOneImage(Image Image, Lesson Lesson)
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
    }
}
