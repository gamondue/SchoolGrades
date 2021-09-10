using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal List<SchoolPeriod> GetSchoolPeriods(string currentSchoolYear)
        {
            return dl.GetSchoolPeriods(currentSchoolYear);
        }
    }
}
