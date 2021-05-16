using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.DataLayer
{
    class DataBase
    {
        DataLayer dl = new DataLayer();

        internal string CreateOneClassOnlyDatabase(Class Class)
        {
            string newDatabasePathName = Class.PathRestrictedApplication + "\\SchoolGrades\\Data\\";
            if (!Directory.Exists(newDatabasePathName))
                Directory.CreateDirectory(newDatabasePathName);

            string newDatabaseFullName = newDatabasePathName +
                System.DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss") +
                "_" + Class.Abbreviation + "_" + Class.SchoolYear + "_" +
                Commons.FileDatabase;
            File.Copy(Commons.PathAndFileDatabase, newDatabaseFullName);

            // open a local connection to database 
            DataLayer.DataLayer newDatabaseDl = new DataLayer.DataLayer(newDatabaseFullName);

            // erase all the data of the students of other classes
            using (DbConnection conn = newDatabaseDl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();

                // erase all the other classes
                cmd.CommandText = "DELETE FROM Classes" +
                " WHERE idClass<>" + Class.IdClass + ";";
                cmd.ExecuteNonQuery();

                // erase all the lessons of other classes
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Lessons" +
                    " WHERE idClass<>" + Class.IdClass + ";";
                cmd.ExecuteNonQuery();

                // erase all the students of other classes from the link table
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Classes_Students" +
                 " WHERE idClass<>" + Class.IdClass + ";";
                cmd.ExecuteNonQuery();

                // erase all the students of other classes 
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Students" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT idStudent FROM Classes_Students);";
                cmd.ExecuteNonQuery();

                // erase all the StartLinks of other classes
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Classes_StartLinks" +
                    " WHERE idClass<>" + Class.IdClass + ";";
                cmd.ExecuteNonQuery();

                // erase all the grades of other classes' students
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Grades" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT idStudent FROM Classes_Students);";
                cmd.ExecuteNonQuery();

                // erase all the links to photos of other classes' students
                // !! retains previous year's photos of this classes students !!
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsPhotos_Students" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT idStudent FROM Classes_Students);";
                cmd.ExecuteNonQuery();

                // erase all the annotations of other classes
                cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT idStudent FROM Classes_Students)" +
                    ";";
                cmd.ExecuteNonQuery();

                // erase all the photos of other classes' students
                // !! retains previous year's photos of this classes students !!
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsPhotos" +
                    " WHERE idStudentsPhoto NOT IN" +
                    " (SELECT idStudentsPhoto FROM StudentsPhotos_Students);";
                cmd.ExecuteNonQuery();

                // erase all the questions of the students of the other classes
                // !! StudentsQuestions currently not used !!
                cmd.CommandText = "DELETE FROM StudentsQuestions" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT idStudent FROM Classes_Students);";
                cmd.ExecuteNonQuery();

                // erase all the answers  of the students of the other classes
                // !! StudentsAnswers currently not used !!
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsAnswers" +
                " WHERE idStudent NOT IN" +
                " (SELECT idStudent FROM Classes_Students);";
                cmd.ExecuteNonQuery();

                // erase all the tests of students of the other classes
                // !! StudentsTests currently not used !!
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsTests" +
                " WHERE idStudent NOT IN" +
                " (SELECT idStudent FROM Classes_Students);";
                cmd.ExecuteNonQuery();

                // erase all the images of other classes' lessons
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Lessons_Images" +
                    " WHERE idLesson NOT IN" +
                    " (SELECT idLesson from Lessons);";
                cmd.ExecuteNonQuery();

                // erase all the topics of other classes' lessons
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Lessons_Topics" +
                    " WHERE idLesson NOT IN" +
                    " (SELECT idLesson from Lessons);";
                cmd.ExecuteNonQuery();

                // erase all the users
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Users" +
                    ";";
                cmd.ExecuteNonQuery();

                // copy all the students' photo files that aren't already there or that have a newer date 
                string query = "SELECT StudentsPhotos.photoPath" +
                " FROM StudentsPhotos" +
                " JOIN StudentsPhotos_Students ON StudentsPhotos_Students.idStudentsPhoto = StudentsPhotos.idStudentsPhoto" +
                " JOIN Classes_Students ON StudentsPhotos_Students.idStudent = Classes_Students.idStudent" +
                " WHERE Classes_Students.idClass = " + Class.IdClass + "; ";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dReader = cmd.ExecuteReader();
                while (dReader.Read())
                {
                    string destinationFile = Class.PathRestrictedApplication + "\\SchoolGrades\\Images\\" + (string)dReader["photoPath"];
                    if (!Directory.Exists(Path.GetDirectoryName(destinationFile)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationFile));
                    }
                    if (!File.Exists(destinationFile) ||
                        File.GetLastWriteTime(destinationFile)
                        < File.GetLastWriteTime(Commons.PathImages + "\\" + (string)dReader["photoPath"]))
                        try
                        {
                            // destination file not existing or older
                            File.Copy(Commons.PathImages + "\\" + (string)dReader["photoPath"],
                                destinationFile);
                        }
                        catch { }
                }
                // copy all the picture's files that aren't already there or that have a newer date 
                query = "SELECT Images.imagePath, Classes.pathRestrictedApplication" +
                    " FROM Images" +
                    " JOIN Lessons_Images ON Lessons_Images.idImage=Images.idImage" +
                    " JOIN Lessons ON Lessons_Images.idLesson=Lessons.idLesson" +
                    " JOIN Classes ON Classes.idClass=Lessons.idClass" +
                    " WHERE Lessons.idClass=" + Class.IdClass +
                    ";";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dReader = cmd.ExecuteReader();
                while (dReader.Read())
                {
                    if (dReader["pathRestrictedApplication"] is DBNull)
                    {
                        Console.Beep();
                        break;
                    }
                    if (dReader["imagePath"] is DBNull)
                    {
                        Console.Beep();
                        break;
                    }
                    string destinationFile = (string)dReader["pathRestrictedApplication"] +
                        "\\SchoolGrades\\" + "Images" + "\\" + (string)dReader["imagePath"];
                    if (!Directory.Exists(Path.GetDirectoryName(destinationFile)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationFile));
                    }
                    if (!File.Exists(destinationFile) ||
                        File.GetLastWriteTime(destinationFile)
                        < File.GetLastWriteTime(Commons.PathImages + "\\" + (string)dReader["imagePath"]))
                        // destination file not existing or older
                        try
                        {
                            File.Copy(Commons.PathImages + "\\" + (string)dReader["imagePath"],
                                destinationFile);
                        }
                        catch { }
                }
                dReader.Dispose();
                // compact the database 
                cmd.CommandText = "VACUUM;";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            // ???? Students_GradeTypes serve ???? se non serve, eliminare
            // ???? StudentsTestsStudentsTests serve ???? se non serve, eliminare
            return Class.PathRestrictedApplication;
        }
        internal string CreateDemoDatabase(Class Class1, Class Class2)
        {
            DbCommand cmd;

            string newDatabasePathName = Commons.PathDatabase;
            if (!Directory.Exists(newDatabasePathName))
                Directory.CreateDirectory(newDatabasePathName);

            string newDatabaseFullName = newDatabasePathName +
                "\\Demo_SchoolGrades_" + Class1.SchoolYear + "_" + DateTime.Now.Date.ToString("yy-MM-dd") + ".sqlite";

            if (File.Exists(newDatabaseFullName))
            {
                if (System.Windows.Forms.MessageBox.Show("Il file " + newDatabaseFullName + " esiste già." +
                    "\nDevo re-inizializzarlo (Sì) o non creare il database (No)?", "",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(newDatabaseFullName);

                }
                else
                    return "";
            }
            File.Copy(Commons.PathAndFileDatabase, newDatabaseFullName);

            // local instance of a DataLayer to operate on a second database 
            DataLayer.DataLayer newDatabaseDl = new DataLayer.DataLayer(newDatabaseFullName);

            // erase all the data of the students of other classes
            using (DbConnection conn = newDatabaseDl.Connect()) // connect to the new database, just copied
            {
                cmd = conn.CreateCommand();

                // erase all the other classes
                cmd.CommandText = "DELETE FROM Classes" +
                " WHERE idClass<>" + Class1.IdClass +
                " AND idClass<>" + Class2.IdClass + ";";
                cmd.ExecuteNonQuery();

                // erase all the lessons of other classes
                cmd.CommandText = "DELETE FROM Lessons" +
                    " WHERE idClass<>" + Class1.IdClass +
                    " AND idClass<>" + Class2.IdClass + ";";
                cmd.ExecuteNonQuery();

                // erase all the students of other classes from the link table
                cmd.CommandText = "DELETE FROM Classes_Students" +
                 " WHERE idClass<>" + Class1.IdClass +
                 " AND idClass<>" + Class2.IdClass + ";";
                cmd.ExecuteNonQuery();

                // erase all the students of other classes 
                cmd.CommandText = "DELETE FROM Students" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT idStudent FROM Classes_Students" +
                    " WHERE idClass<>" + Class1.IdClass +
                    " OR idClass<>" + Class2.IdClass +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the annotation, of all classes
                cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                    ";";
                cmd.ExecuteNonQuery();

                // erase all the StartLinks of other classes
                cmd.CommandText = "DELETE FROM Classes_StartLinks" +
                    " WHERE idClass<>" + Class1.IdClass +
                    " AND idClass<>" + Class2.IdClass +
                    ";";
                cmd.ExecuteNonQuery();

                // erase all the grades of other classes' students
                cmd.CommandText = "DELETE FROM Grades" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT idStudent FROM Classes_Students" +
                    " WHERE idClass<>" + Class1.IdClass +
                    " OR idClass<>" + Class2.IdClass +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the links to photos of other classes' students
                cmd.CommandText = "DELETE FROM StudentsPhotos_Students" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT idStudent FROM Classes_Students" +
                    " WHERE idClass<>" + Class1.IdClass +
                    " OR idClass<>" + Class2.IdClass +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the photos of other classes' students
                cmd.CommandText = "DELETE FROM StudentsPhotos WHERE StudentsPhotos.idStudentsPhoto NOT IN" +
                    "(SELECT StudentsPhotos_Students.idStudentsPhoto" +
                    " FROM StudentsPhotos, StudentsPhotos_Students, Classes_Students" +
                    " WHERE StudentsPhotos_Students.idStudent = Classes_Students.idStudent" +
                    " AND StudentsPhotos.idStudentsPhoto = StudentsPhotos_Students.idStudentsPhoto" +
                    " AND (Classes_Students.idClass=" + Class1.IdClass +
                    " OR Classes_Students.idClass=" + Class2.IdClass + ")" +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the images of other classes
                cmd.CommandText = "DELETE FROM Images WHERE Images.idImage NOT IN" +
                    "(SELECT DISTINCT Lessons_Images.idImage" +
                    " FROM Images, Lessons_Images, Lessons" +
                    " WHERE Lessons_Images.idImage = Images.idImage" +
                    " AND Lessons_Images.idLesson = Lessons.idLesson" +
                    " AND (Lessons.idClass=" + Class1.IdClass +
                    " OR Lessons.idClass=" + Class2.IdClass + ")" +
                    ");";
                cmd.ExecuteNonQuery();

                //erase all links to the images of other classes
                cmd.CommandText = "DELETE FROM Lessons_Images WHERE Lessons_Images.idImage NOT IN" +
                    "(SELECT DISTINCT Lessons_Images.idImage" +
                    " FROM Images, Lessons_Images, Lessons" +
                    " WHERE Lessons_Images.idImage = Images.idImage" +
                    " AND Lessons_Images.idLesson = Lessons.idLesson" +
                    " AND (Lessons.idClass=" + Class1.IdClass +
                    " OR Lessons.idClass=" + Class2.IdClass + ")" +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the questions of the students of the other classes
                // !! StudentsQuestions currently not used !!
                cmd.CommandText = "DELETE FROM StudentsQuestions" +
                    " WHERE idStudent NOT IN" +
                    " (SELECT DISTINCT idStudent FROM Classes_Students" +
                    " WHERE idClass=" + Class1.IdClass +
                    " OR idClass=" + Class2.IdClass +
                    ");";
                cmd.ExecuteNonQuery();

                // erase all the answers  of the students of the other classes
                // !! StudentsAnswers currently not used !!
                cmd.CommandText = "DELETE FROM StudentsAnswers" +
                " WHERE idStudent NOT IN" +
                " (SELECT idStudent FROM Classes_Students" +
                    " WHERE idClass=" + Class1.IdClass +
                    " OR idClass=" + Class2.IdClass + ");";
                cmd.ExecuteNonQuery();

                // erase all the tests of students of the other classes
                // !! StudentsTests currently not used !!
                cmd.CommandText = "DELETE FROM StudentsTests" +
                " WHERE idStudent NOT IN" +
                " (SELECT idStudent FROM Classes_Students" +
                " WHERE idClass=" + Class1.IdClass +
                    " OR idClass=" + Class2.IdClass +
                ");";
                cmd.ExecuteNonQuery();

                // erase all the topics of other classes' lessons
                cmd.CommandText = "DELETE FROM Lessons_Topics" +
                    " WHERE idLesson NOT IN" +
                    " (SELECT idLesson from Lessons" +
                    " WHERE idClass=" + Class1.IdClass +
                    " OR idClass=" + Class2.IdClass +
                    ");";
                cmd.ExecuteNonQuery();

                // change the data of the classes
                Class1.Abbreviation = "DEMO1";
                Class1.Description = "SchoolGrades demo class 1";
                // Class1.IdSchool = ""; // left the existing code 
                Class1.PathRestrictedApplication = Commons.PathExe + "\\demo1";
                // Class1.SchoolYear = // !!!! shift the data to the destination school year, to be done when year's shifting will be managed!!!!
                Class1.IdSchool = Commons.IdSchool;
                Class1.UriWebApp = ""; // ???? decide what to put here ????

                // SaveClass Class1;
                string query = "UPDATE Classes" +
                    " SET" +
                    " idClass=" + Class1.IdClass + "" +
                    ",idSchoolYear='" + SqlVal.SqlString(Class1.SchoolYear) + "'" +
                    ",idSchool='" + SqlVal.SqlString(Class1.IdSchool) + "'" +
                    ",abbreviation='" + SqlVal.SqlString(Class1.Abbreviation) + "'" +
                    ",desc='" + SqlVal.SqlString(Class1.Description) + "'" +
                    ",uriWebApp='" + Class1.UriWebApp + "'" +
                    ",pathRestrictedApplication='" + SqlVal.SqlString(Class1.PathRestrictedApplication) + "'" +
                    " WHERE idClass=" + Class1.IdClass +
                    ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                Class2.Abbreviation = "DEMO2";
                Class2.Description = "SchoolGrades demo class 2";
                Class2.PathRestrictedApplication = Commons.PathExe + "\\demo2";
                // Class2.SchoolYear = !!!! shift the data to the destination school year !!!!
                Class2.IdSchool = Commons.IdSchool;
                Class2.UriWebApp = ""; // ???? decide what to put here ????
                // SaveClass Class2;
                query = "UPDATE Classes" +
                    " SET" +
                    " idClass=" + Class2.IdClass + "" +
                    ",idSchoolYear='" + SqlVal.SqlString(Class2.SchoolYear) + "'" +
                    ",idSchool='" + SqlVal.SqlString(Class2.IdSchool) + "'" +
                    ",abbreviation='" + SqlVal.SqlString(Class2.Abbreviation) + "'" +
                    ",desc='" + SqlVal.SqlString(Class2.Description) + "'" +
                    ",uriWebApp='" + Class2.UriWebApp + "'" +
                    ",pathRestrictedApplication='" + SqlVal.SqlString(Class2.PathRestrictedApplication) + "'" +
                    " WHERE idClass=" + Class2.IdClass +
                    ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                // erase all the users
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Users" +
                    ";";
                cmd.ExecuteNonQuery();

                // rename every student left in the database according to the names found in the pictures' filenames
                RenameStudentsNamesFromPictures(Class1, conn);
                RenameStudentsNamesFromPictures(Class2, conn);

                // change the paths of the images 
                ChangeImagesPath(Class1, conn);
                ChangeImagesPath(Class2, conn);

                // randomly change all grades 
                RandomizeGrades(conn);

                // change the lesson dates to this school year (when we implement year shift!) 
                // !!!! TODO !!!!

                // change the school year in StudentsPhotos_Students (when we implement year shift!) 
                // !!!! TODO !!!!

                // compact the database 
                cmd.CommandText = "VACUUM;";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return newDatabaseFullName;
        }
        internal string NewDatabase()
        {
            DbCommand cmd;

            string newDatabasePathName = Commons.PathDatabase;
            if (!Directory.Exists(newDatabasePathName))
                Directory.CreateDirectory(newDatabasePathName);

            string newDatabaseFullName = newDatabasePathName +
                "\\SchoolGradesNew.sqlite";

            if (File.Exists(newDatabaseFullName))
            {
                if (System.Windows.Forms.MessageBox.Show("Il file " + newDatabaseFullName + " esiste già." +
                    "\nDevo re-inizializzarlo (Sì) o non creare il database (No)?", "",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(newDatabaseFullName);
                }
                else
                    return "";
            }
            File.Copy(Commons.PathAndFileDatabase, newDatabaseFullName);

            // local instance of a DataLayer to operate on a second database 
            DataLayer.DataLayer newDatabaseDl = new DataLayer.DataLayer(newDatabaseFullName);

            // erase all the data on all the tables
            using (DbConnection conn = newDatabaseDl.Connect()) // connect to the new database, just copied
            {
                cmd = conn.CreateCommand();

                // erase all the answers to questions
                cmd.CommandText = "DELETE FROM Answers;" +
                "DELETE FROM Students;" +
                "DELETE FROM SchoolYears;" +
                "DELETE FROM Schools;" +
                "DELETE FROM Classes;" +
                "DELETE FROM QuestionTypes;" +
                "DELETE FROM Topics;" +
                "DELETE FROM Subjects;" +
                "DELETE FROM SchoolSubjects;" +
                "DELETE FROM Images;" +
                "DELETE FROM Questions;" +
                "DELETE FROM Answers;" +
                "DELETE FROM TestTypes;" +
                "DELETE FROM Tests;" +
                "DELETE FROM Classes_Tests;" +
                "DELETE FROM Tags;" +
                "DELETE FROM Tests_Tags;" +
                "DELETE FROM Tests_Questions;" +
                "DELETE FROM Questions_Tags;" +
                "DELETE FROM Answers_Questions;" +
                "DELETE FROM Classes_SchoolSubjects;" +
                "DELETE FROM GradeCategories;" +
                "DELETE FROM GradeTypes;" +
                "DELETE FROM Grades;" +
                "DELETE FROM Students_GradeTypes;" +
                "DELETE FROM SchoolPeriodTypes;" +
                "DELETE FROM SchoolPeriods;" +
                "DELETE FROM StudentsAnswers;" +
                "DELETE FROM StudentsQuestions;" +
                "DELETE FROM StudentsTests;" +
                "DELETE FROM StudentsPhotos;" +
                "DELETE FROM StudentsTests_StudentsPhotos;" +
                "DELETE FROM StudentsPhotos_Students;" +
                "DELETE FROM Classes_Students;" +
                "DELETE FROM Lessons;" +
                "DELETE FROM Lessons_Topics;" +
                "DELETE FROM Lessons_Images;" +
                "DELETE FROM Classes_StartLinks;" +
                "DELETE FROM Flags;" +
                "DELETE FROM usersCategories;" +
                "DELETE FROM Users;";
                cmd.ExecuteNonQuery();

                // compact the database 
                cmd.CommandText = "VACUUM;";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return newDatabaseFullName;
        }
    }
}
