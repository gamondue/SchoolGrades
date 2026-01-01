using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using ImageBO = SchoolGrades.BusinessObjects.Image;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal bool IsDataLayerFunctioning
        {
            get
            {
                return dl.IsTableReadable("Lessons");
            }
        }
        internal List<StartLink> GetStartLinksOfClass(Class Class)
        {
            return dl.GetStartLinksOfClass(Class);
        }
        internal void UpdatePathStartLinkOfClass(Class currentClass, string text)
        {
            dl.UpdatePathStartLinkOfClass(currentClass, text);
        }
        internal int? SaveStartLink(int? IdStartLink, int? IdClass, string SchoolYear,
            string StartLink, string Desc)
        {
            return dl.SaveStartLink(IdStartLink, IdClass, SchoolYear, StartLink, Desc);
        }
        internal void DeleteStartLink(int? currentIdStartLink)
        {
            dl.DeleteStartLink(currentIdStartLink);
        }
        internal List<SchoolPeriodType> GetSchoolPeriodTypes()
        {
            return dl.GetSchoolPeriodTypes();
        }
        internal List<Student> GetStudentsOfClassList(int? idClass)
        {
            throw new NotImplementedException();
        }
        internal void AddImageToLesson(string SourceImagePathAndFileName, string LessonImagesPath,
            string LessonImagesRelativePath, Lesson Lesson, Class Class, ImageBO ImageBO, bool AutoRename, bool MantainOldFileName)
        {
            // if the chosen file is already in the ImageBO path, the program
            // will avoid copying it under the ImageBO path and will link to the 
            // existing file instead 
            //if (txtPathImportImage.Text.Contains(Commons.PathImages))
            if (Path.GetDirectoryName(SourceImagePathAndFileName).Contains(Commons.PathImages))
            {
                // chosen file is inside the images path 
                // does not copy and rename the file
                // this spares HDD space on teachers' machine 
                justLinkFileToLesson(SourceImagePathAndFileName, Lesson, ImageBO.Caption);
            }
            else
            {
                // chosen file is outside the common images path 
                copyFileToImagesAndLinkToLessons(SourceImagePathAndFileName, LessonImagesPath,
                    LessonImagesRelativePath, Lesson, Class, ImageBO, AutoRename, MantainOldFileName);
            }
        }
        private void justLinkFileToLesson(string PathAndFileName, Lesson Lesson, string ImageCaption)
        {
            ImageBO currentImage = Commons.bl.FindImageWithGivenFile(PathAndFileName);
            // if the ImageBO that reference to the file isn't anymore in the database 
            // create a new ImageBO that references to this file 
            // (eg. if the lesson has been deleted from the database together with its images, but 
            // the file is (somehow) still there) 
            if (currentImage == null)
            {
                currentImage = new ImageBO();
                currentImage.IdImage = 0;
                currentImage.RelativePathAndFilename = PathAndFileName.Remove(0, Commons.PathImages.Length + 1);
            }
            //currentImage.Caption = txtCaption.Text;
            currentImage.Caption = ImageCaption;

            Commons.bl.LinkOneImageToLesson(currentImage, Lesson);
        }
        private void copyFileToImagesAndLinkToLessons(string SourcePathAndFileName, string LessonImagesFullPath,
            string LessonImagesRelativePath, Lesson Lesson, Class Class, ImageBO ImageBO, bool AutoRename, bool MantainOldFileName)
        {
            string ext = Path.GetExtension(SourcePathAndFileName);
            //LessonImagesPath = Class.SchoolYear +
            //        Class.Abbreviation + "\\Lessons" +
            //        "\\" + Lesson.IdSchoolSubject; ;
            //if (rdbAutoRename.Checked)
            //if (AutoRename)
            //    //LessonImagesPath = txtSubFolderStorage.Text + "\\"; // + currentLesson.IdSchoolSubject;
            //    LessonImagesPath = LessonImagesPath + "\\"; // + currentLesson.IdSchoolSubject;
            string destinationFileName = "";
            string destinationPathAndFileName = "";

            if (AutoRename)
            {
                string tempFileName;
                string oldFilename = Path.GetFileName(SourcePathAndFileName);
                if (MantainOldFileName)
                    tempFileName = ((DateTime)Lesson.Date).ToString("yyyy-MM-dd") + "_" +
                        Lesson.IdSchoolSubject + "-xggR" +
                        "_" + oldFilename;
                else
                {
                    tempFileName = ((DateTime)Lesson.Date).ToString("yyyy-MM-dd") + "_L_" +
                    Class.Abbreviation + Class.SchoolYear +
                    Lesson.IdSchoolSubject + "-xggR";
                    tempFileName += ext;
                }
                int i = 1;
                do
                {
                    if (!Directory.Exists(LessonImagesFullPath))
                        Directory.CreateDirectory(LessonImagesFullPath);
                    destinationPathAndFileName = Path.Combine(LessonImagesFullPath,
                        tempFileName.Replace("xggR", (i++).ToString("00")));
                } while (File.Exists(destinationPathAndFileName));
                destinationFileName = tempFileName.Replace("xggR", (--i).ToString("00"));
                ImageBO.RelativePathAndFilename = Path.Combine(LessonImagesRelativePath, destinationFileName);
            }
            else
            {
                destinationFileName = SourcePathAndFileName;
                destinationPathAndFileName = Path.Combine(Commons.PathImages,
                    LessonImagesFullPath, destinationFileName);
                if (File.Exists(destinationPathAndFileName))
                {
                    // !!!!! find another way to send this message !!!!! 
                    //MessageBox.Show("Il file " + destinationPathAndFileName + " esiste già.");
                    return;
                }
                ImageBO.RelativePathAndFilename = LessonImagesFullPath + destinationFileName;
            }

            if (!File.Exists(SourcePathAndFileName))
            {
                // !!!!! find another way to send this message !!!!! 
                //MessageBox.Show("Il file " + SourcePathAndFileName + " non esiste!");
                return;
            }
            // if it doesn't exist, create the folder of the images of the lessons of the class
            if (!Directory.Exists(LessonImagesFullPath))
            {
                Directory.CreateDirectory(Path.Combine(Commons.PathImages, LessonImagesFullPath));
            }
            File.Copy(SourcePathAndFileName, destinationPathAndFileName);
            ImageBO.IdImage = 0; // to force creation of a new record
            Commons.bl.LinkOneImageToLesson(ImageBO, Lesson);
        }
        internal string GetNewestAmongFilesWithDateInName(string DatabasePath)
        {
            if (!Directory.Exists(DatabasePath))
            {
                return null;
            }
            string[] files = Directory.GetFiles(DatabasePath);
            DateTime newestFileDate = DateTime.MinValue;
            string newestFileNameAndPath = "";
            foreach (string file in files)
            {
                DateTime thisFileDate = Commons.GetValidDateFromString(Path.GetFileName(file).Substring(0, 10));
                if (thisFileDate > newestFileDate)
                {
                    newestFileDate = thisFileDate;
                    newestFileNameAndPath = file;
                }
            }
            return newestFileNameAndPath;
        }
    }
}
