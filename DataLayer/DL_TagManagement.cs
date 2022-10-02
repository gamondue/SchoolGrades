using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using System.Text;

namespace SchoolGrades
{
    internal partial class  DataLayer
    {
        internal List<Tag> GetTagsContaining(string Pattern)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Tag> TagList = new List<Tag>();

            using (DbConnection conn = Connect())
            {
                string query = "SELECT *" +
                    " FROM Tags" +
                    " WHERE Tag " + SqlStringLike(Pattern) + "" +
                    ";";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Tag t = new Tag();
                    t.IdTag = Safe.Int(dRead["IdTag"]);
                    t.TagName = (string)dRead["tag"];
                    t.Desc = (string)dRead["Desc"];

                    TagList.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return TagList;
        }

        internal int? CreateNewTag(Tag CurrentTag)
        {
            // trova una chiave da assegnare alla nuova domanda
            CurrentTag.IdTag = NextKey("Tags", "IdTag");
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Tags " +
                    "(IdTag, tag, Desc) " +
                    "Values (" + CurrentTag.IdTag + "," +
                    "'" + CurrentTag.TagName + "'," +
                    "'" + CurrentTag.Desc + "'" +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return CurrentTag.IdTag;
        }

        internal void SaveTag(Tag CurrentTag)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Tags " +
                    " SET IdTag=" + CurrentTag.IdTag + "," +
                    " tag=" + "'" + CurrentTag.TagName + "'," +
                    " Desc=" + "'" + CurrentTag.Desc + "'" +
                    " WHERE idTag=" + CurrentTag.IdTag +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal List<Tag> TagsOfAQuestion(int? IdQuestion)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Tag> l = new List<Tag>();
            using (DbConnection conn = Connect())
            {
                string query = "SELECT * " +
                    " FROM Questions_Tags, Tags" +
                    " WHERE Tags.IdTag = Questions_Tags.IdTag " +
                    " AND Questions_Tags.idQuestion=" + IdQuestion +
                    " ORDER BY Tags.tag;";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Tag t = new Tag();
                    t.Desc = (string)dRead["Desc"];
                    t.IdTag = Safe.Int(dRead["IdTag"]);
                    t.TagName = (string)dRead["tag"];
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }

        internal void AddTagToQuestion(int? IdQuestion, int? IdTag)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Questions_Tags " +
                    "(idQuestion, IdTag) " +
                    "Values (" + IdQuestion + "," +
                    IdTag +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
    }
}
