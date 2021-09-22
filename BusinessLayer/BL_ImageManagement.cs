using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal Image FindImageWithGivenFile(string sourcePathAndFileName)
        {
            return dl.FindImageWithGivenFile(sourcePathAndFileName);
        }
        internal void RemoveImageFromLesson(Lesson Lesson, Image Image, bool AlsoEraseFile)
        {
            if (AlsoEraseFile)
            {
                try
                {
                    // !!!! TODO: FIX: this gives error every time, so currently the program doesn't erase the pictures !!!!
                    File.Delete(Commons.PathImages + "\\" + Image.RelativePathAndFilename);
                }
                catch (Exception ex)
                {
                    string err = "DbLayer|RemoveImageFromLesson|" +
                        Commons.PathImages + "\\" + Image.RelativePathAndFilename +
                        ".\r\n" + ex.Message + ex.StackTrace;
                    Commons.ErrorLog(err);
                    Console.Beep(); 
                    //////throw new Exception(err);
                }
            }
            dl.RemoveImageFromLesson(Lesson, Image, AlsoEraseFile);
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
        internal List<string> GetCaptionsOfThisImage(string Text)
        {
            return dl.GetCaptionsOfThisImage(Text);
        }
    }
}
