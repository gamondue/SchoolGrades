using SchoolGrades.BusinessObjects;
using System.Collections.Generic;
using System.Data;

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
        internal void EraseAnnotationById(int? IdAnnotation)
        {
            dl.EraseAnnotationById(IdAnnotation);
        }
        internal void EraseAnnotationByText(string Text, Student Student)
        {
            dl.EraseAnnotationByText(Text, Student);
        }
        internal DataTable GetAnnotationsOfClass(int? idClass, bool IncludeAlsoNonActive, bool IncludeJustPopUp)
        {
            return dl.GetAnnotationsOfClass(idClass, IncludeAlsoNonActive, IncludeJustPopUp);
        }
    }
}
