using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using ImageBO = SchoolGrades.BusinessObjects.Image;



namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal ImageBO FindImageWithGivenFile(string sourcePathAndFileName)
        {
            return dl.FindImageWithGivenFile(sourcePathAndFileName);
        }
        internal void RemoveImageFromLesson(Lesson Lesson, ImageBO ImageBO, bool AlsoEraseFile)
        {
            if (AlsoEraseFile)
            {
                try
                {
                    // !!!! TODO: FIX: this gives error every time, so currently the program doesn't erase the pictures !!!!
                    File.Delete(Path.Combine(Commons.PathImages, ImageBO.RelativePathAndFilename));
                }
                catch (Exception ex)
                {
                    string err = "DbLayer|RemoveImageFromLesson| " + Commons.PathImages + ImageBO.RelativePathAndFilename + " , " + ex.Message + ", " + ex.StackTrace;
                    Commons.ErrorLog(err);
                    Console.Beep();
                    //////throw new Exception(err);
                }
            }
            dl.RemoveImageFromLesson(Lesson, ImageBO, AlsoEraseFile);
        }
        internal void SaveImage(ImageBO currentImage)
        {
            dl.SaveImage(currentImage);
        }
        internal void AddLinkToOldPhoto(int? IdStudent, string IdPreviousSchoolYear, string IdNextSchoolYear)
        {
            dl.AddLinkToPreviousYearPhoto(IdStudent, IdPreviousSchoolYear, IdNextSchoolYear);
        }
        internal List<ImageBO> GetAllImagesShownToAClassDuringLessons(Class currentClass, SchoolSubject currentSubject, DateTime dateTime, DateTime now)
        {
            return dl.GetAllImagesShownToAClassDuringLessons(currentClass, currentSubject, dateTime, now);
        }
        internal List<string> GetCaptionsOfThisImage(string Text)
        {
            return dl.GetCaptionsOfThisImage(Text);
        }
        internal void RecusivelyFindImagesUnderPath(string ParentPath, ref List<string> AllFilesInTree)
        {
            if (Directory.Exists(ParentPath))
            {
                string[] filesInThisFolder = Directory.GetFiles(ParentPath);
                foreach (string file in filesInThisFolder)
                {
                    string ext = Path.GetExtension(file);
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".png" || ext == ".svg")
                        AllFilesInTree.Add(file);
                }
                string[] DaughterFolders = Directory.GetDirectories(ParentPath);
                foreach (string path in DaughterFolders)
                {
                    RecusivelyFindImagesUnderPath(path, ref AllFilesInTree);
                }
            }
        }
    }
}
