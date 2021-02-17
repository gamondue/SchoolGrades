using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.DbClasses
{
    public class Student
    {
        string residence;
        string origin;
        string email;
        Nullable<DateTime> birthDate;
        string birthPlace;

        public string RegisterNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public float ArithmeticMean { get; set; }    // modificare il programma per eliminarlo 
        public double? Sum { get; set; }     // modificare il programma per eliminarlo 
        public string SchoolYear { get; set; }
        public double? DummyNumber { get; set; }  // usewd by the program when it need fo associate a number to a student
        public bool? Eligible { get; set; } // TODO: chenge the name of the database field from "drawable" to "eligible"
        public int? IdStudent { get; set; }
        public int? IdClass { get; set; }
        public string Class { get; set; }
        public string Residence { get => residence; set => residence = value; }
        public string Origin { get => origin; set => origin = value; }
        public string Email { get => email; set => email = value; }
        public Nullable<DateTime> BirthDate { get => birthDate; set => birthDate = (DateTime?) value; }
        public string BirthPlace { get => birthPlace; set => birthPlace = value; }
        public int? RevengeFactorCounter { get; set; }  // revenge factor counter 
        public bool? Disabled { get; set; }
        public double? SortOrDrawCriterion { get; internal set; }

        public override string ToString()
        {
            return LastName + " " + FirstName + " (" + RevengeFactorCounter + ")";
            //return RegisterNumber + " " + LastName + " " + FirstName + " " + Class + " " + SchoolYear;
            //return LastName + " " + FirstName;
        }
    }
}
