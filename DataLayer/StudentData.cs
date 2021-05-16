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
        internal void SaveStudentsAnswer(Student Student, Test Test, Answer Answer,
    bool StudentsBoolAnswer, string StudentsTextAnswer)
        {
            // TODO put this UI matter into form's code 
            if (Student == null)
            {
                MessageBox.Show("Scegliere un allievo");
                return;
            }
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // find if an answer has already been given
                int? IdStudentsAnswer = StudentHasAnswered(Answer.IdAnswer, Test.IdTest, Student.IdStudent);
                if (IdStudentsAnswer != null)
                {   // update answer
                    cmd.CommandText = "UPDATE StudentsAnswers" +
                    " SET idStudent=" + SqlVal.SqlInt(Student.IdStudent) + "," +
                    "idAnswer=" + SqlVal.SqlInt(Answer.IdAnswer) + "," +
                    "studentsBoolAnswer=" + SqlVal.SqlBool(StudentsBoolAnswer) + "," +
                    "studentsTextAnswer='" + SqlVal.SqlString(StudentsTextAnswer) + "'," +
                    "IdTest=" + SqlVal.SqlInt(Test.IdTest) +
                    "" +
                    " WHERE IdStudentsAnswer=" + Answer.IdAnswer +
                    ";";
                }
                else
                {   // create answer
                    int nextId = NextKey("StudentsAnswers", "IdStudentsAnswer");

                    cmd.CommandText = "INSERT INTO StudentsAnswers " +
                    "(idStudentsAnswer,idStudent,idAnswer,studentsBoolAnswer," +
                    "studentsTextAnswer,IdTest" +
                    ")" +
                    "Values " +
                    "(" + nextId + "," + SqlVal.SqlInt(Student.IdStudent) + "," +
                     SqlVal.SqlInt(Answer.IdAnswer) + "," + SqlVal.SqlBool(StudentsBoolAnswer) + ",'" +
                    SqlVal.SqlString(StudentsTextAnswer) + "'," +
                     SqlVal.SqlInt(Test.IdTest) +
                    ");";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        private int? StudentHasAnswered(int? IdAnswer, int? IdTest, int? IdStudent)
        {
            int? key;
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT idStudentsAnswer" +
                    " FROM StudentsAnswers" +
                    " WHERE idStudent=" + IdStudent +
                    " AND IdTest=" + IdTest + "" +
                    " AND IdAnswer=" + IdAnswer + "" +
                    ";";
                cmd.CommandText = query;
                //idStudentsAnswer cmd.ExecuteScalar() != null;
                key = (int?)cmd.ExecuteScalar();
            }
            return key;
        }
        internal List<StudentsAnswer> GetAllAnswersOfAStudentToAQuestionOfThisTest(
            int? IdStudent, int? IdQuestion, int? IdTest)
        {
            List<StudentsAnswer> list = new List<StudentsAnswer>();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM StudentsAnswers" +
                    " JOIN Answers ON Answers.idAnswer = StudentsAnswers.idAnswer" +
                    " JOIN Questions ON Questions.IdQuestion = Answers.IdQuestion" +
                    " JOIN Tests_Questions ON Questions.IdQuestion = Tests_Questions.IdQuestion" +
                    " WHERE StudentsAnswers.idStudent=" + IdStudent +
                    " AND Questions.IdQuestion=" + IdQuestion + "" +
                    " AND Tests_Questions.IdTest=" + IdTest + "" +
                    ";";

                cmd.CommandText = query;
                DbDataReader dRead;
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    StudentsAnswer a = GetStudentsAnswerFromRow(dRead);
                    list.Add(a);
                }
            }
            return list;
        }





        internal List<Answer> GetAllCorrectAnswersToThisQuestionOfThisTest(int? IdQuestion, int? IdTest)
        {
            List<Answer> list = new List<Answer>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT Answers.*" +
                    " FROM Answers" +
                    " JOIN Questions ON Questions.IdQuestion=Answers.IdQuestion" +
                    " JOIN Tests_Questions ON Questions.IdQuestion=Tests_Questions.IdQuestion" +
                    " WHERE Questions.IdQuestion=" + IdQuestion + "" +
                    " AND Tests_Questions.IdTest=" + IdTest + "" +
                    " ORDER BY idAnswer" +
                    ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Answer a = GetAnswerFromRow(dRead);
                    list.Add(a);
                }
            }
            return list;
        }

        internal Answer GetAnswerFromRow(DbDataReader Row)
        {
            Answer a = new Answer();
            a.IdAnswer = SafeDb.SafeInt(Row["IdAnswer"]);
            a.IdQuestion = SafeDb.SafeInt(Row["IdQuestion"]);
            a.ShowingOrder = SafeDb.SafeInt(Row["ShowingOrder"]);
            a.Text = SafeDb.SafeString(Row["Text"]);
            a.ErrorCost = SafeDb.SafeInt(Row["ErrorCost"]);
            a.IsCorrect = SafeDb.SafeBool(Row["IsCorrect"]);
            a.IsOpenAnswer = SafeDb.SafeBool(Row["IsOpenAnswer"]);
            a.IsMutex = SafeDb.SafeBool(Row["IsMutex"]);

            return a;
        }
    }
}
}
