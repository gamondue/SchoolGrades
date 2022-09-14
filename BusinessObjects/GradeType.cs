
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
{
    public class GradeType
    {
        private string idGradeType;
        private string idGradeCategory;
        private string name;
        private string desc;
        private double? defaultWeight;
        private int programsCode;
        private string idGradeTypeParent;

        public string IdGradeType { get => idGradeType; set => idGradeType = value; }
        public string IdGradeCategory { get => idGradeCategory; set => idGradeCategory = value; }
        public string Name { get => name; set => name = value; }
        public string Desc { get => desc; set => desc = value; }
        public double? DefaultWeight { get => defaultWeight; set => defaultWeight = value; }
        public int ProgramsCode { get => programsCode; set => programsCode = value; }
        public string IdGradeTypeParent { get => idGradeTypeParent; set => idGradeTypeParent = value; } 

        public string IntegerKey
        {   // remaps the primary key to the name of the base class
            get
            { return IdGradeType;}
            set
            {
                IdGradeType = IntegerKey = value; 
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
