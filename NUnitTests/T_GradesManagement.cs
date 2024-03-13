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
        public void T_GradeTypes_Create()
        {
            Test_Commons.dl.CreateTableGradeTypes();
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
        [Test]
        public void T_GetDefaultWeightOfGradeTypes()
        {
            Console.WriteLine(Test_Commons.dl.GetDefaultWeightOfGradeType("1"));
        }
        [Test]
        public void T_GetGradeType()
        {
            Console.WriteLine(Test_Commons.dl.GetGradeType("1"));
        }
        [Test]
        public void T_SaveGradeValue()
        {
            Test_Commons.dl.SaveGradeValue(1, 66);
        }
        [Test]
        public void T_EraseGrade()
        {
            Test_Commons.dl.EraseGrade(1);
        }
        [Test]
        public void T_GetGradesOfStudent()
        {
            //Test_Commons.dl.GetGradesOfStudent();
        }
        [Test]
        public void T_CloneGrade()
        {
            //Test_Commons.dl.CloneGrade()
        }
    }
}
