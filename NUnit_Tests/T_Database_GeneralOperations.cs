using SchoolGrades;

namespace NUnit_Tests
{
    public class T_Database_GeneralOperations
    {
        [SetUp]
        public void Setup()
        {
            Commons.PathAndFileDatabase = Test_Commons.dbTest;

            // datalayer to directly check results of database operations
            Test_Commons.dl = new DataLayer(Test_Commons.dbTest);
            // business layer to test 
            Test_Commons.bl = new BusinessLayer();
        }
        [Test]
        public void T_CreateDatabaseFromExisting()
        {
            Commons.PathAndFileDatabase = Test_Commons.dbCampione;
            Test_Commons.bl.CreateNewDatabase(Test_Commons.dbTest);
            Test_Commons.T_RecoverStandardDb(); 
            Assert.That(Test_Commons.dl.ReadFirstRowFirstField("Students") == null);
        }
    }
}