using SchoolGrades;
using SchoolGrades.BusinessObjects;

namespace NUnitDbTests
{
    public class T_Database_GeneralOperations
    {
        [SetUp]
        public void Setup()
        {
            Test_Commons.SetDataLayer(); 
        }
        [Test]
        public void T_CreateDatabase()
        {
            Test_Commons.dl.CreateNewDatabaseFromScratch(Test_Commons.dbTest);
        }
        //[Test]
        //public void T_CreateNewDatabaseFromExisting()
        //{
        //    Commons.PathAndFileDatabase = Test_Commons.dbStandard;
        //    Test_Commons.bl.CreateNewDatabaseFromExisting(Test_Commons.dbTest);
        //    Assert.That(Test_Commons.dl.ReadFirstRowFirstField("Students") == null);
        //    Assert.That(Test_Commons.dl.ReadFirstRowFirstField("Lessons") == null);
        //}
        //[Test]
        //public void T_RecoverDatabaseFromStandard()
        //{
        //    Test_Commons.T_RecoverStandardDb();
        //    Assert.That(Test_Commons.dl.ReadFirstRowFirstField("Students") != null);
        //    Assert.That(Test_Commons.dl.ReadFirstRowFirstField("Lessons") != null);
        //}
    }
}