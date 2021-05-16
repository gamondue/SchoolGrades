using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal List<Topic> GetTopicsDoneFromThisTopic(Class currentClass, Topic tag, SchoolSubject currentSchoolSubject)
        {
            return dl.GetTopicsDoneFromThisTopic(currentClass, tag, currentSchoolSubject);
        }
        internal List<Topic> GetTopicsNotDoneFromThisTopic(Class currentClass, Topic tag, SchoolSubject currentSchoolSubject)
        {
            return dl.GetTopicsNotDoneFromThisTopic(currentClass, tag, currentSchoolSubject);
        }
        internal Topic GetTopicById(int? idTopic)
        {
            return dl.GetTopicById(idTopic);
        }
        internal List<Topic> GetTopicsDoneInPeriod(Class currentClass, SchoolSubject currentSubject, DateTime dateFrom, DateTime DateTo)
        {
            return dl.GetTopicsDoneInPeriod(currentClass, currentSubject, dateFrom, DateTo);
        }
    }
}
