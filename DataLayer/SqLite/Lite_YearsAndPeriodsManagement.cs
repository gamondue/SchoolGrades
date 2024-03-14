using SchoolGrades.BusinessObjects;
using System;
using System.Data.Common;

namespace SchoolGrades
{
    internal partial class SqLite_DataLayer : DataLayer
    {
        internal override void CreateTableSchoolYears()
        {
            throw new NotImplementedException();
        }
        internal override bool SchoolYearExists(string idSchoolYear)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idSchoolYear" +
                    " FROM SchoolYears" +
                    " WHERE idSchoolYear='" + idSchoolYear + "'" +
                    " LIMIT 1; ";
                var result = cmd.ExecuteScalar();
                return (result != null);
            }
        }
        internal override void AddSchoolYear(SchoolYear newSchoolYear)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO SchoolYears" +
                    " (idSchoolYear,shortDesc,notes)" +
                    " Values (" +
                    SqlString(newSchoolYear.IdSchoolYear) +
                    "," + SqlString(newSchoolYear.ShortDescription) + "" +
                    "," + SqlString(newSchoolYear.Notes) + "" +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal override void DeleteSchoolYear(string anno)
        {
            throw new NotImplementedException();
        }
    }
}
