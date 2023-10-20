using SchoolGrades.BusinessObjects;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal object ReadFirstRowFirstField(string Table)
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
                // TODO !!!! FIX !!!!
            }
            return r;
        }
    }
}
