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
    class Start
    {

        DataLayer dl = new DataLayer();

        private int NextKey(string Table, string Id)
        {
            int nextId;
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT MAX(" + Id + ") FROM " + Table + ";";
                var firstColumn = cmd.ExecuteScalar();
                if (firstColumn != DBNull.Value)
                {
                    nextId = int.Parse(firstColumn.ToString()) + 1;
                }
                else
                {
                    nextId = 1;
                }
                cmd.Dispose();
            }
            return nextId;
        }

        internal int? SaveStartLink(int? IdStartLink, int? IdClass, string SchoolYear,
            string StartLink, string Desc)
        {
            DbCommand cmd = null;
            try
            {
                using (DbConnection conn = dl.Connect())
                {
                    cmd = conn.CreateCommand();
                    if (IdStartLink != null && IdStartLink != 0)
                    {
                        cmd.CommandText = "UPDATE Classes_StartLinks" +
                            " SET" +
                            " idStartLink=" + IdStartLink +
                            ",idClass=" + IdClass + "" +
                            ",startLink='" + SqlVal.SqlString(StartLink) + "'" +
                            ",desc='" + SqlVal.SqlString(Desc) + "'" +
                            " WHERE idStartLink=" + IdStartLink +
                            ";";
                    }
                    else
                    {
                        IdStartLink = NextKey("Classes_StartLinks", "IdStartLink");
                        cmd.CommandText = "INSERT INTO Classes_StartLinks" +
                            " (idStartLink,idClass,startLink,desc)" +
                            " VALUES " +
                            "(" +
                            IdStartLink +
                            "," + IdClass +
                            ",'" + SqlVal.SqlString(StartLink) + "'" +
                            ",'" + SqlVal.SqlString(Desc) + "'" +
                            ");";
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                Commons.ErrorLog("DbLayer.SaveStartLink: " + ex.Message, true);
                IdStartLink = null;
                cmd.Dispose();
            }
            return IdStartLink;
        }

        internal void DeleteStartLink(Nullable<int> IdStartLink)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Classes_StartLinks" +
                    " WHERE idStartLink=" + IdStartLink +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal DataTable GetAllStartLinks(string Year, int? IdClass)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT Classes.idSchoolYear,Classes.abbreviation,Classes.idClass," +
                    "Classes_StartLinks.startLink, Classes_StartLinks.desc,Classes_StartLinks.idStartLink" +
                    " FROM Classes" +
                    " JOIN Classes_StartLinks ON Classes_StartLinks.idClass=Classes.idClass" +
                    " WHERE Classes.idSchoolYear=" + Year;
                if (IdClass != null && IdClass != 0)
                    query += " AND Classes.idClass=" + IdClass;
                query += " ORDER BY Classes.abbreviation" +
                    ";";
                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("AllStartLinks");
                try
                {
                    DAdapt.Fill(DSet);
                    t = DSet.Tables[0];
                }
                catch
                {
                    t = null;
                }
                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }

        internal List<string> GetStartLinksOfClass(Class Class)
        {
            List<string> listOfLinks = new List<string>();
            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = dl.Connect())
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
