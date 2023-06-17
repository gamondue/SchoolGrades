using gamon;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
        /// <summary>
        /// Data Access Layer: abstracts the access to dbms using to transfer data 
        /// DbClasses and ADO db classes (ADO should be avoided, if possible) 
        /// </summary>
        private string dbName;

        #region constructors
        /// <summary>
        /// Constructor of DataLayer class that uses the default database of the program
        /// Assumes that the file exists.
        /// </summary>
        internal DataLayer()
        {
            // ???? is next if() useful ????
            if (!System.IO.File.Exists(Commons.PathAndFileDatabase))
            {
                string err = @"[" + Commons.PathAndFileDatabase + " not in the current nor in the dev directory]";
                Commons.ErrorLog(err);
                throw new System.IO.FileNotFoundException(err);

            }
            dbName = Commons.PathAndFileDatabase;
        }
        /// <summary>
        /// Constructor of DataLayer class that get from outside the databases to use
        /// Assumes that the file exists.
        /// </summary>
        internal DataLayer(string PathAndFile)
        {
            dbName = PathAndFile;
        }
        #endregion
        #region properties
        internal string NameAndPathDatabase
        {
            get { return dbName; }
            //set { nomeEPathDatabase = value; }
        }
        #endregion
        internal DbConnection Connect()
        {
            DbConnection connection;
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbName +
                ";version=3;new=False;datetimeformat=CurrentCulture");
                connection.Open();
            }
            catch (Exception ex)
            {
#if DEBUG
                //Get call stack
                StackTrace stackTrace = new StackTrace();
                //Log calling method name
                Commons.ErrorLog("Connect Method in: " + stackTrace.GetFrame(1).GetMethod().Name);
#endif
                Commons.ErrorLog("Error connecting to the database: " + ex.Message + "\r\nFile SQLIte>: " + dbName + " " + "\n");
                connection = null;
            }
            return connection;
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
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // compact the database 
                cmd.CommandText = "VACUUM;";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            //Application.Exit();
        }
        internal School GetSchool(string OfficialSchoolAbbreviation)
        {
            // !!!! TODO read school info from the database !!!!
            School news = new School();
            // the next should be a real integer id, 
            news.IdSchool = Commons.IdSchool;
            news.Name = "ITT Pascal - Cesena";
            news.Desc = "Istituto Tecnico Tecnologico Blaise Pascal, Cesena";
            news.OfficialSchoolAbbreviation = Commons.IdSchool;
            return news;
        }
        internal int NextKey(string Table, string KeyName)
        {
            int nextId;
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT MAX(" + KeyName + ") FROM " + Table + ";";
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
        internal bool CheckKeyExistence
            (string TableName, string KeyName, string KeyValue)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT " + KeyName + " FROM " + TableName +
                    " WHERE " + KeyName + "=" + SqlString(KeyValue) +
                    ";";
                var keyResult = cmd.ExecuteScalar();
                cmd.Dispose();
                if (keyResult != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        internal void CreateNewDatabase()
        {
            DbCommand cmd;
            // erase all the data on all the tables
            using (DbConnection conn = Connect()) // connect to the new database, just copied
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
        }
        internal void BackupAllStudentsDataTsv()
        {
            BackupTableTsv("Students");
            BackupTableTsv("StudentsPhotos");
            BackupTableTsv("StudentsPhotos_Students");
            BackupTableTsv("Classes_Students");
            BackupTableTsv("Grades");
        }
        internal void BackupAllStudentsDataXml()
        {
            BackupTableXml("Students");
            BackupTableXml("StudentsPhotos");
            BackupTableXml("StudentsPhotos_Students");
            BackupTableXml("Classes_Students");
            BackupTableXml("Grades");
        }
        internal void RestoreAllStudentsDataTsv(bool MustErase)
        {
            RestoreTableTsv("Students", MustErase);
            RestoreTableTsv("StudentsPhotos", MustErase);
            RestoreTableTsv("StudentsPhotos_Students", MustErase);
            RestoreTableTsv("Classes_Students", MustErase);
            RestoreTableTsv("Grades", MustErase);
        }
        internal void RestoreAllStudentsDataXml(bool MustErase)
        {
            RestoreTableXml("Students", MustErase);
            RestoreTableXml("StudentsPhotos", MustErase);
            RestoreTableXml("StudentsPhotos_Students", MustErase);
            RestoreTableXml("Classes_Students", MustErase);
            RestoreTableXml("Grades", MustErase);
        }
        internal void BackupTableTsv(string TableName)
        {
            DbDataReader dRead;
            DbCommand cmd;
            string fileContent = "";

            using (DbConnection conn = Connect())
            {
                string query = "SELECT *" +
                    " FROM " + TableName + " ";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                int y = 0;
                while (dRead.Read())
                {
                    // field names only in first row 
                    if (y == 0)
                    {
                        string types = "";
                        for (int i = 0; i < dRead.FieldCount; i++)
                        {
                            fileContent += "\"" + dRead.GetName(i) + "\"\t";
                            types += "\"" + Safe.String(dRead.GetDataTypeName(i)) + "\"\t";
                        }
                        fileContent = fileContent.Substring(0, fileContent.Length - 1) + "\r\n";
                        fileContent += types.Substring(0, types.Length - 1) + "\r\n";
                    }
                    // field values
                    string values = "";
                    if (dRead.GetValue(0) != null)
                    {
                        Console.Write(dRead.GetValue(0));
                        for (int i = 0; i < dRead.FieldCount; i++)
                        {
                            values += "\"" + Safe.String(dRead.GetValue(i).ToString()) + "\"\t";
                        }
                        fileContent += values.Substring(0, values.Length - 1) + "\r\n";
                    }
                    else
                    {

                    }
                    y++;
                }
                TextFile.StringToFile(Path.Combine(Commons.PathDatabase, TableName + ".tsv"), fileContent, false);
                dRead.Dispose();
                cmd.Dispose();
            }
        }
        internal void BackupTableXml(string TableName)
        {
            DataAdapter dAdapt;
            DataSet dSet = new DataSet();
            DataTable t;
            string query = "SELECT *" +
                    " FROM " + TableName + ";";

            using (DbConnection conn = Connect())
            {
                dAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                dSet = new DataSet("GetTable");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                t.WriteXml(Path.Combine(Commons.PathDatabase,TableName + ".xml"),
                    XmlWriteMode.WriteSchema);

                dAdapt.Dispose();
                dSet.Dispose();
            }
        }
        internal void RestoreTableTsv(string TableName, bool EraseBefore)
        {
            List<string> fieldNames;
            List<string> fieldTypes = new List<string>();
            //string[,] dati = FileDiTesto.FileInMatrice(Commons.PathDatabase +
            //    "\\" + TableName + ".tsv", '\t',
            //    out fieldsNames, out fieldTypes);
            string dati = TextFile.FileToString(Commons.PathDatabase +
                "\\" + TableName + ".tsv");
            if (dati is null)
                return;
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                if (EraseBefore)
                {
                    // first: erases existing rows in the table
                    cmd.CommandText += "DELETE FROM " + TableName + ";";
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Append of table records to an existing table id not implemented yet");
                    //return; 
                }
                string fieldsString = " (";
                string valuesString;
                int fieldsCount = 0;

                int index = 0;
                string fieldName = "";
                while (index < dati.Length)
                {
                    // parse first line: field names
                    fieldNames = new List<string>();
                    do
                    {
                        if (dati[index++] != '\"')
                            return; // error! 
                        fieldName = "";
                        while (dati[index] != '\"')
                        {
                            fieldName += dati[index++];
                        }
                        fieldNames.Add(fieldName);
                        fieldsString += fieldName + ",";
                        fieldsCount++;
                        if (dati[++index] != '\t' && dati[index] != '\r')
                            return; // ERROR!
                    } while (dati[++index] != '\r');
                    index++; // void line feed

                    // parse second line: field types
                    string fieldType = "";
                    while (dati[index] != '\r')
                    {
                        while (dati[index] != '\"')
                        {
                            fieldType += dati[index++];
                        }
                        fieldTypes.Add(fieldType);
                        fieldsString += fieldName + ",";
                        fieldsCount++;
                    }
                    index++; // void line feed

                    // parse the rest of the rows: values
                    string fieldValue = "";
                    while (dati[index] != '\r')
                    {
                        while (dati[index] != '\"')
                        {
                            fieldType += dati[index++];
                        }
                        fieldTypes.Add(fieldType);
                        fieldsString += fieldName + ",";
                        fieldsCount++;
                    }
                }
                //for (int col = 0; col < dati.GetLength(1); col++)
                //{
                //    if (fieldNames[col] != "")
                //    {
                //        fieldsString += fieldNames[col] + ",";
                //        fieldsCount++; 
                //    }
                //}
                //fieldsString = fieldsString.Substring(0, fieldsString.Length - 1);
                //fieldsString += ")";
                //for (int row = 0; row < dati.GetLength(0); row++)
                //{
                //    valuesString = " Values (";
                //    for (int col = 0; col < fieldsCount; col++)
                //    {
                //        if (fieldNames[col] != "")
                //        {
                //            if (fieldTypes[col].IndexOf("VARCHAR") >= 0)
                //                valuesString += "" + SqlString(dati[row, col]) + ",";
                //            else if (fieldTypes[col].IndexOf("INT") >= 0)
                //                valuesString +=  SqlInt(dati[row, col]) + ",";
                //            else if (fieldTypes[col].IndexOf("REAL") >= 0)
                //                valuesString += SqlFloat(dati[row, col]) + ",";
                //            else if (fieldTypes[col].IndexOf("FLOAT") >= 0)
                //                valuesString += SqlFloat(dati[row, col]) + ",";
                //            else if (fieldTypes[col].IndexOf("DATE") >= 0)
                //                valuesString += SqlDate(dati[row, col]) + ",";
                //        }
                //    }
                //    valuesString = valuesString.Substring(0, valuesString.Length - 1);
                //    valuesString += ")";
                //    cmd.CommandText = "INSERT INTO " + TableName +
                //                fieldsString +
                //                valuesString;
                //    //" WHERE " + fieldsNames[0] + "=";
                //    //if (fieldTypes[0].IndexOf("VARCHAR") >= 0)
                //    //    cmd.CommandText += "'" + StringSql(dati[row, 0]) + "'";
                //    //else
                //    //    cmd.CommandText += StringSql(dati[row, 0]);
                //    cmd.CommandText += ";";
                //    cmd.ExecuteNonQuery();
                //}
                //cmd.Dispose();
            }
        }
        internal void RestoreTableXml(string TableName, bool EraseBefore)
        {
            DataSet dSet = new DataSet();
            DataTable t = null;
            dSet.ReadXml(Commons.PathDatabase + "\\" + TableName + ".xml", XmlReadMode.ReadSchema);
            t = dSet.Tables[0];
            if (t.Rows.Count == 0)
                return;
            using (DbConnection conn = Connect())
            {
                DbCommand cmd;
                cmd = conn.CreateCommand();
                if (EraseBefore)
                {
                    cmd.CommandText = "DELETE FROM " + TableName + ";";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "INSERT INTO " + TableName + "(";
                // column names
                DataRow r = t.Rows[0];
                foreach (DataColumn c in t.Columns)
                {
                    cmd.CommandText += c.ColumnName + ",";
                }
                cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);
                cmd.CommandText += ")VALUES";
                // row values
                foreach (DataRow row in t.Rows)
                {
                    cmd.CommandText += "(";
                    foreach (DataColumn c in t.Columns)
                    {
                        switch (Type.GetTypeCode(c.DataType))
                        {
                            case TypeCode.String:
                            case TypeCode.Char:
                                {
                                    cmd.CommandText += "" + SqlString(row[c.ColumnName].ToString()) + ",";
                                    break;
                                };
                            case TypeCode.DateTime:
                                {
                                    DateTime? d = Safe.DateTime(row[c.ColumnName]);
                                    cmd.CommandText += "'" +
                                        ((DateTime)(d)).ToString("yyyy-MM-dd_HH.mm.ss") + "',";
                                    break;
                                }
                            default:
                                {
                                    if (!(row[c.ColumnName] is DBNull))
                                        cmd.CommandText += row[c.ColumnName] + ",";
                                    else
                                        cmd.CommandText += "0,";
                                    break;
                                }
                        }
                    }
                    cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);
                    cmd.CommandText += "),";
                }
                cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);
                cmd.CommandText += ";";
                cmd.ExecuteNonQuery();
                dSet.Dispose();
                t.Dispose();
                cmd.Dispose();
            }
        }
        internal string CreateDemoDatabase(string newDatabaseFullName, Class Class1, Class Class2)
        {
            DbCommand cmd;

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

                // erase all the annotations, of all classes
                cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                    ";";
                cmd.ExecuteNonQuery();

                // erase all the StartLinks of ALL the classes (they will be re-done in the new database) 
                cmd.CommandText = "DELETE FROM Classes_StartLinks" +
                    //" WHERE idClass<>" + Class1.IdClass +
                    //" AND idClass<>" + Class2.IdClass +
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
                Class1.Abbreviation = "1DEMO";
                Class1.Description = "SchoolGrades demo class 1";
                // Class1.SchoolYear = // !!!! shift the data to the destination school year, to be done when year's shifting will be managed!!!!
                Class1.PathRestrictedApplication = Commons.PathExe + "\\1demo";
                Class1.IdSchool = Commons.IdSchool; 
                Class1.UriWebApp = ""; // ???? decide what to put here ????
                // SaveClass Class1;
                string query = "UPDATE Classes" +
                    " SET" +
                    " idClass=" + Class1.IdClass + "" +
                    ",idSchoolYear=" + SqlString(Class1.SchoolYear) + "" +
                    ",idSchool=" + SqlString(Class1.IdSchool) + "" +
                    ",abbreviation=" + SqlString(Class1.Abbreviation) + "" +
                    ",desc=" + SqlString(Class1.Description) + "" +
                    ",uriWebApp=" + SqlString(Class1.UriWebApp) + "" +
                    ",pathRestrictedApplication=" + SqlString(Class1.PathRestrictedApplication) + "" +
                    " WHERE idClass=" + Class1.IdClass +
                    ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                // class 2
                Class2.Abbreviation = "2DEMO";
                Class2.Description = "SchoolGrades demo class 2";
                Class2.PathRestrictedApplication = Commons.PathExe + "\\2demo";
                Class2.IdSchool = Commons.IdSchool;
                Class2.UriWebApp = ""; // ???? decide what to put here ????
                // SaveClass Class2;
                query = "UPDATE Classes" +
                    " SET" +
                    " idClass=" + Class2.IdClass + "" +
                    ",idSchoolYear=" + SqlString(Class2.SchoolYear) + "" +
                    ",idSchool=" + SqlString(Class2.IdSchool) + "" +
                    ",abbreviation=" + SqlString(Class2.Abbreviation) + "" +
                    ",desc=" + SqlString(Class2.Description) + "" +
                    ",uriWebApp=" + SqlString(Class2.UriWebApp) + "" +
                    ",pathRestrictedApplication=" + SqlString(Class2.PathRestrictedApplication) + "" +
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

                // Class1 start links

                // !!!! understand why the next 3 queries don't work (the )
                int IdStartLink = NextKey("Classes_StartLinks", "IdStartLink");
                query = "INSERT INTO Classes_StartLinks" +
                    "(idStartLink, idClass, startLink, desc)" +
                    " Values (" + IdStartLink + "," +
                    Class1.IdClass + "," +
                    SqlString(@"https://web.spaggiari.eu/home/app/default/login.php?custcode=FOIP0004") + "," +
                    SqlString("Registro di classe") +
                    ");";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            using (DbConnection conn = newDatabaseDl.Connect())
            {
                int IdStartLink = NextKey("Classes_StartLinks", "IdStartLink");
                string query = "INSERT INTO Classes_StartLinks" +
                    "(idStartLink, idClass, startLink, desc)" +
                    " Values (" + IdStartLink + "," +
                    Class1.IdClass + "," +
                    SqlString(@"https://github.com/gamondue/SchoolGrades") + "," +
                    SqlString("Repo sorgenti") +
                    ");";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                // Class2 start links
                IdStartLink = NextKey("Classes_StartLinks", "IdStartLink");
                query = "INSERT INTO Classes_StartLinks" +
                    "(idStartLink, idClass, startLink, desc)" +
                    " Values (" + IdStartLink + "," +
                    Class1.IdClass + "," +
                    SqlString(@"http://www.ingmonti.it/") + "," +
                    SqlString("Sito gamon") +
                    ");";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                IdStartLink = NextKey("Classes_StartLinks", "IdStartLink");
                query = "INSERT INTO Classes_StartLinks" +
                    "(idStartLink, idClass, startLink, desc)" +
                    " Values (" + IdStartLink + "," +
                    Class1.IdClass + "," +
                    SqlString(@".\README.md") + "," +
                    SqlString("File di testo!") +
                    ");";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                // compact the database 
                cmd.CommandText = "VACUUM;";
                cmd.ExecuteNonQuery();
            }
            return newDatabaseFullName;
        }
        private bool FieldExists(string TableName, string FieldName)
        {
            // watch if field isPopUp exist in the database
            DataTable table = new DataTable();
            bool fieldExists;
            using (DbConnection conn = Connect())
            {
                table = conn.GetSchema("Columns", new string[] { null, null, TableName, null});
                fieldExists = false;
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        if (row["COLUMN_NAME"].ToString() == FieldName)
                        {
                            fieldExists = true;
                            break; 
                        }
                    }
                }
            }
            return fieldExists;
        }
        internal bool IsTableReadable(string Table)
        {
            try
            {
                int Id;
                //var row = null; 
                using (DbConnection conn = Connect())
                {
                    DbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM (" + Table + ") LIMIT 1 ;";
                    var row = cmd.ExecuteScalar();
                    cmd.Dispose();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
