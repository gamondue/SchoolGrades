using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SchoolGrades
{
    internal partial class  DataLayer
    {
        internal List<SchoolPeriod> GetSchoolPeriodsOfDate(DateTime Date)
        {
            List<SchoolPeriod> l = new List<SchoolPeriod>();
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *" +
                    " FROM SchoolPeriods" +
                    " WHERE " + SqlDate(Date) +
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
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT * " +
                    "FROM SchoolPeriods"; 
                if (IdSchoolYear != null)
                {
                    query += 
                    " WHERE idSchoolYear=" + SqlString(IdSchoolYear) +
                    " OR IdSchoolYear IS null OR IdSchoolYear=''" +
                    ";";
                }
                cmd.CommandText = query; 
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
            p.IdSchoolPeriodType = Safe.String(Row["idSchoolPeriodType"]);
            if (p.IdSchoolPeriodType != "N")
            {
                p.DateFinish = Safe.DateTime(Row["dateFinish"]);
                p.DateStart = Safe.DateTime(Row["dateStart"]);
            }
            p.Name = Safe.String(Row["name"]);
            p.Desc = Safe.String(Row["desc"]);
            p.IdSchoolPeriod = Safe.String(Row["idSchoolPeriod"]);
            p.IdSchoolYear = Safe.String(Row["idSchoolYear"]);
            return p;
        }
        internal void SaveSchoolPeriod(SchoolPeriod SchoolPeriod)
        {
            if (FindIfIdIsAlreadyExisting(SchoolPeriod.IdSchoolPeriod))
            {
                UpdateSchoolPeriod(SchoolPeriod); 
            }
            else
            {
                CreateSchoolPeriod(SchoolPeriod); 
            }
        }
        internal void CreateSchoolPeriod(SchoolPeriod SchoolPeriod)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "INSERT INTO SchoolPeriods" +
                "(idSchoolPeriod, idSchoolPeriodType, dateStart, dateFinish, " +
                " name, desc, idSchoolYear)"; 
                query += " Values(";
                query += "" + SqlString(SchoolPeriod.IdSchoolPeriod);
                query += "," + SqlString(SchoolPeriod.IdSchoolPeriodType);
                query += "," + SqlDate(SchoolPeriod.DateStart);
                query += "," + SqlDate(SchoolPeriod.DateFinish);
                query += "," + SqlString(SchoolPeriod.Name);
                query += "," + SqlString(SchoolPeriod.Desc);
                query += "," + SqlString(SchoolPeriod.IdSchoolYear);
                query += ");";

                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return;
        }
        internal void UpdateSchoolPeriod(SchoolPeriod SchoolPeriod)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "UPDATE SchoolPeriods" +
                " SET" +
                //" idSchoolPeriod=" + SqlString(SchoolPeriod.IdSchoolPeriod) + "," +
                " idSchoolPeriodType=" + SqlString(SchoolPeriod.IdSchoolPeriodType) + "," +
                " dateFinish=" + SqlDate(SchoolPeriod.DateFinish) + "," +
                " dateStart=" + SqlDate(SchoolPeriod.DateStart) + "," +
                " name=" + SqlString(SchoolPeriod.Name) + "," +
                " desc=" + SqlString(SchoolPeriod.Desc) + "," +
                " idSchoolYear=" + SqlString(SchoolPeriod.IdSchoolYear) +
                " WHERE idSchoolPeriod=" + SqlString(SchoolPeriod.IdSchoolPeriod) +
                ";";

                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal void DeleteSchoolPeriod(string IdSchoolPeriod)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "DELETE FROM SchoolPeriods" +
                " WHERE idSchoolPeriod=" + SqlString(IdSchoolPeriod) +
                ";";

                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal bool FindIfPeriodsAreAlreadyExisting(string SchoolYear)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idSchoolPeriod FROM SchoolPeriods" +
                    " WHERE idSchoolPeriod LIKE '%" + SchoolYear + "%'";
                var onlyColumn = cmd.ExecuteScalar();
                cmd.Dispose();
                return onlyColumn != null;
                //return onlyColumn != DBNull.Value;
            }
        }
        internal bool FindIfIdIsAlreadyExisting(string IdSchoolPeriod)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idSchoolPeriod FROM SchoolPeriods" +
                    " WHERE idSchoolPeriod='" + IdSchoolPeriod + "'";
                var onlyColumn = cmd.ExecuteScalar();
                cmd.Dispose();
                return onlyColumn != null;
            }
        }
        internal List<SchoolPeriodType> GetSchoolPeriodTypes()
        {
            List<SchoolPeriodType> l = new List<SchoolPeriodType>();
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *" +
                    " FROM SchoolPeriodTypes" +
                    ";";
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    SchoolPeriodType p = new SchoolPeriodType();
                    p.IdSchoolPeriodType = Safe.String(dRead["idSchoolPeriodType"]);
                    p.Desc = Safe.String(dRead["desc"]);
                    l.Add(p);
                }
            }
            return l;
        }
    }
}
