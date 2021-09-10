using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal Image FindImageWithGivenFile(string sourcePathAndFileName)
        {
            return dl.FindImageWithGivenFile(sourcePathAndFileName);
        }
        internal void RemoveImageFromLesson(Lesson currentLesson, Image currentImage, bool v)
        {
            dl.RemoveImageFromLesson(currentLesson, currentImage, v);
        }
        internal void SaveImage(Image currentImage)
        {
            dl.SaveImage(currentImage);
        }
        internal void AddLinkToOldPhoto(int value, string text1, string text2)
        {
            dl.AddLinkToOldPhoto(value, text1, text2);
        }
        internal List<Image> GetAllImagesShownToAClassDuringLessons(Class currentClass, SchoolSubject currentSubject, DateTime dateTime, DateTime now)
        {
            return dl.GetAllImagesShownToAClassDuringLessons(currentClass, currentSubject, dateTime, now);
        }
    }
}
