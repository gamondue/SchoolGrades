using System;
using System.Data.Common;
using System.IO;

namespace SchoolGrades
{
    internal partial class SqlServer_DataLayer : DataLayer
    {
		string creationScript = @""; 

        // special override, only in this class 
        internal override void CreateNewDatabaseFromScratch(string dbName)
        {
            try
            {
                using (DbConnection conn = ConnectNoDatabase())
                {
                    DbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE [name]='" + dbName + "')" +
                        " CREATE DATABASE " + dbName + ";";
                    //cmd.CommandText = "CREATE DATABASE " + dbName + ";";
                    cmd.ExecuteNonQuery();
                    if (creationScript != "")
                    {
                        cmd.CommandText = creationScript;
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                //Common.LogOfProgram.Error("SQL server_DataAndGeneral | CreateNewDatabaseFromScratch", ex);
            }
        }
    }
}
