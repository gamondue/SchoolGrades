using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
{
    public class SchoolSubject
    {
        string idSchoolSubject;
        string name;
        string desc;
        int? color;
        int? orderOfVisualization; 
        string oldId; // to check if the SchoolSubject is new, field not present in the table in database

        public string IdSchoolSubject { get => idSchoolSubject; set => idSchoolSubject = value; }
        public string Name { get => name; set => name = value; }
        public string Desc { get => desc; set => desc = value; }
        public int? Color { get => color; set => color = value; }
        public string OldId { get => oldId; set => oldId = value; }
        public int? OrderOfVisualization { get => orderOfVisualization; set => orderOfVisualization = value; }

        public override string ToString()
        {
            if (Name != null)
                return Name;
            else
                return ""; 
        }
    }
}
