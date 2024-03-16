using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDbTests
{
    internal class T_Serv_DemoDatabaseCreation
    {
        //internal class T_Serv_DemoDatabaseCreation
        //{
        //    [SetUp]
        //    public void Setup()
        //    {
        //        Test_Commons.SetDataLayer();
        //    }
        //    [Test]
        //    public void Create_GradesTable()
        //    {
        //        Test_Commons.dl.Create_GradesTable();
        //    }
        //    [Test]
        //    public void Insert__GradesIntoTable()
        //    {
        //        Test_Commons.dl.Insert_GradesIntoTable();
        //    }
        //    [Test]
        //    public void Delete_AllGrades()
        //    {
        //        Test_Commons.dl.Delete_AllGrades();
        //    }

        //        SqlDataReader SqlRead;
        //        cmd.CommandText = "SELECT * FROM Grades;";
        //            SqlRead = cmd.ExecuteReader();
        //            Random rnd = new Random();
        //            while (SqlRead.Read())
        //            {
        //                double? grade = Safe.Double(SqlRead["value"]);
        //        int? id = Safe.Int(SqlRead["IdGrade"]);
        //                // add to the grade a random delta between -10 and +10 
        //                if (grade > 0)
        //                {
        //                    grade = grade + rnd.NextDouble()* 20 - 10;
        //                    if (grade< 10) grade = 10;
        //                    if (grade > 100) grade = 100;
        //                }
        //                else
        //                    grade = 0;
        //                SaveGradeValue(id, grade);
        //}
        //cmd.Dispose();
        //}
    }
}
