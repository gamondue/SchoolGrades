using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal void GroupStudentsByRandom(ref List<StudentAndGrade> ListStudents)
        {
            Commons.ListShuffleRandom(ListStudents);
        }
    }
}
