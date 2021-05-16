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
    class SchoolPeriodsManagement
    {
        DataLayer dl = new DataLayer();

        internal SchoolPeriod GetOneSchoolPeriodFromRow(DbDataReader Row)
        {
            SchoolPeriod p = new SchoolPeriod();
            p.IdSchoolPeriodType = SafeDb.SafeString(Row["idSchoolPeriodType"]);
            if (p.IdSchoolPeriodType != "N")
            {
                p.DateFinish = SafeDb.SafeDateTime(Row["dateFinish"]);
                p.DateStart = SafeDb.SafeDateTime(Row["dateStart"]);
            }
            p.Name = SafeDb.SafeString(Row["name"]);
            p.Desc = SafeDb.SafeString(Row["desc"]);
            p.IdSchoolPeriod = SafeDb.SafeString(Row["idSchoolPeriod"]);
            p.IdSchoolYear = SafeDb.SafeString(Row["idSchoolYear"]);
            return p;
        }

        internal List<SchoolPeriod> GetSchoolPeriods(string IdSchoolYear)
        {
            List<SchoolPeriod> l = new List<SchoolPeriod>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM SchoolPeriods " +
                    "WHERE idSchoolYear=" + IdSchoolYear +
                    " OR IdSchoolYear IS null OR IdSchoolYear=''" +
                    ";";
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    SchoolPeriod p = GetOneSchoolPeriodFromRow(dRead);
                    l.Add(p);
                }
            }
            return l;
        }

        internal List<SchoolPeriod> GetSchoolPeriodsOfDate(DateTime Date)
        {
            List<SchoolPeriod> l = new List<SchoolPeriod>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *" +
                    " FROM SchoolPeriods" +
                    " WHERE " + SqlVal.SqlDate(Date) +
                    " BETWEEN dateStart and dateFinish" +
                    ";";
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    SchoolPeriod p = GetOneSchoolPeriodFromRow(dRead);
                    l.Add(p);
                }
            }
            return l;
        }
    }
}
