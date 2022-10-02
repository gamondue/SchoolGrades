using gamon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using System.Text;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal void GetLookupTable(string Table, ref DataSet DSet, ref DataAdapter DAdapt)
        {
            using (DbConnection conn = Connect())
            {
                // !!!! TODO fix this !!!!
                //////Exception exception = new Exception.
                //////string query = "SELECT * FROM " + Table + ";";
                //////DbCommand cmd = conn.CreateCommand();
                //////cmd.CommandText = query;
                //////t = new DataTable();
                //////DbDataReader reader = cmd.ExecuteReader();
                //////t.Load(reader);

                ////////DAdapt = new SQLiteDataAdapter(query, (SqliteConnection)conn);
                ////////DSet = new DataSet("OpenLookupTable");

                ////////DAdapt.Fill(DSet);
                ////////DAdapt.Dispose();
                ////////DSet.Dispose();
            }
        }
        internal void SaveTableOnCsv(DataTable Table, string FileName)
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
        internal void CreateLookupTableRow(string Table, string IdTable, DataRow Row)
        {
            // !!!! TODO !!!! GENERALIZZARE A TABELLE CON NOMI DEI CAMPI ARBITRARI E FAR FUNZIONARE !!!!
            string query;
            try
            {
                // if key field is Integer, this works
                int iId = Safe.Int(Row[0]);
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
    }
}
