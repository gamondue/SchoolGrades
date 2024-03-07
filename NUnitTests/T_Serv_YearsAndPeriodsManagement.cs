using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System.Data.Common;

namespace NUnitDbTests
{
    public class T_Serv_YearsAndPeriodsManagement
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
            Test_Commons.dl.CreateTableSchoolYears();
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
            bool test = Test_Commons.dl.SchoolYearExists("17-18");
            Assert.That(test = true);   //in teoria se è true significa che quell anno esiste

        }
        [Test]
        public void T_SchoolYears_Update(/*SchoolYear schoolYear*/)
        {
            SchoolYear schoolYear1 = new();
            schoolYear1.IdSchoolYear = "24-25";
            schoolYear1.ShortDescription = "2023-2024";
            schoolYear1.Notes = "Anno scolastico introdotto per sola prova";
            // test of DataLayer Methods that update data from table SchoolYears
            Test_Commons.dl.AddSchoolYear(schoolYear1);
            Assert.That(Test_Commons.dl.SchoolYearExists(schoolYear1.IdSchoolYear));
        }
        [Test]
        public void T_SchoolYears_Delete()
        {
            // test of DataLayer Methods that delete data from table SchoolYears
            string anni = "24-25";
            SchoolYear schoolYear1 = new();
            schoolYear1.IdSchoolYear = "24-25";
            schoolYear1.ShortDescription = "2023-2024";
            schoolYear1.Notes = "Anno scolastico introdotto per sola prova";
            Test_Commons.dl.AddSchoolYear(schoolYear1);
        
            Assert.That(Test_Commons.dl.DeleteShcoolYear(anni) = true);

        }
    }
}