using SchoolGrades.DbClasses;
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
        internal int CopyAndLinkOnePhoto(Student Student, Class Class, string PathAndFileName)
        {
            if (!File.Exists(PathAndFileName))
            {
                throw new FileNotFoundException(@"[" + PathAndFileName + " not found.]");
                //return 0;
            }
            if (File.Exists(PathAndFileName + "TEMP"))
            {
                File.Delete(PathAndFileName + "TEMP");
            }
            File.Copy(PathAndFileName, PathAndFileName + "TEMP");

            string ext = Path.GetExtension(PathAndFileName);
            string newFileName = Commons.PathImages + "\\" + Class.SchoolYear + Class.Abbreviation + "\\" +
                Student.LastName + "_" + Student.FirstName + "_" + Class.Abbreviation + Class.SchoolYear + ext;
            if (!Directory.Exists(Commons.PathImages + "\\" + Class.SchoolYear + Class.Abbreviation + "\\"))
            {
                Directory.CreateDirectory(Commons.PathImages + "\\" + Class.SchoolYear + Class.Abbreviation + "\\");
            }
            if (File.Exists(newFileName))
            {
                // !!!! TODO: resolve the problem of the lock that is still active here, 
                // !!!! despite many attempts to free it !!!!
                File.Delete(newFileName);
            }
            File.Move(PathAndFileName + "TEMP", newFileName);

            // trova la chiave per la prossima foto 
            int codiceFoto = NextKey("StudentsPhotos", "idStudentsPhoto");
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string PathFileImage = Class.SchoolYear + Class.Abbreviation + "\\" +
                    Student.LastName + "_" + Student.FirstName + "_" + Class.Abbreviation + Class.SchoolYear + ".jpg"; 
                // aggiunge la foto alle foto (cartella relativa, cui verrà aggiunta la path delle foto)
                cmd.CommandText = "INSERT INTO StudentsPhotos " +
                "(idStudentsPhoto, photoPath)" +
                "Values " +
                "('" + codiceFoto + "'," + SqlString(PathFileImage) +
                ");";
                cmd.ExecuteNonQuery();

                // cancella tutti gli eventuali riferimenti nella tabella link delle foto ad altre foto nell'anno 
                cmd.CommandText = "DELETE FROM StudentsPhotos_Students " +
                    "WHERE idStudent=" + Student.IdStudent +
                    " AND idSchoolYear='" + Class.SchoolYear + "'" +
                    ";";
                cmd.ExecuteNonQuery();
                // aggiunge questa foto alla tabella link delle foto
                cmd.CommandText = "INSERT INTO StudentsPhotos_Students " +
                    "(idStudentsPhoto, idStudent, idSchoolYear) " +
                    "Values (" + codiceFoto + "," + Student.IdStudent + "," + SqlString(Class.SchoolYear) +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return codiceFoto;
        }
        internal int? SaveStartLink(int? IdStartLink, int? IdClass, string SchoolYear,
            string StartLink, string Desc)
        {
            DbCommand cmd = null;
            try
            {
                using (DbConnection conn = Connect())
                {
                    cmd = conn.CreateCommand();
                    if (IdStartLink != null && IdStartLink != 0)
                    {
                        cmd.CommandText = "UPDATE Classes_StartLinks" +
                            " SET" +
                            //" idStartLink=" + IdStartLink +
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
                cmd.Dispose();
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
                    l.Desc= Safe.String(dRead["Desc"]);
                    l.IdClass = Safe.Int(dRead["IdClass"]);
                    l.IdStartLink = Safe.Int(dRead["IdStartLink"]);
                    listOfLinks.Add(l);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return listOfLinks;
        }
    }
}
