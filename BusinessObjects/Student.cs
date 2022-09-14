using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
{
    public class Student
    {
        string residence;
        string origin;
        string email;
        Nullable<DateTime> birthDate;
        string birthPlace;

        public int? IdStudent { get; set; }
        public string RegisterNumber { get; set; } // field not in the table Student in database
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public float ArithmeticMean { get; set; }    // modificare il programma per eliminarlo 
        public double? Sum { get; set; }     // modificare il programma per eliminarlo 
        public string SchoolYear { get; set; }    // field not in the table Student in database
        public double? DummyNumber { get; set; }  // usewd by the program when it need fo associate a number to a student
        public bool? Eligible { get; set; } // TODO: change the name of the database field from "drawable" to "eligible"
        public int? IdClass { get; set; }   // field not in the table Student in database
        public string ClassAbbreviation { get; set; } // field not in the table Student in database
        public string Residence { get => residence; set => residence = value; }
        public string Origin { get => origin; set => origin = value; }
        public string Email { get => email; set => email = value; }
        public Nullable<DateTime> BirthDate { get => birthDate; set => birthDate = (DateTime?) value; }
        public string BirthPlace { get => birthPlace; set => birthPlace = value; }
        public int? RevengeFactorCounter { get; set; }  // revenge factor counter start from 0 
        public bool? Disabled { get; set; }
        public bool? HasSpecialNeeds { get; set; }

        public double? SortOrDrawCriterion { get; internal set; }

        public override string ToString()
        {
            return LastName + " " + FirstName + " (" + RevengeFactorCounter + ")";
            //return RegisterNumber + " " + LastName + " " + FirstName + " " + Class + " " + SchoolYear;
            //return LastName + " " + FirstName;
        }
    }
}
