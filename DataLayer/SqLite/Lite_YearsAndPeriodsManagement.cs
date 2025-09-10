using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
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
        internal override List<SchoolYear> GetAllSchoolYears()
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<SchoolYear> ly = new List<SchoolYear>();

            // Execute the query
            using (DbConnection conn = Connect())
            {
                // get the list of school years that have classes,
                // order by school year with 9X-9X+1 years first
                string query =
                    @"SELECT *
                    FROM SchoolYears
                    WHERE SchoolYears.IdSchoolYear IS NOT NULL
                    ORDER BY
                        CASE
                            WHEN SUBSTRING(SchoolYears.IdSchoolYear, 1, 1) BETWEEN '5' AND '9' THEN 1
                        ELSE 2
                    END,
                    SchoolYears.IdSchoolYear ASC" +
                    ";";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    SchoolYear y = new SchoolYear();
                    y.IdSchoolYear = (string)dRead["idSchoolYear"];
                    y.ShortDescription = Safe.String(dRead["shortDesc"]);
                    y.Notes = Safe.String(dRead["notes"]);
                    ly.Add(y);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return ly;
        }
    }
}
