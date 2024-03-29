﻿using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal bool SchoolYearExists(string idSchoolYear)
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
        internal void AddSchoolYear(SchoolYear newSchoolYear)
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
    }
}
