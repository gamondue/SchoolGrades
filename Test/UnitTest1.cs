using SchoolGrades;

namespace Test
{
    public class Tests
    {
        BusinessLayer bl;
        string dbCampione = @"..\..\SchoolGrades\bin\Debug\net6.0-windows\Data\SchoolGrades_StandardDb.sqlite";
        string dbTest = @"..\..\SchoolGrades\bin\Debug\net6.0-windows\Data\SchoolGrades_TestDb.sqlite";

        [SetUp]
        public void Setup()
        {
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