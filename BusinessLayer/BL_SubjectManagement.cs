using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal List<SchoolSubject> GetListSchoolSubjects(bool Value)
        {
            return dl.GetListSchoolSubjects(Value);
        }
        internal void SaveSubjects(List<SchoolSubject> SubjectsList)
        {
            dl.SaveSubjects(SubjectsList);
        }
        internal void EraseSchoolSubjectById(string IdSchoolSubject)
        {
            dl.EraseSchoolSubjectById(IdSchoolSubject);
        }
        internal string CheckNewKeySchoolSubject(string NewKey)
        {
            if (dl.CheckKeyExistence("SchoolSubjectS", "IdSchoolSubject", NewKey))
                return "Id già esistente, sceglierne uno diverso!";
            else
                return ""; 
        }
    }
}
