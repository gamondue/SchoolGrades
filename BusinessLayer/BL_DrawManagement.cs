using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal List<Student> PrepareEligiblesByEqualProbability(List<Student> StudentsList)
        {
            List<Student> eligiblesList = new List<Student>();
            foreach (Student s in StudentsList)
            {
                if (s.Eligible == true)
                {
                    s.SortOrDrawCriterion = 1; // equal probability to all
                    eligiblesList.Add(s);
                }
            }
            return eligiblesList; 
        }
        internal List<Student> EqualizeTheNumberOfTheGrades(List<Student> StudentsWithCheck, Class Class, GradeType GradeType)
        {
            List<Student> eligiblesList = new List<Student>();

            List<Grade> gradesCounts = Commons.bl.CountNonClosedMicroGrades(Class,
            GradeType);

            // find the max number of microgrades that haven't been closed
            int nMaxTimes = 0;
            foreach (Student stud in StudentsWithCheck)
            {
                // find max of microgrades 
                foreach (Grade g in gradesCounts)
                {
                    if (g.IdStudent == stud.IdStudent)
                    {
                        stud.DummyNumber = g.DummyInt;
                        if (stud.DummyNumber > nMaxTimes)
                        {
                            nMaxTimes = (int)stud.DummyNumber;
                        }
                    }
                }
            }
            // put the student in the eligibles' list as many time as enough
            // to have a number of grades equal to the maximum just found
            foreach (Student st in StudentsWithCheck)
            {
                for (int j = 0; j < 1 + nMaxTimes - st.DummyNumber; j++)
                {
                    eligiblesList.Add(st);
                }
            }
            return eligiblesList;
        }
    }
}
