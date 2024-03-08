using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace SchoolGrades
{
    internal partial class SqLite_DataLayer : DataLayer
    {
        internal override void DeleteOneStudentFromClass(int? IdDeletingStudent, int? IdClass)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Classes_Students" +
                    " WHERE Classes_Students.idClass=" + IdClass +
                    " AND Classes_Students.idStudent=" + IdDeletingStudent.ToString() +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal override void EraseAllStudentsOfAClass(Class Class)
        {
            using (DbConnection conn = Connect())
            {
                // erase all the info in tables linked to student

                // erase all the grades of the students of the class 
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Grades WHERE idStudent IN" +
                    "(SELECT Students.idStudent FROM Students" +
                    " JOIN Classes_Students ON Students.idStudent = Classes_Students.idStudent" +
                    " WHERE Classes_Students.idClass=" + Class.IdClass + ");";
                cmd.ExecuteNonQuery();

                // erase all the questions of the students of the class
                cmd.CommandText = "DELETE FROM StudentsQuestions WHERE idStudent IN" +
                    "(SELECT Students.idStudent FROM Students" +
                    " JOIN Classes_Students ON Students.idStudent = Classes_Students.idStudent" +
                    " WHERE Classes_Students.idClass=" + Class.IdClass + ");";
                cmd.ExecuteNonQuery();

                // erase all the answers of students of the class
                cmd.CommandText = "DELETE FROM StudentsAnswers WHERE idStudent IN" +
                    "(SELECT Students.idStudent FROM Students" +
                    " JOIN Classes_Students ON Students.idStudent = Classes_Students.idStudent" +
                    " WHERE Classes_Students.idClass=" + Class.IdClass + ");";
                cmd.ExecuteNonQuery();

                // erase all the tests of students of the class
                cmd.CommandText = "DELETE FROM StudentsTests WHERE idStudent IN" +
                    "(SELECT Students.idStudent FROM Students" +
                    " JOIN Classes_Students ON Students.idStudent = Classes_Students.idStudent" +
                    " WHERE Classes_Students.idClass=" + Class.IdClass + ");";
                cmd.ExecuteNonQuery();

                // delete all the photos of students of the class 
                cmd.CommandText = "DELETE FROM StudentsPhotos WHERE StudentsPhotos.idStudentsPhoto IN" +
                    "(SELECT StudentsPhotos_Students.idStudentsPhoto" +
                    " FROM StudentsPhotos, StudentsPhotos_Students, Classes_Students" +
                    " WHERE StudentsPhotos_Students.idStudent = Classes_Students.idStudent" +
                    " AND StudentsPhotos.idStudentsPhoto = StudentsPhotos_Students.idStudentsPhoto" +
                    " AND Classes_Students.idClass=" + Class.IdClass + ");";
                cmd.ExecuteNonQuery();

                // delete all the references in link table to photos of students of the class 
                cmd.CommandText = "DELETE FROM StudentsPhotos_Students WHERE idStudent IN" +
                    "(SELECT StudentsPhotos_Students.idStudent" +
                    " FROM StudentsPhotos_Students, Classes_Students" +
                    " WHERE StudentsPhotos_Students.idStudent = Classes_Students.idStudent" +
                    " AND Classes_Students.idClass=" + Class.IdClass + ");";
                cmd.ExecuteNonQuery();

                // delete all the students in class
                // AFTER THIS idStudent OF DELETED IN NOT AVAILABLE ANY LONGER 
                cmd.CommandText = "DELETE FROM Students WHERE idStudent IN" +
                    "(SELECT Students.idStudent FROM Students" +
                    " JOIN Classes_Students ON Students.idStudent = Classes_Students.idStudent" +
                    " WHERE Classes_Students.idClass=" + Class.IdClass + ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal override void EraseClassFromClasses(Class Class)
        {
            //EraseAllStudentsOfAClass(Class); 
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // erase all the photos of the students of the class 
                cmd.CommandText = "DELETE FROM StudentsPhotos_Students" +
                    " WHERE IdStudent IN (" +
                    "SELECT IdStudent FROM Classes_Students WHERE IdClass=" + Class.IdClass + ")" +
                    " AND IdSchoolYear=" + Class.SchoolYear +
                    ";";
                cmd.ExecuteNonQuery();
                // delete all the references in link table between students and classes
                cmd.CommandText = "DELETE FROM Classes_Students" +
                    " WHERE Classes_Students.idClass=" + Class.IdClass +
                    ";";
                cmd.ExecuteNonQuery();
                // erase class from Classes_SchoolSubjects
                cmd.CommandText = "DELETE FROM Classes_SchoolSubjects" +
                    " WHERE Classes_SchoolSubjects.idClass=" + Class.IdClass +
                    ";";
                cmd.ExecuteNonQuery();
                // erase class from Classes_Tests
                cmd.CommandText = "DELETE FROM Classes_Tests" +
                    " WHERE Classes_Tests.idClass=" + Class.IdClass +
                    ";";
                cmd.ExecuteNonQuery();
                // erase class from table Classes 
                cmd.CommandText = "DELETE FROM Classes" +
                    " WHERE Classes.idClass=" + Class.IdClass +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal override string CreateOneClassOnlyDatabase(Class Class)
        {
            string newDatabasePathName = Path.Combine(Class.PathRestrictedApplication, @"SchoolGrades\Data");
            if (!Directory.Exists(newDatabasePathName))
                Directory.CreateDirectory(newDatabasePathName);

            string NewDatabasePathName = Path.Combine(newDatabasePathName,
                System.DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss") +
                "_" + Class.Abbreviation + "_" + Class.SchoolYear + "_" +
                Commons.DatabaseFileName_Teacher);
            File.Copy(Commons.PathAndFileDatabase, NewDatabasePathName);

            // open a local connection to database 
            DataLayer newDatabaseDl = Commons.SetDataLayer(NewDatabasePathName);

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

                // erase all the users (table currently not used) 
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Users" +
                    ";";
                cmd.ExecuteNonQuery();

                // null all Special Needs flags (privacy) 
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Students" +
                    " SET hasSpecialNeeds=null" +
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
                    string destinationFile = Path.Combine(Class.PathRestrictedApplication,
                        "SchoolGrades", "Images" + (string)dReader["photoPath"]);
                    if (!Directory.Exists(Path.GetDirectoryName(destinationFile)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationFile));
                    }
                    if (!File.Exists(destinationFile) ||
                        File.GetLastWriteTime(destinationFile)
                        < File.GetLastWriteTime(Path.Combine(Commons.PathImages, (string)dReader["photoPath"])))
                        try
                        {
                            // destination file not existing or older
                            File.Copy(Path.Combine(Path.Combine(Commons.PathImages, (string)dReader["photoPath"])), destinationFile);
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
                    string destinationFile = Path.Combine((string)dReader["pathRestrictedApplication"],
                        "SchoolGrades", "Images", (string)dReader["imagePath"]);
                    if (!Directory.Exists(Path.GetDirectoryName(destinationFile)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationFile));
                    }
                    if (!File.Exists(destinationFile) ||
                        File.GetLastWriteTime(destinationFile)
                        < File.GetLastWriteTime(Path.Combine(Commons.PathImages,
                        (string)dReader["imagePath"])))
                        // destination file not existing or older
                        try
                        {
                            File.Copy(Path.Combine(Commons.PathImages, (string)dReader["imagePath"]),
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
            return Class.PathRestrictedApplication;
        }
        internal override int CreateClass(string ClassAbbreviation, string ClassDescription, string SchoolYear,
            string IdSchool)
        {
            // find a key for the new class
            int idClass = NextKey("Classes", "idClass");
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // creation of the new class into the Classes table (just creation!) 
                cmd.CommandText = "INSERT INTO Classes " +
                    "(idClass, Desc, idSchoolYear, idSchool, abbreviation) " +
                    "Values (" + idClass + "," + SqlString(ClassDescription) + "," +
                    SqlString(SchoolYear) + "," + SqlString(IdSchool) + "," +
                    SqlString(ClassAbbreviation) +
                    ");";
                cmd.ExecuteNonQuery();

                int nextId = NextKey("Classes_StartLinks", "idStartLink");
                cmd = conn.CreateCommand();
                // create a link in StartLinks' link table
                cmd.CommandText = "INSERT INTO Classes_StartLinks " +
                    "(idStartLink,idClass,startLink,desc)" +
                    " Values (" + nextId +
                    "," + idClass + ",'http://www.ingmonti.it','Test link'" +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            // if it doesn't exist, create the folder of classes student's images
            if (!Directory.Exists(Path.Combine(Commons.PathImages, SchoolYear, ClassAbbreviation)))
            {
                Directory.CreateDirectory(Path.Combine(Commons.PathImages, SchoolYear, ClassAbbreviation));
            }
            return idClass;
        }
        internal override int CreateClassAndStudents(string[,] StudentsData, string ClassAbbreviation,
                    string ClassDescription, string SchoolYear, string OfficialSchoolAbbreviation,
                    bool LinkPhoto)
        {
            // creation of a new class in the Classes table

            // finds a key for the new class
            int idClass = NextKey("Classes", "idClass");
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Classes " +
                    "(idClass, Desc, idSchoolYear, idSchool, abbreviation) " +
                    "Values (" + idClass + "," + SqlString(ClassDescription) + "," +
                    SqlString(SchoolYear) + "," + SqlString(OfficialSchoolAbbreviation) + "," +
                    SqlString(ClassAbbreviation) + "" +
                    ");";
                cmd.ExecuteNonQuery();

                // find the key for next student
                int idNextStudent = NextKey("Students", "idStudent");
                // find the key for next picture 
                int idNextPhoto = NextKey("StudentsPhotos", "idStudentsPhoto");
                // add the student to the students' table 
                // start from the second row of the file, first row is descriptions of columns 
                for (int row = 1; row < StudentsData.GetLength(0); row++)
                {
                    int nColumns = StudentsData.GetLength(1);
                    int rigap1 = row + 1, dummy;
                    string query = "INSERT INTO Students " +
                        "(idStudent, lastName, firstName, birthDate, residence, origin, email, birthPlace) " +
                        "Values (" + idNextStudent;
                    // create new student
                    // last name in column 1 
                    query += "," + SqlString(StudentsData[row, 1])
                        + "," + SqlString(StudentsData[row, 2]);
                    // if we have a column 3, it is birth date 
                    if (nColumns > 3)
                        query += "," + SqlString(StudentsData[row, 3]);
                    else
                        query += ", ''";
                    if (nColumns > 4)
                        query += ", ''" + SqlString(StudentsData[row, 4]);
                    else
                        query += ", ''";
                    if (nColumns > 5)
                        query += ", ''" + SqlString(StudentsData[row, 5]);
                    else
                        query += ", ''";
                    if (nColumns > 6)
                        query += ", ''" + SqlString(StudentsData[row, 6]);
                    else
                        query += ", ''";
                    if (nColumns > 7)
                        query += ", ''" + SqlString(StudentsData[row, 7]);
                    else
                        query += ", ''";
                    query += ");";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    // add the new student to the class
                    cmd.CommandText = "INSERT INTO Classes_Students " +
                        "(idClass, idStudent, registerNumber) " +
                        "Values ('" + idClass + "','" + idNextStudent + "','" + rigap1.ToString() + "'" +
                        ");";
                    cmd.ExecuteNonQuery();

                    if (LinkPhoto)
                    {
                        string photoPath = Path.Combine(SchoolYear + ClassAbbreviation,
                            StudentsData[row, 1] + "_" + StudentsData[row, 2] + "_" +
                            ClassAbbreviation + SchoolYear + ".jpg");  // !! TODO here we should put the actual file extension!!
                        // aggiunge la foto alle foto
                        cmd.CommandText = "INSERT INTO StudentsPhotos " +
                            "(idStudentsPhoto, photoPath)" +
                            "Values " +
                            "(" + idNextPhoto + "," + SqlString(photoPath) +
                            ");"; // relative path. Home path will be added at visualization time 
                        cmd.ExecuteNonQuery();

                        // add the picture to the link table
                        cmd.CommandText = "INSERT INTO StudentsPhotos_Students " +
                            "(idStudentsPhoto, idStudent, idSchoolYear) " +
                            "Values (" + idNextPhoto + "," + idNextStudent + "," + SqlString(SchoolYear) +
                            ");";
                        cmd.ExecuteNonQuery();
                        idNextPhoto++;
                    }
                    idNextStudent++;
                }
                cmd.Dispose();
            }
            return idClass;
        }
        internal override List<Class> GetClassesOfYear(string School, string Year)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Class> lc = new List<Class>();

            // Execute the query
            using (DbConnection conn = Connect())
            {
                string query = "SELECT * " +
                " FROM Classes" +
                " WHERE idSchoolYear = '" + Year + "'" +
                " ORDER BY abbreviation" +
                ";";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                // fill the list with this year's classes
                while (dRead.Read())
                {
                    Class c = new Class();
                    GetClassFromRow(c, dRead);
                    lc.Add(c);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return lc;
        }
        internal override DataTable GetClassTable(int? idClass)
        {
            DataTable t;
            using (DbConnection conn = Connect())
            {
                DataAdapter dAdapter;
                DataSet dSet = new DataSet();

                string query = "SELECT * FROM Classes" +
                " WHERE Classes.idClass = " + idClass + ";";
                dAdapter = new SQLiteDataAdapter(query, (System.Data.SQLite.SQLiteConnection)conn);
                dAdapter.Fill(dSet);
                t = dSet.Tables[0];
                dAdapter.Dispose();
                dSet.Dispose();
            }
            return t;
        }
        internal override Class GetClassById(int? IdClass)
        {
            Class c = null;
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Classes" +
                    " WHERE Classes.idClass=" + IdClass +
                    ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                dRead.Read();

                c = new Class(IdClass, Safe.String(dRead["abbreviation"]), Safe.String(dRead["idSchoolYear"]),
                    Safe.String(dRead["idSchool"]));
                c.PathRestrictedApplication = Safe.String(dRead["pathRestrictedApplication"]);
                c.UriWebApp = Safe.String(dRead["uriWebApp"]);

                dRead.Dispose();
                cmd.Dispose();
            }
            return c;
        }
        internal override DataTable GetClassDataTable(string IdSchool, string IdSchoolYear, string ClassAbbreviation)
        {
            DataTable t;
            using (DbConnection conn = Connect())
            {
                DataAdapter dAdapter;
                DataSet dSet = new DataSet();

                string query = "SELECT DISTINCT registerNumber, Classes.idSchool, Classes.idSchoolYear, " +
                                "Classes.abbreviation, Students.*" +
                " FROM Students, Classes_Students, Classes" +
                " WHERE Students.idStudent=Classes_Students.idStudent AND Classes.idClass = Classes_Students.idClass" +
                    " AND Classes.idSchool=" + SqlString(IdSchool) + " AND Classes.idSchoolYear = " + SqlString(IdSchoolYear) +
                    " AND Classes.abbreviation=" + SqlString(ClassAbbreviation) +
                    " ORDER BY Students.lastName, Students.firstName;";
                dAdapter = new SQLiteDataAdapter(query,
                    (System.Data.SQLite.SQLiteConnection)conn);
                dAdapter.Fill(dSet);
                t = dSet.Tables[0];

                dAdapter.Dispose();
                dSet.Dispose();
            }
            return t;
        }
        internal override Class GetClass(string IdSchool, string IdSchoolYear, string ClassAbbreviation)
        {
            Class c = new Class();
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd = conn.CreateCommand();
                string query = "SELECT Classes.*" +
                   " FROM Classes" +
                   " WHERE" +
                   " Classes.idSchoolYear=" + SqlString(IdSchoolYear) +
                   " AND Classes.abbreviation=" + SqlString(ClassAbbreviation);
                if (IdSchool != null && IdSchool != "")
                    query += " AND Classes.idSchool = " + SqlString(IdSchool);
                query += ";";

                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    GetClassFromRow(c, dRead);
                    break; // just the first! 
                }
            }
            return c;
        }
        internal override Class GetClassOfStudent(string IdSchool, string SchoolYearCode, Student Student)
        {
            Class c = new Class();
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Classes.*" +
                   " FROM Classes" +
                   " JOIN Classes_Students ON Classes.idClass = Classes_Students.idClass" +
                   " JOIN Students ON Students.idStudent = Classes_Students.idStudent" +
                   " WHERE" +
                   " Classes.idSchool = " + SqlString(IdSchool) + "" +
                   " AND Classes.idSchoolYear = " + SqlString(SchoolYearCode) + "" +
                   " AND Students.IdStudent = " + Student.IdStudent +
                   ";";
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    GetClassFromRow(c, dRead);
                    break; // just the first! 
                }
            }
            return c;
        }
        internal override void SaveClass(Class Class)
        {
            //bool leaveConnectionOpen = true;
            //if (conn == null)
            //{
            //    conn = dl.Connect();
            //    leaveConnectionOpen = false;
            //}
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "UPDATE Classes" +
                    " SET" +
                    " idClass=" + Class.IdClass + "" +
                    ",idSchoolYear=" + SqlString(Class.SchoolYear) + "" +
                    ",idSchool=" + SqlString(Class.IdSchool) + "" +
                    ",abbreviation=" + SqlString(Class.Abbreviation) + "" +
                    ",desc=" + SqlString(Class.Description) + "" +
                    ",uriWebApp=" + SqlString(Class.UriWebApp) + "" +
                    ",pathRestrictedApplication=" + SqlString(Class.PathRestrictedApplication) + "" +
                    " WHERE idClass=" + Class.IdClass +
                    ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal override void GetClassFromRow(Class Class, DbDataReader Row)
        {
            if (Class == null)
                Class = new Class();
            Class.IdClass = (int)Row["idClass"];
            Class.Abbreviation = Safe.String(Row["abbreviation"]);
            Class.IdSchool = Safe.String(Row["idSchool"]);
            Class.PathRestrictedApplication = Safe.String(Row["pathRestrictedApplication"]);
            Class.SchoolYear = Safe.String(Row["idSchoolYear"]);
            Class.UriWebApp = Safe.String(Row["uriWebApp"]);
            Class.Description = Safe.String(Row["desc"]);
        }
        internal override List<SchoolYear> GetSchoolYearsThatHaveClasses()
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<SchoolYear> ly = new List<SchoolYear>();

            // Execute the query
            using (DbConnection conn = Connect())
            {
                string query = "SELECT DISTINCT SchoolYears.*" +
                " FROM SchoolYears" +
                " JOIN Classes ON Classes.IdSchoolYear = SchoolYears.IdSchoolYear" +
                " WHERE SchoolYears.IdSchoolYear IS NOT NULL" +
                " ORDER BY IdSchoolYear" +
                ";";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    SchoolYear y = new SchoolYear();
                    y.IdSchoolYear = (string)dRead["idSchoolYear"];
                    y.ShortDescription = Safe.String(dRead["shortDesc"]);
                    y.Notes = Safe.String(dRead["notes"]);

                    ly.Add(y);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return ly;
        }
        internal override Class GetThisClassNextYear(Class Class)
        {
            string nextYear = Commons.IncreaseIntegersInString(Class.SchoolYear);
            string nextAbbreviation = Commons.IncreaseIntegersInString(Class.Abbreviation);
            return GetClass(Class.IdSchool, nextYear, nextAbbreviation);
        }
    }
}
