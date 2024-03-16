using Newtonsoft.Json.Linq;
using SchoolGrades.BusinessObjects;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing.Printing;

namespace NUnitDbTests
{
    public class T_Database_ConstructorsAndGeneralMethods
    {
        [SetUp]
        public void Setup()
        {
            Test_Commons.SetDataLayer();
            DbCommand cmd;
            using (DbConnection conn = Test_Commons.dl.Connect())
            {
                //conn.CreateCommand();
                //cmd = conn.CreateCommand();
                //cmd.CommandText = @"DROP TABLE Students";
                //cmd = conn.CreateCommand();
                //cmd.CommandText = @"CREATE TABLE Students (
                //               idStudent	INT NOT NULL,
                //               lastName	VARCHAR(45),
                //               firstName	VARCHAR(45),
                //               residence	VARCHAR(45),
                //               origin	VARCHAR(45),
                //               email	VARCHAR(45),
                //               drawable	int,
                //               birthDate	DATE,
                //               birthPlace	VARCHAR(45),
                //               VFCounter	INTEGER,
                //               disabled	int,
                //               hasSpecialNeeds	INTEGER,
                //               PRIMARY KEY(idStudent)
                //                  );";
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();
                //cmd = conn.CreateCommand();
        //        cmd.CommandText = @"INSERT INTO Students(idStudent,lastName,firstName,residence,origin,email,drawable,birthdate,birthplace,disabled,hasSpecialNeeds) VALUES(
        //                          1,
        //                          'Berna',
        //                          'DiegoBini',
        //                          'S.Agata Feltria',
        //                          '1L',
        //                          'Diego.bernabini.stud@ispascalcomandini.it',
		//                          1,
        //                          '2008-11-11 13:23:44',
        //                          'Ponte non specificato',
        //                          1,
        //                          0)";
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();

            }
        }
        [Test]
        public void T_ConstructorsAndGeneralMethods_Create()
        {
            

        }
        [Test]
        public void T_ConstructorsAndGeneralMethods_Read()
        {
            String tableName = "Students";
            String keyName = "idStudent";
            String keyValue = "1";
            
            Assert.That(Test_Commons.dl.NextKey(tableName, keyName) == 2);
            Assert.That(Test_Commons.dl.CheckKeyExistence(tableName, keyName, keyValue));
            Assert.That(Test_Commons.dl.IsTableReadable(tableName));
           
        }
        [Test]
        public void T_ConstructorsAndGeneralMethods_Update()
        {
           

        }
        [Test]
        public void T_ConstructorsAndGeneralMethods_Delete()
        {
           
        }
    }
}