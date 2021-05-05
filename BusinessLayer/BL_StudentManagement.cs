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
        internal int CreateStudentFromStringMatrix(string[,] StudentData, int? StudentRow)
        {
            return dl.CreateStudentFromStringMatrix(StudentData, StudentRow);
        }

        internal int CreateStudent(Student Student)
        {
            return dl.CreateStudent(Student);
        }

        internal void SaveStudentsOfList(List<Student> studentsList, DbConnection conn)
        {
            foreach (Student s in studentsList)
            {
                SaveStudent(s, conn);
            }
        }

        internal int? SaveStudent(Student Student, DbConnection conn)
        {
            return dl.SaveStudent(Student, conn);
        }

        internal Student GetStudent(int? IdStudent)
        {
            return dl.GetStudent(IdStudent);
        }

        internal DataTable GetStudentsSameName(string LastName, string FirstName)
        {
            return GetStudentsSameName(LastName, FirstName);
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
            string SiglaClasse, bool IncludeNonActiveStudents)
        {
            return dl.GetStudentsOfClassList(Scuola, Anno,
            SiglaClasse, IncludeNonActiveStudents);
        }

        internal List<Student> GetStudentsAndSumOfWeights(Class Class,
            GradeType GradeType, SchoolSubject SchoolSubject,
            DateTime DateFrom, DateTime DateTo)
        {
            List<Student> ls = new List<Student>();

            DataTable t = dl.GetWeightedAveragesOfClass(Class, GradeType.IdGradeType,
                SchoolSubject.IdSchoolSubject, DateFrom, DateTo);
            foreach (DataRow row in t.Rows)
            {
                Student s = dl.GetStudent((int)row["idStudent"]);
                s.Sum = SafeDb.SafeDouble(row["GradesFraction"]);
                s.DummyNumber = SafeDb.SafeDouble(row["GradesCount"]);
                ls.Add(s);
            }
            return ls;
        }
    }
}
