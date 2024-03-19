using SchoolGrades.BusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDbTests
{
    internal class T_Serv_QuestionManagement
    {
        [SetUp]
        public void Setup()
        {
            Test_Commons.SetDataLayer();
        }
        [Test]
        public void T_QuestionManagement_ACreate()
        {
            string connectionString = "SERVER=localhost;UID=sa;PWD=burbero2023;Database=schoolGrades;TrustServerCertificate=true";
            DbConnection conn;
            conn = new SqlConnection(connectionString);
            conn.Open();
            DbCommand cmd = conn.CreateCommand();

            #region CREATE
            //-------QUERY FUNZIONANTI DI CREAZIONE TABELLE-------
            //string query = "CREATE TABLE Questions " +
            //    "(idQuestion INT NOT NULL, " +
            //    "text VARCHAR (255), " +
            //    "weight FLOAT, duration INT, " +
            //    "difficulty INT, idImage INT, " +
            //    "image VARCHAR (90), " +
            //    "idQuestionType VARCHAR (5), " +
            //    "idTopic INT, idSubject INT, " +
            //    "idSchoolSubject VARCHAR (6), " +
            //    "nRows INT, isParamount INT, " +
            //    "PRIMARY KEY(idQuestion));";

            //string query = "CREATE TABLE Questions_Tags " +
            //    "(idQuestion INT NOT NULL, " +
            //    "idTag INT NOT NULL, PRIMARY KEY " +
            //    "(idQuestion, idTag));";

            //string query = "CREATE TABLE Topics " +
            //    "(idTopic INT NOT NULL, " +
            //    "name VARCHAR(20) NOT NULL, " +
            //    "descr VARCHAR(255), " +
            //    "leftNode INT, " +
            //    "rightNode INT, " +
            //    "parentNode INT, " +
            //    "childNumber INT, " +
            //    "PRIMARY KEY(idTopic));";

            //string query = "CREATE TABLE Tests_Questions " +
            //    "(idTest INT NOT NULL, idQuestion INT NOT NULL, weight REAL, PRIMARY KEY(idTest,idQuestion));";

            //string query = "CREATE TABLE Grades " +
            //    "(idGrade INT NOT NULL, " +
            //    "idStudent INT NOT NULL, " +
            //    "value FLOAT, " +
            //    "idSchoolSubject VARCHAR(6), " +
            //    "weight FLOAT, " +
            //    "cncFactor FLOAT, " +
            //    "idSchoolYear VARCHAR(4) NOT NULL, " +
            //    "timestamp DATETIME, " +
            //    "idGradeType VARCHAR(5) NOT NULL, " +
            //    "idGradeParent INT, " +
            //    "idQuestion INT, " +
            //    "isFixed TINYINT, " +
            //    "PRIMARY KEY(idGrade));";

            //string query = "CREATE TABLE QuestionTypes " +
            //    "(idQuestionType VARCHAR(5) NOT NULL, " +
            //    "name VARCHAR(20) NOT NULL, " +
            //    "descr VARCHAR(255) NULL, " +
            //    "PRIMARY KEY (idQuestionType));";
            //-----------------------------
            #endregion
            #region INSERT
            //-------QUERY FUNZIONANTI DI INSERIMENTO DATI-------

            //string query = "INSERT INTO Questions (idQuestion, text, weight, duration, difficulty, idImage, image, idQuestionType, idTopic, idSubject, idSchoolSubject, nRows, isParamount) " +
            //    "VALUES (1, 'Question1', 10.5, 10, 3, 1, 'aosifdgbasoidgasid', 'info', 1, 1, 'info', 3, 1);";

            //string query = "INSERT INTO Questions_Tags (idQuestion, idTag) VALUES (1, 2);";

            //string query = "INSERT INTO Topics (idTopic, name, descr, leftNode, rightNode, parentNode, childNumber) " +
            //    "VALUES (1, 'informatica', 'databases', 1, 2, 3, 4);";

            //string query = "INSERT INTO Tests_Questions (idTest, idQuestion, weight) VALUES (1, 12, 976);";

            //string query = "INSERT INTO Grades " +
            //    "(idGrade, idStudent, value, idSchoolSubject, weight, cncFactor, idSchoolYear, timestamp, idGradeType, idGradeParent, idQuestion, isFixed) " +
            //    "VALUES (1, 1, 8.5, 'info', 123.4, 0.3, '2024', '2024-03-09T00:00:00Z', 'tipo', 1, 2, 0);";

            //string query = "INSERT INTO QuestionTypes (idQuestionType, name, descr) VALUES ('info', 'database', 'tutto sui database cioe tutto davvero');";

            //cmd.CommandText = query;
            //cmd.ExecuteNonQuery();
            #endregion

            List<Tag> Tags = new List<Tag>();
            Tag tag1 = new Tag();
            tag1.IdTag = 1;
            Tags.Add(tag1);

            Topic QuestionsTopic = new Topic();
            QuestionsTopic.Id = 1;

            string TQuery = Test_Commons.dl.MakeStringForFilteredQuestionsQuery(Tags, "info", "info", QuestionsTopic, false, false);
            Assert.That(TQuery, Is.EqualTo("SELECT DISTINCT Questions.idQuestion " +
                "FROM Questions JOIN Questions_Tags " +
                "ON Questions.idQuestion=Questions_Tags.idQuestion " +
                "WHERE Questions_Tags.idTag IN(1) " +
                "AND idSchoolSubject='info' " +
                "AND idQuestionType='info' " +
                "AND idTopic=1"));

            conn.Close();
        }
        [Test]
        public void T_QuestionManagement_BRead()
        {
            int IdTest = 1;
            List<Question> lq = new List<Question>();
            lq = Test_Commons.dl.GetAllQuestionsOfATest(IdTest);
            Assert.That(lq.Count >= 0);
        }
        [Test]
        public void T_QuestionManagement_CUpdate()
        {
            string connectionString = "SERVER=localhost;UID=sa;PWD=burbero2023;Database=schoolGrades;TrustServerCertificate=true";
            DbConnection conn;
            conn = new SqlConnection(connectionString);
            conn.Open();
            DbCommand cmd = conn.CreateCommand();
            int IdGrade = 3258;
            Test_Commons.dl.FixQuestionInGrade(IdGrade);
            string query = "SELECT COUNT(isFixed) FROM Grades WHERE IdGrade = " + IdGrade + " AND isFixed = 1;";
            cmd.CommandText = query;
            Assert.That(cmd.ExecuteScalar(), Is.EqualTo(1));
        }
        [Test]
        public void T_QuestionManagement_DDelete()
        {

        }
    }
}
