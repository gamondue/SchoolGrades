using SchoolGrades;
using SchoolGrades.BusinessObjects;

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