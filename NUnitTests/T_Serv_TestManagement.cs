using SchoolGrades.BusinessObjects;
using SchoolGrades;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace NUnitDbTests
{
    internal class T_Serv_TestManagement
    {
        [SetUp]
        public void Setup()
        {
            Test_Commons.SetDataLayer();
        }
        [Test]
        public void T_TestManagement_Create()
        {
            //DbCommand cmd;

            //using (DbConnection conn = Test_Commons.dl.Connect())
            //{
            // //   cmd = conn.CreateCommand();
            // //   cmd.CommandText = @"CREATE TABLE Tests (
	           // //idTest	INT NOT NULL,
	           // //name	VARCHAR(20),
	           // //descr	VARCHAR(255),
	           // //idSubject	INT,
	           // //idSchoolSubject	VARCHAR(6),
	           // //idTopic	INT,
	           // //idTestType	VARCHAR(6),
	           // //PRIMARY KEY(idTest)
            // //   );";

            // //   cmd.ExecuteNonQuery();
            //}
            
        }

        [Test]
        public void T_TestManagement_Read()
        {
            SchoolGrades.BusinessObjects.SchoolTest t = new SchoolTest();
            t.Name = "Test";
            t.Desc = "test";
            t.IdTest = 1;
            t.IdTopic = 2;
            t.IdTestType = "scritto";
            t.IdSchoolSubject = "informatica";

            using (DbConnection conn = Test_Commons.dl.Connect())
            {
                //static extern SchoolGrades.BusinessObjects.SchoolTest GetTestFromRow(DbDataReader Row);
               // Test_Commons.dl.GetTest(t.IdTest);
                Test_Commons.dl.GetTests();
            }
        }

        [Test]
        public void T_TestManagement_Update()
        {
            SchoolTest TTS = new SchoolTest();
            TTS.Name = "test";
            TTS.Desc = "test";
            TTS.IdTest = 1;
            TTS.IdTestType = "test";
            TTS.IdTopic = 1;

            Test_Commons.dl.SaveTest(TTS);

        }
        [Test]
        public void T_TestManagement_Delete()
        {
            // test of DataLayer Methods that delete data from table SchoolYears
        }
    }
}
