using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        private string MakeStringForFilteredQuestionsQuery(List<Tag> Tags, string IdSchoolSubject,
            string IdQuestionType, Topic QuestionsTopic, bool QueryManyTopics, bool TagsAnd)
        {
            string query = "SELECT DISTINCT Questions.idQuestion" +
                            " FROM Questions";
            if (Tags != null && Tags.Count > 0)
            {
                // must join info from table Questions_Tags
                string queryTags = " JOIN Questions_Tags ON Questions.idQuestion=Questions_Tags.idQuestion";

                // make an IN clause, useful for both queries
                string InClause = " WHERE Questions_Tags.idTag IN(";
                foreach (Tag tag in Tags)
                {
                    InClause += "" + tag.IdTag.ToString() + ",";
                }
                InClause = InClause.Substring(0, InClause.Length - 1);
                InClause += ")";

                // (se http://howto.philippkeller.com/2005/04/24/Tags-Database-schemas/, "Toxi" solution)
                if (!TagsAnd)
                {
                    // The tags are evaluated in Union (OR) 
                    // limits the query only to those questions that have been associated to at least one of the tags in the list
                    queryTags += InClause;
                }
                else
                {
                    // The tags are in intersection (AND) 
                    queryTags += InClause;
                    queryTags += " GROUP BY Questions.idQuestion";
                    queryTags += " HAVING COUNT(Questions.idQuestion)=" + Tags.Count;
                }
                query += queryTags;
            }
            if (IdSchoolSubject != null && IdSchoolSubject != "")
            {
                // if we have already added the SQL for tags, we don't need a where
                if (query.Contains("WHERE"))
                    query += " AND idSchoolSubject=" + SqlString(IdSchoolSubject);
                else
                    query += " WHERE idSchoolSubject=" + SqlString(IdSchoolSubject);
            }
            if (IdQuestionType != null && IdQuestionType != "")
            {
                if (query.Contains("WHERE"))
                    query += " AND idQuestionType=" + SqlString(IdQuestionType);
                else
                    query += " WHERE idQuestionType=" + SqlString(IdQuestionType);
            }
            if (QuestionsTopic != null && QuestionsTopic.Id != null)
            {
                if (!QueryManyTopics)
                {
                    // just one topic
                    if (query.Contains("WHERE"))
                        query += " AND idTopic=" + QuestionsTopic.Id + "";
                    else
                        query += " WHERE idTopic=" + QuestionsTopic.Id + "";
                }
                else
                {
                    // manu topics: all those that stay under the node passed 
                    string queryApplicableTopics = "SELECT idTopic FROM Topics" +
                        " WHERE Topics.leftNode BETWEEN " + QuestionsTopic.LeftNodeOld +
                        " AND " + QuestionsTopic.RightNodeOld;
                    // query the passed Topic, plus all its descendants in the tree
                    if (query.Contains("WHERE"))
                        query += " AND Questions.IdTopic IN (" + queryApplicableTopics + ")";
                    else
                        query += " WHERE Questions.IdTopic IN (" + queryApplicableTopics + ")";
                }
            }
            return query;
        }
        internal List<Question> GetAllQuestionsOfATest(int? IdTest)
        {
            List<Question> lq = new List<Question>();
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *" +
                    " FROM Questions" +
                    " JOIN Tests_Questions ON Tests_Questions.IdQuestion=Questions.IdQuestion" +
                    " WHERE Tests_Questions.idTest=" + IdTest +
                    ";";
                DbDataReader dRead;
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    Question q = GetQuestionFromRow(dRead);
                    lq.Add(q);
                }
            }
            return lq;
        }
        internal void FixQuestionInGrade(int? IdGrade)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Grades" +
                           " Set" +
                           " isFixed=TRUE" +
                           " WHERE idGrade=" + IdGrade +
                           ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal void RemoveQuestionFromTest(int? IdQuestion, int? IdTest)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Tests_Questions " +
                    "WHERE IdQuestion=" + IdQuestion +
                    " AND IdTest=" + IdTest + 
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        private Question GetQuestionFromRow(DbDataReader Row)
        {
            Question q = new Question();
            q.Difficulty = Safe.Int(Row["Difficulty"]);
            q.IdImage = Safe.Int(Row["IdImage"]);
            q.Duration = Safe.Int(Row["Duration"]);
            q.IdQuestion = Safe.Int(Row["IdQuestion"]);
            q.IdQuestionType = Safe.String(Row["IdQuestionType"]);
            q.IdSchoolSubject = Safe.String(Row["IdSchoolSubject"]);
            //q.IdSubject = Safe.SafeInt(Row["IdSubject"]);
            q.IdTopic = Safe.Int(Row["IdTopic"]);
            q.Image = Safe.String(Row["Image"]);
            q.Text = Safe.String(Row["Text"]);
            q.Weight = Safe.Double(Row["Weight"]);
            q.NRows = Safe.Int(Row["nRows"]);
            q.IsParamount = Safe.Int(Row["isParamount"]);
            ////////q.IsFixed = Safe.SafeBool(Row["isFixed"]);

            return q;
        }
        internal Question GetQuestionById(int? IdQuestion)
        {
            Question question = new Question();
            if (IdQuestion == 0)
            {
                question.IdQuestion = 0;
                question.Text = "";
                return question;
            }
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM Questions " +
                    "WHERE idQuestion=" + IdQuestion.ToString() +
                    ";";
                dRead = cmd.ExecuteReader();
                while (dRead.Read()) // we cycle even if we need just a row, to check if it exists
                {
                    question.IdQuestion = (int)dRead["idQuestion"];
                    question.IdQuestionType = dRead["idQuestionType"].ToString();
                    question.Text = dRead["text"].ToString();
                    question.QuestionImage = dRead["image"].ToString();
                    question.Difficulty = (int)dRead["difficulty"];
                    question.Duration = (int)dRead["duration"];
                    question.IdSchoolSubject = dRead["idSchoolSubject"].ToString();
                    question.IdTopic = (int)dRead["idTopic"];
                    question.Image = dRead["image"].ToString();
                    question.Weight = (double)dRead["weight"];
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return question;
        }
        internal void SaveQuestion(Question Question)
        {
            using (DbConnection conn = Connect())
            {
                string imageNoHome = Question.Image;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Questions " +
                    "SET idQuestionType=" + SqlString(Question.IdQuestionType) + " " +
                     ", idSchoolSubject=" + SqlString(Question.IdSchoolSubject) + " " +
                     //", idSubject=" + Question.IdSubject + " " +
                     ", idSchoolSubject='" + Question.IdSchoolSubject + "'" +
                     ", idTopic=" + Question.IdTopic + " " +
                     ", duration=" + Question.Duration + " " +
                     ", difficulty=" + Question.Difficulty + " " +
                     ", text=" + SqlString(Question.Text) + " " +
                     ", image=" + SqlString(imageNoHome) + " " +
                     ", weight=" + SqlDouble(Question.Weight.ToString()) + " " +
                    "WHERE idQuestion=" + Question.IdQuestion +
                    ";";
                cmd.ExecuteNonQuery();
                // !!!!TODO sistemare le risposte
                // !!!!TODO gestire i tag
                cmd.Dispose();
            }
        }
        internal void AddQuestionToTest(Test Test, Question Question)
        {
            using (DbConnection conn = Connect())
            {
                // get the code of the previous photo
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Tests_Questions" +
                    " (IdTest, IdQuestion)" +
                    " Values" +
                    " (" + Test.IdTest + "," + Question.IdQuestion + ")" +
                    "; ";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal List<QuestionType> GetListQuestionTypes(bool IncludeANullObject)
        {
            List<QuestionType> l = new List<QuestionType>();
            if (IncludeANullObject)
            {
                QuestionType qt = new QuestionType();
                qt.IdQuestionType = "";
                l.Add(qt);
            }
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM QuestionTypes;";
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    QuestionType o = new QuestionType();
                    o.Name = (string)dRead["Name"];
                    o.IdQuestionType = (string)dRead["IdQuestionType"];
                    o.Desc = (string)dRead["Desc"];
                    o.IdQuestionType = (string)dRead["IdQuestionType"];
                    l.Add(o);
                }
                dRead.Dispose();
                cmd.Dispose();
                return l;
            }
        }
        internal Question CreateNewVoidQuestion()
        {
            // trova una chiave da assegnare alla nuova domanda
            Question q = new Question();
            q.IdQuestion = NextKey("Questions", "idQuestion");
            using (DbConnection conn = Connect())
            {
                string imageSenzaHome = q.Image;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Questions " +
                    "(idQuestion) " +
                    "Values (" + q.IdQuestion + ")" +
                     ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            SaveQuestion(q);
            return q;
        }

        /// <summary>
        /// gets the questions regarding the topics taught to the class that 
        /// haven't been made to the student yet. 
        /// Includes also the questions tha do not have a topic 
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Student"></param>
        /// <param name="Subject"></param>
        /// <returns></returns>
        internal List<Question> GetFilteredQuestionsNotAsked(Student Student, Class Class,
            SchoolSubject Subject, string IdQuestionType, List<Tag> Tags, Topic Topic,
            bool QueryManyTopics, bool TagsAnd, string SearchString,
            DateTime DateFrom, DateTime DateTo)
        {
            List<Question> lq = new List<Question>();
            string filteredQuestions;

            // first part of the query: selection of the interesting fields in Questions
            string query = "SELECT Questions.IdQuestion,Questions.text,Questions.idSchoolSubject,Questions.idQuestionType" +
                ",Questions.weight,Questions.duration,Questions.difficulty,Questions.image,Questions.idTopic" +
                " FROM Questions";
            // add the WHERE clauses
            // if the search string is present, then it must be in the searched field 
            if (SearchString != "")
            {
                query += " WHERE Questions.text " + SqlLikeStatement(SearchString) + ""; 
            }

            filteredQuestions = MakeStringForFilteredQuestionsQuery(Tags, Subject.IdSchoolSubject, IdQuestionType,
                    Topic, QueryManyTopics, TagsAnd);

            // !!!! IF we don't want to make the same question to the student the next part SHOULD BE FIXED !!!!
            string questionsAlreadyMade = "";
            if (Student != null)
            {
                questionsAlreadyMade = "SELECT Questions.idQuestion" +
                    " FROM Questions" +
                    " JOIN Grades ON Questions.idQuestion=Grades.idQuestion" +
                    " JOIN Students ON Students.idStudent=Grades.IdStudent" +
                    " WHERE Students.idStudent=" + Student.IdStudent +
                    " AND Grades.idSchoolYear='" + Class.SchoolYear + "'";
            }
            string questionsTopicsMade = "";
            if (Class != null && Subject != null)
            {
                // questions made to the class 
                questionsTopicsMade = "SELECT Questions.idQuestion" +
                    " FROM Questions" +
                    " JOIN Lessons_Topics ON Questions.idTopic=Lessons_Topics.idTopic" +
                    " JOIN Lessons ON Lessons_Topics.idLesson=Lessons.idLesson" +
                    " JOIN Classes ON Classes.idClass=Lessons.idClass" +
                    " WHERE Classes.idClass=" + Class.IdClass +
                    " AND (Questions.idSchoolSubject='" + Subject.IdSchoolSubject + "'" +
                    " OR Questions.idSchoolSubject='' OR Questions.idSchoolSubject=NULL)";
                //////////////if (DateFrom != Commons.DateNull)
                //////////////    questionsTopicsMade += " AND (Lessons.Date BETWEEN " + SqlDate(DateFrom) + " AND " + SqlDate(DateTo) + ")";
                // PART of the final query that extracts the Ids of the questions already made 
                questionsTopicsMade = " Questions.idQuestion IN(" + questionsTopicsMade + ")";
            }
            if (questionsAlreadyMade != "")
            {
                // take only questions already made 
                if (SearchString == "")
                {
                    query += " WHERE Questions.idQuestion NOT IN(" + questionsAlreadyMade + ")";
                }
                else
                {
                    query += " AND Questions.idQuestion NOT IN(" + questionsAlreadyMade + ")";
                }
            }
            if (filteredQuestions != "")
            {
                if (query.Contains("WHERE"))
                {
                    query += " AND";
                }
                else
                {
                    query += " WHERE";
                }
                query += " Questions.idQuestion IN(" + filteredQuestions + ")";
            }
            query += " OR Questions.idTopic IS NULL OR Questions.idTopic = ''";
            //if (SearchString != "")
            //    query += ")";

            query += " ORDER BY Questions.weight;";

            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = query;

                dRead = cmd.ExecuteReader();
                while (dRead.Read()) // 
                {
                    Question questionForList = new Question();

                    questionForList.Difficulty = (int)dRead["difficulty"];
                    questionForList.Duration = (int)dRead["duration"];
                    questionForList.IdQuestion = (int)dRead["idQuestion"];
                    questionForList.IdQuestionType = dRead["idQuestionType"].ToString();
                    questionForList.IdSchoolSubject = dRead["idSchoolSubject"].ToString();
                    //q.idSubject = (int)dRead["idSubject"];
                    questionForList.IdTopic = (int)dRead["idTopic"];
                    questionForList.Image = dRead["image"].ToString();
                    questionForList.QuestionImage = dRead["image"].ToString();
                    questionForList.Text = dRead["text"].ToString();
                    questionForList.Weight = (double)dRead["weight"];

                    lq.Add(questionForList);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return lq;
        }
        internal List<Question> GetFilteredQuestionsAskedToClass(Class Class, SchoolSubject Subject, string IdQuestionType, 
            List<Tag> Tags, Topic Topic, bool QueryManyTopics, bool TagsAnd, 
            string SearchString, DateTime DateFrom, DateTime DateTo)
        {
            List<Question> lq = new List<Question>();
            string filteredQuestions;

            // first part of the query: selection of the interesting fields in Questions
            string query = "SELECT Questions.IdQuestion,Questions.text,Questions.idSchoolSubject,Questions.idQuestionType" +
                ",Questions.weight,Questions.duration,Questions.difficulty,Questions.image,Questions.idTopic" +
                " FROM Questions";
            // add the WHERE clauses
            // if the search string is present, then it must be in the searched field 
            if (SearchString != "")
            {
                query += " WHERE Questions.text " + SqlLikeStatement(SearchString) + "";
            }
            if (Subject != null)
                filteredQuestions = MakeStringForFilteredQuestionsQuery(Tags, Subject.IdSchoolSubject, IdQuestionType,
                    Topic, QueryManyTopics, TagsAnd);
            else
                filteredQuestions = MakeStringForFilteredQuestionsQuery(Tags, "", IdQuestionType,
                    Topic, QueryManyTopics, TagsAnd);
            // !!!! THIS PART MUST BE FIXED !!!!
            string questionsAlreadyMade = "";
            //if (Student != null)
            //{
            //    questionsAlreadyMade = "SELECT Questions.idQuestion" +
            //        " FROM Questions" +
            //        " JOIN Grades ON Questions.idQuestion=Grades.idQuestion" +
            //        " JOIN Students ON Students.idStudent=Grades.IdStudent" +
            //        " WHERE Students.idStudent=" + Student.IdStudent +
            //        " AND Grades.idSchoolYear='" + Class.SchoolYear + "'";
            //}
            //string questionsTopicsMade = "";
            //if (Class != null && Subject != null)
            //{
            //    // questions made to the class in every time ever 
            //    questionsTopicsMade = "SELECT Questions.idQuestion" +
            //        " FROM Questions" +
            //        " JOIN Lessons_Topics ON Questions.idTopic=Lessons_Topics.idTopic" +
            //        " JOIN Lessons ON Lessons_Topics.idLesson=Lessons.idLesson" +
            //        " JOIN Classes ON Classes.idClass=Lessons.idClass" +
            //        " WHERE Classes.idClass=" + Class.IdClass +
            //        " AND (Questions.idSchoolSubject='" + Subject.IdSchoolSubject + "'" +
            //        " OR Questions.idSchoolSubject='' OR Questions.idSchoolSubject=NULL)";
            //    if (DateFrom != Commons.DateNull)
            //        questionsTopicsMade += " AND (Lessons.Date BETWEEN " + SqlDate(DateFrom) + " AND " + SqlDate(DateTo) + ")";
            //    // PART of the final query that extracts the Ids of the questions already made 
            //    questionsTopicsMade = " Questions.idQuestion IN(" + questionsTopicsMade + ")";
            //}

            //if (questionsAlreadyMade != "")
            //{
            //    // take only questions already made 
            //    if (SearchString == "")
            //    {
            //        query += " WHERE Questions.idQuestion NOT IN(" + questionsAlreadyMade + ")";
            //    }
            //    else
            //    {
            //        query += " Questions.idQuestion NOT IN(" + questionsAlreadyMade + ")";
            //    }
            //}
            //if (filteredQuestions != "")
            //{
            //    if (questionsAlreadyMade != "" || SearchString != "")
            //    {
            //        query += " AND Questions.idQuestion IN(" + filteredQuestions + ")";
            //    }
            //    else
            //    {
            //        query += " WHERE Questions.idQuestion IN(" + filteredQuestions + ")";
            //    }
            //}
            //query += " OR Questions.idTopic IS NULL OR Questions.idTopic = ''";
            //if (SearchString != "")
            //    query += ")";

            query += " ORDER BY Questions.weight;";

            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = query;

                dRead = cmd.ExecuteReader();
                while (dRead.Read()) // 
                {
                    Question questionForList = new Question();

                    questionForList.Difficulty = (int)dRead["difficulty"];
                    questionForList.Duration = (int)dRead["duration"];
                    questionForList.IdQuestion = (int)dRead["idQuestion"];
                    questionForList.IdQuestionType = dRead["idQuestionType"].ToString();
                    questionForList.IdSchoolSubject = dRead["idSchoolSubject"].ToString();
                    //q.idSubject = (int)dRead["idSubject"];
                    questionForList.IdTopic = (int)dRead["idTopic"];
                    questionForList.Image = dRead["image"].ToString();
                    questionForList.QuestionImage = dRead["image"].ToString();
                    questionForList.Text = dRead["text"].ToString();
                    questionForList.Weight = (double)dRead["weight"];

                    lq.Add(questionForList);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return lq;
        }
    }
}
