using SchoolGrades.BusinessObjects;
using System.Collections.Generic;
using System.Data.Common;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal SchoolGrades.BusinessObjects.SchoolTest GetTestFromRow(DbDataReader Row)
        {
            SchoolGrades.BusinessObjects.SchoolTest t = new SchoolTest();
            t.IdTest = Safe.Int(Row["idTest"]);
            t.Name = Safe.String(Row["name"]);
            t.Desc = Safe.String(Row["desc"]);
            t.IdSchoolSubject = Safe.String(Row["IdSchoolSubject"]);
            t.IdTestType = Safe.String(Row["IdTestType"]);
            t.IdSchoolSubject = Safe.String(Row["IdSchoolSubject"]);
            t.IdTopic = Safe.Int(Row["IdTopic"]);

            return t;
        }
        internal SchoolTest GetTest(int? IdTest)
        {
            SchoolTest t = new SchoolTest();
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
        internal List<SchoolTest> GetTests()
        {
            List<SchoolTest> list = new List<SchoolTest>();
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
                    SchoolTest t = GetTestFromRow(dRead);
                    list.Add(t);
                }
            }
            return list;
        }

        internal void SaveTest(SchoolTest TestToSave)
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
                    "(" + nextId + "," + SqlString(TestToSave.Name) + "," +
                    SqlString(TestToSave.Desc) + "," + SqlString(TestToSave.IdSchoolSubject) + "," +
                     SqlInt(TestToSave.IdTestType) + "," + SqlInt(TestToSave.IdTopic) +
                    ");";
                }
                else
                {   // update old record
                    cmd.CommandText = "UPDATE Tests" +
                    " SET name=" + SqlString(TestToSave.Name) + "," +
                    "desc=" + SqlString(TestToSave.Desc) + "" +
                    ",IdSchoolSubject=" + SqlString(TestToSave.IdSchoolSubject) +
                    ",IdTestType=" + SqlInt(TestToSave.IdTestType) +
                    ",IdTopic=" + SqlInt(TestToSave.IdTopic) +
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
