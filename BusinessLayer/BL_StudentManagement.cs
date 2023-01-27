using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal Student CreateStudentFromStringMatrix(string[,] StudentData, int? StudentRow)
        {
            return dl.CreateStudentFromStringMatrix(StudentData, StudentRow);
        }
        internal int? CreateStudent(Student Student)
        {
            return dl.CreateStudent(Student);
        }
        internal void SaveStudentsOfList(List<Student> studentsList, DbConnection conn = null)
        {
            foreach (Student s in studentsList)
            {
                SaveStudent(s, conn);
            }
        }
        internal int? SaveStudent(Student Student, DbConnection conn = null)
        {
            if(Student.IdStudent == null || Student.IdStudent == 0)
            {
                // creation 
                return dl.CreateStudent(Student);
            }
            else
            {
                // modification 
                return dl.UpdateStudent(Student, conn);
            }
        }
        internal Student GetStudent(int? IdStudent)
        {
            return dl.GetStudent(IdStudent);
        }
        internal DataTable GetStudentsSameName(string LastName, string FirstName)
        {
            return dl.GetStudentsSameName(LastName, FirstName);
        }
        internal DataTable FindStudentsLike(string LastName, string FirstName)
        {
            return dl.FindStudentsLike(LastName, FirstName);
        }
        internal void PutStudentInClass(int? IdStudent, int? IdClass)
        {
            dl.PutStudentInClass(IdStudent, IdClass);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdClass">Id of the class to be searched</param>
        /// <param name="conn">Connection already open on a database different from standard. 
        /// If not null this connection is left open</param>
        /// <returns>List of the </returns>
        internal List<Student> GetStudentsOfClass(int? IdClass, DbConnection conn)
        {
            return dl.GetStudentsOfClass(IdClass, conn);
        }
        internal List<Student> GetStudentsOfClassList(string Scuola, string Anno,
            string ClassAbbreviation, bool IncludeNonActiveStudents)
        {
            return dl.GetStudentsOfClassList(Scuola, Anno,
            ClassAbbreviation, IncludeNonActiveStudents);
        }
        internal List<Student> GetStudentsAndSumOfWeights(Class Class,
            GradeType GradeType, SchoolSubject SchoolSubject,
            DateTime DateFrom, DateTime DateTo)
        {
            List<Student> ls = new List<Student>();

            DataTable t = dl.GetWeightedAveragesOfClassByGradesFraction(Class, GradeType.IdGradeType,
                SchoolSubject.IdSchoolSubject, DateFrom, DateTo);
            foreach (DataRow row in t.Rows)
            {
                Student s = dl.GetStudent((int)row["idStudent"]);
                s.Sum = Safe.Double(row["GradesFraction"]);
                s.DummyNumber = Safe.Double(row["GradesCount"]);
                ls.Add(s);
            }
            return ls;
        }
        internal void EraseStudentsPhoto(int IdStudent, string SchoolYear)
        {
            dl.EraseStudentsPhoto(IdStudent, SchoolYear); 
        }
        internal void ToggleDisabledFlagOneStudent(Student DisablingStudent)
        {
            dl.ToggleDisabledFlagOneStudent(DisablingStudent);
        }
        internal string GetFilePhoto(int? IdStudent, string SchoolYear)
        {
            return dl.GetFilePhoto(IdStudent, SchoolYear);
        }
        internal void UpdateStudent(Student Student)
        {
            dl.UpdateStudent(Student);
        }
        internal DataTable GetStudentsWithNoMicrogrades(Class currentClass, string idGradeType, string idSchoolSubject, DateTime value1, DateTime value2)
        {
            return dl.GetStudentsWithNoMicrogrades(currentClass, idGradeType, idSchoolSubject, value1, value2);
        }
        internal List<int> GetIdStudentsNonGraded(Class currentClass, GradeType currentGradeType, SchoolSubject currentSubject)
        {
            return dl.GetIdStudentsNonGraded(currentClass, currentGradeType, currentSubject);
        }
        internal void SaveStudentsAnswer(Student Student, Test Test, Answer Answer, bool IsChecked, string StudentsTextAnswer)
        {
            dl.SaveStudentsAnswer(Student, Test, Answer, IsChecked, StudentsTextAnswer);
        }
        internal List<Student> FindStudentsOnBirthday(Class Class, DateTime Date)
        {
            return dl.GetStudentsOnBirthday(Class, Date); 
        }
    }
}
