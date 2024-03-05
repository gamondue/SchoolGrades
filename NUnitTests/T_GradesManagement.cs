using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDbTests
{
    public class T_GradesManagement
    {
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
            Test_Commons.dl.SaveMicroGrade(new()
            {
                IdStudent = 455,
                IdSchoolSubject = "2",
                Value = 80,
                Weight = 33,
                Timestamp = DateTime.Now,
                IdSchoolYear = "anno",
                IdGradeType = "prova",
            });
        }
        [Test]
        public void T_Grades_SaveMacroGrade()
        {
            //TODO
            //Test_Commons.dl.SaveMacroGrade(999, )
        }
    }
}
