using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SchoolGrades.BusinessObjects
{
    public class SchoolYear
    {
        public string IdSchoolYear { get; set; }
        public string ShortDescription { get; set; }
        public string Notes { get; set; }
        public override string ToString()
        {
            if (IdSchoolYear != null)
                return IdSchoolYear;
            else
                return "";
        }
    }
}
