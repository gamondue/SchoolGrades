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
    class AnnotationData
    {
        DataLayer dl = new DataLayer();

        internal void EraseAnnotationByText(string AnnotationText, Student Student)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                    " WHERE annotation='" + SqlVal.SqlString(AnnotationText) + "'" +
                    " AND idStudent=" + SqlVal.SqlInt(Student.IdStudent) +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal void EraseAnnotationById(int? IdAnnotation)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                    " WHERE idAnnotation=" + SqlVal.SqlInt(IdAnnotation) +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal StudentAnnotation GetAnnotation(int? IdAnnotation)
        {
            StudentAnnotation a;
            if (IdAnnotation == null)
                return null;
            a = new StudentAnnotation();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM StudentsAnnotations" +
                    " WHERE IdAnnotation=" + IdAnnotation;
                query += ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                dRead.Read();
                a = GetAnnotationFromRow(dRead);
                cmd.Dispose();
            }
            return a;
        }
        private StudentAnnotation GetAnnotationFromRow(DbDataReader Row)
        {
            StudentAnnotation a = new StudentAnnotation();
            a.IdAnnotation = SafeDb.SafeInt(Row["idAnnotation"]);
            a.IdStudent = SafeDb.SafeInt(Row["idStudent"]);
            a.IdSchoolYear = SafeDb.SafeString(Row["idSchoolYear"]);
            a.Annotation = SafeDb.SafeString(Row["annotation"]);
            a.InstantTaken = SafeDb.SafeDateTime(Row["instantTaken"]);
            a.InstantClosed = SafeDb.SafeDateTime(Row["instantClosed"]);
            a.IsActive = SafeDb.SafeBool(Row["isActive"]);
            return a;
        }

        internal int? SaveAnnotation(StudentAnnotation Annotation, Student s)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "";
                // find if an answer has already been given
                if (Annotation.IdAnnotation != null && Annotation.IdAnnotation != 0)
                {   // update answer
                    query = "UPDATE StudentsAnnotations" +
                    " SET" +
                    " idStudent=" + SqlVal.SqlInt(s.IdStudent) + "," +
                    " idSchoolYear='" + SqlVal.SqlString(Annotation.IdSchoolYear) + "'," +
                    " instantTaken=" + SqlVal.SqlDate(Annotation.InstantTaken) + "," +
                    " instantClosed=" + SqlVal.SqlDate(Annotation.InstantClosed) + "," +
                    " isActive=" + SqlVal.SqlBool(Annotation.IsActive) + "," +
                    " annotation='" + SqlVal.SqlString(Annotation.Annotation) + "'" +
                    " WHERE idStudent=" + SqlVal.SqlInt(s.IdStudent) +
                    ";";
                }
                else
                {
                    Annotation.InstantTaken = DateTime.Now;
                    Annotation.IsActive = true;
                    // create answer on database
                    int? nextId = NextKey("StudentsAnnotations", "IdAnnotation");
                    Annotation.IdAnnotation = nextId;

                    query = "INSERT INTO StudentsAnnotations " +
                    "(idAnnotation, idStudent, annotation,instantTaken," +
                    "instantClosed,isActive";
                    if (Annotation.IdSchoolYear != null && Annotation.IdSchoolYear != "")
                        query += ",idSchoolYear";
                    query += ")";
                    query += " Values(";
                    query += "" + SqlVal.SqlInt(Annotation.IdAnnotation) + ",";
                    query += "" + SqlVal.SqlInt(s.IdStudent) + ",";
                    query += "'" + SqlVal.SqlString(Annotation.Annotation) + "'";
                    query += "," + SqlVal.SqlDate(Annotation.InstantTaken);
                    query += "," + SqlVal.SqlDate(Annotation.InstantClosed);
                    query += "," + SqlVal.SqlBool(Annotation.IsActive);
                    if (Annotation.IdSchoolYear != null && Annotation.IdSchoolYear != "")
                        query += ",'" + SqlVal.SqlString(Annotation.IdSchoolYear) + "'";
                    query += ");";
                }
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return Annotation.IdAnnotation;
        }

        internal List<StudentAnnotation> AnnotationsAboutThisStudent(Student currentStudent, string IdSchoolYear,
            bool IncludeOnlyActiveAnnotations)
        {
            if (currentStudent == null)
                return null;
            List<StudentAnnotation> la = new List<StudentAnnotation>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM StudentsAnnotations" +
                    " WHERE StudentsAnnotations.idStudent=" + currentStudent.IdStudent;
                if (IdSchoolYear != null && IdSchoolYear != "")
                    query += " AND idSchoolYear=" + IdSchoolYear;
                if (IncludeOnlyActiveAnnotations)
                    query += " AND isActive=true";
                query += " ORDER BY instantTaken DESC, instantClosed DESC";
                query += ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    StudentAnnotation a = GetAnnotationFromRow(dRead);
                    la.Add(a);
                }
            }
            return la;
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
    }
}
