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
    //Andrea Siboni, Francesco Citarella, Cesare Colella, Riccardo Brunelli 4°L
    class SchoolData
    {
        DataLayer dl = new DataLayer();

        internal School GetSchool(string OfficialSchoolAbbreviation)
        {
            // !!!! TODO read school info from the database !!!!
            School news = new School();
            // the next should be a real integer id, 
            news.IdSchool = Commons.IdSchool;
            news.Name = "IS Pascal Comandini";
            news.Desc = "Istituto Di Istruzione Superiore Pascal-Comandini, Cesena";
            news.OfficialSchoolAbbreviation = Commons.IdSchool;
            return news;
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

    }
}
