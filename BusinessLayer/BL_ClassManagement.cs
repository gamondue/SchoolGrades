using gamon;
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
        internal string CreateFileAllTopicsOfTheClass(Class Class, SchoolSubject Subject)
        {
            string fileContent = "";
            string tabs = "";

            // write down all the lessons descriptions 
            fileContent += "Lessons descriptions\r\n";
            List<Lesson> ll = dl.GetLessonsOfClass(Class, Subject.IdSchoolSubject, true);
            foreach (Lesson l in ll)
            {
                fileContent += $"\r\nLesson: {l.Note} \r\n";
                List<Topic> lt1 = dl.GetTopicsOfLesson(l.IdLesson);
                foreach (Topic t in lt1)
                {
                    fileContent += $"{t.Name}\r\n";
                    if (t.Desc != null && t.Desc != "")
                        fileContent += $"\t{t.Desc}\r\n";
                }
            }
            // write down all the topics selected
            fileContent += "\r\n\r\nTopics done\r\n";
            List<Topic> lt = dl.GetTopicsDoneInClassInPeriod(Class, Subject, null, null);
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
                fileContent += tabs + t.Name;
                if (t.Desc != "")
                    fileContent += ": " + t.Desc;
                fileContent += "\r\n";
                previous = t;
            }
            return fileContent; 
        }
        internal List<string> GetStartLinksOfClass(Class currentClass)
        {
            return dl.GetStartLinksOfClass(currentClass); 
        }
    }
}
