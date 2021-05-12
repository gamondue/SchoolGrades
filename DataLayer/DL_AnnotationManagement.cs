using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal List<StudentAnnotation> AnnotationsAboutThisStudent(Student currentStudent, string IdSchoolYear,
            bool IncludeOnlyActiveAnnotations)
        {
            if (currentStudent == null)
                return null;
            List<StudentAnnotation> la = new List<StudentAnnotation>();
            using (DbConnection conn = Connect())
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

        internal void EraseAnnotationByText(string AnnotationText, Student Student)
        {
            using (DbConnection conn = Connect())
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

        internal StudentAnnotation GetAnnotationFromRow(DbDataReader Row)
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

        internal void EraseAnnotationById(int? IdAnnotation)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                    " WHERE idAnnotation=" + SqlVal.SqlInt(IdAnnotation) +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
    }
}
