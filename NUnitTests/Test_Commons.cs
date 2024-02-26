using SchoolGrades;

namespace NUnitDbTests
{
    internal static class Test_Commons
    {
        internal static DataLayer dl;

        internal static void CreateDataLayer()
        {
#if SQL_SERVER
            Test_Commons.dl = new SqlServer_DataLayer("SchoolGrades");
#else
            Test_Commons.dl = new SqLite_DataLayer();
#endif 
        }
    }
}
