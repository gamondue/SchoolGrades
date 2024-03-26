using SchoolGrades;

namespace NUnitDbTests
{
    internal static class Test_Commons
    {
        internal static DataLayer dl;
        internal static string dbTest = "SchoolGrades"; 

        internal static void SetDataLayer()
        {
#if SQL_SERVER
            Test_Commons.dl = new SqlServer_DataLayer(dbTest);
#else
            Test_Commons.dl = new SqLite_DataLayer();
#endif 
        }
    }
}
