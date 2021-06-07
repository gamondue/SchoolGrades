using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Text;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal void SaveSubjects(List<SchoolSubject> SubjectList)
        {
            foreach (SchoolSubject s in SubjectList)
            {
                SaveSubject(s);
            }
        }

        internal string SaveSubject(SchoolSubject Subject)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                if (Subject.OldId != "" && Subject.OldId != null)
                {
                    cmd.CommandText = "UPDATE SchoolSubjects " +
                        "SET" +
                        " Name='" + SqlVal.SqlString(Subject.Name) + "'" +
                        ",Desc='" + SqlVal.SqlString(Subject.Desc) + "'" +
                        ",Color='" + SqlVal.SqlInt(Subject.Color) + "'" +
                        " WHERE idSchoolSubject='" + SqlVal.SqlString(Subject.IdSchoolSubject) + "'" +
                        ";";
                }
                else
                {
                    cmd.CommandText = "INSERT INTO SchoolSubjects " +
                        "(idSchoolSubject, name, desc, color) " +
                        "Values ('" + SqlVal.SqlString(Subject.IdSchoolSubject) + "','" + SqlVal.SqlString(Subject.Name)
                        + "','" + SqlVal.SqlString(Subject.Desc) + "'," + SqlVal.SqlInt(Subject.Color) + "" +
                        ");";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return Subject.IdSchoolSubject;
        }

        internal SchoolSubject GetSchoolSubject(string IdSchoolSubject)
        {
            SchoolSubject subject = new SchoolSubject();
            DbDataReader dRead;
            DbCommand cmd;
            string query;
            using (DbConnection conn = Connect())
            {
                query = "SELECT * FROM SchoolSubjects" +
                    " WHERE IdSchoolSubject='" + IdSchoolSubject + "'";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                while (dRead.Read()) // just the first row 
                {
                    subject.Name = dRead["Name"].ToString();
                    subject.Desc = dRead["Desc"].ToString();
                    subject.Color = (int)dRead["Color"];
                    subject.IdSchoolSubject = IdSchoolSubject;
                    subject.OldId = IdSchoolSubject;
                }
            }
            cmd.Dispose();
            dRead.Dispose();
            return subject;
        }

        internal List<SchoolSubject> GetListSchoolSubjects(bool IncludeANullObject)
        {
            List<SchoolSubject> lss = new List<SchoolSubject>();
            if (IncludeANullObject)
            {
                SchoolSubject ss = new SchoolSubject();
                ss.IdSchoolSubject = "";
                lss.Add(ss);
            }

            DbDataReader dRead;
            DbCommand cmd;
            string query;

            using (DbConnection conn = Connect())
            {
                query = "SELECT * FROM SchoolSubjects";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    SchoolSubject subject = new SchoolSubject();
                    subject.IdSchoolSubject = dRead["IdSchoolSubject"].ToString();
                    subject.OldId = dRead["IdSchoolSubject"].ToString();
                    subject.Name = dRead["Name"].ToString();
                    subject.Desc = dRead["Desc"].ToString();
                    subject.Color = SafeDb.SafeInt(dRead["color"]);

                    lss.Add(subject);
                }
            }
            cmd.Dispose();
            dRead.Dispose();
            return lss;
        }
    }
}
