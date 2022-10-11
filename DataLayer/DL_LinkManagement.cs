using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal void UpdatePathStartLinkOfClass(Class currentClass, string text)
        {
            // !!!! currently not used, because pathStartLink field does not exist yet in the database !!!!
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Classes" +
                           " Set" +
                           " pathStartLink='" + text + "'" +
                           " WHERE IdClass=" + currentClass.IdClass +
                           ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal void AddLinkToOldPhoto(int? IdStudent, string IdPreviousSchoolYear, string IdNextSchoolYear)
        {
            using (DbConnection conn = Connect())
            {
                // get the code of the previous photo
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idStudentsPhoto" +
                    " FROM StudentsPhotos_Students" +
                    " WHERE idSchoolYear='" + IdPreviousSchoolYear + "'" +
                    " AND StudentsPhotos_Students.idStudent = " + IdStudent + "; ";
                int? idStudentsPhoto = (int?)cmd.ExecuteScalar();
                if (idStudentsPhoto != null)
                {
                    // add link to old photo
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO StudentsPhotos_Students " +
                    "(idStudent, idStudentsPhoto, idSchoolYear) " +
                    "Values (" +
                    "" + IdStudent + "" +
                    "," + idStudentsPhoto + "" +
                    ",'" + IdNextSchoolYear + "'" +
                    ");";
                    cmd.ExecuteNonQuery();
                }
                cmd.Dispose();
            }
        }
        internal int LinkOnePhoto(Student Student, Class Class, string RelativePathAndFilePhoto)
        {
            // find the key for next photo
            int keyPhoto = NextKey("StudentsPhotos", "idStudentsPhoto");
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // add the relative path of the photo to the StudentsPhotos table
                cmd.CommandText = "INSERT INTO StudentsPhotos " +
                "(idStudentsPhoto, photoPath)" +
                "Values " +
                "('" + keyPhoto + "'," + SqlString(RelativePathAndFilePhoto) +
                ");";
                cmd.ExecuteNonQuery();

                // erase all possible links of old photos from the StudentsPhotos_Students table
                cmd.CommandText = "DELETE FROM StudentsPhotos_Students " +
                    "WHERE idStudent=" + Student.IdStudent +
                    " AND idSchoolYear='" + Class.SchoolYear + "'" +
                    ";";
                cmd.ExecuteNonQuery();
                // add this photo to the StudentsPhotos_Students table 
                cmd.CommandText = "INSERT INTO StudentsPhotos_Students " +
                    "(idStudentsPhoto, idStudent, idSchoolYear) " +
                    "Values (" + keyPhoto + "," + Student.IdStudent + "," + SqlString(Class.SchoolYear) +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return keyPhoto;
        }
        internal int? SaveStartLink(int? IdStartLink, int? IdClass, string SchoolYear,
            string StartLink, string Desc)
        {
            try
            {
                using (DbConnection conn = Connect())
                {
                    DbCommand cmd = null;
                    cmd = conn.CreateCommand();
                    if (IdStartLink != null && IdStartLink != 0)
                    {
                        cmd.CommandText = "UPDATE Classes_StartLinks" +
                            " SET" +
                            " idClass=" + IdClass + "" +
                            ",startLink=" + SqlString(StartLink) + "" +
                            ",desc=" + SqlString(Desc) + "" +
                            " WHERE idStartLink=" + IdStartLink +
                            ";";
                    }
                    else
                    {
                        IdStartLink = NextKey("Classes_StartLinks", "IdStartLink");
                        cmd.CommandText = "INSERT INTO Classes_StartLinks" +
                            " (idStartLink,idClass,startLink,desc)" +
                            " VALUES " +
                            "(" +
                            IdStartLink +
                            "," + IdClass +
                            "," + SqlString(StartLink) + "" +
                            "," + SqlString(Desc) + "" +
                            ");";
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                Commons.ErrorLog("DbLayer.SaveStartLink: " + ex.Message);
                IdStartLink = null;
            }
            return IdStartLink;
        }
        internal void DeleteStartLink(Nullable<int> IdStartLink)
        {
            DbCommand cmd = null;
            try
            {
                using (DbConnection conn = Connect())
                {
                    cmd = conn.CreateCommand();
                    cmd.CommandText =  "DELETE FROM Classes_StartLinks" +
                            " WHERE idStartLink=" + IdStartLink +
                            ";";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                Commons.ErrorLog("DbLayer.SaveStartLink: " + ex.Message);
                IdStartLink = null;
                cmd.Dispose();
            }
        }
        internal List<StartLink> GetStartLinksOfClass(Class Class)
        {
            List<StartLink> listOfLinks = new List<StartLink>();
            if (Class == null || Class.IdClass == null)
                return listOfLinks; 
            DbDataReader dRead;
            DbCommand cmd;
            try
            {
                using (DbConnection conn = Connect())
                {
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT *" +
                        " FROM Classes_StartLinks" +
                        " WHERE idClass=" + Class.IdClass + "; ";
                    dRead = cmd.ExecuteReader();
                    while (dRead.Read())
                    {
                        StartLink l = new StartLink();
                        l.Link = Safe.String(dRead["startLink"]);
                        l.Desc = Safe.String(dRead["Desc"]);
                        l.IdClass = Safe.Int(dRead["IdClass"]);
                        l.IdStartLink = Safe.Int(dRead["IdStartLink"]);
                        listOfLinks.Add(l);
                    }
                    dRead.Dispose();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                Commons.ErrorLog("DbLayer.GetStartLinksOfClass: " + ex.Message);
            }
            return listOfLinks;
        }
    }
}
