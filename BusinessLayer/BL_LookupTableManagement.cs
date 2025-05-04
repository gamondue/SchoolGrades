using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal DataTable GetLookupTable(string tableName, string PrimaryKeyName)
        {
            return dl.GetLookupTable(tableName, PrimaryKeyName);
        }
        internal void UpdateLookupTableRow(string table, string idTable, DataRow riga)
        {
            dl.UpdateLookupTableRow(table, idTable, riga);
        }
        internal void CreateLookupTableRow(string table, string idTable, DataRow riga)
        {
            dl.CreateLookupTableRow(table, idTable, riga);
        }
        internal void SaveTableOnCvs(DataTable dataSource, string fileName)
        {
            dl.SaveTableOnCsv(dataSource, fileName);
        }
        internal void BackupTableXml(string Value)
        {
            dl.BackupTableXml(Value);
        }
        internal void UpdateLookupTable()
        {
            dl.UpdateInternalDataSet();
        }
        internal void CloseLookupTableEditing()
        {
            dl.CloseInternalConnection();
        }
        internal bool PrimaryKeyExists(string nameOfTable,
            string nameOfPrimaryKey, object valueOfPrimaryKey)
        {
            return dl.PrimaryKeyExistsInInternalDataTable(nameOfTable, nameOfPrimaryKey, valueOfPrimaryKey);
        }
        internal bool LookupTableDataHasChanged()
        {
            return dl.LookupTableDataHasChanged();
        }
    }
}
