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
            Test_Commons.dl.CreateTableStudents();
            // !!!! TODO !!!! Assert that the table exists
            //Assert.That(Test_Commons.dl.exist)
            // populate table 
            SchoolYear sy = new();
            sy.IdSchoolYear = "23-24";
            sy.ShortDescription = "2023-2024";
            sy.Notes = "Anno scolastico introdotto per sola prova";
            Assert.That(!Test_Commons.dl.SchoolYearExists(sy.IdSchoolYear));
            Test_Commons.dl.AddSchoolYear(sy);
            Assert.That(Test_Commons.dl.SchoolYearExists(sy.IdSchoolYear));
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
        }











    }
}
