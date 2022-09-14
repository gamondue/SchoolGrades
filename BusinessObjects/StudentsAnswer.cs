using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
{
    class StudentsAnswer
    {
        int? idStudentsAnswer;
        int? idStudent;
        int? idAnswer;
        bool? studentsBoolAnswer;
        string studentsTextAnswer;
        int? idTest;

        public int? IdStudentsAnswer { get => idStudentsAnswer; set => idStudentsAnswer = value; }
        public int? IdStudent { get => idStudent; set => idStudent = value; }
        public int? IdAnswer { get => idAnswer; set => idAnswer = value; }
        public bool? StudentsBoolAnswer { get => studentsBoolAnswer; set => studentsBoolAnswer = value; }
        public string StudentsTextAnswer { get => studentsTextAnswer; set => studentsTextAnswer = value; }
        public int? IdTest { get => idTest; set => idTest = value; }
    }
}
