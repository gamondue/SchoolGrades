using SchoolGrades.BusinessObjects;
using System.Data.Common;

namespace SchoolGrades
{
    // QUERY USATE PER CREARE LE TABELLE 
    //-- Tabella: SchoolYears
    //CREATE TABLE "SchoolYears" (
    //  "idSchoolYear" VARCHAR(4) NOT NULL,
    //  "shortDesc" VARCHAR(10) NULL,
    //  "notes" VARCHAR(255) NULL,
    //  PRIMARY KEY("idSchoolYear"));

    // CODICE DEI PROGRAMMI DI PROVA
    //SchoolYear sy = new();
    //sy.IdSchoolYear = "23-24";
    //        sy.Notes = "Anno di prova";
    //        sy.ShortDescription = "2023-2024";
    //        sy.Notes = "Anno scolastico introdotto per sola prova";
    //        Commons.bl.AddSchoolYearIfNotExists(sy);

    internal partial class SqlServer_DataLayer : DataLayer
    {
        internal void CreateTableSchoolYears()
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // Tabella: SchoolYears
                cmd.CommandText = @"CREATE TABLE SchoolYears (
                    'idSchoolYear' VARCHAR(4) NOT NULL,
                    'shortDesc' VARCHAR(10) NULL,
                    'notes' VARCHAR(255) NULL,
                    PRIMARY KEY(idSchoolYear));";
                cmd.ExecuteNonQuery();
            }
        }
        internal override bool SchoolYearExists(string idSchoolYear)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT TOP 1 idSchoolYear" +
                    " FROM SchoolYears" +
                    " WHERE idSchoolYear='" + idSchoolYear + "'" +
                    ";";
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
    }
}
