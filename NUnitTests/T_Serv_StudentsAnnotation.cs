using NUnit.Framework.Internal;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
            annotation.InstantClosed = null;
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
                StudentAnnotation a = Test_Commons.dl.GetAnnotationFromRow(dRead);
                Assert.That((int)dRead["idAnnotation"], Is.EqualTo(a.IdAnnotation));
            }

            Test_Commons.dl.GetAnnotation(1);

            conn.Close();
        }
        [Test]
        public void T_Serv_AnnotationManagement_Update()
        {
            DbConnection conn;

            string connectionStringSqlServer = "SERVER=localhost;UID=sa;PWD=burbero2023;Database=SchoolGrades;TrustServerCertificate=true;";

            conn = new SqlConnection(connectionStringSqlServer);
            conn.Open();

            DbCommand cmd = conn.CreateCommand();
            DbDataReader dRead;

            Student student = new Student();
            student.IdStudent = 15;
            StudentAnnotation annotation = new StudentAnnotation();
            
            annotation.InstantTaken = DateTime.Now;
            annotation.InstantClosed = null;

            string query = "SELECT * " +
                " FROM StudentsAnnotations" +
                " WHERE StudentsAnnotations.idStudent=" +
                student.IdStudent + ";";

            cmd.CommandText = query;
            dRead = cmd.ExecuteReader();
            if (dRead.Read())
            {
                annotation.Annotation = "test UPDATE";
                annotation.IdAnnotation = (int)dRead["idAnnotation"];
            }
            else
            {
                annotation.Annotation = "test";
            }
                

            Test_Commons.dl.SaveAnnotation(annotation, student);

            conn.Close();
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

            string query = "SELECT idAnnotation " +
                " FROM StudentsAnnotations" +
                " WHERE StudentsAnnotations.idStudent=15;";

            cmd.CommandText = query;
            dRead = cmd.ExecuteReader();

            dRead.Read();
            Test_Commons.dl.EraseAnnotationById((int)dRead["idAnnotation"]);

            conn.Close();
        }
    }
}
