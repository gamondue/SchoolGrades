using SchoolGrades.BusinessObjects;
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
            if (Subject.Desc != "" && Subject.Desc != null)
            {
                using (DbConnection conn = Connect())
                {
                    try
                    {
                        DbCommand cmd = conn.CreateCommand();
                        if (Subject.OldId != "" && Subject.OldId != null)
                        {
                            cmd.CommandText = "UPDATE SchoolSubjects " +
                                "SET" +
                                " Name=" + SqlString(Subject.Name) + "" +
                                ",Desc=" + SqlString(Subject.Desc) + "" +
                                ",Color=" + SqlInt(Subject.Color) + "" +
                                ",orderOfVisualization=" + SqlInt(Subject.OrderOfVisualization) + "" +
                                " WHERE idSchoolSubject=" + SqlString(Subject.IdSchoolSubject) + "" +
                                ";";
                        }
                        else
                        {
                            // !! TODO verify that the new code in not already taken !!


                            cmd.CommandText = "INSERT INTO SchoolSubjects " +
                                "(idSchoolSubject, name, desc, color,orderOfVisualization) " +
                                "Values (" + SqlString(Subject.IdSchoolSubject) + "," + SqlString(Subject.Name)
                                + "," + SqlString(Subject.Desc) + "," + SqlInt(Subject.Color) + "" +
                                 "," + SqlInt(Subject.OrderOfVisualization) + "" +
                                ");";
                        }
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    catch (Exception e)
                    {

                    }
                }
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
                    subject.Color = Safe.Int(dRead["Color"]);
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
                try
                {
                    query = "SELECT * FROM SchoolSubjects" +
                        " ORDER BY orderOfVisualization, name";
                    cmd = new SQLiteCommand(query);
                    cmd.Connection = conn;
                    dRead = cmd.ExecuteReader();
                    while (dRead.Read())
                    {
                        SchoolSubject subject = new SchoolSubject();
                        subject.IdSchoolSubject = dRead["IdSchoolSubject"].ToString();
                        subject.Name = dRead["Name"].ToString();
                        subject.Desc = dRead["Desc"].ToString();
                        subject.Color = Safe.Int(dRead["color"]);
                        subject.OrderOfVisualization = Safe.Int(dRead["orderOfVisualization"]);
                        subject.OldId = subject.IdSchoolSubject; // to check if the user changes IdSchoolSubject

                        lss.Add(subject);
                    }
                }
                catch
                {   // if database is old, dont use orderOfVisualization
                    query = "SELECT * FROM SchoolSubjects;";
                    cmd = new SQLiteCommand(query);
                    cmd.Connection = conn;
                    dRead = cmd.ExecuteReader();
                    while (dRead.Read())
                    {
                        SchoolSubject subject = new SchoolSubject();
                        subject.IdSchoolSubject = dRead["IdSchoolSubject"].ToString();
                        subject.Name = dRead["Name"].ToString();
                        subject.Desc = dRead["Desc"].ToString();
                        subject.Color = Safe.Int(dRead["color"]);
                        subject.OldId = subject.IdSchoolSubject; // to check if the user changes IdSchoolSubject

                        lss.Add(subject);
                    }
                }
            }
            cmd.Dispose();
            dRead.Dispose();
            return lss;
        }
        internal void EraseSchoolSubjectById(string IdSchoolSubject)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM SchoolSubjects" +
                    " WHERE idSchoolSubject=" + SqlString(IdSchoolSubject) +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
    }
}
