﻿using gamon;
using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal void CreateAllTopicsDoneFile(string Filename, Class CurrentClass,
            SchoolSubject CurrentSubject, bool IsPlainText)
        {
            List<Topic> lt = dl.GetAllTopicsDoneInClassAndSubject(CurrentClass,
                CurrentSubject);
            string f = "";
            string tabs = "";
            Topic previous = new Topic();
            previous.Id = -2;
            string status = "s"; // start tab 
            foreach (Topic t in lt)
            {
                // put a tab in front of descending nodes 
                switch (status)
                {
                    case "s": // start tab
                        {
                            if (t.ParentNodeOld == previous.Id)
                            {
                                // is son of the previous
                                tabs += "\t";
                                status = "b"; // brothers
                            }
                            else
                                tabs = "";
                            break;
                        }
                    case "b": // brothers 
                        {
                            if (t.ParentNodeOld == previous.ParentNodeOld)
                            {
                                // another brother: do nothing
                            }
                            else if (t.ParentNodeOld == previous.Id)
                            {
                                // is son of the previous
                                tabs += "\t";
                                status = "b"; // brothers
                            }
                            else
                            {   // non brothers & non son 
                                tabs = "";
                                status = "s"; // brothers
                            }
                            break;
                        }
                    case "u":
                        {
                            break;
                        }
                }
                if (IsPlainText)
                    f += tabs + t.Name;
                else
                {
                    f += tabs.Replace('\t', '#') + " " + t.Name;
                }
                if (t.Desc != "")
                    f += ": " + t.Desc;
                f += "\r\n";
                previous = t;
            }
            if (IsPlainText)
                TextFile.StringToFile(Commons.PathDatabase + "\\" + Filename + ".txt", f, false);
            else
                TextFile.StringToFile(Commons.PathDatabase + "\\" + Filename + ".md", f, false);
        }
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
