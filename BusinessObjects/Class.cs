using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using gamon;

namespace SchoolGrades.BusinessObjects
{
    public class Class
    {
        public string FileName;

        private Student currentStudent;

        public Student CurrentStudent
        {
            get { return currentStudent; }
            set { currentStudent = value; }
        }

        public string SchoolYear { get; internal set; }
        public string IdSchool { get; set; }
        public string Abbreviation { get; internal set; }
        public int? IdClass { get; internal set; }
        public string PathRestrictedApplication { get => pathRestrictedApplication; set => pathRestrictedApplication = value; }
        public string UriWebApp { get; internal set; } // field currently not used (relationship 1 to N of table ClassesStartlinks instead) 
        public string Description { get; internal set; }

        private string pathRestrictedApplication;

        public Class()
        {
        }

        public Class(string nomeFile)
        {
            FileName = nomeFile; 
        }

        public Class(int? IdClass, string Abbreviation, 
            string SchoolYear, string IdSchool)
        {
            this.IdClass = IdClass;
            this.Abbreviation = Abbreviation;
            this.SchoolYear = SchoolYear;
            this.IdSchool = IdSchool; 
        }

        public override string ToString()
        {
            return Abbreviation;
            //return Abbreviation + " " + SchoolYear;
        }
    }
}
