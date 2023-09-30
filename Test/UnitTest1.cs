using SchoolGrades;

namespace Test
{
    public class Tests
    {
        const string dbCampione = @"..\..\..\..\Test\SchoolGrades_StandardDb.sqlite";
        const string dbTest = @"..\..\..\..\Test\SchoolGrades_TestDb.sqlite";

        [SetUp]
        public void Setup()
        {
            File.Copy(dbCampione, dbTest);
            var bl = new BusinessLayer(dbTest);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}