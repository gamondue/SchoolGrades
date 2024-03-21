using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;

namespace SchoolGrades
{
    internal partial class SqLite_DataLayer : DataLayer
    {
        internal override List<Image> GetAllImagesShownToAClassDuringLessons(Class Class, SchoolSubject Subject,
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
        internal override List<string> GetCaptionsOfThisImage(string FileName)
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
        internal override void EraseStudentsPhoto(int? IdStudent, string SchoolYear)
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
        internal override string GetFilePhoto(int? IdStudent, string SchoolYear)
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
        internal override void ChangeImagesPath(Class Class, DbCommand cmd)
        {
            // find 
            DbDataReader dRead;
            cmd.CommandText = "SELECT Images.idImage, Images.imagePath" +
                " FROM Images" +
                " JOIN Lessons_Images ON Images.idImage=Lessons_Images.idImage" +
                " JOIN Lessons ON Lessons.idLesson = Lessons_Images.idLesson" +
                " WHERE Lessons.idClass=" + Class.IdClass +
                " LIMIT 1" +
            ";";
            dRead = cmd.ExecuteReader();
            dRead.Read();
            string originalPath = Path.GetDirectoryName(Safe.String(dRead["imagePath"]));
            string originalFolder = originalPath.Substring(0, originalPath.IndexOf("\\"));
            dRead.Close();
            string newFolder = Class.SchoolYear + "_" + Class.Abbreviation;

            // replace the folder name in Images path 
            cmd.CommandText = "UPDATE Images" +
                " SET imagePath=REPLACE(Images.imagePath,'" + originalFolder + "','" + newFolder + "')" +
            " FROM Images Img" +
            " JOIN Lessons_Images ON Img.IdImage=Lessons_Images.idImage" +
            " JOIN Lessons ON Lessons.idLesson=Lessons_Images.idLesson" +
            " WHERE Lessons.idClass=" + Class.IdClass +
            ";";
            cmd.ExecuteNonQuery();
        }
        internal override void SaveImagePath(int? id, string path)
        {
            string query;
            using (DbConnection conn = Connect())
            {
                DbCommand cmd1 = conn.CreateCommand();
                query = "UPDATE Images" +
                " SET imagePath=" + SqlString(path) + "" +
                " WHERE idImage=" + id +
                ";";
                cmd1.CommandText = query;
                cmd1.ExecuteNonQuery();
            }
        }
        internal override int? SaveDemoStudentPhotoPath(string relativePath, DbCommand cmd)
        {
            int? nextId = null;
            try
            {
                cmd.CommandText = "SELECT MAX(idStudentsPhoto) FROM StudentsPhotos;";
                var firstColumn = cmd.ExecuteScalar();
                if (firstColumn != DBNull.Value)
                {
                    nextId = int.Parse(firstColumn.ToString()) + 1;
                }
                else
                {
                    nextId = 1;
                }
                cmd.CommandText = "INSERT INTO StudentsPhotos" +
                " (idStudentsPhoto, photoPath)" +
                " Values (" + SqlInt(nextId.ToString()) + "," + SqlString(relativePath) + ");";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            return nextId;
        }
        internal override void RemoveImageFromLesson(Lesson Lesson, Image Image, bool AlsoEraseImageFile)
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
        internal override void SaveImage(Image Image)
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
        internal override Image FindImageWithGivenFile(string PathAndFileNameOfImage)
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
        /// If the image has an nextId != 0, it exists and is not created 
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="Lesson"></param>
        /// <returns></returns>
        internal override int? LinkOneImage(Image Image, Lesson Lesson)
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
