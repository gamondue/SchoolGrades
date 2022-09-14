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
        internal List<StudentAnnotation> AnnotationsAboutThisStudent(Student CurrentStudent, string YearUsed, bool IsChecked)
        {
            return dl.AnnotationsAboutThisStudent(CurrentStudent, YearUsed, IsChecked);
        }
        internal int? SaveAnnotation(StudentAnnotation CurrentAnnotation, Student CurrentStudent)
        {
            return dl.SaveAnnotation(CurrentAnnotation, CurrentStudent);
        }
        internal StudentAnnotation GetAnnotation(int? IdAnnotation)
        {
            return dl.GetAnnotation(IdAnnotation);
        }
        internal void EraseAnnotationById(int? idAnnotation)
        {
            dl.EraseAnnotationById(idAnnotation);
        }
        internal void EraseAnnotationByText(string Text, Student Student)
        {
            dl.EraseAnnotationByText(Text, Student);
        }
        internal DataTable GetAnnotationsOfClasss(int? idClass, bool IncludeAlsoNonActive, bool IncludeJustPopUp)
        {
            return dl.GetAnnotationsOfClasss(idClass, IncludeAlsoNonActive, IncludeJustPopUp);
        }
    }
}
