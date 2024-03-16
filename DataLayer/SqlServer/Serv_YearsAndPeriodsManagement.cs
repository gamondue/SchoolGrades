using SchoolGrades.BusinessObjects;
using System;
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
        internal override void CreateTableSchoolYears()  //crea una nuova tabella
        {
            try
            {
                using (DbConnection conn = Connect())
                {
                    DbCommand cmd = conn.CreateCommand();
                    // Tabella: SchoolYears
                    cmd.CommandText = @"CREATE TABLE SchoolYears 
                    (idSchoolYear VARCHAR(5) NOT NULL,
                    shortDesc VARCHAR(10) NULL,
                    notes VARCHAR(255) NULL,
                    PRIMARY KEY(idSchoolYear));";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
        internal override bool SchoolYearExists(string idSchoolYear)  //guarda cosa c'è nella tabella
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT  1 idSchoolYear" +
                    " FROM SchoolYears" +
                    " WHERE idSchoolYear='" + idSchoolYear + "'" +
                    ";";
                var result = cmd.ExecuteScalar();
                return (result != null);


            }
        }
        internal override void AddSchoolYear(SchoolYear newSchoolYear)  //aggiunge i valori all'interno della tabella
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
        internal override void DeleteSchoolYear(string year)  //cancella i dati di una tabella
        {   // query funzionante:  delete from SchoolYears where idSchoolYear = '27-28' ;
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM SchoolYears WHERE IdSchoolYear = '" + year + "';";
                var result = cmd.ExecuteNonQuery();
            }
        }
    }
}
