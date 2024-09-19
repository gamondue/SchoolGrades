using System;

namespace SchoolGrades.BusinessObjects
{
    public class SchoolYear
    {
        public SchoolYear()
        {

        }
        public SchoolYear(string IdSchoolYear)
        {
            this.IdSchoolYear = IdSchoolYear;
            // defaults
            ShortDescription = "A.S. " + IdSchoolYear;
            // TODO: change the next if in 2050 :-) 
            try
            {
                int first = Convert.ToInt32(IdSchoolYear.Substring(0, 1));
                if (first >= 0 && first <= 5)
                    Notes = "Anno scolastico 20" + IdSchoolYear.Substring(0, 2)
                        + " 20" + IdSchoolYear.Substring(3, 2);
                else
                    Notes = "Anno scolastico 19" + IdSchoolYear.Substring(0, 2)
                        + " 19" + IdSchoolYear.Substring(3, 2);
            }
            catch { }
        }
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
