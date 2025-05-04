using gamon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace SchoolGrades
{
    internal partial class SqlServer_DataLayer : DataLayer
    {
        internal override DataTable GetLookupTable(string NameOfTable, string PrimaryKeyName)
        {
            // connection il left open and stored internally; it will be closed by the UpdateInternalDataSet() Method
            internalConnection = Connect();
            string query = "SELECT * FROM " + NameOfTable + ";";
            internalDataAdapter = new SqlDataAdapter(query, (SqlConnection)internalConnection);
            internalDataSet = new DataSet("OpenLookupTable");
            internalDataAdapter.Fill(internalDataSet);
            DataTable Table = internalDataSet.Tables[0];
            return Table;
        }
        internal override void UpdateInternalDataSet()
        {
            // Ensure the SqlCommandBuilder is used to generate commands for the SqlDataAdapter
            SqlCommandBuilder CommandBuilder = new SqlCommandBuilder((SqlDataAdapter)internalDataAdapter);

            // Generate InsertCommand, UpdateCommand, and DeleteCommand
            internalDataAdapter.InsertCommand = CommandBuilder.GetInsertCommand();
            internalDataAdapter.UpdateCommand = CommandBuilder.GetUpdateCommand();
            internalDataAdapter.DeleteCommand = CommandBuilder.GetDeleteCommand();

            // Update the DataSet
            internalDataAdapter.Update(internalDataSet);
        }
        internal override void SaveTableOnCsv(DataTable Table, string FileName)
        {
            string fileContent = "";
            foreach (DataColumn col in Table.Columns)
            {
                fileContent += col.Caption + '\t';
            }
            fileContent += "\r\n";
            foreach (DataRow row in Table.Rows)
            {
                foreach (DataColumn col in Table.Columns)
                {
                    fileContent += row[col].ToString() + '\t';
                }
                fileContent += "\r\n";
            }
            TextFile.StringToFile(FileName, fileContent, false);
        }
        internal override void CreateLookupTableRow(string Table, string IdTable, DataRow Row)
        {
            // !!!! TODO !!!! GENERALIZZARE A TABELLE CON NOMI DEI CAMPI ARBITRARI E FAR FUNZIONARE !!!!
            string query;
            try
            {
                // if key field is Integer, this works
                int iId = (int)Row[0];
                query = "INSERT INTO " + Table +
                    " (" + IdTable + ", name, desc)" +
                    " VALUES (" + iId + ",'" + Row["name"] + "','" + Row["desc"] + "'" +
                ");";
            }
            catch
            {
                // if key field wasn't Integer, this other will work 
                string sId = (string)Row[0];
                query = "INSERT INTO " + Table +
                    " (" + IdTable + ", name, desc)" +
                    " VALUES ('" + sId + "','" + Row["name"] + "','" + Row["desc"] + "'" +
                ");";
            }
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal override void UpdateLookupTableRow(string Table, string IdTable, DataRow Row)
        {
            throw new NotImplementedException();
        }
    }
}
