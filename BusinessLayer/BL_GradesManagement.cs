using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal Grade GetGrade(int? IdGrade)
        {
            return dl.GetGrade(IdGrade);
        }
    }
}
