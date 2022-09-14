using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.BusinessObjects
{
    public class StudentAndGrade
    {
        private string v1;
        private string v2;
        private double v3;
        public StudentAndGrade()
        {
            Student = new Student();
            Grade = new Grade(); 
        }
        //public StudentAndGrade(string v1, string v2, double v3)
        //{
        //    Student = new Student();
        //    Grade = new Grade();

        //    this.v1 = v1;
        //    this.v2 = v2;
        //    this.v3 = v3;
        //}
        public Student Student { get; set; }
        public Grade Grade { get; set; }
        public double? WeightedAverage { get; internal set; }
        public double? WeightedRms { get; internal set; }
        public int? GradesCount { get; internal set; }
    }
    // comparer for sorting list 
    //internal class ComparerWeightedAverages : IComparer<StudentAndGrade>
    //{
    //    public double Compare(StudentAndGrade x, StudentAndGrade y)
    //    {
    //        if (x.WeightedAverage == 0 || y.WeightedAverage == 0)
    //        {
    //            return 0;
    //        }

    //        // CompareTo() method
    //        return x.CompareTo(y);
    //    }
    //}

    //public int Compare(Order x, Order y)
    //{
    //    int compareDate = x.Date.CompareTo(y.Date);
    //    if (compareDate == 0)
    //    {
    //        return x.OrderID.CompareTo(y.OrderID);
    //    }
    //    return compareDate;
    //}


}
