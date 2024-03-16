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
        public void T_Serv_AnnotationManagement_aCreate()
        {
            DbConnection conn;

            string connectionStringSqlServer = "SERVER=localhost;UID=sa;PWD=burbero2023;Database=SchoolGrades;TrustServerCertificate=true;";

            conn = new SqlConnection(connectionStringSqlServer);
            conn.Open();

            DbCommand cmd = conn.CreateCommand();
            string query;
            query = "CREATE TABLE StudentsAnnotations " +
            "(idAnnotation INT PRIMARY KEY, " +
            "idStudent INT, annotation VARCHAR(256), " +
            "idSchoolYear VARCHAR(5), instantTaken DATETIME, " +
            "instantClosed DATETIME, isActive INT, " +
            "isPopUp INT);";

            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            ;
            Student student = new Student();
            student.IdStudent = 15;
            StudentAnnotation annotation = new StudentAnnotation();
            annotation.Annotation = "test";
            annotation.InstantTaken = null;
            annotation.InstantClosed = null;
            Test_Commons.dl.SaveAnnotation(annotation, student);
            annotation.IdAnnotation = null;
            annotation.Annotation = "test deleteByText";
            Test_Commons.dl.SaveAnnotation(annotation, student);

            query = "SELECT * " +
                " FROM StudentsAnnotations" +
                " WHERE StudentsAnnotations.idStudent=" +
                student.IdStudent + ";";

            cmd.CommandText = query;
            DbDataReader dRead;
            dRead = cmd.ExecuteReader();

            Assert.That(dRead.Read());
            Assert.Pass("Creazione della tabella avvenuta + inserimento didati all'interno di essa.");
            conn.Close();
        }
        [Test]
        public void T_Serv_AnnotationManagement_bRead()
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
            StudentAnnotation a;
            while (dRead.Read())
            {
                a = Test_Commons.dl.GetAnnotationFromRow(dRead);
                Assert.That((int)dRead["idAnnotation"], Is.EqualTo(a.IdAnnotation));
            }

            a = Test_Commons.dl.GetAnnotation(1);

            Assert.That((int)a.IdAnnotation, Is.EqualTo(1));
            Assert.Pass("Lettura dei dati precedentemente inseriti avvenuta correttamente.");
            conn.Close();
        }
        [Test]
        public void T_Serv_AnnotationManagement_cUpdate()
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
                Assert.Fail("Non viene modificata, ma creata da zero!!");
            }
                

            Assert.That(Test_Commons.dl.SaveAnnotation(annotation, student), Is.EqualTo(1));
            Assert.Pass("Update avvenuto 'test' --> 'test UPDATE'.");
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
            Student student = new Student();
            student.IdStudent = 15;

            string query = "SELECT idAnnotation " +
                " FROM StudentsAnnotations" +
                " WHERE StudentsAnnotations.idStudent=" +
                student.IdStudent + ";";

            cmd.CommandText = query;
            dRead = cmd.ExecuteReader();

            while (dRead.Read())
            {
                Test_Commons.dl.EraseAnnotationById((int)dRead["idAnnotation"]);
                Test_Commons.dl.EraseAnnotationByText("test deleteByText", student);
            }
            Assert.That(!dRead.Read());
            Test_Commons.dl.DeleteTable("StudentsAnnotations");
            Assert.That(!Test_Commons.dl.ExistsTable("StudentsAnnotations"));
            Assert.Pass("Eliminati i dati di SchoolGrades.StudentsAnnotations + drop della tabella stessa.");

            conn.Close();
        }
    }
}
