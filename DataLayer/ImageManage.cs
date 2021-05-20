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
    class ImageManage
    {
        //Andrea Siboni, Francesco Citarella, Cesare Colella, Riccardo Brunelli 4L

        DataLayer dl = new DataLayer();



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





    }
}
