using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal List<Class> GetClassesOfYear(string IdSchool, string SchoolYear)
        {
            return dl.GetClassesOfYear(IdSchool, SchoolYear); 
        }
    }
}
