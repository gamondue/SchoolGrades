using System.Data.Common;
using System.IO;

namespace SchoolGrades
{
    internal partial class SqLite_DataLayer : DataLayer
    {
        //internal static BusinessLayer bl;
        internal static DataLayer dl;

        internal static string dbStandard = @"..\..\..\SchoolGrades_StandardDb.sqlite";
        internal static string dbTest = @"..\..\..\SchoolGrades_TestDb.sqlite";
        internal override object ReadFirstRowFirstField(string Table)
        {
            object r;
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM " + Table +
                    " LIMIT 1" +
                    ";";
                r = cmd.ExecuteScalar();
            }
            return r;
        }
        internal static void T_RecoverStandardDb()
        {
            if (File.Exists(dbTest))
                File.Delete(dbTest);
            File.Copy(dbStandard, dbTest);
        }
    }
}
