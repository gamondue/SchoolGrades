using gamon;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;

namespace SchoolGrades
{
    internal partial class SqLite_DataLayer : DataLayer
    {
        internal override DataTable GetLookupTable(string NameOfTable, string PrimaryKeyName)
        {
            // connection il left open and stored internally, like the rest of data access objects;
            // they will be closed by the UpdateInternalDataSet() Method
            internalConnection = Connect();
            string query = "SELECT * FROM " + NameOfTable + ";";
            internalDataAdapter = new SQLiteDataAdapter(query, (SQLiteConnection)internalConnection);
            internalDataSet = new DataSet("OpenLookupTable");
            internalDataAdapter.Fill(internalDataSet);
            internalDataTable = internalDataSet.Tables[0];
            return internalDataTable;
        }
        internal override void UpdateInternalDataSet()
        {
            // Ensure the SqlCommandBuilder is used to generate commands for the SqlDataAdapter
            SQLiteCommandBuilder CommandBuilder = new SQLiteCommandBuilder((SQLiteDataAdapter)internalDataAdapter);

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

            // t
            //string query;
            //try
            //{
            //    // if key field is Integer, this works
            //    int iId = (int)Row[0];
            //    query = "INSERT INTO " + NameOfTable +
            //        " (" + IdTable + ", name, desc)" +
            //        " VALUES (" + iId + ",'" + Row["name"] + "','" + Row["desc"] + "'" +
            //    ");";
            //}
            //catch
            //{
            //    // if key field wasn't Integer, this other will work 
            //    string sId = (string)Row[0];
            //    query = "INSERT INTO " + NameOfTable +
            //        " (" + IdTable + ", name, desc)" +
            //        " VALUES ('" + sId + "','" + Row["name"] + "','" + Row["desc"] + "'" +
            //    ");";
            //}
            //using (DbConnection conn = Connect())
            //{
            //    DbCommand cmd = conn.CreateCommand();
            //    cmd.CommandText = query;

            //    cmd.ExecuteNonQuery();
            //    cmd.Dispose();
            //}
        }
        internal override void UpdateLookupTableRow(string Table, string IdTable, DataRow Row)
        {
            //// !!!! TODO !!!! METTERE UPDATE E GENERALIZZARE A TABELLE CON NOMI DEI CAMPI ARBITRARI E FAR FUNZIONARE !!!!
            //string query;
            //try
            //{
            //    // if key field is Integer, this works
            //    int iId = (int)Row[0];
            //    query = "UPDATE " + internalDataTable +
            //        " (" + IdTable + ", name, desc)" +
            //        " VALUES (" + iId + ",'" + Row["name"] + "','" + Row["desc"] + "'" +
            //    ");";
            //}
            //catch
            //{
            //    // if key field wasn't Integer, this other will work 
            //    string sId = (string)Row[0];
            //    query = "UPDATE " + internalDataTable +
            //        " (" + IdTable + ", name, desc)" +
            //        " VALUES ('" + sId + "','" + Row["name"] + "','" + Row["desc"] + "'" +
            //    ");";
            //}
            //using (DbConnection conn = Connect())
            //{
            //    DbCommand cmd = conn.CreateCommand();
            //    cmd.CommandText = query;

            //    cmd.ExecuteNonQuery();
            //    cmd.Dispose();
            //}
        }
        internal override bool PrimaryKeyExistsInInternalDataTable(string nameOfTable, string nameOfPrimaryKey,
            object valueOfPrimaryKey)
        {
            // LINQ expression that checks if the primary key exists in the DataTable
            bool containsValueOfPrimaryKey = internalDataTable.AsEnumerable().
                Any(row => row.Field<string>(nameOfPrimaryKey) == valueOfPrimaryKey);
            return containsValueOfPrimaryKey;
        }
        internal override bool LookupTableDataHasChanged()
        {
            // find if the data in the internalDataSet has changed
            return internalDataTable.GetChanges() != null;
        }
    }
}
