using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;

namespace SchoolGrades
{
    internal enum TypeOfDraw
    {
        EqualProbability,
        WeightsSum,
        NoOfGrades,
        OldestFirst,
        Alphabetical,
        LowGradesFirst,
        RevengeFactor
    }

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
        internal int RandomNumber(int v, int v1)
        {
            Random rnd = new Random();
            return rnd.Next(v, v1);
        }
        internal void DrawOrSort(TypeOfDraw TypeOfDraw, List<Student> StudentsList, ref List<Student> EligiblesList
            , Class Class, SchoolSubject Subject, GradeType GradeType, bool ShouldDraw)
        {
            EligiblesList.Clear();

            // first pass: prepare the sort or draw criterion and pick those present
            // sets the value of property SortOrDrawCriterion according to the type of draw
            if (TypeOfDraw == TypeOfDraw.EqualProbability)
            {
                EligiblesList = Commons.bl.PrepareEligiblesByEqualProbability(StudentsList);
            }
            else if (TypeOfDraw == TypeOfDraw.WeightsSum)
            {
                EligiblesList = PrepareEligiblesByWeightSum(StudentsList, EligiblesList,
                    Class, GradeType, Subject);
            }
            else if (TypeOfDraw == TypeOfDraw.NoOfGrades)
            {
                EligiblesList = PrepareEligiblesByNumberOfGrades(Class, StudentsList, GradeType, Subject);
            }
            else if (TypeOfDraw == TypeOfDraw.OldestFirst)
            {
                EligiblesList = PrepareEligiblesByOldestFirst();
            }
            else if (TypeOfDraw == TypeOfDraw.Alphabetical)
            {
                // same as equal probability
                // but draw will be forbidden later
                EligiblesList = Commons.bl.PrepareEligiblesByEqualProbability(StudentsList);
            }
            else if (TypeOfDraw == TypeOfDraw.LowGradesFirst)
            {
                EligiblesList = PrepareEligiblesByLowGradesFirst();
            }
            else if (TypeOfDraw == TypeOfDraw.RevengeFactor)
            {
                EligiblesList = PrepareEligiblesByRevengeFactor(StudentsList);
            }
            // second pass: shuffle the list or sort 
            // for both operations it uses the SortOrDrawCriterion Property
            if (ShouldDraw && TypeOfDraw != TypeOfDraw.Alphabetical)
            {
                Commons.ListShuffleWithDifferentProbabilities(EligiblesList);
            }
            else
            {  // sort the list by the criterion
                Commons.SortListBySortOrDrawCriterionDescending(EligiblesList);
            }
        }
        private List<Student> PrepareEligiblesByWeightSum(List<Student> StudentsList, List<Student> EligiblesList
            , Class Class, GradeType GradeType, SchoolSubject Subject)
        {
            //find the sum of the weights of grades of each student
            List<Student> studentsAndWeights =
                Commons.bl.GetStudentsAndSumOfWeights(Class, StudentsList, GradeType, Subject,
                DateTime.MinValue, DateTime.MaxValue); // TODO: put the dates of the current school period
            // find max of weights
            double? maxOfWeights = 0;
            foreach (Student s in studentsAndWeights)
            {
                if (s.Sum > maxOfWeights)
                    maxOfWeights = s.Sum;
            }
            foreach (Student studentOfAll in StudentsList)
            {
                // put in SortOrDrawCriterion a number lower if the student has higher weights
                foreach (Student studentOfGraded in studentsAndWeights)
                {
                    // if we will not find the student, then he will get maximum for the SortOrDrawCriterion
                    studentOfAll.SortOrDrawCriterion = maxOfWeights;// we shouldn't ever pass 10 as a sum of weights 
                    // search for this student in the list of those that have a weight of questions
                    if (studentOfAll.IdStudent == studentOfGraded.IdStudent)
                    {
                        // student found, is he has more than maxiumum weights, take maximum
                        // (in Sum there is the sum of the weights of questions of the student)
                        if (studentOfGraded.Sum > maxOfWeights)
                            studentOfGraded.Sum = maxOfWeights;
                        studentOfAll.SortOrDrawCriterion = maxOfWeights - studentOfGraded.Sum;
                        break;
                    }
                }
                // put this student in the eligibles list if he is present
                if ((bool)studentOfAll.Eligible)
                    EligiblesList.Add(studentOfAll);
            }
            return EligiblesList;
        }
        private List<Student> PrepareEligiblesByNumberOfGrades(Class Class, List<Student> StudentsList
            , GradeType GradeType, SchoolSubject Subject)
        {
            List<Student> eligiblesList = new List<Student>();
            //find the number of grades of each student (beside the sum of the weights)
            List<Student> studentsAndWeights =
                Commons.bl.GetStudentsAndSumOfWeights(Class, StudentsList, GradeType, Subject,
                DateTime.MinValue, DateTime.MaxValue); // TODO: put the dates of the current school period

            double? maxOfCounts = 0;
            foreach (Student s in studentsAndWeights)
            {
                // in DummyNumber the database passes the number of questions answered by the student
                if (s.DummyNumber > maxOfCounts)
                    maxOfCounts = s.Sum;
            }
            foreach (Student studentOfAll in StudentsList)
            {
                // put in SortOrDrawCriterion a number lower if the student has higher weights
                foreach (Student studentOfGraded in studentsAndWeights)
                {
                    // if we will not find the student, then he will get maximum for the SortOrDrawCriterion
                    studentOfAll.SortOrDrawCriterion = maxOfCounts;// we shouldn't ever pass 10 as a sum of weights 
                    // search for this student in the list of those that have a weight of questions
                    if (studentOfAll.IdStudent == studentOfGraded.IdStudent)
                    {
                        // student found, is he has more than maxiumum weights, take maximum
                        // (in Sum there is the sum of the weights of questions of the student)
                        if (studentOfGraded.DummyNumber > maxOfCounts)
                            studentOfGraded.DummyNumber = maxOfCounts;
                        studentOfAll.SortOrDrawCriterion = maxOfCounts - studentOfGraded.DummyNumber;
                        break;
                    }
                }
                // put this student in the eligibles list if he is present
                if (studentOfAll.Eligible == true)
                    eligiblesList.Add(studentOfAll);
            }
            return eligiblesList;
        }
        private List<Student> PrepareEligiblesByRevengeFactor(List<Student> StudentsList)
        {
            return CreateRevengeList(StudentsList);
        }
        private List<Student> PrepareEligiblesByLowGradesFirst()
        {
            throw new NotImplementedException();
        }
        private List<Student> PrepareEligiblesByOldestFirst()
        {
            throw new NotImplementedException();
        }
        internal List<Student> CreateRevengeList(List<Student> StudentList)
        {
            List<Student> listVf = new List<Student>();
            int? maxVf = 0;
            // take only the eligible students with V.F. > 0 
            foreach (Student s in StudentList)
            {
                if (s.RevengeFactorCounter > 0 && (bool)s.Eligible)
                {
                    listVf.Add(s);
                    // set parameter for sort or draw
                    s.SortOrDrawCriterion = s.RevengeFactorCounter;
                    if (s.RevengeFactorCounter > maxVf)
                        maxVf = s.RevengeFactorCounter;
                }
            }
            return listVf;
        }
    }
}
