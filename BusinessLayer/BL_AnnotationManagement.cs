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
        internal List<StudentAnnotation> AnnotationsAboutThisStudent(Student CurrentStudent, string YearUsed, bool IsChecked)
        {
            return dl.AnnotationsAboutThisStudent(CurrentStudent, YearUsed, IsChecked);
        }
        internal int? SaveAnnotation(StudentAnnotation CurrentAnnotation, Student CurrentStudent)
        {
            return SaveAnnotation(CurrentAnnotation, CurrentStudent);
        }
        internal StudentAnnotation GetAnnotation(int? IdAnnotation)
        {
            return dl.GetAnnotation(IdAnnotation);
        }
        internal void EraseAnnotationById(int? idAnnotation)
        {
            EraseAnnotationById(idAnnotation);
        }
        internal void EraseAnnotationByText(string Text, Student Student)
        {
            EraseAnnotationByText(Text, Student);
        }
    }
}
