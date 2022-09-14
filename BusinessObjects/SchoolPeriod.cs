using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
{
    public class SchoolPeriod
    {
        private string idSchoolPeriod;
        private string idSchoolPeriodType;
        private DateTime? dateStart;
        private DateTime? dateFinish;
        private string name;
        private string desc;
        private string idSchoolYear;

        public string IdSchoolPeriod { get => idSchoolPeriod; set => idSchoolPeriod = value; }
        public string IdSchoolPeriodType { get => idSchoolPeriodType; set => idSchoolPeriodType = value; }
        public DateTime? DateStart { get => dateStart; set => dateStart = value; }
        public DateTime? DateFinish { get => dateFinish; set => dateFinish = value; }
        public string Name { get => name; set => name = value; }
        public string Desc { get => desc; set => desc = value; }
        public string IdSchoolYear { get => idSchoolYear; set => idSchoolYear = value; }

        public override string ToString()
        {
            return Name; 
        }
    }
}
