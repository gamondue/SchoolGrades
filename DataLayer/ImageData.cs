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
    //Andrea Siboni, Francesco Citarella, Cesare Colella, Riccardo Brunelli 4L
    class ImageData
    {
        DataLayer dl = new DataLayer();

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

    }
}
