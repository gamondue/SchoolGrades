using gamon;
using System;
using System.Data;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace SchoolGrades
{
    internal partial class SqLite_DataLayer : DataLayer
    {
        internal override DataTable GetLookupTable(string NameOfTable, string PrimaryKeyName)
        {
            internalConnection = Connect();
            string query = "SELECT * FROM " + NameOfTable + ";";
            internalDataSet = new DataSet("OpenLookupTable");
            using (DbCommand cmd = internalConnection.CreateCommand())
            {
                cmd.CommandText = query;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    internalDataTable = new DataTable();
                    internalDataTable.Load(reader);
                }
            }
            internalDataSet.Tables.Add(internalDataTable);
            return internalDataTable;
        }
        internal override void UpdateInternalDataSet()
        {
            // Manual update logic required; SqliteDataAdapter and SqliteCommandBuilder removed.
            // This method should be implemented to update the database from internalDataTable changes if needed.
            throw new NotImplementedException("UpdateInternalDataSet is not implemented without SqliteDataAdapter.");
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
