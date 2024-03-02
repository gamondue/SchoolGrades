using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDbTests
{
    internal class T_Serv_StudentsAnnotation
    {
        [SetUp]
        public void Setup()
        {
            Test_Commons.SetDataLayer();
        }
        [Test]
        public void T_Serv_AnnotationManagement_Create()
        {
            DbConnection conn;

            string connectionStringSqlServer = "SERVER=localhost;UID=sa;PWD=burbero2023;Database=SchoolGrades;TrustServerCertificate=true;";

            conn = new SqlConnection(connectionStringSqlServer);
            conn.Open();

            DbCommand cmd = conn.CreateCommand();
            string query;
            //    query = "CREATE TABLE StudentsAnnotations " +
            //    "(idAnnotation INT PRIMARY KEY IDENTITY, " +
            //    "idStudent INT, annotation VARCHAR(256), " +
            //    "idSchoolYear VARCHAR(5), instatTaken DATETIME, " +
            //    "instatClosed DATETIME, isActive INT, " +
            //    "isPopUp INT, " +
            //    "FOREIGN KEY (idStudent) REFERENCES Students (idStudent), " +
            //    FOREIGN KEY (idSchoolYear) REFERENCES SchoolYears (idSchoolYear));";

            //cmd.CommandText = query;
            //cmd.ExecuteNonQuery();

            query = "INSERT INTO StudentsAnnotations (idAnnotation, idStudent, annotation)" +
                "VALUES (0, 15, 'test');";

            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

        }
        [Test]
        public void T_Serv_AnnotationManagement_Read()
        {

        }
        [Test]
        public void T_Serv_AnnotationManagement_Update()
        {

        }
        [Test]
        public void T_Serv_AnnotationManagement_Delete()
        {

        }
    }
}
