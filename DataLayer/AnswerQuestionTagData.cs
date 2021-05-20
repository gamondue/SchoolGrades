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
    //Andrea Siboni, Francesco Citarella, Cesare Colella, Riccardo Brunelli 4L

    class AnswerQuestionTagData
    {
        DataLayer dl = new DataLayer();
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

        internal List<QuestionType> GetListQuestionTypes(bool IncludeANullObject)
        {
            List<QuestionType> l = new List<QuestionType>();
            if (IncludeANullObject)
            {
                QuestionType qt = new QuestionType();
                qt.IdQuestionType = "";
                l.Add(qt);
            }
            using (DbConnection conn = dl.Connect())
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


        internal void RemoveQuestionFromTest(int? IdQuestion, int? IdTest)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Tests_Questions " +
                    "WHERE IdQuestion=" + IdQuestion +
                    " AND IdTest='" + IdTest + "'" +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        private Question GetQuestionFromRow(DbDataReader Row)
        {
            Question q = new Question();
            q.Difficulty = SafeDb.SafeInt(Row["Difficulty"]);
            q.IdImage = SafeDb.SafeInt(Row["IdImage"]);
            q.Duration = SafeDb.SafeInt(Row["Duration"]);
            q.IdQuestion = SafeDb.SafeInt(Row["IdQuestion"]);
            q.IdQuestionType = SafeDb.SafeString(Row["IdQuestionType"]);
            q.IdSchoolSubject = SafeDb.SafeString(Row["IdSchoolSubject"]);
            //q.IdSubject = SafeDb.SafeInt(Row["IdSubject"]);
            q.IdTopic = SafeDb.SafeInt(Row["IdTopic"]);
            q.Image = SafeDb.SafeString(Row["Image"]);
            q.Text = SafeDb.SafeString(Row["Text"]);
            q.Weight = SafeDb.SafeDouble(Row["Weight"]);
            q.NRows = SafeDb.SafeInt(Row["nRows"]);
            q.IsParamount = SafeDb.SafeInt(Row["isParamount"]);
            ////////q.IsFixed = SafeDb.SafeBool(Row["isFixed"]);

            return q;
        }

        internal List<Question> GetAllQuestionsOfATest(int? IdTest)
        {
            List<Question> lq = new List<Question>();
            using (DbConnection conn = dl.Connect())
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

        private StudentsAnswer GetStudentsAnswerFromRow(DbDataReader Row)
        {
            StudentsAnswer a = new StudentsAnswer();
            a.IdAnswer = SafeDb.SafeInt(Row["IdAnswer"]);
            a.IdStudent = SafeDb.SafeInt(Row["IdStudent"]);
            a.IdStudentsAnswer = SafeDb.SafeInt(Row["IdStudentsAnswer"]);
            a.IdTest = SafeDb.SafeInt(Row["IdTest"]);
            a.StudentsBoolAnswer = SafeDb.SafeBool(Row["StudentsBoolAnswer"]);
            a.StudentsTextAnswer = SafeDb.SafeString(Row["StudentsTextAnswer"]);

            return a;
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

        internal Student GetStudent(int? IdStudent)
        {
            Student s = new Student();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM Students " +
                    "WHERE idStudent=" + IdStudent +
                    ";";
                dRead = cmd.ExecuteReader();
                dRead.Read();
                s = GetStudentFromRow(dRead);
                dRead.Dispose();
                cmd.Dispose();
            }
            return s;
        }

        private Student GetStudentFromRow(DbDataReader Row)
        {
            Student s = new Student();
            s.IdStudent = (int)Row["IdStudent"];
            s.LastName = SafeDb.SafeString(Row["LastName"]);
            s.FirstName = SafeDb.SafeString(Row["FirstName"]);
            s.Residence = SafeDb.SafeString(Row["Residence"]);
            s.Origin = SafeDb.SafeString(Row["Origin"]);
            s.Email = SafeDb.SafeString(Row["Email"]);
            if (!(Row["birthDate"] is DBNull))
                s.BirthDate = SafeDb.SafeDateTime(Row["birthDate"]);
            s.BirthPlace = SafeDb.SafeString(Row["birthPlace"]);
            s.Eligible = SafeDb.SafeBool(Row["drawable"]);
            s.Disabled = SafeDb.SafeBool(Row["disabled"]);
            s.RevengeFactorCounter = SafeDb.SafeInt(Row["VFCounter"]);

            return s;
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

        internal void AddQuestionToTest(Test Test, Question Question)
        {
            using (DbConnection conn = dl.Connect())
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


        internal Question CreateNewVoidQuestion()
        {
            // trova una chiave da assegnare alla nuova domanda
            Question q = new Question();
            q.IdQuestion = NextKey("Questions", "idQuestion");
            using (DbConnection conn = dl.Connect())
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


        internal Question GetQuestionById(int? IdQuestion)
        {
            Question question = new Question();
            if (IdQuestion == 0)
            {
                question.IdQuestion = 0;
                question.Text = "";
                return question;
            }
            using (DbConnection conn = dl.Connect())
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
            using (DbConnection conn = dl.Connect())
            {
                string imageNoHome = Question.Image;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Questions " +
                    "SET idQuestionType='" + SqlVal.SqlString(Question.IdQuestionType) + "' " +
                     ", idSchoolSubject='" + SqlVal.SqlString(Question.IdSchoolSubject) + "' " +
                     //", idSubject=" + Question.IdSubject + " " +
                     ", idSchoolSubject='" + Question.IdSchoolSubject + "'" +
                     ", idTopic=" + Question.IdTopic + " " +
                     ", duration=" + Question.Duration + " " +
                     ", difficulty=" + Question.Difficulty + " " +
                     ", text='" + SqlVal.SqlString(Question.Text) + "' " +
                     ", image='" + SqlVal.SqlString(imageNoHome) + "' " +
                     ", weight=" + SqlVal.SqlDouble(Question.Weight.ToString()) + " " +
                    "WHERE idQuestion=" + Question.IdQuestion +
                    ";";
                cmd.ExecuteNonQuery();
                // !!!!TODO sistemare le risposte
                // !!!!TODO gestire i tag
                cmd.Dispose();
            }
        }

        internal DataTable GetFilteredQuestions(List<Tag> Tags, string IdSchoolSubject,
            string IdQuestionType, Topic QuestionsTopic, bool QueryManyTopics, bool TagsAnd)
        {
            DataTable t;

            string subquery = MakeStringForFilteredQuestionsQuery(Tags, IdSchoolSubject, IdQuestionType, QuestionsTopic, QueryManyTopics, TagsAnd);
            string query = "SELECT Questions.IdQuestion,Questions.text,Questions.idSchoolSubject,Questions.idQuestionType" +
                            ",Questions.weight,Questions.duration,Questions.difficulty,Questions.image,Questions.idTopic" +
                            " FROM Questions" +
                            " WHERE Questions.IdQuestion IN(" + subquery + ")" +
                            " ORDER BY Questions.IdQuestion;";
            DataSet DSet;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DSet = new DataSet("FilteredQuestions");
                DAdapt.Fill(DSet);
                DAdapt.Dispose();
                t = DSet.Tables[0];
                DSet.Dispose();
            }
            return t;
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
                query += " WHERE Questions.text LIKE('%" + SqlVal.SqlString(SearchString) + "%')" +
                    "AND (";
            }
            if (Subject != null)
                filteredQuestions = MakeStringForFilteredQuestionsQuery(Tags, Subject.IdSchoolSubject, IdQuestionType,
                    Topic, QueryManyTopics, TagsAnd);
            else
                filteredQuestions = MakeStringForFilteredQuestionsQuery(Tags, "", IdQuestionType,
                    Topic, QueryManyTopics, TagsAnd);

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
                // questions made to the class in every time ever 
                questionsTopicsMade = "SELECT Questions.idQuestion" +
                    " FROM Questions" +
                    " JOIN Lessons_Topics ON Questions.idTopic=Lessons_Topics.idTopic" +
                    " JOIN Lessons ON Lessons_Topics.idLesson=Lessons.idLesson" +
                    " JOIN Classes ON Classes.idClass=Lessons.idClass" +
                    " WHERE Classes.idClass=" + Class.IdClass +
                    " AND (Questions.idSchoolSubject='" + Subject.IdSchoolSubject + "'" +
                    " OR Questions.idSchoolSubject='' OR Questions.idSchoolSubject=NULL)";
                if (DateFrom != Commons.DateNull)
                    questionsTopicsMade += " AND (Lessons.Date BETWEEN " + SqlVal.SqlDate(DateFrom) + " AND " + SqlVal.SqlDate(DateTo) + ")";
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
                    query += " Questions.idQuestion NOT IN(" + questionsAlreadyMade + ")";
                }
            }
            if (filteredQuestions != "")
            {
                if (questionsAlreadyMade != "" || SearchString != "")
                {
                    query += " AND Questions.idQuestion IN(" + filteredQuestions + ")";
                }
                else
                {
                    query += " WHERE Questions.idQuestion IN(" + filteredQuestions + ")";
                }
            }
            query += " OR Questions.idTopic IS NULL OR Questions.idTopic = ''";
            if (SearchString != "")
                query += ")";

            query += " ORDER BY Questions.weight;";

            using (DbConnection conn = dl.Connect())
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
            if (IdSchoolSubject != "")
            {
                // if we have already added the SQL for tags, we don't need a where
                if (Tags != null && Tags.Count > 0)
                    query += " AND idSchoolSubject ='" + SqlVal.SqlString(IdSchoolSubject) + "'";
                else
                    query += " WHERE idSchoolSubject ='" + SqlVal.SqlString(IdSchoolSubject) + "'";
            }
            if (IdQuestionType != null && IdQuestionType != "")
            {
                if (IdSchoolSubject != "" || Tags.Count > 0)
                    query += " AND idQuestionType ='" + SqlVal.SqlString(IdQuestionType) + "'";
                else
                    query += " WHERE idQuestionType ='" + SqlVal.SqlString(IdQuestionType) + "'";
            }
            if (QuestionsTopic != null)
            {
                if (!QueryManyTopics)
                {
                    if (IdSchoolSubject != "" || Tags.Count > 0 || IdQuestionType != "")
                        query += " AND idTopic=" + QuestionsTopic.Id + "";
                    else
                        query += " WHERE idTopic=" + QuestionsTopic.Id + "";
                }
                else
                {
                    string queryApplicableTopics = "SELECT idTopic FROM Topics" +
                        " WHERE Topics.leftNode BETWEEN " + QuestionsTopic.LeftNodeOld +
                        " AND " + QuestionsTopic.RightNodeOld;
                    // query the passed Topic, plus all its descendants in the tree
                    if (IdSchoolSubject != "" || Tags.Count > 0 || IdQuestionType != "")
                        query += " AND Questions.IdTopic IN (" + queryApplicableTopics + ")";
                    else
                        query += " WHERE Questions.IdTopic IN (" + queryApplicableTopics + ")";
                }
            }
            return query;
        }
        internal List<Tag> GetTagsContaining(string Pattern)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Tag> TagList = new List<Tag>();

            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT *" +
                    " FROM Tags" +
                    " WHERE Tag LIKE '%" + SqlVal.SqlString(Pattern) + "%'" +
                    ";";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Tag t = new Tag();
                    t.IdTag = (int)dRead["IdTag"];
                    t.TagName = (string)dRead["tag"];
                    t.Desc = (string)dRead["Desc"];

                    TagList.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return TagList;
        }

        internal int? CreateNewTag(Tag CurrentTag)
        {
            // trova una chiave da assegnare alla nuova domanda
            CurrentTag.IdTag = NextKey("Tags", "IdTag");
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Tags " +
                    "(IdTag, tag, Desc) " +
                    "Values (" + CurrentTag.IdTag + "," +
                    "'" + CurrentTag.TagName + "'," +
                    "'" + CurrentTag.Desc + "'" +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return CurrentTag.IdTag;
        }

        internal void SaveTag(Tag CurrentTag)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Tags " +
                    " SET IdTag=" + CurrentTag.IdTag + "," +
                    " tag=" + "'" + CurrentTag.TagName + "'," +
                    " Desc=" + "'" + CurrentTag.Desc + "'" +
                    " WHERE idTag=" + CurrentTag.IdTag +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal List<Tag> TagsOfAQuestion(int? IdQuestion)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Tag> l = new List<Tag>();
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT * " +
                    " FROM Questions_Tags, Tags" +
                    " WHERE Tags.IdTag = Questions_Tags.IdTag " +
                    " AND Questions_Tags.idQuestion=" + IdQuestion +
                    " ORDER BY Tags.tag;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Tag t = new Tag();
                    t.Desc = (string)dRead["Desc"];
                    t.IdTag = (int)dRead["IdTag"];
                    t.TagName = (string)dRead["tag"];
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }

            return l;
        }

        internal void AddTagToQuestion(int? IdQuestion, int? IdTag)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Questions_Tags " +
                    "(idQuestion, IdTag) " +
                    "Values (" + IdQuestion + "," +
                    IdTag +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal void AddAnswerToQuestion(int? idQuestion, int? idAnswer)
        {
            using (DbConnection conn = dl.Connect())
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

        internal int CreateAnswer(Answer currentAnswer)
        {
            // trova una chiave da assegnare alla nuova domanda
            int codice = NextKey("Answers", "idAnswer");
            using (DbConnection conn = dl.Connect())
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
            using (DbConnection conn = dl.Connect())
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

        internal List<Answer> GetAnswersOfAQuestion(int? idQuestion)
        {
            List<Answer> l = new List<Answer>();
            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = dl.Connect())
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
                    t.IsCorrect = SafeDb.SafeBool(dRead["isCorrect"]);
                    t.IsOpenAnswer = SafeDb.SafeBool(dRead["isOpenAnswer"]);

                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
    }
}
