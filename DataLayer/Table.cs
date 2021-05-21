using System;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using gamon;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades.DataLayer
{
    class Table
    {
        DataLayer dl = new DataLayer();

        internal void SaveTableOnCvs(DataTable Table, string FileName)
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

        internal DataTable GetClassTable(int? idClass)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter dAdapter;
                DataSet dSet = new DataSet();

                string query = "SELECT * FROM Classes" +
                " WHERE Classes.idClass = " + idClass + ";";
                dAdapter = new SQLiteDataAdapter(query, (System.Data.SQLite.SQLiteConnection)conn);
                dAdapter.Fill(dSet);
                t = dSet.Tables[0];
                dAdapter.Dispose();
                dSet.Dispose();
            }
            return t;
        }

        internal DataTable GetClassDataTable(string IdSchool, string IdSchoolYear, string ClassAbbreviation)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter dAdapter;
                DataSet dSet = new DataSet();

                string query = "SELECT DISTINCT registerNumber, Classes.idSchool, Classes.idSchoolYear, " +
                                "Classes.abbreviation, Students.*" +
                " FROM Students, Classes_Students, Classes" +
                " WHERE Students.idStudent = Classes_Students.idStudent AND Classes.idClass = Classes_Students.idClass" +
                    " AND Classes.idSchool = '" + SqlVal.SqlString(IdSchool) + "' AND Classes.idSchoolYear = '" + SqlVal.SqlString(IdSchoolYear) +
                    "' AND Classes.abbreviation = '" + SqlVal.SqlString(ClassAbbreviation) +
                    "' ORDER BY Students.lastName, Students.firstName;";
                dAdapter = new SQLiteDataAdapter(query,
                    (System.Data.SQLite.SQLiteConnection)conn);
                dAdapter.Fill(dSet);
                t = dSet.Tables[0];

                dAdapter.Dispose();
                dSet.Dispose();
            }
            return t;
        }

        internal void GetLookupTable(string Table, ref DataSet DSet, ref DataAdapter DAdapt)
        {
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT * FROM " + Table + ";";
                DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DSet = new DataSet("OpenLookupTable");

                DAdapt.Fill(DSet);
                DAdapt.Dispose();
                DSet.Dispose();
            }
        }

        internal void CreateLookupTableRow(string Table, string IdTable, DataRow Row)
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
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal void BackupTableTsv(string TableName)
        {
            DbDataReader dRead;
            DbCommand cmd;
            string fileContent = "";

            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT *" +
                    " FROM " + TableName + " ";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                int y = 0;
                while (dRead.Read())
                {
                    // field names only in first row 
                    if (y == 0)
                    {
                        string types = "";
                        for (int i = 0; i < dRead.FieldCount; i++)
                        {
                            fileContent += "\"" + dRead.GetName(i) + "\"\t";
                            types += "\"" + SafeDb.SafeString(dRead.GetDataTypeName(i)) + "\"\t";
                        }
                        fileContent = fileContent.Substring(0, fileContent.Length - 1) + "\r\n";
                        fileContent += types.Substring(0, types.Length - 1) + "\r\n";
                    }
                    // field values
                    string values = "";
                    if (dRead.GetValue(0) != null)
                    {
                        Console.Write(dRead.GetValue(0));
                        for (int i = 0; i < dRead.FieldCount; i++)
                        {
                            values += "\"" + SafeDb.SafeString(dRead.GetValue(i).ToString()) + "\"\t";
                        }
                        fileContent += values.Substring(0, values.Length - 1) + "\r\n";
                    }
                    else
                    {

                    }
                    y++;
                }
                TextFile.StringToFile(Commons.PathDatabase + "\\" + TableName + ".tsv", fileContent, false);
                dRead.Dispose();
                cmd.Dispose();
            }
        }

        internal void BackupTableXml(string TableName)
        {
            DataAdapter dAdapt;
            DataSet dSet = new DataSet();
            DataTable t;
            string query = "SELECT *" +
                    " FROM " + TableName + ";";

            using (DbConnection conn = dl.Connect())
            {
                dAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                dSet = new DataSet("GetTable");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                t.WriteXml(Commons.PathDatabase + "\\" + TableName + ".xml",
                    XmlWriteMode.WriteSchema);

                dAdapt.Dispose();
                dSet.Dispose();
            }
        }

        internal void RestoreTableTsv(string TableName, bool EraseBefore)
        {
            List<string> fieldNames;
            List<string> fieldTypes = new List<string>();
            //string[,] dati = FileDiTesto.FileInMatrice(Commons.PathDatabase +
            //    "\\" + TableName + ".tsv", '\t',
            //    out fieldsNames, out fieldTypes);
            string dati = TextFile.FileToString(Commons.PathDatabase +
                "\\" + TableName + ".tsv");
            if (dati is null)
                return;
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                if (EraseBefore)
                {
                    // first: erases existing rows in the table
                    cmd.CommandText += "DELETE FROM " + TableName + ";";
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Append of table records to an existing table id not implemented yet");
                    //return; 
                }
                string fieldsString = " (";
                string valuesString;
                int fieldsCount = 0;

                int index = 0;
                string fieldName = "";
                while (index < dati.Length)
                {
                    // parse first line: field names
                    fieldNames = new List<string>();
                    do
                    {
                        if (dati[index++] != '\"')
                            return; // error! 
                        fieldName = "";
                        while (dati[index] != '\"')
                        {
                            fieldName += dati[index++];
                        }
                        fieldNames.Add(fieldName);
                        fieldsString += fieldName + ",";
                        fieldsCount++;
                        if (dati[++index] != '\t' && dati[index] != '\r')
                            return; // ERROR!
                    } while (dati[++index] != '\r');
                    index++; // void line feed

                    // parse second line: field types
                    string fieldType = "";
                    while (dati[index] != '\r')
                    {
                        while (dati[index] != '\"')
                        {
                            fieldType += dati[index++];
                        }
                        fieldTypes.Add(fieldType);
                        fieldsString += fieldName + ",";
                        fieldsCount++;
                    }
                    index++; // void line feed

                    // parse the rest of the rows: values
                    string fieldValue = "";
                    while (dati[index] != '\r')
                    {
                        while (dati[index] != '\"')
                        {
                            fieldType += dati[index++];
                        }
                        fieldTypes.Add(fieldType);
                        fieldsString += fieldName + ",";
                        fieldsCount++;
                    }
                }
                //for (int col = 0; col < dati.GetLength(1); col++)
                //{
                //    if (fieldNames[col] != "")
                //    {
                //        fieldsString += fieldNames[col] + ",";
                //        fieldsCount++; 
                //    }
                //}
                //fieldsString = fieldsString.Substring(0, fieldsString.Length - 1);
                //fieldsString += ")";
                //for (int row = 0; row < dati.GetLength(0); row++)
                //{
                //    valuesString = " Values (";
                //    for (int col = 0; col < fieldsCount; col++)
                //    {
                //        if (fieldNames[col] != "")
                //        {
                //            if (fieldTypes[col].IndexOf("VARCHAR") >= 0)
                //                valuesString += "'" + SqlVal.SqlString(dati[row, col]) + "',";
                //            else if (fieldTypes[col].IndexOf("INT") >= 0)
                //                valuesString +=  SqlVal.SqlInt(dati[row, col]) + ",";
                //            else if (fieldTypes[col].IndexOf("REAL") >= 0)
                //                valuesString += SqlFloat(dati[row, col]) + ",";
                //            else if (fieldTypes[col].IndexOf("FLOAT") >= 0)
                //                valuesString += SqlFloat(dati[row, col]) + ",";
                //            else if (fieldTypes[col].IndexOf("DATE") >= 0)
                //                valuesString += SqlVal.SqlDate(dati[row, col]) + ",";
                //        }
                //    }
                //    valuesString = valuesString.Substring(0, valuesString.Length - 1);
                //    valuesString += ")";
                //    cmd.CommandText = "INSERT INTO " + TableName +
                //                fieldsString +
                //                valuesString;
                //    //" WHERE " + fieldsNames[0] + "=";
                //    //if (fieldTypes[0].IndexOf("VARCHAR") >= 0)
                //    //    cmd.CommandText += "'" + StringSql(dati[row, 0]) + "'";
                //    //else
                //    //    cmd.CommandText += StringSql(dati[row, 0]);
                //    cmd.CommandText += ";";
                //    cmd.ExecuteNonQuery();
                //}
                //cmd.Dispose();
            }
        }

        internal void RestoreTableXml(string TableName, bool EraseBefore)
        {
            DataSet dSet = new DataSet();
            DataTable t = null;
            dSet.ReadXml(Commons.PathDatabase + "\\" + TableName + ".xml", XmlReadMode.ReadSchema);
            t = dSet.Tables[0];
            if (t.Rows.Count == 0)
                return;
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd;
                cmd = conn.CreateCommand();
                if (EraseBefore)
                {
                    cmd.CommandText = "DELETE FROM " + TableName + ";";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "INSERT INTO " + TableName + "(";
                // column names
                DataRow r = t.Rows[0];
                foreach (DataColumn c in t.Columns)
                {
                    cmd.CommandText += c.ColumnName + ",";
                }
                cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);
                cmd.CommandText += ")VALUES";
                // row values
                foreach (DataRow row in t.Rows)
                {
                    cmd.CommandText += "(";
                    foreach (DataColumn c in t.Columns)
                    {
                        switch (Type.GetTypeCode(c.DataType))
                        {
                            case TypeCode.String:
                            case TypeCode.Char:
                                {
                                    cmd.CommandText += "'" + SqlVal.SqlString(row[c.ColumnName].ToString()) + "',";
                                    break;
                                };
                            case TypeCode.DateTime:
                                {
                                    DateTime? d = SafeDb.SafeDateTime(row[c.ColumnName]);
                                    cmd.CommandText += "'" +
                                        ((DateTime)(d)).ToString("yyyy-MM-dd_HH.mm.ss") + "',";
                                    break;
                                }
                            default:
                                {
                                    if (!(row[c.ColumnName] is DBNull))
                                        cmd.CommandText += row[c.ColumnName] + ",";
                                    else
                                        cmd.CommandText += "0,";
                                    break;
                                }
                        }
                    }
                    cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);
                    cmd.CommandText += "),";
                }
                cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);
                cmd.CommandText += ";";
                cmd.ExecuteNonQuery();
                dSet.Dispose();
                t.Dispose();
                cmd.Dispose();
            }
        }
    }
}
