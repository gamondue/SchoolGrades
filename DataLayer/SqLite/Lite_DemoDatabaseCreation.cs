using Microsoft.Data.Sqlite;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Security.Policy;

namespace SchoolGrades
{
    internal partial class SqLite_DataLayer : DataLayer
    {
        internal override void Create_GradesTable()
        {
            throw new NotImplementedException();
        }
        internal override void Delete_AllGrades()
        {
            throw new NotImplementedException();
        }
        internal override void Insert_GradesIntoTable()
        {
            throw new NotImplementedException();
        }
        internal override void EraseAllNotConcerningDataOfOtherClasses(DataLayer newDatabaseDl, List<Class> Classes)
        {
            // !!!! TODO bring this method to Business Layer !!!!
            DbCommand cmd;
            string andClausesWithIdClass = BuildAndClauseOnPassedField(Classes, "IdClass");
            string orClausesWithIdClass = BuildOrClauseOnPassedField(Classes, "IdClass");
            using (DbConnection conn = newDatabaseDl.Connect()) // connect to the new database, just copied
            {
                // cmd will used in all deleting commands
                cmd = conn.CreateCommand();

                // delete SchoolPeriods not involved in the database demo
                // execute this before deleting the SchoolYears
                cmd.CommandText = "DELETE FROM SchoolPeriods" +
                    " WHERE idSchoolYear NOT IN (" +
                    "SELECT SchoolYears.idSchoolYear" +
                    " FROM SchoolYears" +
                    " JOIN Classes ON SchoolYears.IdSchoolYear == Classes.IdSchoolYear" +
                    " WHERE " + orClausesWithIdClass +
                    ");";
                cmd.ExecuteNonQuery();

                // delete SchoolYears not involved in the database demo" !!!!
                int IdStartLink = NextKey("Classes_StartLinks", "IdStartLink");
                cmd.CommandText = "DELETE FROM SchoolYears" +
                    " WHERE IdSchoolYear NOT IN" +
                    " (SELECT SchoolYears.idSchoolYear" +
                    " FROM SchoolYears" +
                    " JOIN Classes ON SchoolYears.IdSchoolYear == Classes.IdSchoolYear" +
                    " WHERE " + orClausesWithIdClass +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the users
                cmd.CommandText = "DELETE FROM Users" +
                    ";";
                cmd.ExecuteNonQuery();

                // erase the classes not involved in the generation of demo classes 
                cmd.CommandText = "DELETE FROM Classes" +
                " WHERE " + andClausesWithIdClass +
                ";";
                cmd.ExecuteNonQuery();

                // erase all the lessons of other classes
                cmd.CommandText = "DELETE FROM Lessons" +
                    " WHERE " + andClausesWithIdClass +
                    ";";
                cmd.ExecuteNonQuery();
                // erase all the students of other classes from the link table
                cmd.CommandText = "DELETE FROM Classes_Students" +
                 " WHERE " + andClausesWithIdClass +
                 ";";
                cmd.ExecuteNonQuery();
                // erase all the students of other classes 
                cmd.CommandText = "DELETE FROM Students" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT idStudent FROM Classes_Students" +
                    " WHERE " + orClausesWithIdClass +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the annotations, of all the classes
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
                    " WHERE " + orClausesWithIdClass +
                    ");";
                cmd.ExecuteNonQuery();

                //// erase all the links to photos of other classes' students
                //cmd.CommandText = "DELETE FROM StudentsPhotos_Students" +
                //    " WHERE idStudent NOT IN" +
                //    " (SELECT idStudent FROM Classes_Students" +
                //    " WHERE " + orClausesWithIdClass +
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
                    " WHERE " + orClausesWithIdClass +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the answers  of the students of the other classes
                // !! StudentsAnswers is currently not used !!
                cmd.CommandText = "DELETE FROM StudentsAnswers" +
                " WHERE idStudent NOT IN" +
                " (SELECT idStudent FROM Classes_Students" +
                " WHERE " + orClausesWithIdClass +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the tests of students of the other classes
                // !! StudentsTests is currently not used !!
                cmd.CommandText = "DELETE FROM StudentsTests" +
                " WHERE idStudent NOT IN" +
                " (SELECT idStudent FROM Classes_Students" +
                " WHERE " + orClausesWithIdClass +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the topics of other classes' lessons
                cmd.CommandText = "DELETE FROM Lessons_Topics" +
                    " WHERE idLesson NOT IN" +
                    " (SELECT idLesson from Lessons" +
                    " WHERE " + orClausesWithIdClass +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                // !!!! TODO optionally erase also the topics not covered by lessons

            }
        }
        internal override void CreateDemoDataInDatabase(DataLayer newDatabaseDl, List<Class> Classes)
        {
            // The program imports the first al last names from the filename of the pictures. The full name can have many words.
            // The words in the filename that are ALL UPPERCASE will be considered parts of the last name. 
            // If a word has one or more lower case letters, it will be considered part of the first name.
            // The word will be added to name and surname from left to right.
            DbCommand cmd;
            string query;
            // modify all the data that hasn't been previously erased
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

                    // change the paths of the images to match the new names
                    ChangeImagePath(c, cmd);
                    // copy all the lessons images files
                    query = "SELECT Images.imagePath, Classes.pathRestrictedApplication" +
                    " FROM Images" +
                        " JOIN Lessons_Images ON Lessons_Images.idImage=Images.idImage" +
                        " JOIN Lessons ON Lessons_Images.idLesson=Lessons.idLesson" +
                        " JOIN Classes ON Classes.idClass=Lessons.idClass" +
                        " WHERE Lessons.idClass=" + c.IdClass +
                        ";";
                    cmd.CommandText = query;
                    DbDataReader dReader = cmd.ExecuteReader();
                    while (dReader.Read())
                    {
                        string finalPart = (string)dReader["imagePath"];
                        string originalPathAndFile = Path.Combine(Commons.PathImages, finalPart);
                        string partToBeReplaced = finalPart.Substring(0, finalPart.IndexOf("\\"));
                        string destinationPathAndFile = originalPathAndFile.Replace(partToBeReplaced, 
                            c.SchoolYear + "_" + c.Abbreviation);
                        string destinationFolder = Path.GetDirectoryName(destinationPathAndFile);
                        if (!Directory.Exists(destinationFolder))
                        {
                            Directory.CreateDirectory(destinationFolder);
                        }
                        if (!File.Exists(destinationPathAndFile) ||
                            File.GetLastWriteTime(destinationPathAndFile) < File.GetLastWriteTime(originalPathAndFile))
                            // destination file not existing or older
                            try
                            {
                                File.Copy(originalPathAndFile, destinationPathAndFile);
                            }
                            catch (Exception ex)
                            {
                                Console.Beep();
                            }
                    }
                    dReader.Close();
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
                // assign new names and pictures to all the students of the class
                // rename every student of the previous class
                // according to the names found in the pictures' filenames
                RenameAllStudentsNamesAndManagePictures(cmd);
                // randomly change all grades 
                RandomizeGrades();
                // compact the database 
                cmd.CommandText = "VACUUM;";
                cmd.ExecuteNonQuery();
            }
        }
        internal override void RandomizeGrades()
        {
            List<Grade> grades = new List<Grade>();
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                DbDataReader dRead;
                cmd.CommandText = "SELECT * FROM Grades" +
                    ";";
                dRead = cmd.ExecuteReader();
                Random rnd = new Random();
                // read all the grades in the list
                while (dRead.Read())
                {
                    Grade g = new();
                    g.IdGrade = Safe.Int(dRead["IdGrade"]);
                    g.Value = Safe.Double(dRead["value"]);
                    grades.Add(g);
                }
                dRead.Close();
                // for each grade, add a random delta between -15 and +15
                // and update the grade in the database
                foreach (Grade g in grades)
                {
                    double? grade = g.Value;
                    // add to the grade a random delta between -15 and +15 
                    if (grade != null && grade > 0)
                    {
                        grade = grade + rnd.NextDouble() * 30 - 15;
                        if (grade < 10) grade = 10;
                        if (grade > 100) grade = 100;
                    }
                    else
                        grade = 0;
                    cmd.CommandText = "UPDATE Grades" +
                    " SET value=" + SqlDouble(g.Value) +
                    " WHERE idGrade=" + SqlInt(g.IdGrade) +
                    ";";
                    cmd.ExecuteNonQuery();
                }
                cmd.Dispose();
            }
        }
        internal override void RenameStudentsNamesAndManagePictures(Class Class, DbCommand cmd)
        {
            // get the "previous" students from database 
            List<Student> studentsOfClass = GetStudentsOfClass(Class, true, cmd);

            // rename the students' names according to the names found in the image files 
            string[] OriginalDemoStudentPictures = Directory.GetFiles(Path.Combine(Commons.PathImages, "DemoPictures\\"));
            // start assigning the names from a random image
            Random rnd = new Random();
            int pictureIndex = (int)(rnd.NextDouble() * OriginalDemoStudentPictures.Length);

            string lastName;
            string firstName;
            // copy the students "photos" taking the name of the student from the name of the file 
            foreach (Student s in studentsOfClass)
            {
                // if the demo student has already been created, we don't create it
                // a demo student has a null in at least; BirthDate, BirthPlace, RegisterNumber, City
                if (s.BirthDate == null && s.BirthPlace == null && s.RegisterNumber == null && s.City == null)
                {
                    break;
                }
                string file = GetFilePhoto(s.IdStudent);
                // user is still not changed
                string fileExtension = "";
                do
                {
                    if (++pictureIndex >= OriginalDemoStudentPictures.Length)
                        pictureIndex = 0;
                    fileExtension = Path.GetExtension(OriginalDemoStudentPictures[pictureIndex]);
                } while (fileExtension != ".jpeg" && fileExtension != ".png" && fileExtension != ".jpg");
                // generate the name of the student from the name of the picture file
                string justFileName = Path.GetFileName(OriginalDemoStudentPictures[pictureIndex]);
                string fileWithNoExtension = justFileName.Substring(0, justFileName.LastIndexOf('.'));
                string[] wordsInFileName = (Path.GetFileName(fileWithNoExtension)).Split(' ');
                lastName = "";
                firstName = "";
                foreach (string word in wordsInFileName)
                {
                    // last name in picture filename must be upper case 
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

                s.LastName = lastName;
                s.FirstName = firstName;
                s.BirthDate = null;
                s.BirthPlace = null;
                s.ClassAbbreviation = "";
                s.Email = "";
                s.IdClass = 0;
                s.ArithmeticMean = 0;
                s.RegisterNumber = null;
                s.City = null;
                s.RevengeFactorCounter = 0;
                s.Origin = null;
                s.SchoolYear = null;
                s.Sum = 0;
                UpdateStudent(s, cmd);

                string outFolder = Path.Combine(Commons.PathImages, Class.SchoolYear + "_" + Class.Abbreviation + "\\");
                string filename = s.LastName + "_" + s.FirstName + "_" + Class.Abbreviation + Class.SchoolYear + fileExtension;
                if (!Directory.Exists(outFolder))
                {
                    Directory.CreateDirectory(outFolder);
                }
                if (File.Exists(outFolder + filename))
                {
                    File.Delete(outFolder + filename);
                }
                // save student pictures' paths in table StudentsPhotos
                string relativeOutPathAndFile = Path.Combine(Class.SchoolYear + "_" + Class.Abbreviation, filename);
                string absoluteOutPathAndFile = Path.Combine(Commons.PathImages, relativeOutPathAndFile);
                File.Copy(OriginalDemoStudentPictures[pictureIndex], absoluteOutPathAndFile);
                int? idImage = SaveDemoStudentPhotoPath(relativeOutPathAndFile, cmd);
                AddLinkPhotoToStudent(s.IdStudent, idImage, Class.SchoolYear, cmd);
            }
            List<Student> AllStudents = GetAllStudents(cmd);
            foreach (Student s in studentsOfClass)
            {
                //// if the demo student has already been created, we don't create it
                //// a demo student has a null in at least; BirthDate, BirthPlace, RegisterNumber, City
                //if (s.BirthDate == null && s.BirthPlace == null && s.RegisterNumber == null && s.City == null)
                //{
                //    break;
                //}
                string file = GetFilePhoto(s.IdStudent);
                // user is still not changed
                string fileExtension = "";
                do
                {
                    if (++pictureIndex >= OriginalDemoStudentPictures.Length)
                        pictureIndex = 0;
                    fileExtension = Path.GetExtension(OriginalDemoStudentPictures[pictureIndex]);
                } while (fileExtension != ".jpeg" && fileExtension != ".png" && fileExtension != ".jpg");
                // generate the name of the student from the name of the picture file
                string justFileName = Path.GetFileName(OriginalDemoStudentPictures[pictureIndex]);
                string fileWithNoExtension = justFileName.Substring(0, justFileName.LastIndexOf('.'));
                string[] wordsInFileName = (Path.GetFileName(fileWithNoExtension)).Split(' ');
                lastName = "";
                firstName = "";
                foreach (string word in wordsInFileName)
                {
                    // last name in picture filename must be upper case 
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

                s.LastName = lastName;
                s.FirstName = firstName;
                s.BirthDate = null;
                s.BirthPlace = null;
                s.ClassAbbreviation = "";
                s.Email = "";
                s.IdClass = 0;
                s.ArithmeticMean = 0;
                s.RegisterNumber = null;
                s.City = null;
                s.RevengeFactorCounter = 0;
                s.Origin = null;
                s.SchoolYear = null;
                s.Sum = 0;
                UpdateStudent(s, cmd);

                string outFolder = Path.Combine(Commons.PathImages, Class.SchoolYear + "_" + Class.Abbreviation + "\\");
                string filename = s.LastName + "_" + s.FirstName + "_" + Class.Abbreviation + Class.SchoolYear + fileExtension;
                if (!Directory.Exists(outFolder))
                {
                    Directory.CreateDirectory(outFolder);
                }
                if (File.Exists(outFolder + filename))
                {
                    File.Delete(outFolder + filename);
                }
                // save student pictures' paths in table StudentsPhotos
                string relativeOutPathAndFile = Path.Combine(Class.SchoolYear + "_" + Class.Abbreviation, filename);
                string absoluteOutPathAndFile = Path.Combine(Commons.PathImages, relativeOutPathAndFile);
                File.Copy(OriginalDemoStudentPictures[pictureIndex], absoluteOutPathAndFile);
                int? idImage = SaveDemoStudentPhotoPath(relativeOutPathAndFile, cmd);
                AddLinkPhotoToStudent(s.IdStudent, idImage, Class.SchoolYear, cmd);
            }
            // copy all the lessons images files
            string query = "SELECT Images.imagePath, Classes.pathRestrictedApplication" +
            " FROM Images" +
                " JOIN Lessons_Images ON Lessons_Images.idImage=Images.idImage" +
                " JOIN Lessons ON Lessons_Images.idLesson=Lessons.idLesson" +
                " JOIN Classes ON Classes.idClass=Lessons.idClass" +
                " WHERE Lessons.idClass=" + Class.IdClass +
                ";";
            cmd.CommandText = query;
            DbDataReader dReader = cmd.ExecuteReader();
            while (dReader.Read())
            {
                string finalPart = (string)dReader["imagePath"];
                string originalPathAndFile = Path.Combine(Commons.PathImages, finalPart);
                string partToBeReplaced = finalPart.Substring(0, finalPart.IndexOf("\\"));
                string destinationPathAndFile = originalPathAndFile.Replace(partToBeReplaced, Class.SchoolYear + "_" + Class.Abbreviation);
                string destinationFolder = Path.GetDirectoryName(destinationPathAndFile);
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }
                if (!File.Exists(destinationPathAndFile) ||
                    File.GetLastWriteTime(destinationPathAndFile) < File.GetLastWriteTime(originalPathAndFile))
                    // destination file not existing or older
                    try
                    {
                        File.Copy(originalPathAndFile, destinationPathAndFile);
                    }
                    catch (Exception ex)
                    {
                        Console.Beep();
                    }
            }
            dReader.Close();
        }
        internal override void RenameAllStudentsNamesAndManagePictures(DbCommand cmd)
        {
            // get the "previous" students from database 
            //List<Student> studentsOfClass = GetStudentsOfClass(Class, true, cmd);

            // rename the students' names according to the names found in the image files 
            string[] OriginalDemoStudentPictures = Directory.GetFiles(Path.Combine(Commons.PathImages, "DemoPictures\\"));
            // start assigning the names from a random image
            Random rnd = new Random();
            int pictureIndex = (int)(rnd.NextDouble() * OriginalDemoStudentPictures.Length);

            string lastName;
            string firstName;

            // get all the students from database 
            List<Student> AllStudents = GetAllStudents(cmd);
            foreach (Student s in AllStudents)
            {
                //// if the demo student has already been created, we don't create it
                //// a demo student has a null in at least; BirthDate, BirthPlace, RegisterNumber, City
                //if (s.BirthDate == null && s.BirthPlace == null && s.RegisterNumber == null && s.City == null)
                //{
                //    break;
                //}
                string file = GetFilePhoto(s.IdStudent);
                // user is still not changed
                string fileExtension = "";
                do
                {
                    if (++pictureIndex >= OriginalDemoStudentPictures.Length)
                        pictureIndex = 0;
                    fileExtension = Path.GetExtension(OriginalDemoStudentPictures[pictureIndex]);
                } while (fileExtension != ".jpeg" && fileExtension != ".png" && fileExtension != ".jpg");
                // generate the name of the student from the name of the picture file
                string justFileName = Path.GetFileName(OriginalDemoStudentPictures[pictureIndex]);
                string fileWithNoExtension = justFileName.Substring(0, justFileName.LastIndexOf('.'));
                string[] wordsInFileName = (Path.GetFileName(fileWithNoExtension)).Split(' ');
                lastName = "";
                firstName = "";
                foreach (string word in wordsInFileName)
                {
                    // last name in picture filename must be upper case 
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

                s.LastName = lastName;
                s.FirstName = firstName;
                s.BirthDate = null;
                s.BirthPlace = null;
                s.ClassAbbreviation = "";
                s.Email = "";
                s.IdClass = 0;
                s.ArithmeticMean = 0;
                s.RegisterNumber = null;
                s.City = null;
                s.RevengeFactorCounter = 0;
                s.Origin = null;
                s.SchoolYear = null;
                s.Sum = 0;
                UpdateStudent(s, cmd);

                // get first class of student
                Class Class = GetAllClassesOfStudent(s)[0];

                string outFolder = Path.Combine(Commons.PathImages, Class.SchoolYear + "_" + Class.Abbreviation + "\\");
                string filename = s.LastName + "_" + s.FirstName + "_" + Class.Abbreviation + Class.SchoolYear + fileExtension;
                if (!Directory.Exists(outFolder))
                {
                    Directory.CreateDirectory(outFolder);
                }
                if (File.Exists(outFolder + filename))
                {
                    File.Delete(outFolder + filename);
                }
                // save student pictures' paths in table StudentsPhotos
                string relativeOutPathAndFile = Path.Combine(Class.SchoolYear + "_" + Class.Abbreviation, filename);
                string absoluteOutPathAndFile = Path.Combine(Commons.PathImages, relativeOutPathAndFile);
                File.Copy(OriginalDemoStudentPictures[pictureIndex], absoluteOutPathAndFile);
                int? idImage = SaveDemoStudentPhotoPath(relativeOutPathAndFile, cmd);
                AddLinkPhotoToStudent(s.IdStudent, idImage,  Class.SchoolYear, cmd);
            }
        }
        internal override void AddLinkPhotoToStudent(int? idStudent, int? idStudentsPhoto,
            string schoolYear, DbCommand cmd)
        {
            cmd.CommandText = "";
            cmd.CommandText = "INSERT INTO StudentsPhotos_Students" +
            " (idStudentsPhoto, idStudent, idSchoolYear)" +
                "Values(" + SqlInt(idStudentsPhoto) + "," + SqlInt(idStudent) + "," + SqlString(schoolYear) + ")" +
            ";";
            cmd.ExecuteNonQuery();
        }
        internal override bool isDuplicate(string lastName, string firstName, List<Student> StudentsInClass)
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
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
