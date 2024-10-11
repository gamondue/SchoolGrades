using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal int? CreateStudent(Student Student)
        {
            return dl.CreateStudent(Student);
        }
        internal void SaveStudentsOfList(List<Student> studentsList, DbCommand cmd = null)
        {
            foreach (Student s in studentsList)
            {
                SaveStudent(s, cmd);
            }
        }
        internal int? SaveStudent(Student Student, DbCommand cmd = null)
        {
            if (Student.IdStudent == null || Student.IdStudent == 0)
            {
                // creation 
                return dl.CreateStudent(Student);
            }
            else
            {
                // modification 
                return dl.UpdateStudent(Student, cmd);
            }
        }
        internal Student GetStudent(int? IdStudent)
        {
            return dl.GetStudent(IdStudent);
        }
        internal List<Student> GetStudentsHomonyms(Student Student)
        {
            return dl.GetStudentsSameName(Student.LastName, Student.FirstName);
        }
        internal DataTable GetStudentsLike(string LastName, string FirstName)
        {
            return dl.FindStudentsLike(LastName, FirstName);
        }
        internal void PutStudentInClass(Student Student, int? IdClass)
        {
            dl.PutStudentInClass(Student.IdStudent, Student.IdClass);
            ////////dl.AddLinkPhotoToStudent()
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdClass">Id of the class to be searched</param>
        /// <param name="cmd">Connection already open on a database different from standard. 
        /// If not null this connection is left open</param>
        /// <returns>List of the </returns>
        internal List<Student> GetStudentsOfClass(int? IdClass, DbCommand cmd)
        {
            return dl.GetStudentsOfClass(IdClass, cmd);
        }
        internal List<Student> GetStudentsOfClassList(string Scuola, string Anno,
            string ClassAbbreviation, bool IncludeNonActiveStudents)
        {
            return dl.GetStudentsOfClassList(Scuola, Anno,
            ClassAbbreviation, IncludeNonActiveStudents);
        }
        internal List<Student> GetStudentsAndSumOfWeights(Class Class,
            List<Student> studentsList, GradeType GradeType, SchoolSubject SchoolSubject,
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
        internal void SaveStudentsAnswer(Student Student, SchoolTest Test, Answer Answer, bool IsChecked, string StudentsTextAnswer)
        {
            dl.SaveStudentsAnswer(Student, Test, Answer, IsChecked, StudentsTextAnswer);
        }
        internal List<Student> FindStudentsOnBirthday(Class Class, DateTime Date)
        {
            return dl.GetStudentsOnBirthday(Class, Date);
        }
        internal Student CreateNewStudentFromFileRow(string[,] StudentData, int StudentRow)
        {
            int nRow = (int)StudentRow;
            Student s = new Student();
            s.RegisterNumber = nRow.ToString();
            s.SchoolYear = StudentData[nRow, 0];
            s.ClassAbbreviation = StudentData[nRow, 1];
            s.LastName = StudentData[nRow, 2];
            s.FirstName = StudentData[nRow, 3];
            s.City = StudentData[nRow, 4];
            s.Origin = StudentData[nRow, 5];
            s.Email = StudentData[nRow, 6];
            s.BirthDate = Safe.DateTime(StudentData[nRow, 7]);
            s.BirthPlace = StudentData[nRow, 8];
            s.Telephone = StudentData[nRow, 9];
            s.MobileTelephone = StudentData[nRow, 10];
            s.Gender = StudentData[nRow, 11];
            s.StreetAddress = StudentData[nRow, 12];
            s.ZipCode = StudentData[nRow, 13];
            s.County = StudentData[nRow, 14];
            s.State = StudentData[nRow, 15];
            s.Eligible = false;
            return s;
        }
    }
}
