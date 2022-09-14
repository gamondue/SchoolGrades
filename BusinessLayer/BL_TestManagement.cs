using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    internal partial class  BusinessLayer
    {
        internal Test GetTest(int IdTest)
        {
            return dl.GetTest(IdTest);
        }
        internal List<Student> GetAllStudentsThatAnsweredToATest(Test currentTest, Class currentClass)
        {
            return dl.GetAllStudentsThatAnsweredToATest(currentTest, currentClass);
        }
        internal void SaveTest(Test currentTest)
        {
            dl.SaveTest(currentTest);
        }
        internal object GetTests()
        {
            return dl.GetTests();
        }
        internal List<Question> GetAllQuestionsOfATest(int? idTest)
        {
            return dl.GetAllQuestionsOfATest(idTest);
        }
        internal object GetGradesWeightedAveragesOfStudent(Student currentStudent, string idGradeType, string idSchoolSubject, DateTime value1, DateTime value2)
        {
            return dl.GetGradesWeightedAveragesOfStudent(currentStudent, idGradeType, idSchoolSubject, value1, value2);
        }
        internal object GetGradesWeightsOfStudentOnOpenGrades(Student currentStudent, string idGradeType, string idSchoolSubject, DateTime value1, DateTime value2)
        {
            return dl.GetGradesWeightsOfStudentOnOpenGrades(currentStudent, idGradeType, idSchoolSubject, value1, value2);
        }
    }
}
