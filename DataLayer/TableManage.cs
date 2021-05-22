using System;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using gamon;
using System.Windows.Forms;
using SchoolGrades.DbClasses;

namespace SchoolGrades.DataLayer
{
    //Andrea Siboni, Francesco Citarella, Cesare Colella, Riccardo Brunelli 4°L
    class TableManage
    {
        DataLayer dl = new DataLayer();


        internal void SaveTableOnCvs(DataTable Table, string FileName)
        {
            string fileContent = "";
            foreach (DataColumn col in Table.Columns)
            {
                fileContent += col.Caption + '\t';
            }
            fileContent += "\r\n";
            foreach (DataRow row in Table.Rows)
            {
                foreach (DataColumn col in Table.Columns)
                {
                    fileContent += row[col].ToString() + '\t';
                }
                fileContent += "\r\n";
            }
            TextFile.StringToFile(FileName, fileContent, false);
        }


        public int nFieldDbDataReader(string NomeCampo, DbDataReader dr)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i) == NomeCampo)
                {
                    return i;
                }
            }
            return -1;
        }

        internal void CompactDatabase()
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // compact the database 
                cmd.CommandText = "VACUUM;";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            //Application.Exit();
        }

        






        internal void GetLookupTable(string Table, ref DataSet DSet, ref DataAdapter DAdapt)
        {
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT * FROM " + Table + ";";
                DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DSet = new DataSet("OpenLookupTable");

                DAdapt.Fill(DSet);
                DAdapt.Dispose();
                DSet.Dispose();
            }
        }

        internal void CreateLookupTableRow(string Table, string IdTable, DataRow Row)
        {
            // !!!! TODO !!!! GENERALIZZARE A TABELLE CON NOMI DEI CAMPI ARBITRARI E FAR FUNZIONARE !!!!
            string query;
            try
            {
                // if key field is Integer, this works
                int iId = (int)Row[0];
                query = "INSERT INTO " + Table +
                    " (" + IdTable + ", name, desc)" +
                    " VALUES (" + iId + ",'" + Row["name"] + "','" + Row["desc"] + "'" +
                ");";
            }
            catch
            {
                // if key field wasn't Integer, this other will work 
                string sId = (string)Row[0];
                query = "INSERT INTO " + Table +
                    " (" + IdTable + ", name, desc)" +
                    " VALUES ('" + sId + "','" + Row["name"] + "','" + Row["desc"] + "'" +
                ");";
            }
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
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
            DataLayer newDatabaseDl = new DataLayer(newDatabaseFullName);

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

        private void RandomizeGrades(DbConnection conn)
        {
            DbDataReader dRead;
            DbCommand cmd = conn.CreateCommand();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Grades" +
                ";";
            dRead = cmd.ExecuteReader();
            Random rnd = new Random();
            while (dRead.Read())
            {
                double? grade = SafeDb.SafeDouble(dRead["value"]);
                int? id = SafeDb.SafeInt(dRead["IdGrade"]);
                // add to the grade a random delta between -10 and +10 
                if (grade > 0)
                {
                    grade = grade + rnd.NextDouble() * 20 - 10;
                    if (grade < 10) grade = 10;
                    if (grade > 100) grade = 100;
                }
                else
                    grade = 0;
                SaveGradeValue(id, grade, conn);
            }
            cmd.Dispose();
        }

        private void SaveGradeValue(int? id, double? grade, DbConnection conn)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Grades" +
            " SET value=" + SqlVal.SqlDouble(grade) +
            " WHERE idGrade=" + id +
            ";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
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
            DataLayer newDatabaseDl = new DataLayer(newDatabaseFullName);

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


        private void ChangeImagesPath(Class Class, DbConnection conn)
        {
            DbDataReader dRead;
            DbCommand cmd = conn.CreateCommand();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Images.idImage, Images.imagePath" +
                " FROM Images" +
                " JOIN Lessons_Images ON Images.idImage=Lessons_Images.idImage" +
                " JOIN Lessons ON Lessons.idLesson = Lessons_Images.idLesson" +
                " WHERE Lessons.idClass=" + Class.IdClass +
            ";";
            dRead = cmd.ExecuteReader();
            string newFolder = Class.SchoolYear + Class.Abbreviation;
            while (dRead.Read())
            {
                string path = SafeDb.SafeString(dRead["imagePath"]);
                int? id = SafeDb.SafeInt(dRead["idImage"]);
                string partToReplace = path.Substring(0, path.IndexOf("\\"));
                path = path.Replace(partToReplace, newFolder);
                SaveImagePath(id, path, conn);
            }
            cmd.Dispose();
        }

        private void SaveImagePath(int? id, string path, DbConnection conn)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Images" +
            " SET imagePath='" + SqlVal.SqlString(path) + "'" +
            " WHERE idImage=" + id +
            ";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        private void RenameStudentsNamesFromPictures(Class Class, DbConnection conn)
        {
            // get the "previous" students from database 
            List<Student> StudentsInClass = GetStudentsOfClass(Class.IdClass, conn);

            // rename the students' names according to the names found in the image files 
            string[] OriginalDemoPictures = Directory.GetFiles(Commons.PathImages + "\\DemoPictures\\");
            // start assigning the names from a random image
            Random rnd = new Random();
            int pictureIndex = rnd.Next(0, OriginalDemoPictures.Length - 1);
            foreach (Student s in StudentsInClass)
            {
                string justFileName = Path.GetFileName(OriginalDemoPictures[pictureIndex]);
                string fileWithNoExtension = justFileName.Substring(0, justFileName.LastIndexOf('.'));
                string[] wordsInFileName = (Path.GetFileName(fileWithNoExtension)).Split(' ');
                string lastName = "";
                string firstName = "";
                foreach (string word in wordsInFileName)
                {
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
                s.Class = "";
                s.Email = "";
                s.IdClass = 0;
                s.ArithmeticMean = 0;
                s.RegisterNumber = null;
                s.Residence = null;
                s.RevengeFactorCounter = 0;
                s.Origin = null;
                s.SchoolYear = null;
                s.Sum = 0;
                SaveStudent(s, conn);

                // save the image with standard name in the folder of the demo class
                string fileExtension = Path.GetExtension(OriginalDemoPictures[pictureIndex]);
                string folder = Commons.PathImages + "\\" + Class.SchoolYear + Class.Abbreviation + "\\";
                string filename = s.LastName + "_" + s.FirstName + "_" + Class.Abbreviation + Class.SchoolYear + fileExtension;
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                if (File.Exists(folder + filename))
                {
                    File.Delete(folder + filename);
                }
                File.Copy(OriginalDemoPictures[pictureIndex], folder + filename);

                // change student pictures' paths in table StudentsPhotos
                string relativePathAndFile = Class.SchoolYear + Class.Abbreviation + "\\" + filename;
                int? idImage = GetStudentsPhotoId(s.IdStudent, Class.SchoolYear, conn);
                SaveStudentsPhotosPath(idImage, relativePathAndFile, conn);

                // copy all the lessons images files that aren't already there or that have a newer date 
                string query = "SELECT Images.imagePath, Classes.pathRestrictedApplication" +
                " FROM Images" +
                    " JOIN Lessons_Images ON Lessons_Images.idImage=Images.idImage" +
                    " JOIN Lessons ON Lessons_Images.idLesson=Lessons.idLesson" +
                    " JOIN Classes ON Classes.idClass=Lessons.idClass" +
                    " WHERE Lessons.idClass=" + Class.IdClass +
                    ";";
                DbCommand cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dReader = cmd.ExecuteReader();
                while (dReader.Read())
                {
                    //string destinationFile = (string)dReader["pathRestrictedApplication"] +
                    //    "\\SchoolGrades\\" + "Images" + "\\" + (string)dReader["imagePath"];
                    string filePart = (string)dReader["imagePath"];
                    string partToReplace = filePart.Substring(0, filePart.IndexOf("\\"));
                    filePart = filePart.Replace(partToReplace, Class.SchoolYear + Class.Abbreviation);
                    string destinationFile = (string)Commons.PathImages + "\\" + filePart;

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


        internal List<Student> GetStudentsOfClass(int? IdClass, DbConnection conn)
        {
            List<Student> l = new List<Student>();
            bool leaveConnectionOpen = true;

            if (conn == null)
            {
                conn = dl.Connect();
                leaveConnectionOpen = false;
            }
            DbDataReader dRead;
            DbCommand cmd = conn.CreateCommand();
            string query = "SELECT Students.*" +
                " FROM Students" +
                " JOIN Classes_Students ON Classes_Students.idStudent=Students.idStudent" +
                " WHERE Classes_Students.idClass=" + IdClass +
            ";";
            cmd.CommandText = query;
            dRead = cmd.ExecuteReader();

            while (dRead.Read())
            {
                Student s = GetStudentFromRow(dRead);
                l.Add(s);
            }
            if (!leaveConnectionOpen)
            {
                conn.Close();
                conn.Dispose();
            }
            return l;
        }

        private Nullable<int> GetStudentsPhotoId(int? idStudent, string schoolYear, DbConnection conn)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idStudentsPhoto FROM StudentsPhotos_Students " +
                "WHERE idStudent=" + idStudent + " AND idSchoolYear=" + schoolYear + "" +
                ";";
            return (int?)cmd.ExecuteScalar();
        }



        private void SaveStudentsPhotosPath(int? id, string path, DbConnection conn)
        {
            if (id != null)
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE StudentsPhotos" +
                " SET photoPath='" + SqlVal.SqlString(path) + "'" +
                " WHERE idStudentsPhoto=" + id +
                ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        private Student GetStudentFromRow(DbDataReader Row)
        {
            Student s = new Student();
            s.IdStudent = (int)Row["IdStudent"];
            s.LastName = SafeDb.SafeString(Row["LastName"]);
            s.FirstName = SafeDb.SafeString(Row["FirstName"]);
            s.Residence = SafeDb.SafeString(Row["Residence"]);
            s.Origin = SafeDb.SafeString(Row["Origin"]);
            s.Email = SafeDb.SafeString(Row["Email"]);
            if (!(Row["birthDate"] is DBNull))
                s.BirthDate = SafeDb.SafeDateTime(Row["birthDate"]);
            s.BirthPlace = SafeDb.SafeString(Row["birthPlace"]);
            s.Eligible = SafeDb.SafeBool(Row["drawable"]);
            s.Disabled = SafeDb.SafeBool(Row["disabled"]);
            s.RevengeFactorCounter = SafeDb.SafeInt(Row["VFCounter"]);

            return s;
        }


        internal int? SaveStudent(Student Student, DbConnection conn)
        {
            bool leaveConnectionOpen = true;
            if (conn == null)
            {
                conn = dl.Connect();
                leaveConnectionOpen = false;
            }
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Students " +
                "SET" +
                " idStudent=" + Student.IdStudent +
                ",lastName='" + SqlVal.SqlString(Student.LastName) + "'" +
                ",firstName='" + SqlVal.SqlString(Student.FirstName) + "'" +
                ",residence='" + SqlVal.SqlString(Student.Residence) + "'" +
                ",birthDate=" + SqlVal.SqlDate(Student.BirthDate.ToString()) + "" +
                ",email='" + SqlVal.SqlString(Student.Email) + "'" +
                //",schoolyear='" + SqlVal.SqlString(Student.SchoolYear) + "'" +
                ",drawable='" + SqlVal.SqlBool(Student.Eligible) + "'" +
                ",origin='" + SqlVal.SqlString(Student.Origin) + "'" +
                ",birthPlace='" + SqlVal.SqlString(Student.BirthPlace) + "'" +
                ",drawable=" + SqlVal.SqlBool(Student.Eligible) + "" +
                ",disabled=" + SqlVal.SqlBool(Student.Disabled) + "" +
                ",VFCounter=" + Student.RevengeFactorCounter + "" +
                " WHERE idStudent = " + Student.IdStudent +
                ";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (!leaveConnectionOpen)
            {
                conn.Close();
                conn.Dispose();
            }
            return Student.IdStudent;
        }






    }
}
