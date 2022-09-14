using System;
using System.Collections.Generic;
using SchoolGrades.BusinessObjects;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal Lesson GetLastLesson(Lesson currentLesson)
        {
            return dl.GetLastLesson(currentLesson);
        }
        internal List<Topic> GetTopicsOfLesson(int? idLesson)
        {
            return dl.GetTopicsOfLesson(idLesson);
        }
        internal List<Lesson> GetLessonsOfClass(Class currentClass, string idSchoolSubject)
        {
            return dl.GetLessonsOfClass(currentClass, idSchoolSubject, false);
        }
        internal Lesson GetLessonInDate(Class currentClass, string idSchoolSubject, DateTime value)
        {
            return dl.GetLessonInDate(currentClass, idSchoolSubject, value);
        }
        internal void SaveLesson(Lesson currentLesson)
        {
            dl.SaveLesson(currentLesson);
        }
        internal object GetTopicsOfOneLessonOfClass(Class currentClass, Lesson currentLesson)
        {
            return dl.GetTopicsOfOneLessonOfClass(currentClass, currentLesson);
        }
        internal void SaveTopicsOfLesson(int? idLesson, List<Topic> topicsOfTheLesson)
        {
            dl.SaveTopicsOfLesson(idLesson, topicsOfTheLesson);
        }
        internal List<Image> GetListLessonsImages(Lesson currentLesson)
        {
            return dl.GetLessonsImagesList(currentLesson);
        }
        internal void EraseLesson(int? IdLesson, bool AlsoEraseImageFiles)
        {
            dl.EraseLesson(IdLesson, AlsoEraseImageFiles); 
        }
        internal int? NewLesson(Lesson currentLesson)
        {
            return dl.NewLesson(currentLesson); 
        }
        internal void LinkOneImageToLesson(Image currentImage, Lesson currentLesson)
        {
            dl.LinkOneImageToLesson(currentImage, currentLesson);
        }
    }
}
