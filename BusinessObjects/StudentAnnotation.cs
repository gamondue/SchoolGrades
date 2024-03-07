using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
{
    class StudentAnnotation
    {
        int? idAnnotation;
        int? idStudent;
        string annotation;
		string idSchoolYear;
		DateTime? instantTaken;
		DateTime? instantClosed;

        public int? IdAnnotation { get => idAnnotation; set => idAnnotation = value; }
        public string Annotation { get => annotation; set => annotation = value; }
        public string IdSchoolYear { get => idSchoolYear; set => idSchoolYear = value; }
        public DateTime? InstantTaken { get => instantTaken; set => instantTaken = value; }
        public DateTime? InstantClosed { get => instantClosed; set => instantClosed = value; }
        public bool? IsActive { get; internal set; }
        public int? IdStudent { get => idStudent; set => idStudent = value; }
        public bool? IsPopUp { get; internal set; }
    }
}
