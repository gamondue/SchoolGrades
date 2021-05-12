using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SchoolGrades
{
    internal partial class DataLayer
    {

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
                    "," + SqlVal.SqlInt(currentAnswer.IdQuestion) +
                    "," + SqlVal.SqlInt(currentAnswer.ShowingOrder) +
                    ",'" + SqlVal.SqlString(currentAnswer.Text) + "'" +
                    "," + SqlVal.SqlDouble(currentAnswer.ErrorCost) +
                    "," + SqlVal.SqlBool(currentAnswer.IsCorrect) +
                    "," + SqlVal.SqlBool(currentAnswer.IsOpenAnswer) +
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
                    " isCorrect='" + SqlVal.SqlBool(currentAnswer.IsCorrect) + "'," +
                    " isOpenAnswer='" + SqlVal.SqlBool(currentAnswer.IsOpenAnswer) + "'," +
                    " Text='" + SqlVal.SqlString(currentAnswer.Text) + "'," +
                    " errorCost=" + SqlVal.SqlDouble(currentAnswer.ErrorCost.ToString()) + "" +
                    " WHERE idAnswer = " + currentAnswer.IdAnswer +
                    ";";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
        }

    }
}
