using SchoolGrades;
using SchoolGrades.BusinessObjects;

namespace NUnitDbTests
{
    public class T_Serv_YearsAndPeriodsManagement
    {
        [SetUp]
        public void Setup()
        {
#if SQL_SERVER

            Helpers.dl = new SqlServer_DataLayer("SchoolGrades");
#else
            Helpers.dl = new SqLite_DataLayer();
#endif 
        }
        [Test]
        public void T_TableSchoolYears()
        {
            Helpers.dl.CreateTableSchoolYears();
            Assert.That(!Helpers.dl.SchoolYearExists(sy.IdSchoolYear));

            SchoolYear sy = new();
            sy.IdSchoolYear = "23-24";
            sy.Notes = "Anno di prova";
            sy.ShortDescription = "2023-2024";
            sy.Notes = "Anno scolastico introdotto per sola prova";
            Helpers.dl.AddSchoolYear(sy);

            Assert.That(Helpers.dl.SchoolYearExists(sy.IdSchoolYear));
            List<SchoolYear> list = Helpers.dl.GetSchoolYearsThatHaveClasses();
            // Assert the results
            // !!!! TODO

        }
    }
}