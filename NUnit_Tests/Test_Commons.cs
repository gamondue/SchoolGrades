using SchoolGrades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Tests
{
    internal static class Test_Commons
    {
        internal static BusinessLayer bl;
        internal static DataLayer dl;

        internal static string dbCampione = @"..\..\..\SchoolGrades_StandardDb.sqlite";
        internal static string dbTest = @"..\..\..\SchoolGrades_TestDb.sqlite";
        internal static void T_RecoverStandardDb()
        {
            Commons.PathAndFileDatabase = dbCampione;
            bl.CreateNewDatabase(dbTest);
            Assert.That(dl.ReadFirstRowFirstField("Students") == null);
        }
    }
}
