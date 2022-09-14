using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
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
        internal int? UpdateAnnotationsGroup(StudentAnnotation currentAnnotation, Student currentStudent)
        {
            throw new NotImplementedException();
        }
        internal void EraseAnnotationByText(string AnnotationText, Student Student)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                    " WHERE annotation=" + SqlString(AnnotationText) + "" +
                    " AND idStudent=" + SqlInt(Student.IdStudent) +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal int? SaveAnnotation(StudentAnnotation Annotation, Student s)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "";
                if (Annotation.IdAnnotation != null && Annotation.IdAnnotation != 0)
                {
                    query = "UPDATE StudentsAnnotations" +
                    " SET" +
                    " idStudent=" + SqlInt(s.IdStudent) + "," +
                    " idSchoolYear=" + SqlString(Annotation.IdSchoolYear) + "," +
                    " instantTaken=" + SqlDate(Annotation.InstantTaken) + "," +
                    " instantClosed=" + SqlDate(Annotation.InstantClosed) + "," +
                    " isActive=" + SqlBool(Annotation.IsActive) + ",";
                    if (FieldExists("StudentsAnnotations", "isPopUp"))
                        query += " isPopUp=" + SqlBool(Annotation.IsPopUp) + ",";
                    query += " annotation=" + SqlString(Annotation.Annotation) + "" +
                    " WHERE idAnnotation=" + SqlInt(Annotation.IdAnnotation) + 
                    ";";
                }
                else
                {
                    Annotation.InstantTaken = DateTime.Now;
                    Annotation.IsActive = true;
                    // create an annotation on database
                    int? nextId = NextKey("StudentsAnnotations", "IdAnnotation");
                    Annotation.IdAnnotation = nextId;

                    query = "INSERT INTO StudentsAnnotations " +
                    "(idAnnotation, idStudent, annotation,instantTaken," +
                    "instantClosed,isActive";
                    if (FieldExists("StudentsAnnotations", "isPopUp"))
                        query += ",isPopUp"; 
                    if (Annotation.IdSchoolYear != null && Annotation.IdSchoolYear != "")
                        query += ",idSchoolYear";
                    query += ")";
                    query += " Values(";
                    query += "" + SqlInt(Annotation.IdAnnotation) + ",";
                    query += "" + SqlInt(s.IdStudent) + ",";
                    query += "" + SqlString(Annotation.Annotation) + "";
                    query += "," + SqlDate(Annotation.InstantTaken);
                    query += "," + SqlDate(Annotation.InstantClosed);
                    query += "," + SqlBool(Annotation.IsActive);
                    if (FieldExists("StudentsAnnotations", "isPopUp"))
                        query += "," + SqlBool(Annotation.IsPopUp);
                    if (Annotation.IdSchoolYear != null && Annotation.IdSchoolYear != "")
                        query += "," + SqlString(Annotation.IdSchoolYear) + "";
                    query += ");";
                }
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return Annotation.IdAnnotation;
        }
        internal StudentAnnotation GetAnnotation(int? IdAnnotation)
        {
            StudentAnnotation a;
            if (IdAnnotation == null)
                return null;
            a = new StudentAnnotation();
            using (DbConnection conn = Connect())
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
            a.IdAnnotation = Safe.Int(Row["idAnnotation"]);
            a.IdStudent = Safe.Int(Row["idStudent"]);
            a.IdSchoolYear = Safe.String(Row["idSchoolYear"]);
            a.Annotation = Safe.String(Row["annotation"]);
            a.InstantTaken = Safe.DateTime(Row["instantTaken"]);
            a.InstantClosed = Safe.DateTime(Row["instantClosed"]);
            a.IsActive = Safe.Bool(Row["isActive"]);
             
            // the program must work also with old versions of database 
            if(FieldExists("StudentsAnnotations", "isPopUp"))
            {
                a.IsPopUp = Safe.Bool(Row["isPopUp"]);
            }
            return a;
        }
        internal void EraseAnnotationById(int? IdAnnotation)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                    " WHERE idAnnotation=" + SqlInt(IdAnnotation) +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal DataTable GetAnnotationsOfClasss(int? IdClass, 
            bool IncludeAlsoNonActive, bool IncludeJustPopUp)
        {
            DataTable table = new DataTable(); 
            using (DbConnection conn = Connect())
            {
                DataAdapter dAdapter;
                DataSet dSet = new DataSet();
                string query = "SELECT Students.lastName, Students.firstName, StudentsAnnotations.annotation" +
                    ",Students.IdStudent, StudentsAnnotations.IdAnnotation" +
                    " FROM StudentsAnnotations" +
                    " JOIN Students ON Students.idStudent = StudentsAnnotations.idStudent" +
                    " JOIN Classes_Students ON Classes_Students.idStudent = Students.idStudent" +
                    " WHERE Classes_Students.idClass=" + IdClass; 
                if (!IncludeAlsoNonActive)
                    query += " AND isActive=true";
                // !!!! TODO avoid to check field existence after some versions
                // (made to avoid breaking the code with an old database) !!!!
                if (IncludeJustPopUp && FieldExists("StudentsAnnotations", "isPopUp")) 
                    query += " AND isPopUp=true";
                query += ";";
                dAdapter = new SQLiteDataAdapter(query, (System.Data.SQLite.SQLiteConnection)conn);

                dAdapter.Fill(dSet);
                table = dSet.Tables[0];

                dAdapter.Dispose();
                dSet.Dispose();
            }
            return table;
        }
    }
}
