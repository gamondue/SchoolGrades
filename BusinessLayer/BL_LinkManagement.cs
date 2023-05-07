using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        internal bool IsDataLayerFunctioning
        { 
            get {
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
            string LessonImagesRelativePath, Lesson Lesson, Class Class, Image Image, bool AutoRename, bool MantainOldFileName)
        {
            // if the chosen file is already in the image path, the program
            // will avoid copying it under the image path and will link to the 
            // existing file instead 
            //if (txtPathImportImage.Text.Contains(Commons.PathImages))
            if (Path.GetDirectoryName(SourceImagePathAndFileName).Contains(Commons.PathImages))
            {
                // chosen file is inside the images path 
                // does not copy and rename the file
                // this spares HDD space on teachers' machine 
                justLinkFileToLesson(SourceImagePathAndFileName, Lesson, Image.Caption);
            }
            else
            {
                // chosen file is outside the common images path 
                copyFileToImagesAndLinkToLessons(SourceImagePathAndFileName, LessonImagesPath,
                    LessonImagesRelativePath, Lesson, Class, Image, AutoRename, MantainOldFileName);
            }
        }
        private void justLinkFileToLesson(string PathAndFileName, Lesson Lesson, string ImageCaption)
        {
            BusinessObjects.Image currentImage = Commons.bl.FindImageWithGivenFile(PathAndFileName);
            // if the image that reference to the file isn't anymore in the database 
            // create a new image that references to this file 
            // (eg. if the lesson has been deleted from the database together with its images, but 
            // the file is (somehow) still there) 
            if (currentImage == null)
            {
                currentImage = new BusinessObjects.Image();
                currentImage.IdImage = 0;
                currentImage.RelativePathAndFilename = PathAndFileName.Remove(0, Commons.PathImages.Length + 1);
            }
            //currentImage.Caption = txtCaption.Text;
            currentImage.Caption = ImageCaption;
            
            Commons.bl.LinkOneImageToLesson(currentImage, Lesson);
        }
        private void copyFileToImagesAndLinkToLessons(string SourcePathAndFileName, string LessonImagesFullPath, 
            string LessonImagesRelativePath, Lesson Lesson, Class Class, Image Image, bool AutoRename, bool MantainOldFileName)
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
                Image.RelativePathAndFilename = Path.Combine (LessonImagesRelativePath, destinationFileName);
            }
            else 
            {
                destinationFileName = SourcePathAndFileName;
                destinationPathAndFileName = Commons.PathImages + "\\" +
                    LessonImagesFullPath + destinationFileName;
                if (File.Exists(destinationPathAndFileName))
                {
                    MessageBox.Show("Il file " + destinationPathAndFileName + " esiste già.");
                    return;
                }
                Image.RelativePathAndFilename = LessonImagesFullPath + destinationFileName;
            }

            if (!File.Exists(SourcePathAndFileName))
            {
                MessageBox.Show("Il file " + SourcePathAndFileName + " non esiste!");
                return;
            }
            // if it doesn't exist, create the folder of the images of the lessons of the class
            if (!Directory.Exists(LessonImagesFullPath))
            {
                Directory.CreateDirectory(Commons.PathImages + "\\" + LessonImagesFullPath);
            }
            File.Copy(SourcePathAndFileName, destinationPathAndFileName);
            Image.IdImage = 0; // to force creation of a new record
            Commons.bl.LinkOneImageToLesson(Image, Lesson);
        }
    }
}
