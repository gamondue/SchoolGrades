using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
{
    public class Grade
    {
        private int? idGrade;
        private int? idStudent;
        private double? value;
        private double? weight;
        private double? cncFactor;
        private string idSchoolYear;
        private DateTime? timestamp;
        private string idGradeType;
        private int? idGradeParent;
        private int? idQuestion;
        private string idSchoolSubject;
        private int? dummyInt; 

        public int? IdGrade { get => idGrade; set => idGrade = value; }
        public int? IdStudent { get => idStudent; set => idStudent = value; }
        public string IdSchoolSubject { get => idSchoolSubject; set => idSchoolSubject = value; }
        public double? Value { get => value; set => this.value = value; }
        public double? Weight { get => weight; set => weight = value; }
        public string IdSchoolYear { get => idSchoolYear; set => idSchoolYear = value; }
        public DateTime? Timestamp { get => timestamp; set => timestamp = value; }
        public string IdGradeType { get => idGradeType; set => idGradeType = value; }
        public int? IdGradeParent { get => idGradeParent; set => idGradeParent = value; }
        public int? IdQuestion { get => idQuestion; set => idQuestion = value; }
        public double? CncFactor { get => cncFactor; set => cncFactor = value; }

        // Id of the type of grade that aggregates this kind of grade
        // NOT included in the database table. Inferred from the program 
        public string IdGradeTypeParent { get; internal set; }

        public int? DummyInt { get => dummyInt; set => dummyInt = value; }

        public Grade()
        {
            
        }

        public Grade (int? IdGrade)
        {
            idGrade = IdGrade; 
        }
    }
}
