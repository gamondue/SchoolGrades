using SchoolGrades;

namespace Test
{
    public class Tests
    {
        BusinessLayer bl;
        string dbCampione = @"..\..\..\SchoolGrades_StandardDb.sqlite";
        string dbTest = @"..\..\..\SchoolGrades_TestDb.sqlite";

        [SetUp]
        public void Setup()
        {
            File.Delete(dbTest);
            File.Copy(dbCampione, dbTest);
            bl = new BusinessLayer(dbTest);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}