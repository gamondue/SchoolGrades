using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal Test GetTestFromRow(DbDataReader Row)
        {
            Test t = new Test();
            t.IdTest = SafeDb.SafeInt(Row["idTest"]);
            t.Name = SafeDb.SafeString(Row["name"]);
            t.Desc = SafeDb.SafeString(Row["desc"]);
            t.IdSchoolSubject = SafeDb.SafeString(Row["IdSchoolSubject"]);
            t.IdTestType = SafeDb.SafeString(Row["IdTestType"]);
            t.IdSchoolSubject = SafeDb.SafeString(Row["IdSchoolSubject"]);
            t.IdTopic = SafeDb.SafeInt(Row["IdTopic"]);

            return t;
        }
        internal Test GetTest(int? IdTest)
        {
            Test t = new Test();
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM Tests " +
                    "WHERE IdTest=" + IdTest +
                    ";";
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    t = GetTestFromRow(dRead);
                }
            }
            return t;
        }
        internal List<Test> GetTests()
        {
            List<Test> list = new List<Test>();
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM Tests " +
                    //"WHERE idSchoolYear=" + IdSchoolYear +
                    //" OR IdSchoolYear IS null OR IdSchoolYear=''" +
                    ";";
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    Test t = GetTestFromRow(dRead);
                    list.Add(t);
                }
            }
            return list;
        }

        internal void SaveTest(Test TestToSave)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                if (TestToSave.IdTest == 0 || TestToSave.IdTest == null)
                {   // create new record
                    int nextId = NextKey("Tests", "idTest");

                    cmd.CommandText = "INSERT INTO Tests " +
                    "(idTest,name,desc,IdSchoolSubject,IdTestType,IdTopic" +
                    ")" +
                    "Values " +
                    "(" + nextId + ",'" + SqlVal.SqlString(TestToSave.Name) + "','" +
                    SqlVal.SqlString(TestToSave.Desc) + "','" + SqlVal.SqlString(TestToSave.IdSchoolSubject) + "'," +
                     SqlVal.SqlInt(TestToSave.IdTestType) + "," + SqlVal.SqlInt(TestToSave.IdTopic) +
                    ");";
                }
                else
                {   // update old record
                    cmd.CommandText = "UPDATE Tests" +
                    " SET name='" + SqlVal.SqlString(TestToSave.Name) + "'," +
                    "desc='" + SqlVal.SqlString(TestToSave.Desc) + "'" +
                    ",IdSchoolSubject=" + SqlVal.SqlString(TestToSave.IdSchoolSubject) +
                    ",IdTestType=" + SqlVal.SqlInt(TestToSave.IdTestType) +
                    ",IdTopic=" + SqlVal.SqlInt(TestToSave.IdTopic) +
                    ")" +
                    " WHERE idTest=" + TestToSave.IdTest +
                    ";";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
    }
}
