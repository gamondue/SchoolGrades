using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        internal void EraseAllNotConcerningDataOfOtherClasses(DataLayer newDatabaseDl, List<Class> Classes)
        {
            DbCommand cmd;
            using (DbConnection conn = newDatabaseDl.Connect()) // connect to the new database, just copied
            {
                // erase all the users
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Users" +
                    ";";
                cmd.ExecuteNonQuery();

                cmd = conn.CreateCommand();

                // erase the classes not involved in the generation of demo classes 
                cmd.CommandText = "DELETE FROM Classes" +
                " WHERE " + BuildAndClauseOnPassedField(Classes, "IdClass") +
                ";";
                cmd.ExecuteNonQuery();

                // erase all the lessons of other classes
                cmd.CommandText = "DELETE FROM Lessons" +
                    " WHERE " + BuildAndClauseOnPassedField(Classes, "IdClass") +
                    ";";
                cmd.ExecuteNonQuery();
                // erase all the students of other classes from the link table
                cmd.CommandText = "DELETE FROM Classes_Students" +
                 " WHERE " + BuildAndClauseOnPassedField(Classes, "IdClass") +
                 ";";
                cmd.ExecuteNonQuery();
                // erase all the students of other classes 
                cmd.CommandText = "DELETE FROM Students" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT idStudent FROM Classes_Students" +
                    " WHERE " + BuildOrClauseOnPassedField(Classes, "IdClass") +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the annotations, of all classes
                cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                    ";";
                cmd.ExecuteNonQuery();

                // erase all the StartLinks of ALL the classes (they will be re-done in the new database) 
                cmd.CommandText = "DELETE FROM Classes_StartLinks" +
                    ";";
                cmd.ExecuteNonQuery();

                // erase all the grades of other classes' students
                cmd.CommandText = "DELETE FROM Grades" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT idStudent FROM Classes_Students" +
                    " WHERE " + BuildOrClauseOnPassedField(Classes, "IdClass") +
                    ");";
                cmd.ExecuteNonQuery();

                //// erase all the links to photos of other classes' students
                //cmd.CommandText = "DELETE FROM StudentsPhotos_Students" +
                //    " WHERE idStudent NOT IN" +
                //    " (SELECT idStudent FROM Classes_Students" +
                //    " WHERE " + BuildOrClauseOnPassedField(Classes, "IdClass") +
                //    ");";

                // erase all the links to photos of all students
                cmd.CommandText = "DELETE FROM StudentsPhotos_Students" +
                    ";";
                cmd.ExecuteNonQuery();

                //// erase all the photos of other classes' students
                //cmd.CommandText = "DELETE FROM StudentsPhotos WHERE StudentsPhotos.idStudentsPhoto NOT IN" +
                //    "(SELECT StudentsPhotos_Students.idStudentsPhoto" +
                //    " FROM StudentsPhotos, StudentsPhotos_Students, Classes_Students" +
                //    " WHERE StudentsPhotos_Students.idStudent = Classes_Students.idStudent" +
                //    " AND StudentsPhotos.idStudentsPhoto = StudentsPhotos_Students.idStudentsPhoto" +
                //    " AND (" + BuildOrClauseOnPassedField(Classes, "Classes_Students.idClass") +
                //    "));";
                //cmd.ExecuteNonQuery();

                // erase all the photos of students. Those of new students will be created after 
                cmd.CommandText = "DELETE FROM StudentsPhotos" +
                    ";";
                cmd.ExecuteNonQuery();

                // erase all the images of other classes
                cmd.CommandText = "DELETE FROM Images WHERE Images.idImage NOT IN" +
                    "(SELECT DISTINCT Lessons_Images.idImage" +
                    " FROM Images, Lessons_Images, Lessons" +
                    " WHERE Lessons_Images.idImage = Images.idImage" +
                    " AND Lessons_Images.idLesson = Lessons.idLesson" +
                    " AND (" + BuildOrClauseOnPassedField(Classes, "Lessons.idClass") +
                    ")); ";
                cmd.ExecuteNonQuery();

                //erase all links to the images of other classes
                cmd.CommandText = "DELETE FROM Lessons_Images WHERE Lessons_Images.idImage NOT IN" +
                    "(SELECT DISTINCT Lessons_Images.idImage" +
                    " FROM Images, Lessons_Images, Lessons" +
                    " WHERE Lessons_Images.idImage = Images.idImage" +
                    " AND Lessons_Images.idLesson = Lessons.idLesson" +
                    " AND (" + BuildOrClauseOnPassedField(Classes, "Lessons.idClass") +
                    "));";
                cmd.ExecuteNonQuery();

                // erase all the questions of the students of the other classes
                // !! StudentsQuestions currently not used !!
                cmd.CommandText = "DELETE FROM StudentsQuestions" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT DISTINCT idStudent FROM Classes_Students" +
                    " WHERE " + BuildOrClauseOnPassedField(Classes, "IdClass") +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the answers  of the students of the other classes
                // !! StudentsAnswers is currently not used !!
                cmd.CommandText = "DELETE FROM StudentsAnswers" +
                " WHERE idStudent NOT IN" +
                " (SELECT idStudent FROM Classes_Students" +
                " WHERE " + BuildOrClauseOnPassedField(Classes, "IdClass") +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the tests of students of the other classes
                // !! StudentsTests is currently not used !!
                cmd.CommandText = "DELETE FROM StudentsTests" +
                " WHERE idStudent NOT IN" +
                " (SELECT idStudent FROM Classes_Students" +
                " WHERE " + BuildOrClauseOnPassedField(Classes, "IdClass") +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the topics of other classes' lessons
                cmd.CommandText = "DELETE FROM Lessons_Topics" +
                    " WHERE idLesson NOT IN" +
                    " (SELECT idLesson from Lessons" +
                    " WHERE " + BuildOrClauseOnPassedField(Classes, "IdClass") +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                // !!!! TODO delete SchoolPeriods not involved in the database demo" !!!!
                //int IdStartLink = NextKey("Classes_StartLinks", "IdStartLink");
                //cmd.CommandText = "DELETE FROM Lessons_Topics" +
                //    " WHERE idLesson NOT IN" +
                //    " (SELECT idLesson from Lessons" +
                //    " WHERE " + OrClauseOnPassedField(Classes, "IdClass") +
                //    ");";
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();

                // !!!! TODO delete SchoolYears not involved in the database demo" !!!!
                //int IdStartLink = NextKey("Classes_StartLinks", "IdStartLink");
                //cmd.CommandText = "DELETE FROM Lessons_Topics" +
                //    " WHERE idLesson NOT IN" +
                //    " (SELECT idLesson from Lessons" +
                //    " WHERE " + OrClauseOnPassedField(Classes, "IdClass") +
                //    ");";
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();
            }
        }
        internal void CreateDemoDataInDatabase(DataLayer newDatabaseDl, List<Class> Classes)
        {
            DbCommand cmd;
            string query;
            // modify all the data that hasn't been erased
            using (DbConnection conn = newDatabaseDl.Connect()) // connect to the new database, just copied
            {
                cmd = conn.CreateCommand();
                int classCount = 1;
                // change the data of all the classes
                foreach (Class c in Classes)
                {
                    // general data of the class
                    c.Abbreviation = c.Abbreviation.Substring(0, 1) + "DEMO" + classCount;
                    c.Description = "SchoolGrades demo class " + c.Abbreviation + ", year " + c.SchoolYear;
                    c.PathRestrictedApplication = Path.Combine(@".\", c.Abbreviation);
                    c.IdSchool = Commons.IdSchool;
                    c.UriWebApp = ""; // ???? decide what to put here ????
                    query = "UPDATE Classes" +
                        " SET" +
                        " idClass=" + c.IdClass + "" +
                        ",idSchoolYear=" + SqlString(c.SchoolYear) + "" +
                        ",idSchool=" + SqlString(c.IdSchool) + "" +
                        ",abbreviation=" + SqlString(c.Abbreviation) + "" +
                        ",desc=" + SqlString(c.Description) + "" +
                        ",uriWebApp=" + SqlString(c.UriWebApp) + "" +
                        ",pathRestrictedApplication=" + SqlString(c.PathRestrictedApplication) + "" +
                        " WHERE idClass=" + c.IdClass +
                        ";";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    classCount++;
                    // rename every student of the previous class
                    // according to the names found in the pictures' filenames
                    RenameStudentsNamesAndManagePictures(c, cmd);
                    // change the paths of the images to match the new names
                    ChangeImagesPath(c, cmd);
                    // randomly change all grades 
                    RandomizeGrades(cmd);

                    // make example start links 
                    // !!!! TODO insert demo startlinks in the database 
                    //int IdStartLink = NextKey("Classes_StartLinks", "IdStartLink");
                    //query = "INSERT INTO Classes_StartLinks" +
                    //    "(idStartLink, idClass, startLink, desc)" +
                    //    " Values (" + IdStartLink + "," +
                    //    c.IdClass + "," +
                    //    SqlString(@"https://web.spaggiari.eu/home/app/default/login.php?custcode=FOIP0004") + "," +
                    //    SqlString("Registro di classe") +
                    //    ");";
                    //cmd.CommandText = query;
                }
                // compact the database 
                cmd.CommandText = "VACUUM;";
                cmd.ExecuteNonQuery();
            }
        }
        private void RandomizeGrades(DbCommand cmd)
        {
            DbDataReader dRead;
            cmd.CommandText = "SELECT * FROM Grades" +
                ";";
            dRead = cmd.ExecuteReader();
            Random rnd = new Random();
            while (dRead.Read())
            {
                double? grade = Safe.Double(dRead["value"]);
                int? id = Safe.Int(dRead["IdGrade"]);
                // add to the grade a random delta between -10 and +10 
                if (grade > 0)
                {
                    grade = grade + rnd.NextDouble() * 20 - 10;
                    if (grade < 10) grade = 10;
                    if (grade > 100) grade = 100;
                }
                else
                    grade = 0;
                SaveGradeValue(id, grade, cmd);
            }
            cmd.Dispose();
        }
        private void RenameStudentsNamesAndManagePictures(Class Class, DbCommand cmd)
        {
            // get the "previous" students from database 
            List<Student> StudentsInClass = GetStudentsOfClass(Class.IdClass, cmd);

            // rename the students' names according to the names found in the image files 
            string[] OriginalDemoPictures = Directory.GetFiles(Commons.PathImages + "\\DemoPictures\\");
            // start assigning the names from a random image
            Random rnd = new Random();

            int pictureIndex;
            string lastName;
            string firstName;
            foreach (Student s in StudentsInClass)
            {
                do
                {   // avoid the same name and picture for different students 
                    pictureIndex = rnd.Next(0, OriginalDemoPictures.Length - 1);
                    string justFileName = Path.GetFileName(OriginalDemoPictures[pictureIndex]);
                    string fileWithNoExtension = justFileName.Substring(0, justFileName.LastIndexOf('.'));
                    string[] wordsInFileName = (Path.GetFileName(fileWithNoExtension)).Split(' ');
                    lastName = "";
                    firstName = "";
                    foreach (string word in wordsInFileName)
                    {
                        // last name in picture must be upper case 
                        if (word == word.ToUpper())
                        {
                            lastName += " " + word;
                        }
                        else
                        {
                            firstName += " " + word;
                        }
                    }
                    lastName = lastName.Trim();
                    firstName = firstName.Trim();
                } while (isDuplicate(lastName, firstName, StudentsInClass));
                s.LastName = lastName;
                s.FirstName = firstName;
                s.BirthDate = null;
                s.BirthPlace = null;
                s.ClassAbbreviation = "";
                s.Email = "";
                s.IdClass = 0;
                s.ArithmeticMean = 0;
                s.RegisterNumber = null;
                s.Residence = null;
                s.RevengeFactorCounter = 0;
                s.Origin = null;
                s.SchoolYear = null;
                s.Sum = 0;
                UpdateStudent(s, cmd);
                // save the image with standard name in the folder of the demo class
                string fileExtension = Path.GetExtension(OriginalDemoPictures[pictureIndex]);
                string folder = Commons.PathImages + "\\" + Class.SchoolYear + "_" + Class.Abbreviation + "\\";
                string filename = s.LastName + "_" + s.FirstName + "_" + Class.Abbreviation + Class.SchoolYear + fileExtension;
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                if (File.Exists(folder + filename))
                {
                    File.Delete(folder + filename);
                }
                // save student pictures' paths in table StudentsPhotos
                string relativePathAndFile = Path.Combine(Class.SchoolYear + "_" + Class.Abbreviation, filename);
                string absolutePathAndFile = Path.Combine(Commons.PathImages, relativePathAndFile);
                File.Copy(OriginalDemoPictures[pictureIndex], absolutePathAndFile);
                int? idImage = SaveDemoStudentPhotoPath(relativePathAndFile, cmd);
                AddLinkPhotoToStudent(s.IdStudent, idImage, Class.SchoolYear, cmd);
                // copy all the lessons images files that aren't already there or that have a newer date 
                string query = "SELECT Images.imagePath, Classes.pathRestrictedApplication" +
                " FROM Images" +
                    " JOIN Lessons_Images ON Lessons_Images.idImage=Images.idImage" +
                    " JOIN Lessons ON Lessons_Images.idLesson=Lessons.idLesson" +
                    " JOIN Classes ON Classes.idClass=Lessons.idClass" +
                    " WHERE Lessons.idClass=" + Class.IdClass +
                    ";";
                //DbCommand cmd = new SQLiteCommand(query);
                //cmd.Connection = conn;
                DbDataReader dReader = cmd.ExecuteReader();
                while (dReader.Read())
                {
                    string originFile = Commons.PathImages + "\\" + (string)dReader["imagePath"];
                    string filePart = (string)dReader["imagePath"];
                    string partToReplace = filePart.Substring(0, filePart.IndexOf("\\"));
                    filePart = filePart.Replace(partToReplace, Class.SchoolYear + "_" + Class.Abbreviation);
                    string destinationFile = Path.Combine(Commons.PathImages, filePart);
                    string destinationFolder = Path.GetDirectoryName(destinationFile);
                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }
                    if (!File.Exists(destinationFile) ||
                        File.GetLastWriteTime(destinationFile) < File.GetLastWriteTime(originFile))
                        // destination file not existing or older
                        try
                        {
                            File.Copy(originFile, destinationFile);
                        }
                        catch (Exception ex)
                        {
                            Console.Beep();
                        }
                }
                dReader.Dispose();

                if (++pictureIndex >= OriginalDemoPictures.Length)
                    pictureIndex = 0;
            }
        }
        private void AddLinkPhotoToStudent(int? idStudent, int? idStudentsPhoto, string schoolYear, DbCommand cmd)
        {
            cmd.CommandText = "INSERT INTO StudentsPhotos_Students" +
                " (idStudentsPhoto, idStudent, idSchoolYear)" +
                    "Values(" + SqlInt(idStudent) + "," + SqlInt(idStudentsPhoto) + "," + SqlString(schoolYear) + ")" +
                ";";
            cmd.ExecuteNonQuery();
        }
        private bool isDuplicate(string lastName, string firstName, List<Student> StudentsInClass)
        {
            bool found = false;
            foreach (Student s in StudentsInClass)
            {
                if (s.FirstName == firstName && s.LastName == lastName)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
    }
}
