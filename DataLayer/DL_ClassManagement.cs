using SchoolGrades.DbClasses;
using System.Collections.Generic;
using System.Data.Common;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal List<Class> GetClassesOfYear(string School, string Year)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Class> lc = new List<Class>();

            // Execute the query
            using (DbConnection conn = Connect())
            {
                string query = "SELECT Classes.* " +
                " FROM Classes" +
                " WHERE idSchoolYear = '" + Year + "'" +
                " ORDER BY abbreviation" +
                ";";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                // fill the combo with this year's classes
                while (dRead.Read())
                {
                    Class c = new Class((int)dRead["idClass"],
                        (string)dRead["abbreviation"], Year, "dummy");
                    c.UriWebApp = SafeDb.SafeString(dRead["UriWebApp"]);
                    c.PathRestrictedApplication = SafeDb.SafeString(dRead["pathRestrictedApplication"]);

                    lc.Add(c);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return lc;
        }
        internal List<string> GetStartLinksOfClass(Class Class)
        {
            List<string> listOfLinks = new List<string>();
            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = Connect())
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *" +
                    " FROM Classes_StartLinks" +
                    " WHERE idClass=" + Class.IdClass + "; ";
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    string item = (string)dRead["startLink"];
                    listOfLinks.Add(item);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return listOfLinks;
        }
    }
}
