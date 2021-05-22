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
    class ClassesManage
    {
        //Andrea Siboni, Francesco Citarella, Cesare Colella, Riccardo Brunelli 4°L

        DataLayer dl = new DataLayer();

        internal void UpdatePathStartLinkOfClass(Class currentClass, string text)
        {
            // !!!! currently not used, because pathStartLink field does not exist yet in the database !!!!
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Classes" +
                           " Set" +
                           " pathStartLink='" + text + "'" +
                           " WHERE IdClass=" + currentClass.IdClass +
                           ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        private int NextKey(string Table, string Id)
        {
            int nextId;
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT MAX(" + Id + ") FROM " + Table + ";";
                var firstColumn = cmd.ExecuteScalar();
                if (firstColumn != DBNull.Value)
                {
                    nextId = int.Parse(firstColumn.ToString()) + 1;
                }
                else
                {
                    nextId = 1;
                }
                cmd.Dispose();
            }
            return nextId;
        }

        internal int CreateClass(string ClassAbbreviation, string ClassDescription, string SchoolYear,
            string IdSchool)
        {
            // trova una chiave da assegnare alla nuova classe
            int idClass = NextKey("Classes", "idClass");
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // creazione della classe nella tabella delle classi (soltanto quella) 
                cmd.CommandText = "INSERT INTO Classes " +
                    "(idClass, Desc, idSchoolYear, idSchool, abbreviation) " +
                    "Values (" + idClass + ",'" + SqlVal.SqlString(ClassDescription) + "','" +
                    SqlVal.SqlString(SchoolYear) + "','" + SqlVal.SqlString(IdSchool) + "','" +
                    SqlVal.SqlString(ClassAbbreviation) +
                    "');";
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
            // crea la cartella delle foto della classe, se non esiste
            // if it doesn't exist, create the folder of classes student's images
            if (!Directory.Exists(Commons.PathImages + "\\" + SchoolYear + ClassAbbreviation))
            {
                Directory.CreateDirectory(Commons.PathImages + "\\" + SchoolYear + ClassAbbreviation);
            }
            return idClass;
        }


        internal void SaveSubjects(List<SchoolSubject> SubjectList)
        {
            foreach (SchoolSubject s in SubjectList)
            {
                SaveSubject(s);
            }
        }

        internal string SaveSubject(SchoolSubject Subject)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                if (Subject.OldId != "" && Subject.OldId != null)
                {
                    cmd.CommandText = "UPDATE SchoolSubjects " +
                        "SET" +
                        " Name='" + SqlVal.SqlString(Subject.Name) + "'" +
                        ",Desc='" + SqlVal.SqlString(Subject.Desc) + "'" +
                        ",Color='" + SqlVal.SqlInt(Subject.Color) + "'" +
                        " WHERE idSchoolSubject='" + SqlVal.SqlString(Subject.IdSchoolSubject) + "'" +
                        ";";
                }
                else
                {
                    cmd.CommandText = "INSERT INTO SchoolSubjects " +
                        "(idSchoolSubject, name, desc, color) " +
                        "Values ('" + SqlVal.SqlString(Subject.IdSchoolSubject) + "','" + SqlVal.SqlString(Subject.Name)
                        + "','" + SqlVal.SqlString(Subject.Desc) + "'," + SqlVal.SqlInt(Subject.Color) + "" +
                        ");";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return Subject.IdSchoolSubject;
        }



        internal DataTable GetClassTable(int? idClass)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
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

        internal Class GetClassById(int? IdClass)
        {
            DbDataReader dRead;
            DbCommand cmd;
            Class c = null;
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT *" +
                    " FROM Classes" +
                    " WHERE Classes.idClass=" + IdClass +
                    ";";
                cmd = new SQLiteCommand(query);
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    c = new Class(IdClass, SafeDb.SafeString(dRead["abbreviation"]), SafeDb.SafeString(dRead["idSchoolYear"]),
                        SafeDb.SafeString(dRead["idSchool"]));
                    c.PathRestrictedApplication = SafeDb.SafeString(dRead["pathRestrictedApplication"]);
                    c.UriWebApp = SafeDb.SafeString(dRead["uriWebApp"]);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return c;
        }

        internal DataTable GetClassDataTable(string IdSchool, string IdSchoolYear, string ClassAbbreviation)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter dAdapter;
                DataSet dSet = new DataSet();

                string query = "SELECT DISTINCT registerNumber, Classes.idSchool, Classes.idSchoolYear, " +
                                "Classes.abbreviation, Students.*" +
                " FROM Students, Classes_Students, Classes" +
                " WHERE Students.idStudent = Classes_Students.idStudent AND Classes.idClass = Classes_Students.idClass" +
                    " AND Classes.idSchool = '" + SqlVal.SqlString(IdSchool) + "' AND Classes.idSchoolYear = '" + SqlVal.SqlString(IdSchoolYear) +
                    "' AND Classes.abbreviation = '" + SqlVal.SqlString(ClassAbbreviation) +
                    "' ORDER BY Students.lastName, Students.firstName;";
                dAdapter = new SQLiteDataAdapter(query,
                    (System.Data.SQLite.SQLiteConnection)conn);
                dAdapter.Fill(dSet);
                t = dSet.Tables[0];

                dAdapter.Dispose();
                dSet.Dispose();
            }
            return t;
        }


        internal int? SaveStartLink(int? IdStartLink, int? IdClass, string SchoolYear,
            string StartLink, string Desc)
        {
            DbCommand cmd = null;
            try
            {
                using (DbConnection conn = dl.Connect())
                {
                    cmd = conn.CreateCommand();
                    if (IdStartLink != null && IdStartLink != 0)
                    {
                        cmd.CommandText = "UPDATE Classes_StartLinks" +
                            " SET" +
                            " idStartLink=" + IdStartLink +
                            ",idClass=" + IdClass + "" +
                            ",startLink='" + SqlVal.SqlString(StartLink) + "'" +
                            ",desc='" + SqlVal.SqlString(Desc) + "'" +
                            " WHERE idStartLink=" + IdStartLink +
                            ";";
                    }
                    else
                    {
                        IdStartLink = NextKey("Classes_StartLinks", "IdStartLink");
                        cmd.CommandText = "INSERT INTO Classes_StartLinks" +
                            " (idStartLink,idClass,startLink,desc)" +
                            " VALUES " +
                            "(" +
                            IdStartLink +
                            "," + IdClass +
                            ",'" + SqlVal.SqlString(StartLink) + "'" +
                            ",'" + SqlVal.SqlString(Desc) + "'" +
                            ");";
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                Commons.ErrorLog("DbLayer.SaveStartLink: " + ex.Message, true);
                IdStartLink = null;
                cmd.Dispose();
            }
            return IdStartLink;
        }

        internal void DeleteStartLink(Nullable<int> IdStartLink)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Classes_StartLinks" +
                    " WHERE idStartLink=" + IdStartLink +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal DataTable GetAllStartLinks(string Year, int? IdClass)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT Classes.idSchoolYear,Classes.abbreviation,Classes.idClass," +
                    "Classes_StartLinks.startLink, Classes_StartLinks.desc,Classes_StartLinks.idStartLink" +
                    " FROM Classes" +
                    " JOIN Classes_StartLinks ON Classes_StartLinks.idClass=Classes.idClass" +
                    " WHERE Classes.idSchoolYear=" + Year;
                if (IdClass != null && IdClass != 0)
                    query += " AND Classes.idClass=" + IdClass;
                query += " ORDER BY Classes.abbreviation" +
                    ";";
                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("AllStartLinks");
                try
                {
                    DAdapt.Fill(DSet);
                    t = DSet.Tables[0];
                }
                catch
                {
                    t = null;
                }
                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }

        internal List<string> GetStartLinksOfClass(Class Class)
        {
            List<string> listOfLinks = new List<string>();
            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = dl.Connect())
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *" +
                    " FROM Classes_StartLinks" +
                    " WHERE idClass=" + Class.IdClass + "; ";
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    string item = (string)dRead["startLink"];
                    listOfLinks.Add(item);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return listOfLinks;
        }





        internal List<Class> GetClassesOfYear(string School, string Year)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Class> lc = new List<Class>();

            // Execute the query
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT Classes.* " +
                " FROM Classes" +
                " WHERE idSchoolYear = '" + Year + "'" +
                " ORDER BY abbreviation" +
                ";";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                // fill the combo with this year's classes
                while (dRead.Read())
                {
                    Class c = new Class((int)dRead["idClass"],
                        (string)dRead["abbreviation"], Year, "dummy");
                    c.UriWebApp = SafeDb.SafeString(dRead["UriWebApp"]);
                    c.PathRestrictedApplication = SafeDb.SafeString(dRead["pathRestrictedApplication"]);

                    lc.Add(c);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return lc;
        }




        internal SchoolSubject GetSchoolSubject(string IdSchoolSubject)
        {
            SchoolSubject subject = new SchoolSubject();
            DbDataReader dRead;
            DbCommand cmd;
            string query;
            using (DbConnection conn = dl.Connect())
            {
                query = "SELECT * FROM SchoolSubjects" +
                    " WHERE IdSchoolSubject='" + IdSchoolSubject + "'";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                while (dRead.Read()) // just the first row 
                {
                    subject.Name = dRead["Name"].ToString();
                    subject.Desc = dRead["Desc"].ToString();
                    subject.Color = (int)dRead["Color"];
                    subject.IdSchoolSubject = IdSchoolSubject;
                    subject.OldId = IdSchoolSubject;
                }
            }
            cmd.Dispose();
            dRead.Dispose();
            return subject;
        }

        internal List<SchoolSubject> GetListSchoolSubjects(bool IncludeANullObject)
        {
            List<SchoolSubject> lss = new List<SchoolSubject>();
            if (IncludeANullObject)
            {
                SchoolSubject ss = new SchoolSubject();
                ss.IdSchoolSubject = "";
                lss.Add(ss);
            }

            DbDataReader dRead;
            DbCommand cmd;
            string query;

            using (DbConnection conn = dl.Connect())
            {
                query = "SELECT * FROM SchoolSubjects";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    SchoolSubject subject = new SchoolSubject();
                    subject.IdSchoolSubject = dRead["IdSchoolSubject"].ToString();
                    subject.OldId = dRead["IdSchoolSubject"].ToString();
                    subject.Name = dRead["Name"].ToString();
                    subject.Desc = dRead["Desc"].ToString();
                    subject.Color = SafeDb.SafeInt(dRead["color"]);

                    lss.Add(subject);
                }
            }
            cmd.Dispose();
            dRead.Dispose();
            return lss;
        }



        internal bool IsTopicAlreadyTaught(Topic Topic)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idLesson" +
                    " FROM Lessons_Topics" +
                    " WHERE idTopic=" + Topic.Id +
                    " AND idTopic<>0" +
                    " LIMIT 1; ";
                var result = cmd.ExecuteScalar();
                return (result != null);
            }
        }


        internal void EraseClassFromClasses(Class Class)
        {
            //EraseAllStudentsOfAClass(Class); 
            using (DbConnection conn = dl.Connect())
            {
                // delete all the references in link table between students and classes
                DbCommand cmd = conn.CreateCommand();
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
            DataLayer newDatabaseDl = new DataLayer(newDatabaseFullName);

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






    }
}
