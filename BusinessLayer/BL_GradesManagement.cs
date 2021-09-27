using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal Grade GetGrade(int? IdGrade)
        {
            return dl.GetGrade(IdGrade);
        }
        internal void GetGradeAndStudent(Grade currentGrade, Student currentStudent)
        {
            dl.GetGradeAndStudent(currentGrade, currentStudent);
        }
        internal Class GetClassOfStudent(string idSchool, string currentYear, Student currentStudent)
        {
            return dl.GetClassOfStudent(idSchool, currentYear, currentStudent);
        }
        internal GradeType GetGradeType(string idGradeType)
        {
            return dl.GetGradeType(idGradeType);
        }
        internal SchoolSubject GetSchoolSubject(string idSchoolSubject)
        {
            return dl.GetSchoolSubject(idSchoolSubject);
        }
        internal Question GetQuestionById(int? idQuestion)
        {
            return dl.GetQuestionById(idQuestion);
        }
        internal Grade LastOpenGradeOfStudent(Student currentStudent, string currentYear, SchoolSubject currentSchoolSubject, string idGradeTypeParent)
        {
            return dl.LastOpenGradeOfStudent(currentStudent, currentYear, currentSchoolSubject, idGradeTypeParent);
        }
        internal DataTable GetMicroGradesOfStudentWithMacroOpen(int? idStudent, string currentYear, string idGradeType, string idSchoolSubject)
        {
            return dl.GetMicroGradesOfStudentWithMacroOpen(idStudent, currentYear, idGradeType, idSchoolSubject);
        }
        internal double? GetDefaultWeightOfGradeType(string idGradeType)
        {
            return dl.GetDefaultWeightOfGradeType(idGradeType);
        }
        internal void DeleteValueOfGrade(int Value)
        {
            dl.DeleteValueOfGrade(Value);
        }
        internal int? SaveMicroGrade(Grade currentGrade)
        {
            return dl.SaveMicroGrade(currentGrade);
        }
        internal int CreateMacroGrade(ref Grade currentMacroGrade, Student currentStudent, string idGradeType)
        {
            return dl.CreateMacroGrade(ref currentMacroGrade, currentStudent, idGradeType);
        }
        internal void SaveMacroGrade(int? idStudent, int? v, double average, double weight, string currentYear, string idSchoolSubject)
        {
            dl.SaveMacroGrade(idStudent, v, average, weight, currentYear, idSchoolSubject);
        }
        internal void EraseGrade(int? Value)
        {
            dl.EraseGrade(Value);
        }
        internal List<GradeType> GetListGradeTypes()
        {
            return dl.GetListGradeTypes(); 
        }
        internal void CloneGrade(DataRow Row)
        {
            dl.CloneGrade(Row);
        }
        internal DataTable GetGradesOfStudent(Student Student, string IdSchoolYear,
            string IdGradeType, string IdSchoolSubject, DateTime DateFrom, DateTime DateTo)
        {
            return dl.GetGradesOfStudent(Student, IdSchoolYear, IdGradeType, IdSchoolSubject, DateFrom, DateTo);
        }
        internal object GetWeightedAveragesOfStudent(Student Student, string IdGradeType, string IdSchoolSubject, DateTime DateFrom, DateTime DateTo)
        {
            return dl.GetWeightedAveragesOfStudent(Student, IdGradeType, IdSchoolSubject, DateFrom, DateTo);
        }
        internal List<StudentAndGrade> GetGradesWeightedAveragesOfClass(Class Class, string IdGradeType,
            string IdSchoolSubject, DateTime DateFrom, DateTime DateTo)
        {
            return dl.GetGradesWeightedAveragesOfClass(Class, IdGradeType, IdSchoolSubject, DateFrom, DateTo);
        }
        internal DataTable GetGradesWeightsOfClassOnOpenGrades(Class currentClass, string idGradeType, string idSchoolSubject, DateTime value1, DateTime value2)
        {
            return dl.GetGradesWeightsOfClassOnOpenGrades(currentClass, idGradeType, idSchoolSubject, value1, value2);
        }
        internal List<Grade> CountNonClosedMicroGrades(Class currentClass, GradeType currentGradeType)
        {
            return dl.CountNonClosedMicroGrades(currentClass, currentGradeType);
        }
        internal List<Couple> GetGradesOldestInClass(Class currentClass, GradeType selectedItem, SchoolSubject currentSubject)
        {
            return dl.GetGradesOldestInClass(currentClass, selectedItem, currentSubject);
        }
        internal DataTable GetGradesOfClass(Class currentClass, string idGradeType, string idSchoolSubject, DateTime value1, DateTime value2)
        {
            return dl.GetGradesOfClass(currentClass, idGradeType, idSchoolSubject, value1, value2);
        }
    }
}
