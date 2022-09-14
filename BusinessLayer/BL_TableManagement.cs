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
        internal void GetLookupTable(string table, ref DataSet ds, ref DataAdapter da)
        {
            dl.GetLookupTable(table, ref ds, ref da);
        }
        internal void SaveTableOnCvs(DataTable dataSource, string fileName)
        {
            dl.SaveTableOnCsv(dataSource, fileName);
        }
        internal void BackupTableXml(string Value)
        {
            dl.BackupTableXml(Value);
        }
    }
}
