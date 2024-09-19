using System;

namespace SchoolGrades.BusinessObjects
{
    public class Student
    {
        string city;
        string origin;
        string email;
        Nullable<DateTime> birthDate;
        string birthPlace;

        public Student()
        {
        }
        public Student(string LastName, string FirstName)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
        }
        public int? IdStudent { get; set; }
        public string RegisterNumber { get; set; } // field not in the table Student in database
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public float ArithmeticMean { get; set; }    // program should be modified to eliminate this property 
        public double? Sum { get; set; }     // program should be modified to eliminate this property
        public double? DummyNumber { get; set; }  // used by the program when it needs to associate a number to a student
        public bool? Eligible { get; set; }
        public string SchoolYear { get; set; }    // field not in the table Student in database
        public int? IdClass { get; set; }   // field not in the table Student in database
        public string ClassAbbreviation { get; set; } // field not in the table Student in database
        public string City { get => city; set => city = value; }
        public string Origin { get => origin; set => origin = value; }
        public string Email { get => email; set => email = value; }
        public Nullable<DateTime> BirthDate { get => birthDate; set => birthDate = (DateTime?)value; }
        public string BirthPlace { get => birthPlace; set => birthPlace = value; }
        public int? RevengeFactorCounter { get; set; }  // revenge factor counter starts from 0
        public bool? Disabled { get; set; }
        public bool? HasSpecialNeeds { get; set; }
        public double? SortOrDrawCriterion { get; internal set; }
        public string Telephone { get; set; }
        public string MobileTelephone { get; set; }
        public string Gender { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return LastName + " " + FirstName + " (" + RevengeFactorCounter + ")";
            //return RegisterNumber + " " + LastName + " " + FirstName + " " + Class + " " + SchoolYear;
            //return LastName + " " + FirstName;
        }
    }
}
