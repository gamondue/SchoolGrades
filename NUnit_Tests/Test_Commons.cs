using SchoolGrades;

namespace NUnit_Tests
{
    internal static class Test_Commons
    {
        internal static BusinessLayer bl;
        internal static DataLayer dl;

        internal static string dbStandard = @"..\..\..\SchoolGrades_StandardDb.sqlite";
        internal static string dbTest = @"..\..\..\SchoolGrades_TestDb.sqlite";
        internal static void T_RecoverStandardDb()
        {
            if (File.Exists(dbTest))
                File.Delete(dbTest);
            File.Copy(dbStandard, dbTest);
        }
    }
}
