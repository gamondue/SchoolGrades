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
    class AnswersAndStudentData
    {
        DataLayer dl = new DataLayer();

        internal DataTable GetStudentsWithNoMicrogrades(Class Class, string IdGradeType, string IdSchoolSubject,
            DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                // find the macro grade type of the micro grade
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idGradeTypeParent " +
                    "FROM GradeTypes " +
                    "WHERE idGradeType='" + IdGradeType + "'; ";
                string idGradeTypeParent = (string)cmd.ExecuteScalar();

                string query = "SELECT Students.idStudent, LastName, FirstName FROM Students" +
                    " JOIN Classes_Students ON Students.idStudent=Classes_Students.idStudent" +
                    " WHERE Students.idStudent NOT IN" +
                    "(";
                query += "SELECT DISTINCT Students.idStudent" +
                " FROM Classes_Students" +
                " LEFT JOIN Grades ON Students.idStudent=Grades.idStudent" +
                " JOIN Students ON Classes_Students.idStudent=Students.idStudent" +
                " WHERE Classes_Students.idClass =" + Class.IdClass +
                " AND Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                " AND (Grades.idGradeType='" + IdGradeType + "'" +
                " OR Grades.idGradeType IS NULL)" +
                " AND Grades.idSchoolSubject='" + IdSchoolSubject + "'" +
                " AND Grades.value IS NOT NULL AND Grades.value <> 0" +
                " AND Grades.Timestamp BETWEEN " + SqlVal.SqlDate(DateFrom) + " AND " + SqlVal.SqlDate(DateTo) +
                ")";
                query += " AND Classes_Students.idClass=" + Class.IdClass;
                query += ";";
                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("ClosedMicroGrades");

                DAdapt.Fill(DSet);
                t = DSet.Tables[0];

                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }
        internal List<Student> GetAllStudentsThatAnsweredToATest(Test Test, Class Class)
        {
            List<Student> list = new List<Student>();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT DISTINCT StudentsAnswers.IdStudent" +
                    " FROM StudentsAnswers" +
                    " JOIN Classes_Students ON StudentsAnswers.IdStudent=Classes_Students.IdStudent" +
                    " JOIN Students ON Classes_Students.IdStudent=Students.IdStudent" +
                    " WHERE StudentsAnswers.IdTest=" + Test.IdTest + "" +
                    " AND Classes_Students.IdClass=" + Class.IdClass + "" +
                    " ORDER BY Students.LastName, Students.FirstName, Students.IdStudent " +
                    ";";
                cmd.CommandText = query;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    int? idStudent = SafeDb.SafeInt(dRead["idStudent"]);
                    Student s = GetStudent(idStudent);
                    list.Add(s);
                }
            }
            return list;
        }
        internal GradeType GetGradeType(string IdGradeType)
        {
            GradeType gt = null;
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM GradeTypes";
                cmd.CommandText += " WHERE idGradeType ='" + IdGradeType + "'";
                cmd.CommandText += ";";
                dRead = cmd.ExecuteReader();
                dRead.Read();
                gt = GetGradeTypeFromRow(dRead);
                dRead.Dispose();
                cmd.Dispose();
            }
            return gt;
        }
        private GradeType GetGradeTypeFromRow(DbDataReader Row)
        {
            if (Row.HasRows)
            {
                GradeType gt = new GradeType();
                gt.IdGradeType = (string)Row["idGradeType"];
                gt.IdGradeTypeParent = SafeDb.SafeString(Row["IdGradeTypeParent"]);
                gt.IdGradeCategory = (string)Row["IdGradeCategory"];
                gt.Name = (string)Row["Name"];
                gt.DefaultWeight = (double)Row["DefaultWeight"];
                gt.Desc = (string)Row["Desc"];
                return gt;
            }
            return null;
        }

        internal List<GradeType> GetListGradeTypes()
        {
            List<GradeType> lg = new List<GradeType>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM GradeTypes;";
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    GradeType gt = GetGradeTypeFromRow(dRead);
                    lg.Add(gt);
                }
                dRead.Dispose();
                cmd.Dispose();
                return lg;
            }
        }
        private void RandomizeGrades(DbConnection conn)
        {
            DbDataReader dRead;
            DbCommand cmd = conn.CreateCommand();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Grades" +
                ";";
            dRead = cmd.ExecuteReader();
            Random rnd = new Random();
            while (dRead.Read())
            {
                double? grade = SafeDb.SafeDouble(dRead["value"]);
                int? id = SafeDb.SafeInt(dRead["IdGrade"]);
                // add to the grade a random delta between -10 and +10 
                if (grade > 0)
                {
                    grade = grade + rnd.NextDouble() * 20 - 10;
                    if (grade < 10) grade = 10;
                    if (grade > 100) grade = 100;
                }
                else
                    grade = 0;
                SaveGradeValue(id, grade, conn);
            }
            cmd.Dispose();
        }

        private void SaveGradeValue(int? id, double? grade, DbConnection conn)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Grades" +
            " SET value=" + SqlVal.SqlDouble(grade) +
            " WHERE idGrade=" + id +
            ";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }
}
