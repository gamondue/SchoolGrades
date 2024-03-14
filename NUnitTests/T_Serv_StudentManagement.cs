using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDbTests
{
    internal class T_Serv_StudentManagement
    {




        [SetUp]
        public void Setup()
        {
            Test_Commons.SetDataLayer();
        }
        [Test]
        public void T_SchoolYears_Create()
        {
            // create table
            //Test_Commons.dl.CreateTableStudents(); //i comment it because the table has already been createded and if i run it during test it gives me error becuse already exist
            // !!!! TODO !!!! Assert that the table exists do it on your own, start from zero
            //Assert.That(Test_Commons.dl.exist)


            // populate table 

            #region esempio prof
            //SchoolYear sy = new();
            //sy.IdSchoolYear = "23-24";
            //sy.ShortDescription = "2023-2024";
            //sy.Notes = "Anno scolastico introdotto per sola prova";
            //Assert.That(!Test_Commons.dl.SchoolYearExists(sy.IdSchoolYear));
            //Test_Commons.dl.AddSchoolYear(sy);
            //Assert.That(Test_Commons.dl.SchoolYearExists(sy.IdSchoolYear));
            #endregion


            //START CREATING THE IMPLMENTATION OF "EXIXST"

            Assert.That(Test_Commons.dl.ExistTable(), Is.True);


            
            
            //Creating an itance of Student to use as a parameter in the createStudent method
            Student student = new Student();


            student.SchoolYear = "23-24";
            student.BirthPlace = "Internet";
            //student.BirthDate = DateTime.Now;
            student.FirstName = "Enes";
            student.LastName = "Sela";
            student.Email = "EnesSela@gmail.com";
            

            Test_Commons.dl.CreateStudent(student);


        }
        [Test]
        public void T_SchoolYears_Read()
        {
            // test of DataLayer Methods that read data from table SchoolYears
        }
        [Test]
        public void T_SchoolYears_Update()
        {
            // test of DataLayer Methods that update data from table SchoolYears

        }
        [Test]
        public void T_SchoolYears_Delete()
        {
            // test of DataLayer Methods that delete data from table SchoolYears

            //Test_Commons.dl.DelateTable();
        }











    }
}
