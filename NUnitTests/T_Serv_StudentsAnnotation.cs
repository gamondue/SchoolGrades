using NUnit.Framework.Internal;
using SchoolGrades.BusinessObjects;
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

            ;
            Student student = new Student();
            student.IdStudent = 15;
            StudentAnnotation annotation = new StudentAnnotation();
            annotation.Annotation = "test";
            annotation.InstantTaken = null;
            annotation.InstantTaken = null;
            Test_Commons.dl.SaveAnnotation(annotation, student);
            conn.Close();
        }
        [Test]
        public void T_Serv_AnnotationManagement_Read()
        {
            DbConnection conn;

            string connectionStringSqlServer = "SERVER=localhost;UID=sa;PWD=burbero2023;Database=SchoolGrades;TrustServerCertificate=true;";

            conn = new SqlConnection(connectionStringSqlServer);
            conn.Open();

            DbCommand cmd = conn.CreateCommand();
            DbDataReader dRead;

            Student student = new Student();
            student.IdStudent = 15;
            Test_Commons.dl.AnnotationsAboutThisStudent(student, "'23-24'", false);

            string query = "SELECT * " +
                " FROM StudentsAnnotations" +
                " WHERE StudentsAnnotations.idStudent=" +
                student.IdStudent + ";";

            cmd.CommandText = query;
            dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                Assert.That((int)dRead["idAnnotation"], Is.LessThan(2));
            }

            conn.Close();
        }
        [Test]
        public void T_Serv_AnnotationManagement_Update()
        {

        }
        [Test]
        public void T_Serv_AnnotationManagement_Delete()
        {
            DbConnection conn;

            string connectionStringSqlServer = "SERVER=localhost;UID=sa;PWD=burbero2023;Database=SchoolGrades;TrustServerCertificate=true;";

            conn = new SqlConnection(connectionStringSqlServer);
            conn.Open();

            DbCommand cmd = conn.CreateCommand();
            DbDataReader dRead;
            string query = "DELETE " +
                " FROM StudentsAnnotations" +
                " WHERE StudentsAnnotations.idAnnotation=2;";

            cmd.CommandText = query;
            dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                Assert.That((int)dRead["idAnnotation"], Is.LessThan(2));
            }

            conn.Close();
        }
    }
}
