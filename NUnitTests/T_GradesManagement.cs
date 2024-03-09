using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDbTests
{
    public class T_GradesManagement
    {
        Grade voto = new()
        {
            IdStudent = 1,
            IdSchoolSubject = "2",
            Value = 80,
            Weight = 33,
            Timestamp = DateTime.Now,
            IdSchoolYear = "anno",
            IdGradeType = "prova",
        };

        [SetUp]
        public void Setup()
        {
            Test_Commons.SetDataLayer();
        }
        [Test]
        public void T_Grades_Create()
        {
            // creo la tabella
            Test_Commons.dl.CreateTableGrades();
        }
        [Test]
        public void T_Grades_GetGrade()
        {
            Console.WriteLine(Test_Commons.dl.GetGrade(1).Value);
        }
        [Test]
        public void T_Grades_SaveMicroGrade()
        {
            voto.IdGrade = Test_Commons.dl.SaveMicroGrade(voto);
        }
        [Test]
        public void T_Grades_SaveMacroGrade()
        {
            voto.IdGrade = Test_Commons.dl.SaveMicroGrade(voto);
            Test_Commons.dl.SaveMacroGrade(voto.IdStudent, voto.IdGrade, 100, 20, voto.IdSchoolYear, voto.IdSchoolSubject);
        }
        [Test]
        public void T_Grades_GetGradeAndStudentFromIdGrade()
        {
            Student student = new();
            voto.IdGrade = Test_Commons.dl.SaveMicroGrade(voto);
            Test_Commons.dl.GetGradeAndStudentFromIdGrade(ref voto, ref student);
            Console.WriteLine(student);
        }
    }
}
