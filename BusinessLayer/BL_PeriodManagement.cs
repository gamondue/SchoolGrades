using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal List<SchoolPeriod> GetSchoolPeriods(string SchoolYear)
        {
            return dl.GetSchoolPeriods(SchoolYear);
        }
        internal void SaveSchoolPeriod(SchoolPeriod SchoolPeriod)
        {
            dl.SaveSchoolPeriod(SchoolPeriod);
        }
        internal void CreateNewQuadrimesterPeriods(string SchoolYear)
        {
            if (dl.FindIfPeriodsAreAlreadyExisting(SchoolYear))
            {
                throw new Exception("Period already present");
                return;
            }
            SchoolPeriod newSp = new SchoolPeriod();
            int startingYear = Convert.ToInt32("20" + SchoolYear.Substring(0, 2));
            // whole year period
            newSp.IdSchoolPeriod = SchoolYear;
            newSp.IdSchoolPeriodType = "Y";
            newSp.IdSchoolYear = SchoolYear;
            newSp.DateStart = new DateTime(startingYear, 9, 1);
            newSp.DateFinish = new DateTime(startingYear + 1, 6, 15);
            newSp.Name = "Anno " + startingYear.ToString().Substring(2) + "-" + (startingYear + 1).ToString().Substring(2);
            newSp.Desc = "Anno scolastico " + startingYear + "-" + (startingYear + 1);
            dl.SaveSchoolPeriod(newSp);

            // first period
            newSp.IdSchoolPeriod = SchoolYear + "1P";
            newSp.IdSchoolPeriodType = "P";
            newSp.IdSchoolYear = SchoolYear;
            newSp.DateStart = new DateTime(startingYear, 9, 1);
            newSp.DateFinish = new DateTime(startingYear + 1, 1, 31);
            newSp.Name = "1 Per." + startingYear.ToString().Substring(2) + "-" + (startingYear + 1).ToString().Substring(2);
            newSp.Desc = "Primo periodo A.S. " + startingYear + "-" + (startingYear + 1);
            dl.SaveSchoolPeriod(newSp);

            // second period
            newSp.IdSchoolPeriod = SchoolYear + "2P";
            newSp.IdSchoolPeriodType = "P";
            newSp.IdSchoolYear = SchoolYear;
            newSp.DateStart = new DateTime(startingYear + 1, 1, 31);
            newSp.DateFinish = new DateTime(startingYear + 1, 6, 15);
            newSp.Name = "2 Per." + startingYear.ToString().Substring(2) + "-" + (startingYear + 1).ToString().Substring(2);
            newSp.Desc = "Secondo periodo A.S. " + startingYear + "-" + (startingYear + 1);
            dl.SaveSchoolPeriod(newSp);
        }
        internal void CreateNewTrimesterPeriods(string SchoolYear)
        {
            {
                if (dl.FindIfPeriodsAreAlreadyExisting(SchoolYear))
                {
                    throw new Exception("Period already present");
                    return;
                }
                SchoolPeriod newSp = new SchoolPeriod();
                int startingYear = Convert.ToInt32("20" + SchoolYear.Substring(0, 2));
                // whole year period
                newSp.IdSchoolPeriod = SchoolYear;
                newSp.IdSchoolPeriodType = "Y";
                newSp.IdSchoolYear = SchoolYear;
                newSp.DateStart = new DateTime(startingYear, 9, 1);
                newSp.DateFinish = new DateTime(startingYear + 1, 6, 15);
                newSp.Name = "Anno " + SchoolYear;
                newSp.Desc = "Anno scolastico " + startingYear + "-" + (startingYear + 1);
                dl.SaveSchoolPeriod(newSp);
                
                // first period
                newSp.IdSchoolPeriod = SchoolYear + "1P";
                newSp.IdSchoolPeriodType = "P";
                newSp.IdSchoolYear = SchoolYear;
                newSp.DateStart = new DateTime(startingYear, 9, 1);
                newSp.DateFinish = new DateTime(startingYear, 11, 30);
                newSp.Name = "1 Per." + startingYear.ToString().Substring(2) + "-" + (startingYear + 1).ToString().Substring(2);
                newSp.Desc = "Primo periodo A.S. " + startingYear + "-" + (startingYear + 1);
                dl.SaveSchoolPeriod(newSp);

                // second period
                newSp.IdSchoolPeriod = SchoolYear + "2P";
                newSp.IdSchoolPeriodType = "P";
                newSp.IdSchoolYear = SchoolYear;
                newSp.DateStart = new DateTime(startingYear, 11, 30);
                newSp.DateFinish = new DateTime(startingYear + 1, 3, 31);
                newSp.Name = "2 Per." + startingYear.ToString().Substring(2) + "-" + (startingYear + 1).ToString().Substring(2);
                newSp.Desc = "Secondo periodo A.S. " + startingYear + "-" + (startingYear + 1);
                dl.SaveSchoolPeriod(newSp);

                // third period
                newSp.IdSchoolPeriod = SchoolYear + "3P";
                newSp.IdSchoolPeriodType = "P";
                newSp.IdSchoolYear = SchoolYear;
                newSp.DateStart = new DateTime(startingYear + 1, 3, 31);
                newSp.DateFinish = new DateTime(startingYear + 1, 6, 15);
                newSp.Name = "3 Per." + startingYear.ToString().Substring(2) + "-" + (startingYear + 1).ToString().Substring(2);
                newSp.Desc = "Terzo periodo A.S. " + startingYear + "-" + (startingYear + 1);
                dl.SaveSchoolPeriod(newSp);
            }
        }
        internal void DeleteSchoolPeriod(string IdSchoolPeriod)
        {
            dl.DeleteSchoolPeriod(IdSchoolPeriod); 
        }
    }
}
