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
        internal List<Class> GetClassesOfYear(string IdSchool, string SchoolYear)
        {
            return dl.GetClassesOfYear(IdSchool, SchoolYear); 
        }
        internal int? CreateClassAndStudents(string[,] StudentsData, string ClassAbbreviation, string ClassDescription, 
            string SchoolYear, string OfficialSchoolAbbreviation, bool LinkPhoto)
        {
            return dl.CreateClassAndStudents(StudentsData, ClassAbbreviation, ClassDescription, 
                SchoolYear, OfficialSchoolAbbreviation, LinkPhoto);
        }
        internal Class GetClass(string idSchool, string idSchoolYear, string ClassAbbreviation)
        {
            return dl.GetClass(idSchool, idSchoolYear, ClassAbbreviation);
        }
        internal void CopyAndLinkOnePhoto(Student s, Class newClass, string fileName)
        {
            dl.CopyAndLinkOnePhoto(s, newClass, fileName);
        }
        internal int CreateClass(string ClassAbbreviation, string ClassDescription, 
            string SchoolYear, string IdSchool)
        {
            return dl.CreateClass(ClassAbbreviation, ClassDescription, SchoolYear, IdSchool); 
        }

        internal void DeleteOneStudentFromClass(int idDeletingStudent, int? idClass)
        {
            throw new NotImplementedException();
        }
        internal void EraseAllStudentsOfAClass(Class CurrentClass)
        {
            dl.EraseAllStudentsOfAClass(CurrentClass);
        }
        internal void EraseClassFromClasses(Class CurrentClass)
        {
            dl.EraseClassFromClasses(CurrentClass);
        }
        // !!!! TODO: refactor to avoid using ADO objects outside BusinessLayer !!!!
        internal DataTable GetClassTable(int? IdClass) 
        {
            return dl.GetClassTable(IdClass);
        }
        internal void SaveClass(Class Class)
        {
            dl.SaveClass(Class);
        }
    }
}
