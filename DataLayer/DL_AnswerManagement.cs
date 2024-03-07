using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal StudentsAnswer GetStudentsAnswerFromRow(DbDataReader Row)
        {
            StudentsAnswer a = new StudentsAnswer();
            a.IdAnswer = Safe.Int(Row["IdAnswer"]);
            a.IdStudent = Safe.Int(Row["IdStudent"]);
            a.IdStudentsAnswer = Safe.Int(Row["IdStudentsAnswer"]);
            a.IdTest = Safe.Int(Row["IdTest"]);
            a.StudentsBoolAnswer = Safe.Bool(Row["StudentsBoolAnswer"]);
            a.StudentsTextAnswer = Safe.String(Row["StudentsTextAnswer"]);

            return a;
        }
        internal List<StudentsAnswer> GetAllAnswersOfAStudentToAQuestionOfThisTest(
            int? IdStudent, int? IdQuestion, int? IdTest)
        {
            List<StudentsAnswer> list = new List<StudentsAnswer>();
            using (DbConnection conn = Connect())
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
        internal void AddAnswerToQuestion(int? idQuestion, int? idAnswer)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Answers" +
                    " SET idAnswer=" + idAnswer +
                    " WHERE idQuestion =" + idQuestion +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal void PurgeDatabase()
        {
            try
            {
                File.Delete(dbName);
            }
            catch (Exception ex)
            {
                ////////Common.LogOfProgram.Error("Sqlite_DataLayerConstructorsAndGeneral | SaveParameter", ex);
            };
        }
        internal List<Answer> GetAllCorrectAnswersToThisQuestionOfThisTest(int? IdQuestion, int? IdTest)
        {
            List<Answer> list = new List<Answer>();
            using (DbConnection conn = Connect())
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
                    Answer a =  GetAnswerFromRow(dRead);
                    list.Add(a);
                }
            }
            return list;
        }
        internal Answer GetAnswerFromRow(DbDataReader Row)
        {
            Answer a = new Answer();
            a.IdAnswer = Safe.Int(Row["IdAnswer"]);
            a.IdQuestion = Safe.Int(Row["IdQuestion"]);
            a.ShowingOrder = Safe.Int(Row["ShowingOrder"]);
            a.Text = Safe.String(Row["Text"]);
            a.ErrorCost = Safe.Int(Row["ErrorCost"]);
            a.IsCorrect = Safe.Bool(Row["IsCorrect"]);
            a.IsOpenAnswer = Safe.Bool(Row["IsOpenAnswer"]);
            a.IsMutex = Safe.Bool(Row["IsMutex"]);

            return a;
        }
        internal int CreateAnswer(Answer currentAnswer)
        {
            // trova una chiave da assegnare alla nuova domanda
            int codice = NextKey("Answers", "idAnswer");
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Answers" +
                    " (idAnswer,idQuestion,showingOrder,text,errorCost,isCorrect,isOpenAnswer)" +
                    " Values (" + codice +
                    "," + SqlInt(currentAnswer.IdQuestion) +
                    "," + SqlInt(currentAnswer.ShowingOrder) +
                    "," + SqlString(currentAnswer.Text) + "" +
                    "," + SqlDouble(currentAnswer.ErrorCost) +
                    "," + SqlBool(currentAnswer.IsCorrect) +
                    "," + SqlBool(currentAnswer.IsOpenAnswer) +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return codice;
        }
        internal void SaveAnswer(Answer currentAnswer)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Answers" +
                    " SET idAnswer=" + currentAnswer.IdAnswer + "," +
                    " idQuestion=" + currentAnswer.IdQuestion + "," +
                    " isCorrect='" + SqlBool(currentAnswer.IsCorrect) + "'," +
                    " isOpenAnswer='" + SqlBool(currentAnswer.IsOpenAnswer) + "'," +
                    " Text=" + SqlString(currentAnswer.Text) + "," +
                    " errorCost=" + SqlDouble(currentAnswer.ErrorCost.ToString()) + "" +
                    " WHERE idAnswer = " + currentAnswer.IdAnswer +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal List<Answer> GetAnswersOfAQuestion(int? idQuestion)
        {
            List<Answer> l = new List<Answer>();
            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = Connect())
            {
                string query = "SELECT *" +
                    " FROM Answers" +
                    " WHERE idQuestion=" + idQuestion +
                    " ORDER BY showingOrder;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Answer t = new Answer();
                    t.IdAnswer = (int)dRead["idAnswer"];
                    t.IdQuestion = (int)dRead["idQuestion"];
                    t.ShowingOrder = (int)dRead["showingOrder"];
                    t.Text = (string)dRead["text"];
                    t.IdAnswer = (int)dRead["idAnswer"];
                    t.ErrorCost = (int)dRead["errorCost"];
                    t.IsCorrect = Safe.Bool(dRead["isCorrect"]);
                    t.IsOpenAnswer = Safe.Bool(dRead["isOpenAnswer"]);

                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
    }
}
