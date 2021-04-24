using System;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using gamon;
using System.Windows.Forms;

namespace SchoolGrades.DbClasses
{
    /// <summary>
    /// This class plays both the roles of Business ad Data Layer and 
    /// should be separated! Work is in progress into the shared projects
    /// BusinessLayer and DataLayer
    /// </summary>
    public class DbAndBusiness
    {
        DataLayer.DataLayer dl = new DataLayer.DataLayer();
        //private string dbName;

        #region constructors
        public DbAndBusiness()
        {
            dl = new DataLayer.DataLayer();

            //if (!System.IO.File.Exists(Commons.PathAndFileDatabase))
            //{
            //    string err = @"[" + Commons.PathAndFileDatabase + " not in the current nor in the dev directory]";
            //    Commons.ErrorLog(err, true);
            //    //throw new FileNotFoundException(err);
            //}
            //dbName = Commons.PathAndFileDatabase;
        }
        public DbAndBusiness(string PathAndFile)
        {
            dl = new DataLayer.DataLayer(PathAndFile);

            //if (!System.IO.File.Exists(PathAndFile))
            //{
            //    string err = @"[" + PathAndFile + " not in the current nor in the dev directory]";
            //    Commons.ErrorLog(err, true);
            //    throw new FileNotFoundException(err);
            //}
            //dbName = PathAndFile;
        }
        #endregion
        internal DataTable GetGradesOfStudent(Student Student, string SchoolYear,
            string IdGradeType, string IdSchoolSubject,
            DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT Grades.idGrade,datetime(Grades.timeStamp), Students.idStudent," +
                "lastName,firstName," +
                " Grades.value AS 'grade', Grades.weight," +
                " Grades.idGradeParent" +
                " FROM Grades" +
                " JOIN Students" +
                " ON Students.idStudent=Grades.idStudent" +
                " JOIN Classes_Students" +
                " ON Classes_Students.idStudent=Students.idStudent" +
                " WHERE Students.idStudent =" + Student.IdStudent +
                " AND Grades.idSchoolYear='" + SchoolYear + "'" +
                " AND Grades.idGradeType = '" + IdGradeType + "'" +
                " AND Grades.idSchoolSubject = '" + IdSchoolSubject + "'" +
                " AND Grades.Value > 0" +
                " AND Grades.Timestamp BETWEEN " + SqlVal.SqlDate(DateFrom) + " AND " + SqlVal.SqlDate(DateTo) +
                " ORDER BY lastName, firstName, Students.idStudent, Grades.timestamp Desc;";

                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("ClosedMicroGrades");

                DAdapt.Fill(DSet);
                t = DSet.Tables[0];

                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }
        internal void FixQuestionInGrade(int? IdGrade)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Grades" +
                           " Set" +
                           " isFixed=TRUE" +
                           " WHERE idGrade=" + IdGrade +
                           ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

        }
        internal void RemoveQuestionFromTest(int? IdQuestion, int? IdTest)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Tests_Questions " +
                    "WHERE IdQuestion=" + IdQuestion +
                    " AND IdTest='" + IdTest + "'" +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal object GetGradesWeightsOfStudentOnOpenGrades(Student currentStudent, string stringKey1, string stringKey2, DateTime value1, DateTime value2)
        {
            throw new NotImplementedException();

        }

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

        internal DataTable GetGradesWeightsOfClassOnOpenGrades(Class Class,
            string IdGradeType, string IdSchoolSubject, DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                // find the macro grade type of the micro grade
                // TODO take it from a Grade passed as parameter 
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idGradeTypeParent " +
                    "FROM GradeTypes " +
                    "WHERE idGradeType='" + IdGradeType + "'; ";
                string idGradeTypeParent = (string)cmd.ExecuteScalar();

                string query = "SELECT Grades.idGrade,Students.idStudent,lastName,firstName" +
                ",SUM(Grades.weight)/100 AS 'GradesFraction', 1 - SUM(Grades.weight)/100 AS LeftToCloseAssesments" +
                ",COUNT() AS 'GradesCount'" +
                " FROM Grades, Grades AS Parents " +
                " JOIN Classes_Students ON Students.idStudent=Grades.idStudent" +
                " JOIN Students ON Classes_Students.idStudent=Students.idStudent" +
                " WHERE Classes_Students.idClass =" + Class.IdClass +
                " AND Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                " AND (Grades.idGradeType='" + IdGradeType + "'" +
                " OR Grades.idGradeType IS NULL)" +
                " AND Grades.idSchoolSubject='" + IdSchoolSubject + "'" +
                " AND Grades.value IS NOT NULL AND Grades.value <> 0" +
                " AND Grades.Timestamp BETWEEN " + SqlVal.SqlDate(DateFrom) + " AND " + SqlVal.SqlDate(DateTo) +
                " AND Parents.idGradeType = '" + idGradeTypeParent + "'" +
                " AND Grades.idGradeParent = Parents.idGrade" +
                " AND (Parents.Value is null or Parents.Value = 0)" +
                " AND NOT Students.disabled" +
                " GROUP BY Students.idStudent" +
                " ORDER BY GradesFraction ASC, lastName, firstName, Students.idStudent;";

                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("ClosedMicroGrades");

                DAdapt.Fill(DSet);
                t = DSet.Tables[0];

                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }

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

        internal void DeleteValueOfGrade(int IdGrade)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Grades" +
                           " Set" +
                           " value=null" +
                           " WHERE IdGrade=" + IdGrade +
                           ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal void ToggleDisableOneStudent(int? idStudent)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Students" +
                           " Set" +
                           " disabled = ~disabled" +
                           " WHERE IdStudent =" + idStudent +
                           ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        #region funzioni generali per i database
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
        #endregion

        #region Metodi specifici per questo programma
        internal int? UpdateAnnotationGroup(StudentAnnotation currentAnnotation, Student currentStudent)
        {
            throw new NotImplementedException();
        }
        internal void EraseStudentsPhoto(int? IdStudent, string SchoolYear)
        {
            using (DbConnection conn =dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsPhotos_Students" +
                    " WHERE idStudent=" + IdStudent +
                    " AND idSchoolYear='" + SchoolYear + "'" +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
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

        internal DataTable GetUnfixedGrades(Student Student, string IdSchoolSubject,
            double Threshold)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter dAdapt;
                DataSet dSet = new DataSet();
                string query = "SELECT Grades.IdGrade,Grades.idStudent,Grades.value,Grades.timestamp,Grades.isFixed," +
                    "Grades.idGradeType,Grades.idQuestion,Questions.text,Questions.*,Grades.*" +
                    " FROM Grades" +
                    " JOIN Questions ON Grades.idQuestion=Questions.idQuestion" +
                    " WHERE idStudent=" + Student.IdStudent +
                    " AND Grades.value<" + Threshold.ToString() +
                    " AND (Grades.isFixed=0 OR Grades.isFixed is NULL)";
                if (IdSchoolSubject != "")
                    query += " AND Grades.idSchoolSubject='" + IdSchoolSubject + "'";
                query += ";";
                dAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                dSet = new DataSet("GetUnfixedGradesInTheYear");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                dSet.Dispose();
                dAdapt.Dispose();
            }
            return t;
        }

        private Question GetQuestionFromRow(DbDataReader Row)
        {
            Question q = new Question();
            q.Difficulty = SafeDb.SafeInt(Row["Difficulty"]);
            q.IdImage = SafeDb.SafeInt(Row["IdImage"]);
            q.Duration = SafeDb.SafeInt(Row["Duration"]);
            q.IdQuestion = SafeDb.SafeInt(Row["IdQuestion"]);
            q.IdQuestionType = SafeDb.SafeString(Row["IdQuestionType"]);
            q.IdSchoolSubject = SafeDb.SafeString(Row["IdSchoolSubject"]);
            //q.IdSubject = SafeDb.SafeInt(Row["IdSubject"]);
            q.IdTopic = SafeDb.SafeInt(Row["IdTopic"]);
            q.Image = SafeDb.SafeString(Row["Image"]);
            q.Text = SafeDb.SafeString(Row["Text"]);
            q.Weight = SafeDb.SafeDouble(Row["Weight"]);
            q.NRows = SafeDb.SafeInt(Row["nRows"]);
            q.IsParamount = SafeDb.SafeInt(Row["isParamount"]);
            ////////q.IsFixed = SafeDb.SafeBool(Row["isFixed"]);

            return q;
        }

        internal string GetFilePhoto(int? IdStudent, string SchoolYear)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT StudentsPhotos.photoPath" +
                    " FROM StudentsPhotos_Students, StudentsPhotos" +
                    " WHERE StudentsPhotos_Students.idStudentsPhoto = StudentsPhotos.idStudentsPhoto";
                if (SchoolYear != null && SchoolYear != "")
                    query += " AND StudentsPhotos_Students.idSchoolYear='" + SchoolYear + "'";
                query += " AND StudentsPhotos_Students.idStudent = " + IdStudent + "; ";
                string NamePath = null;
                try
                {
                    cmd.CommandText = query;
                    NamePath = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {

                }
                cmd.Dispose();
                return NamePath;
            }
        }

        internal void AddLinkToOldPhoto(int? IdStudent, string IdPreviousSchoolYear, string IdNextSchoolYear)
        {
            using (DbConnection conn = dl.Connect())
            {
                // get the code of the previous photo
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idStudentsPhoto" +
                    " FROM StudentsPhotos_Students" +
                    " WHERE idSchoolYear='" + IdPreviousSchoolYear + "'" +
                    " AND StudentsPhotos_Students.idStudent = " + IdStudent + "; ";
                int? idStudentsPhoto = (int?)cmd.ExecuteScalar();
                if (idStudentsPhoto != null)
                {
                    // add link to old photo
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO StudentsPhotos_Students " +
                    "(idStudent, idStudentsPhoto, idSchoolYear) " +
                    "Values (" +
                    "" + IdStudent + "" +
                    "," + idStudentsPhoto + "" +
                    ",'" + IdNextSchoolYear + "'" +
                    ");";
                    cmd.ExecuteNonQuery();
                }
                cmd.Dispose();
            }
        }

        internal int CreateStudentFromStringMatrix(string[,] StudentData, int? StudentRow)
        {
            // trova una chiave da assegnare al nuovo studente
            int codiceStudente = NextKey("Students", "idStudent");
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Students " +
                    "(idStudent, lastName, firstName, residence, origin, email," +
                    //" birthDate," + // save also this field after SqlVal.SqlDate( will include the '', to better treat null values
                    " birthPlace) " +
                    "Values (" + codiceStudente + "," +
                    "'" + SqlVal.SqlString(StudentData[(int)StudentRow, 1]) + "'," +
                    "'" + SqlVal.SqlString(StudentData[(int)StudentRow, 2]) + "'," +
                    "'" + SqlVal.SqlString(StudentData[(int)StudentRow, 3]) + "'," +
                    "'" + SqlVal.SqlString(StudentData[(int)StudentRow, 4]) + "'," +
                    "'" + SqlVal.SqlString(StudentData[(int)StudentRow, 5]) + "'," +
                    //"'" + SqlVal.SqlDate(StudentData[(int)StudentRow, 6]) + "'," + // save also this field after SqlVal.SqlDate( will include the ''
                    "'" + SqlVal.SqlString(StudentData[(int)StudentRow, 7]) + "'" +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return codiceStudente;
        }

        internal int CreateStudent(Student Student)
        {
            // trova una chiave da assegnare al nuovo studente
            int idStudent = NextKey("Students", "idStudent");
            Student.IdStudent = idStudent;
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Students " +
                    "(idStudent,lastName,firstName,residence,origin," +
                    "email,birthDate,birthPlace,disabled) " +
                    "Values ('" + Student.IdStudent + "','" +
                    SqlVal.SqlString(Student.LastName) + "','" +
                    SqlVal.SqlString(Student.FirstName) + "','" +
                    SqlVal.SqlString(Student.Residence) + "','" +
                    SqlVal.SqlString(Student.Origin) + "','" +
                    SqlVal.SqlString(Student.Email) + "'," +
                    SqlVal.SqlDate(Student.BirthDate.ToString()) + ",'" +
                    SqlVal.SqlString(Student.BirthPlace) + "'," +
                    "false" +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return idStudent;
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

        internal void SaveStudentsOfList(List<Student> studentsList, DbConnection conn)
        {
            foreach (Student s in studentsList)
            {
                SaveStudent(s, conn);
            }
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

        internal Student GetStudent(int? IdStudent)
        {
            Student s = new Student();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM Students " +
                    "WHERE idStudent=" + IdStudent +
                    ";";
                dRead = cmd.ExecuteReader();
                dRead.Read();
                s = GetStudentFromRow(dRead);
                dRead.Dispose();
                cmd.Dispose();
            }
            return s;
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

        internal DataTable GetStudentsSameName(string LastName, string FirstName)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter dAdapt;
                DataSet dSet = new DataSet();
                string query = "SELECT Students.IdStudent, Students.lastName, Students.firstName," +
                    " Classes.abbreviation, Classes.idSchoolYear" +
                    " FROM Students" +
                    " LEFT JOIN Classes_Students ON Students.idStudent = Classes_Students.idStudent " +
                    " LEFT JOIN Classes ON Classes.idClass = Classes_Students.idClass " +
                    " WHERE Students.lastName LIKE '%" + LastName + "%'" +
                    " AND Students.firstName LIKE '%" + FirstName + "%'" +
                    ";";
                dAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                dSet = new DataSet("GetStudentsSameName");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                dSet.Dispose();
                dAdapt.Dispose();
            }
            return t;
        }

        internal DataTable FindStudentsLike(string LastName, string FirstName)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter dAdapt;
                DataSet dSet = new DataSet();
                string query = "SELECT Students.IdStudent, Students.lastName, Students.firstName," +
                    " Classes.abbreviation, Classes.idSchoolYear" +
                    " FROM Students" +
                    " LEFT JOIN Classes_Students ON Students.idStudent = Classes_Students.idStudent " +
                    " LEFT JOIN Classes ON Classes.idClass = Classes_Students.idClass ";
                if (LastName != "" && LastName != null)
                {
                    query += "WHERE Students.lastName LIKE '%" + LastName + "%'";
                    if (FirstName != "" && FirstName != null)
                    {
                        query += " AND Students.firstName LIKE '%" + FirstName + "%'";
                    }
                }
                else
                {
                    if (FirstName != "" && FirstName != null)
                    {
                        query += " WHERE Students.firstName LIKE '%" + FirstName + "%'";
                    }
                }
                query += ";";
                dAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                dSet = new DataSet("GetStudentsSameName");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                dSet.Dispose();
                dAdapt.Dispose();
            }
            return t;
        }

        internal void PutStudentInClass(int? IdStudent, int? IdClass)
        {
            using (DbConnection conn = dl.Connect())
            {
                // add student to the class
                DbCommand cmd = conn.CreateCommand();
                // check if already present
                cmd.CommandText = "SELECT IdStudent FROM Classes_Students " +
                    "WHERE idClass=" + IdClass + " AND idStudent=" + IdStudent + "" +
                ";";
                if (cmd.ExecuteScalar() == null)
                {
                    // add student to the class
                    cmd.CommandText = "INSERT INTO Classes_Students " +
                    "(idClass, idStudent) " +
                    "Values ('" + IdClass + "'," + IdStudent + "" +
                    ");";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal int CopyAndLinkOnePhoto(Student Student, Class Class, string PathAndFileName)
        {
            if (!File.Exists(PathAndFileName))
            {
                throw new FileNotFoundException(@"[" + PathAndFileName + " not found.]");
                //return 0;
            }
            if (File.Exists(PathAndFileName + "TEMP"))
            {
                File.Delete(PathAndFileName + "TEMP");
            }
            File.Copy(PathAndFileName, PathAndFileName + "TEMP");

            string ext = Path.GetExtension(PathAndFileName);
            string newFileName = Commons.PathImages + "\\" + Class.SchoolYear + Class.Abbreviation + "\\" +
                Student.LastName + "_" + Student.FirstName + "_" + Class.Abbreviation + Class.SchoolYear + ext;
            if (!Directory.Exists(Commons.PathImages + "\\" + Class.SchoolYear + Class.Abbreviation + "\\"))
            {
                Directory.CreateDirectory(Commons.PathImages + "\\" + Class.SchoolYear + Class.Abbreviation + "\\");
            }
            if (File.Exists(newFileName))
            {
                // !!!! TODO: resolve the problem of the lock that is still active here, 
                // !!!! despite many attempts to free it !!!!
                File.Delete(newFileName);
            }
            File.Move(PathAndFileName + "TEMP", newFileName);

            // trova la chiave per la prossima foto 
            int codiceFoto = NextKey("StudentsPhotos", "idStudentsPhoto");
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();

                // aggiunge la foto alle foto (cartella relativa, cui verrà aggiunta la path delle foto)
                cmd.CommandText = "INSERT INTO StudentsPhotos " +
                "(idStudentsPhoto, photoPath)" +
                "Values " +
                "('" + codiceFoto + "','" + SqlVal.SqlString(Class.SchoolYear) +
                SqlVal.SqlString(Class.Abbreviation) + "\\" + SqlVal.SqlString(Student.LastName) + "_" + SqlVal.SqlString(Student.FirstName) +
                "_" + SqlVal.SqlString(Class.Abbreviation) + SqlVal.SqlString(Class.SchoolYear) + ".jpg" +
                "');";
                cmd.ExecuteNonQuery();

                // cancella tutti gli eventuali riferimenti nella tabella link delle foto ad altre foto nell'anno 
                cmd.CommandText = "DELETE FROM StudentsPhotos_Students " +
                    "WHERE idStudent=" + Student.IdStudent +
                    " AND idSchoolYear='" + Class.SchoolYear + "'" +
                    ";";
                cmd.ExecuteNonQuery();
                // aggiunge questa foto alla tabella link delle foto
                cmd.CommandText = "INSERT INTO StudentsPhotos_Students " +
                    "(idStudentsPhoto, idStudent, idSchoolYear) " +
                    "Values (" + codiceFoto + "," + Student.IdStudent + ",'" + SqlVal.SqlString(Class.SchoolYear) +
                    "');";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return codiceFoto;
        }

        internal int CreateClassAndStudents(string[,] StudentsData, string ClassAbbreviation,
                    string ClassDescription, string SchoolYear, string OfficialSchoolAbbreviation,
                    bool LinkPhoto)
        {
            // creation of a new class in the Classes table

            // finds a key for the new class
            int idClass = NextKey("Classes", "idClass");
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Classes " +
                    "(idClass, Desc, idSchoolYear, idSchool, abbreviation) " +
                    "Values (" + idClass + ",'" + SqlVal.SqlString(ClassDescription) + "','" +
                    SqlVal.SqlString(SchoolYear) + "','" + SqlVal.SqlString(OfficialSchoolAbbreviation) + "','" +
                    SqlVal.SqlString(ClassAbbreviation) + "'" +
                    ");";
                cmd.ExecuteNonQuery();

                // find the key for next student
                int idNextStudent = NextKey("Students", "idStudent");
                // find the key for next picture 
                int idNextPhoto = NextKey("StudentsPhotos", "idStudentsPhoto");
                // add the student to the students' table 
                // start from the second row of the file, first row is descriptions 
                for (int riga = 1; riga < StudentsData.GetLength(0); riga++)
                {
                    int rigap1 = riga + 1;
                    // create new student
                    cmd.CommandText = "INSERT INTO Students " +
                        "(idStudent, lastName, firstName, residence, origin, email, birthDate, birthPlace) " +
                        "Values (" +
                        "'" + idNextStudent + "','" +
                        SqlVal.SqlString(StudentsData[riga, 1]) + "','" +
                        SqlVal.SqlString(StudentsData[riga, 2]) + "','" +
                        SqlVal.SqlString(StudentsData[riga, 3]) + "','" +
                        SqlVal.SqlString(StudentsData[riga, 4]) + "','" +
                        SqlVal.SqlString(StudentsData[riga, 5]) + "'," +
                        SqlVal.SqlDate(StudentsData[riga, 6]) + ",'" +
                        SqlVal.SqlString(StudentsData[riga, 7]) + "'" +
                        ");";
                    cmd.ExecuteNonQuery();

                    // aggiunge lo studente alla classe
                    cmd.CommandText = "INSERT INTO Classes_Students " +
                        "(idClass, idStudent, registerNumber) " +
                        "Values ('" + idClass + "','" + idNextStudent + "','" + rigap1.ToString() + "'" +
                        ");";
                    cmd.ExecuteNonQuery();

                    if (LinkPhoto)
                    {
                        // aggiunge la foto alle foto
                        cmd.CommandText = "INSERT INTO StudentsPhotos " +
                            "(idStudentsPhoto, photoPath)" +
                            "Values " +
                            "('" + idNextPhoto + "','" + SqlVal.SqlString(SchoolYear) +
                            SqlVal.SqlString(ClassAbbreviation) + "\\" + SqlVal.SqlString(StudentsData[riga, 1]) + "_" +
                            SqlVal.SqlString(StudentsData[riga, 2]) + "_" + SqlVal.SqlString(ClassAbbreviation) +
                            SqlVal.SqlString(SchoolYear) + ".jpg" + // TODO mettere l'estensione del file che c'è effettivamente
                            "');"; // relative path. Home path will be added at visualization time 
                        cmd.ExecuteNonQuery();

                        // add the picture to the link table
                        cmd.CommandText = "INSERT INTO StudentsPhotos_Students " +
                            "(idStudentsPhoto, idStudent, idSchoolYear) " +
                            "Values (" + idNextPhoto + "," + idNextStudent + ",'" + SqlVal.SqlString(SchoolYear) +
                            "');";
                        cmd.ExecuteNonQuery();
                        idNextPhoto++;
                    }
                    idNextStudent++;
                }
                cmd.Dispose();
            }
            return idClass;
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

        internal Class GetClass(string IdSchool, string IdSchoolYear, string ClassAbbreviation)
        {
            Class c = new Class();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd = conn.CreateCommand();
                string query = "SELECT Classes.*" +
                   " FROM Classes" +
                   " WHERE" +
                   " Classes.idSchoolYear = '" + SqlVal.SqlString(IdSchoolYear) + "'" +
                   " AND Classes.abbreviation = '" + SqlVal.SqlString(ClassAbbreviation) + "'";
                if (IdSchool != null && IdSchool != "")
                    query += " AND Classes.idSchool = '" + SqlVal.SqlString(IdSchool) + "'";
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdClass">Id of the class to be searched</param>
        /// <param name="conn">Connection already open on a database different from standard. 
        /// If not null this connection is left open</param>
        /// <returns>List of the </returns>
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

        internal Class GetClassOfStudent(string IdSchool, string SchoolYearCode, Student Student)
        {
            Class c = new Class();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Classes.*" +
                   " FROM Classes" +
                   " JOIN Classes_Students ON Classes.idClass = Classes_Students.idClass" +
                   " JOIN Students ON Students.idStudent = Classes_Students.idStudent" +
                   " WHERE" +
                   " Classes.idSchool = '" + SqlVal.SqlString(IdSchool) + "'" +
                   " AND Classes.idSchoolYear = '" + SqlVal.SqlString(SchoolYearCode) + "'" +
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

        private void GetClassFromRow(Class Class, DbDataReader Row)
        {
            if (Class == null)
                Class = new Class();
            Class.IdClass = (int)Row["idClass"];
            Class.Abbreviation = SafeDb.SafeString(Row["abbreviation"]);
            Class.IdSchool = SafeDb.SafeString(Row["idSchool"]);
            Class.PathRestrictedApplication = SafeDb.SafeString(Row["pathRestrictedApplication"]);
            Class.SchoolYear = SafeDb.SafeString(Row["idSchoolYear"]);
            Class.UriWebApp = SafeDb.SafeString(Row["uriWebApp"]);
            Class.Description = SafeDb.SafeString(Row["desc"]);
        }

        internal void SaveClass(Class Class)
        {
            //bool leaveConnectionOpen = true;
            //if (conn == null)
            //{
            //    conn = dl.Connect();
            //    leaveConnectionOpen = false;
            //}
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "UPDATE Classes" +
                    " SET" +
                    " idClass=" + Class.IdClass + "" +
                    ",idSchoolYear='" + SqlVal.SqlString(Class.SchoolYear) + "'" +
                    ",idSchool='" + SqlVal.SqlString(Class.IdSchool) + "'" +
                    ",abbreviation='" + SqlVal.SqlString(Class.Abbreviation) + "'" +
                    ",desc='" + SqlVal.SqlString(Class.Description) + "'" +
                    ",uriWebApp='" + Class.UriWebApp + "'" +
                    ",pathRestrictedApplication='" + SqlVal.SqlString(Class.PathRestrictedApplication) + "'" +
                    " WHERE idClass=" + Class.IdClass +
                    ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal List<Student> GetStudentsOfClassList(string Scuola, string Anno,
            string SiglaClasse, bool IncludeNonActiveStudents)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Student> ls = new List<Student>();
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT registerNumber, Classes.idSchoolYear, " +
                               "Classes.abbreviation, Classes.idClass, Classes.idSchool, " +
                               "Students.*" +
                " FROM Students" +
                " JOIN Classes_Students ON Students.idStudent=Classes_Students.idStudent" +
                " JOIN Classes ON Classes.idClass=Classes_Students.idClass" +
                " WHERE Classes.idSchoolYear = '" + SqlVal.SqlString(Anno) + "'" +
                " AND Classes.abbreviation = '" + SqlVal.SqlString(SiglaClasse) + "'";
                if (!IncludeNonActiveStudents)
                    query += " AND (Students.disabled = 0 OR Students.disabled IS NULL)";
                if (Scuola != null && Scuola != "")
                    query += " AND Classes.idSchool='" + Scuola + "'";
                query += " ORDER BY Students.LastName, Students.FirstName";
                query += ";";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Student s = GetStudentFromRow(dRead);
                    s.Class = (string)dRead["abbreviation"];
                    s.IdClass = (int)dRead["idClass"];
                    ls.Add(s);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return ls;
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

        internal Grade GetGrade(int? IdGrade)
        {
            Grade g = null;
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT  * FROM Grades" +
                    " WHERE Grades.idGrade=" + IdGrade.ToString() +
                    ";";
                dRead = cmd.ExecuteReader();
                dRead.Read(); 
                g = GetGradeFromRow(dRead);
                dRead.Dispose();
                cmd.Dispose();
            }
            return g;
        }

        private Grade GetGradeFromRow(DbDataReader Row)
        {
            Grade g = new Grade();
            g.IdGrade = (int)Row["idGrade"];
            g.IdGradeParent = SafeDb.SafeInt(Row["idGradeParent"]);
            g.IdStudent = SafeDb.SafeInt(Row["idStudent"]);
            g.IdGradeType = SafeDb.SafeString(Row["IdGradeType"]);
            g.IdSchoolSubject = SafeDb.SafeString(Row["IdSchoolSubject"]);
            //g.IdGradeTypeParent = SafeDb.SafeString(Row["idGradeTypeParent"]);
            g.IdQuestion = SafeDb.SafeInt(Row["idQuestion"]);
            g.Timestamp = (DateTime)Row["timestamp"];
            g.Value = SafeDb.SafeDouble(Row["value"]);
            g.Weight = SafeDb.SafeDouble(Row["weight"]);
            g.CncFactor = SafeDb.SafeDouble(Row["cncFactor"]);
            g.IdSchoolYear = SafeDb.SafeString(Row["idSchoolYear"]);
            //g.DummyInt = (int)Row["dummyInt"]; 
            return g; 
        }

        internal void GetGradeAndStudent(Grade Grade, Student Student)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Grades.*,Students.* FROM Grades" +
                    " JOIN Students ON Grades.idStudent = Students.idStudent" +
                    " WHERE Grades.idGrade=" + Grade.IdGrade.ToString() +
                    ";";
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Grade = GetGradeFromRow(dRead);
                    Student = GetStudentFromRow(dRead);
                    break; // just the first! 
                }
                //dRead.Dispose();
                //cmd.Dispose();
            }
        }

        internal void EraseGrade(int? KeyGrade)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Grades" +
                    " WHERE idGrade=" + KeyGrade +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal List<int> GetIdStudentsNonGraded(Class Class,
            GradeType GradeType, SchoolSubject SchoolSubject)
        {
            List<int> keys = new List<int>();

            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT Classes_Students.idStudent" +
                " FROM Classes_Students" +
                " WHERE Classes_Students.idClass=" + Class.IdClass +
                " AND Classes_Students.idStudent NOT IN" +
                "(" +
                "SELECT DISTINCT Classes_Students.idStudent" +
                " FROM Classes_Students" +
                " LEFT JOIN Grades ON Classes_Students.idStudent = Grades.idStudent" +
                " WHERE Classes_Students.idClass=" + Class.IdClass +
                " AND Grades.idSchoolSubject='" + SchoolSubject.IdSchoolSubject + "'" +
                " AND Grades.idGradeType='" + GradeType.IdGradeType + "'" +
                " AND Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                ")" +
                ";";
                cmd = conn.CreateCommand();
                cmd.CommandText = query; 
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    keys.Add((int)SafeDb.SafeInt(dRead["idStudent"]));
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return keys;
        }

        internal Grade LastGradeOfStudent(Student Student, string IdSchoolYear,
            SchoolSubject SchoolSubject, string IdGradeType)
        {
            DbDataReader dRead;
            DbCommand cmd;
            Grade g = new Grade();
            using (DbConnection conn = dl.Connect())
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Grades.* FROM Grades" +
                    " WHERE Grades.idStudent=" + Student.IdStudent.ToString() +
                    " AND Grades.idSchoolSubject='" + SchoolSubject.IdSchoolSubject + "'" +
                    " AND Grades.idGradeType='" + IdGradeType + "'" +
                    " AND Grades.idSchoolYear='" + IdSchoolYear + "'" +
                    " ORDER BY Grades.timestamp DESC;";
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    g = GetGradeFromRow(dRead);
                    break; // just the first! 
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return g;
        }

        /// <summary>
        /// Gets the number of microquestions that haven't yet a global grade
        /// </summary>
        /// <param Name="id"></param>
        /// <returns></returns>
        internal List<Grade> CountNonClosedMicroGrades(Class Class, GradeType GradeType)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Grade> ls = new List<Grade>();
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT Grades.idStudent, Count(*) as nGrades FROM Grades," +
                    "Grades AS Parents,Classes_Students" +
                    " WHERE Classes_Students.idStudent = Grades.idStudent" +
                    " AND Classes_Students.idClass =" + Class.IdClass.ToString() +
                    " AND Grades.idGradeType = '" + GradeType.IdGradeType + "'" +
                    " AND Parents.idGradeType = '" + GradeType.IdGradeTypeParent + "'" +
                    " AND Grades.idGradeParent = Parents.idGrade" +
                    " AND Parents.Value is null or Parents.Value = 0" +
                    " GROUP BY Grades.idStudent;";
                cmd = new SQLiteCommand(query);
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Grade g = new Grade();
                    g.IdStudent = (int)dRead["idStudent"];
                    g.DummyInt = (int)dRead["nGrades"];
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return ls;
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

        internal DataTable GetGradesOfClass(Class Class,
             string IdGradeType, string IdSchoolSubject,
             DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT Grades.idGrade,datetime(Grades.timeStamp),Students.idStudent," +
                "lastName,firstName," +
                "Grades.value AS 'grade',Grades.weight," +
                "Grades.idGradeParent" +
                " FROM Grades" +
                " JOIN Students" +
                " ON Students.idStudent=Grades.idStudent" +
                " JOIN Classes_Students" +
                " ON Classes_Students.idStudent=Students.idStudent" +
                " WHERE Classes_Students.idClass =" + Class.IdClass +
                " AND Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                " AND Grades.idGradeType = '" + IdGradeType + "'" +
                " AND Grades.idSchoolSubject = '" + IdSchoolSubject + "'" +
                " AND Grades.Value > 0" +
                " AND Grades.Timestamp BETWEEN " + SqlVal.SqlDate(DateFrom) + " AND " + SqlVal.SqlDate(DateTo) +
                " ORDER BY lastName, firstName, Students.idStudent, Grades.timestamp Desc;";

                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("ClosedMicroGrades");

                DAdapt.Fill(DSet);
                t = DSet.Tables[0];

                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }

        internal List<Couple> GetGradesOldestInClass(Class Class,
            GradeType GradeType, SchoolSubject SchoolSubject)
        {
            List<Couple> couples = new List<Couple>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query;
                query = "SELECT Classes_Students.idStudent" +
                ",MAX(timestamp) AS InstantLastQuestion" +
                " FROM Classes_Students LEFT JOIN Grades" +
                " ON Classes_Students.idStudent = Grades.idStudent" +
                " WHERE Classes_Students.idClass =" + Class.IdClass +
                " AND Grades.idGradeType = '" + GradeType.IdGradeType + "'" +
                " AND Grades.idSchoolSubject='" + SchoolSubject.IdSchoolSubject + "'" +
                " AND Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                " OR Grades.idGrade IS NULL" + // takes those that haven't any grades
                " GROUP BY Classes_Students.idStudent" +
                " ORDER BY InstantLastQuestion DESC;"; // ???? DESC o no 
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Couple c = new Couple();
                    // we give back also the nulls, as Nows
                    DateTime now = System.DateTime.Now;
                    c.Key = (int)dRead["IdStudent"];
                    if (!dRead.IsDBNull(1))
                        c.Value = SafeDb.SafeDateTime(dRead["InstantLastQuestion"]);
                    else
                        c.Value = now;
                    couples.Add(c);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return couples;
        }

        internal object GetWeightedAveragesOfStudent(Student currentStudent, string stringKey1, string stringKey2, DateTime value1, DateTime value2)
        {
            //throw new NotImplementedException();
            return null;
        }

        internal object GetGradesWeightedAveragesOfStudent(Student currentStudent, string stringKey1, string stringKey2, DateTime value1, DateTime value2)
        {
            throw new NotImplementedException();
        }

        internal DataTable GetWeightedAveragesOfClass(Class Class,
            string IdGradeType, string IdSchoolSubject, DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT Grades.idGrade,Students.idStudent,lastName,firstName" +
                ",SUM(weight)/100 AS 'GradesFraction', 1 - SUM(weight)/100 AS LeftToCloseAssesments" +
                ",COUNT() AS 'GradesCount'" +
                " FROM Classes_Students" +
                " LEFT JOIN Grades ON Students.idStudent=Grades.idStudent" +
                " JOIN Students ON Classes_Students.idStudent=Students.idStudent" +
                " WHERE Classes_Students.idClass =" + Class.IdClass +
                " AND Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                " AND (Grades.idGradeType='" + IdGradeType + "'" +
                " OR Grades.idGradeType IS NULL)" +
                " AND Grades.idSchoolSubject='" + IdSchoolSubject + "'" +
                " AND Grades.value IS NOT NULL AND Grades.value <> 0" +
                " AND Grades.Timestamp BETWEEN " + SqlVal.SqlDate(DateFrom) + " AND " + SqlVal.SqlDate(DateTo) +
                " GROUP BY Students.idStudent" +
                " ORDER BY GradesFraction ASC, lastName, firstName, Students.idStudent;";
                // !!!! TODO change the query to include at first rows also those students that have no grades !!!! 
                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("ClosedMicroGrades");

                DAdapt.Fill(DSet);
                t = DSet.Tables[0];

                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }

        internal DataTable GetGradesWeightedAveragesOfClass(Class Class, string IdGradeType,
            string IdSchoolSubject, DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT Grades.idGrade, Students.idStudent,lastName,firstName," +
                " SUM(Grades.value * Grades.weight)/SUM(Grades.weight) AS 'Weighted average'" +
                // weighted RMS (Root Mean Square) as defined here: 
                // https://stackoverflow.com/questions/10947180/weighted-standard-deviation-in-sql-server-without-aggregation-error
                ",SQRT(SUM(Grades.weight * SQUARE(Grades.value)) / SUM(Grades.weight) - SQUARE(SUM(Grades.weight  * Grades.value) / SUM(Grades.weight))) AS 'Weighted RMS'" +
                ",COUNT() 'Grades Count'" +
                " FROM Grades" +
                " JOIN Students" +
                " ON Students.idStudent=Grades.idStudent" +
                " JOIN Classes_Students" +
                " ON Classes_Students.idStudent=Students.idStudent" +
                " WHERE Classes_Students.idClass =" + Class.IdClass +
                " AND Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                " AND Grades.idGradeType = '" + IdGradeType + "'" +
                " AND Grades.idSchoolSubject = '" + IdSchoolSubject + "'" +
                " AND Grades.Value > 0" +
                " AND Grades.Timestamp BETWEEN " + SqlVal.SqlDate(DateFrom) + " AND " + SqlVal.SqlDate(DateTo) +
                " GROUP BY Students.idStudent" +
                " ORDER BY lastName, firstName, Students.idStudent;";

                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("ClosedMicroGrades");

                DAdapt.Fill(DSet);
                t = DSet.Tables[0];

                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }

        /// <summary>
        /// Gets all the grades of a students of a specified IdGradeType that are the sons 
        /// of another grade which has value greater than zero
        /// </summary>
        /// <param Name="IdStudent"></param> student's Id
        internal DataTable GetMicroGradesOfStudentWithMacroOpen(int? IdStudent, string IdSchoolYear,
            string IdGradeType, string IdSchoolSubject)
        {
            using (DbConnection conn = dl.Connect())
            {
                // find the macro grade type of the micro grade
                // TODO take it from a Grade passed as parameter 
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idGradeTypeParent " +
                    "FROM GradeTypes " +
                    "WHERE idGradeType='" + IdGradeType + "'; ";
                string idGradeTypeParent = (string)cmd.ExecuteScalar();

                string query = "SELECT datetime(Grades.timestamp),Questions.text,Grades.value" +
                    ",Grades.weight,Grades.IdGrade,Grades.idGradeParent,Grades.cncFactor" +
                    ",Questions.IdQuestion,Questions.IdQuestionType,Grades.IdSchoolSubject" +
                    ",Questions.IdTopic,Questions.Image,Questions.Duration,Questions.Difficulty" +
                    ",Questions.*" +
                    ",Grades.*" +
                    " FROM Grades" +
                    " JOIN Grades AS Parents" +
                    " ON Grades.idGradeParent=Parents.idGrade" +
                    " LEFT JOIN Questions" +
                    " ON Grades.idQuestion=Questions.idQuestion" +
                    " WHERE Grades.idStudent =" + IdStudent +
                    " AND Grades.idSchoolYear='" + IdSchoolYear + "'" +
                    " AND Grades.idGradeType = '" + IdGradeType + "'" +
                    " AND Grades.idSchoolSubject = '" + IdSchoolSubject + "'" +
                    " AND Parents.idGradeType = '" + idGradeTypeParent + "'" +
                    " AND Grades.idGradeParent = Parents.idGrade" +
                    " AND (Parents.value = 0 OR Parents.value is NULL)" + 
                    " ORDER BY Grades.timestamp;";

                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("OpenMicroGrades");
                DAdapt.Fill(DSet);
                DAdapt.Dispose();
                DSet.Dispose();
                return DSet.Tables[0];
            }
        }
         
        /// <summary>
        /// Gets all the grades of a students of a specified IdGradeType that are the sons 
        /// of another grade which has value NOT null AND NOT equal to zero
        /// </summary>
        /// <param name="IdStudent"></param>
        /// <param name="IdSchoolYear"></param>
        /// <param name="IdGradeType"></param>
        /// <param name="IdSchoolSubject"></param>
        /// <returns></returns>
        internal DataTable GetMacroGradesOfStudentClosed(int? IdStudent, string IdSchoolYear,
            string IdGradeType, string IdSchoolSubject)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT idGrade, idStudent, value, idSchoolSubject," +
                    "weight, cncFactor, idSchoolYear, datetime(timestamp), idGradeType, " +
                    "idGradeParent,idQuestion" +
                " FROM Grades" +
                " WHERE Grades.idStudent =" + IdStudent +
                " AND Grades.idSchoolYear='" + IdSchoolYear + "'" +
                " AND Grades.idGradeType = '" + IdGradeType + "'" +
                " AND Grades.idSchoolSubject = '" + IdSchoolSubject + "'" +
                " AND Grades.Value > 0" +
                " ORDER BY datetime(Grades.timestamp) Desc;";

                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("ClosedMicroGrades");

                DAdapt.Fill(DSet);
                t = DSet.Tables[0];

                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }

        internal int CreateMacroGrade(ref Grade Grade, Student Student, string IdMicroGradeType)
        {
            int key = NextKey("Grades", "idGrade");
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // find the type of the macro grade of this micrograde
                cmd.CommandText = "SELECT IdGradeTypeParent" +
                    " FROM GradeTypes WHERE idGradetype='" + IdMicroGradeType + "';";
                string IdMacroGrade = (string)cmd.ExecuteScalar();

                // Get the Default Weight of that Grade Type
                cmd.CommandText = "SELECT defaultWeight " +
                    "FROM GradeTypes " +
                    "WHERE idGradeType='" + IdMicroGradeType + "'; ";
                double weight = (double)cmd.ExecuteScalar();

                // add macrograde
                cmd.CommandText = "INSERT INTO Grades " +
                "(idGrade,idStudent,idGradeType,weight,cncFactor,idSchoolYear,timestamp,idSchoolSubject) " +
                "Values (" + key + "," + Student.IdStudent +
                ",'" + IdMacroGrade + "'" +
                "," + SqlVal.SqlDouble(weight) + "" +
                ",0" +
                ",'" + Grade.IdSchoolYear + "','" +
                System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace('.', ':') + "'" +
                ",'" + Grade.IdSchoolSubject +
                "');";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return key;
        }

        internal int? SaveMicroGrade(Grade Grade)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // create a new micro assessment in grades table
                if (Grade == null || Grade.IdGrade == null|| Grade.IdGrade == 0)
                {
                    Grade.IdGrade = NextKey("Grades", "idGrade");
                    cmd.CommandText = "INSERT INTO Grades " +
                    "(idGrade, idGradeType, idGradeParent, idStudent, value, weight, " +
                    "cncFactor,idSchoolYear, timestamp, idQuestion,idSchoolSubject) " +
                    "Values (" + Grade.IdGrade +
                    ",'" + SqlVal.SqlString(Grade.IdGradeType) + "'" +
                    "," +  SqlVal.SqlInt(Grade.IdGradeParent.ToString()) + "" +
                    "," + Grade.IdStudent + "" +
                    "," + SqlVal.SqlDouble(Grade.Value) + "" +
                    "," + SqlVal.SqlDouble(Grade.Weight) + "" +
                    "," + SqlVal.SqlDouble(Grade.CncFactor) + "" +
                    ",'" + SqlVal.SqlString(Grade.IdSchoolYear) + "'" +
                    ",'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace('.', ':') + "'" +
                    "," +  SqlVal.SqlInt(Grade.IdQuestion.ToString()) + "" +
                    ",'" + Grade.IdSchoolSubject + "'" +
                    ");";
                }
                else
                {
                    cmd.CommandText = "UPDATE Grades " +
                    "SET" +
                    " idGrade=" +  SqlVal.SqlInt(Grade.IdGrade.ToString()) + "" +
                    ",idGradeType='" + SqlVal.SqlString(Grade.IdGradeType) + "'" +
                    ",idGradeParent=" +  SqlVal.SqlInt(Grade.IdGradeParent.ToString()) + "" +
                    ",idStudent=" +  SqlVal.SqlInt(Grade.IdStudent.ToString()) + "" +
                    ",idSchoolYear='" + SqlVal.SqlString(Grade.IdSchoolYear) + "'" +
                    ",timestamp='" + SqlVal.SqlString(((DateTime)Grade.Timestamp).ToString("yyyy-MM-dd HH:mm:ss")) + "'" +
                    ",idQuestion='" +  SqlVal.SqlInt(Grade.IdQuestion.ToString()) + "'" +
                    ",idSchoolSubject='" + SqlVal.SqlString(Grade.IdSchoolSubject) + "'" +
                    ",value=" + SqlVal.SqlDouble(Grade.Value) + "" +
                    ",weight=" + SqlVal.SqlDouble(Grade.Weight) + "" +
                    ",cncFactor=" + SqlVal.SqlDouble(Grade.CncFactor) + "" +
                    " WHERE idGrade=" + SqlVal.SqlInt(Grade.IdGrade.ToString()) +
                    ";";
                }

                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return Grade.IdGrade;
        }

        internal List<Student> GetStudentsAndSumOfWeights(Class Class,
            GradeType GradeType, SchoolSubject SchoolSubject,
            DateTime DateFrom, DateTime DateTo)
        {
            List<Student> ls = new List<Student>();

            DataTable t = GetWeightedAveragesOfClass(Class, GradeType.IdGradeType,
                SchoolSubject.IdSchoolSubject, DateFrom, DateTo);
            foreach (DataRow row in t.Rows)
            {
                Student s = GetStudent((int)row["idStudent"]);
                s.Sum = SafeDb.SafeDouble(row["GradesFraction"]);
                s.DummyNumber = SafeDb.SafeDouble(row["GradesCount"]);
                ls.Add(s);
            }
            return ls;
        }

        internal void SaveMacroGrade(int? IdStudent, int? IdParent,
            double Grade, double Weight, string IdSchoolYear,
            string IdSchoolSubject)
        {
            // !!!! TODO !!!! pass a Grade and save all the fields of a grade 
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // creazione del macrovoto nella tabella dei voti  
                cmd.CommandText = "UPDATE Grades " +
                    "SET IdStudent=" + SqlVal.SqlInt(IdStudent) +
                    ",value=" + SqlVal.SqlDouble(Grade) +
                    ",weight=" + SqlVal.SqlDouble(Weight) + 
                    ",idSchoolYear='" + IdSchoolYear + "'" +
                    ",idSchoolSubject='" + IdSchoolSubject +
                    "',timestamp ='" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace('.', ':') + "' " +
                    "WHERE idGrade = " + IdParent +
                    ";";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
        }

        internal double GetDefaultWeightOfGradeType(string IdGradeType)
        {
            double d;
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT defaultWeight " +
                    "FROM GradeTypes " +
                    "WHERE idGradeType='" + IdGradeType + "'; ";
                d = (double)cmd.ExecuteScalar();
                cmd.Dispose();
            }
            return d;
        }

        internal DataTable GetSubGradesOfGrade(int? IdGrade)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT datetime(Grades.timestamp),Questions.text,Grades.value," +
                    " Grades.weight,Grades.cncFactor,Grades.idGradeParent" +
                    " FROM Grades" +
                    " JOIN Questions ON Grades.idQuestion=Questions.idQuestion" +
                    " WHERE Grades.idGradeParent =" + IdGrade +
                    " ORDER BY Grades.timestamp;";

                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("OpenMicroGrades");
                DAdapt.Fill(DSet);
                t = DSet.Tables[0];

                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }

        internal void CloneGrade(DataRow Riga)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // mette peso 0 nel voto precedente  
                cmd.CommandText = "UPDATE Grades " +
                    " SET weight=0" +
                    " WHERE idGrade = " + Riga["idGrade"] +
                    ";";
                cmd.ExecuteNonQuery();
                // crea un nuovo voto copiato dalla riga passata
                int codiceVoto = NextKey("Grades", "idGrade");

                // aggiunge il voto copiato dalla riga passata
                cmd.CommandText = "INSERT INTO Grades " +
                "(idGrade,idStudent,value,weight,cncFactor,idGradeType,idGradeParent,idSchoolYear" +
                ",timestamp,idQuestion) " +
                "Values (" + codiceVoto + "," + Riga["idStudent"] + "," +
                SqlVal.SqlDouble(Riga["value"]) + "," +
                SqlVal.SqlDouble(Riga["weight"]) + ",'" +
                SqlVal.SqlDouble(Riga["cncFactor"]) + ",'" +
                Riga["idGradeType"] + "'," + Riga["idGradeParent"] + ",'" +
                Riga["idSchoolYear"] + "','" +
                System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace('.', ':') +
                //"'," + riga["idQuestion"].ToString() + "" +
                "',NULL" +
                ");";
                cmd.ExecuteNonQuery();

                // aggiusta tutte le domande figlie
                cmd.CommandText = "UPDATE Grades " +
                    " SET idGradeParent=" + codiceVoto +
                    " WHERE idGradeParent = " + Riga["idGrade"] +
                    ";";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
        }

        internal Question CreateNewVoidQuestion()
        {
            // trova una chiave da assegnare alla nuova domanda
            Question q = new Question();
            q.IdQuestion = NextKey("Questions", "idQuestion");
            using (DbConnection conn = dl.Connect())
            {
                string imageSenzaHome = q.Image;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Questions " +
                    "(idQuestion) " +
                    "Values (" + q.IdQuestion + ")" +
                     ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            SaveQuestion(q);
            return q;
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

        internal Question GetQuestionById(int? IdQuestion)
        {
            Question question = new Question();
            if (IdQuestion == 0)
            {
                question.IdQuestion = 0;
                question.Text = ""; 
                return question;
            }
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM Questions " +
                    "WHERE idQuestion=" + IdQuestion.ToString() +
                    ";";
                dRead = cmd.ExecuteReader();
                while (dRead.Read()) // we cycle even if we need just a row, to check if it exists
                {
                    question.IdQuestion = (int)dRead["idQuestion"];
                    question.IdQuestionType = dRead["idQuestionType"].ToString();
                    question.Text = dRead["text"].ToString();
                    question.QuestionImage = dRead["image"].ToString();
                    question.Difficulty = (int)dRead["difficulty"];
                    question.Duration = (int)dRead["duration"];
                    question.IdSchoolSubject = dRead["idSchoolSubject"].ToString();
                    question.IdTopic = (int)dRead["idTopic"];
                    question.Image = dRead["image"].ToString();
                    question.Weight = (double)dRead["weight"];
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return question;
        }

        internal void SaveQuestion(Question Question)
        {
            using (DbConnection conn = dl.Connect())
            {
                string imageNoHome = Question.Image;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Questions " +
                    "SET idQuestionType='" + SqlVal.SqlString(Question.IdQuestionType) + "' " +
                     ", idSchoolSubject='" + SqlVal.SqlString(Question.IdSchoolSubject) + "' " +
                     //", idSubject=" + Question.IdSubject + " " +
                     ", idSchoolSubject='" + Question.IdSchoolSubject + "'" +
                     ", idTopic=" + Question.IdTopic + " " +
                     ", duration=" + Question.Duration + " " +
                     ", difficulty=" + Question.Difficulty + " " +
                     ", text='" + SqlVal.SqlString(Question.Text) + "' " +
                     ", image='" + SqlVal.SqlString(imageNoHome) + "' " +
                     ", weight=" + SqlVal.SqlDouble(Question.Weight.ToString()) + " " +
                    "WHERE idQuestion=" + Question.IdQuestion +
                    ";";
                cmd.ExecuteNonQuery();
                // !!!!TODO sistemare le risposte
                // !!!!TODO gestire i tag
                cmd.Dispose();
            }
        }

        internal DataTable GetFilteredQuestions(List<Tag> Tags, string IdSchoolSubject,
            string IdQuestionType, Topic QuestionsTopic, bool QueryManyTopics, bool TagsAnd)
        {
            DataTable t;

            string subquery = MakeStringForFilteredQuestionsQuery(Tags, IdSchoolSubject, IdQuestionType, QuestionsTopic, QueryManyTopics, TagsAnd);
            string query = "SELECT Questions.IdQuestion,Questions.text,Questions.idSchoolSubject,Questions.idQuestionType" +
                            ",Questions.weight,Questions.duration,Questions.difficulty,Questions.image,Questions.idTopic" +
                            " FROM Questions" +
                            " WHERE Questions.IdQuestion IN(" + subquery + ")" +
                            " ORDER BY Questions.IdQuestion;";
            DataSet DSet;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DSet = new DataSet("FilteredQuestions");
                DAdapt.Fill(DSet);
                DAdapt.Dispose();
                t = DSet.Tables[0];
                DSet.Dispose();
            }
            return t;
        }

        /// <summary>
        /// gets the questions regarding the topics taught to the class that 
        /// haven't been made to the student yet. 
        /// Includes also the questions tha do not have a topic 
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Student"></param>
        /// <param name="Subject"></param>
        /// <returns></returns>
        internal List<Question> GetFilteredQuestionsNotAsked(Student Student, Class Class,
            SchoolSubject Subject, string IdQuestionType, List<Tag> Tags, Topic Topic,
            bool QueryManyTopics, bool TagsAnd, string SearchString,
            DateTime DateFrom, DateTime DateTo)
        {
            List<Question> lq = new List<Question>();
            string filteredQuestions;

            // first part of the query: selection of the interesting fields in Questions
            string query = "SELECT Questions.IdQuestion,Questions.text,Questions.idSchoolSubject,Questions.idQuestionType" +
                ",Questions.weight,Questions.duration,Questions.difficulty,Questions.image,Questions.idTopic" +
                " FROM Questions";
            // add the WHERE clauses
            // if the search string is present, then it must be in the searched field 
            if (SearchString != "")
            {
                query += " WHERE Questions.text LIKE('%" + SqlVal.SqlString(SearchString) + "%')" +
                    "AND (";
            }
            if (Subject != null)
                filteredQuestions = MakeStringForFilteredQuestionsQuery(Tags, Subject.IdSchoolSubject, IdQuestionType,
                    Topic, QueryManyTopics, TagsAnd);
            else
                filteredQuestions = MakeStringForFilteredQuestionsQuery(Tags, "", IdQuestionType,
                    Topic, QueryManyTopics, TagsAnd);

            string questionsAlreadyMade = "";
            if (Student != null)
            {
                questionsAlreadyMade = "SELECT Questions.idQuestion" +
                    " FROM Questions" +
                    " JOIN Grades ON Questions.idQuestion=Grades.idQuestion" +
                    " JOIN Students ON Students.idStudent=Grades.IdStudent" +
                    " WHERE Students.idStudent=" + Student.IdStudent +
                    " AND Grades.idSchoolYear='" + Class.SchoolYear + "'";
            }
            string questionsTopicsMade = "";
            if (Class != null && Subject != null)
            {
                // questions made to the class in every time ever 
                questionsTopicsMade = "SELECT Questions.idQuestion" +
                    " FROM Questions" +
                    " JOIN Lessons_Topics ON Questions.idTopic=Lessons_Topics.idTopic" +
                    " JOIN Lessons ON Lessons_Topics.idLesson=Lessons.idLesson" +
                    " JOIN Classes ON Classes.idClass=Lessons.idClass" +
                    " WHERE Classes.idClass=" + Class.IdClass +
                    " AND (Questions.idSchoolSubject='" + Subject.IdSchoolSubject + "'" +
                    " OR Questions.idSchoolSubject='' OR Questions.idSchoolSubject=NULL)";
                if (DateFrom != Commons.DateNull)
                    questionsTopicsMade += " AND (Lessons.Date BETWEEN " + SqlVal.SqlDate(DateFrom) + " AND " + SqlVal.SqlDate(DateTo) + ")";
                // PART of the final query that extracts the Ids of the questions already made 
                questionsTopicsMade = " Questions.idQuestion IN(" + questionsTopicsMade + ")";
            }

            if (questionsAlreadyMade != "")
            {
                // take only questions already made 
                if (SearchString == "")
                {
                    query += " WHERE Questions.idQuestion NOT IN(" + questionsAlreadyMade + ")";
                }
                else
                {
                    query += " Questions.idQuestion NOT IN(" + questionsAlreadyMade + ")";
                }
            }
            if (filteredQuestions != "")
            {
                if (questionsAlreadyMade != "" || SearchString != "")
                {
                    query += " AND Questions.idQuestion IN(" + filteredQuestions + ")";
                }
                else
                {
                    query += " WHERE Questions.idQuestion IN(" + filteredQuestions + ")";
                }
            }
            query += " OR Questions.idTopic IS NULL OR Questions.idTopic = ''";
            if (SearchString != "")
                query += ")"; 

            query += " ORDER BY Questions.weight;";

            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = query;

                dRead = cmd.ExecuteReader();
                while (dRead.Read()) // 
                {
                    Question questionForList = new Question();

                    questionForList.Difficulty = (int)dRead["difficulty"];
                    questionForList.Duration = (int)dRead["duration"];
                    questionForList.IdQuestion = (int)dRead["idQuestion"];
                    questionForList.IdQuestionType = dRead["idQuestionType"].ToString();
                    questionForList.IdSchoolSubject = dRead["idSchoolSubject"].ToString();
                    //q.idSubject = (int)dRead["idSubject"];
                    questionForList.IdTopic = (int)dRead["idTopic"];
                    questionForList.Image = dRead["image"].ToString();
                    questionForList.QuestionImage = dRead["image"].ToString();
                    questionForList.Text = dRead["text"].ToString();
                    questionForList.Weight = (double)dRead["weight"];

                    lq.Add(questionForList);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return lq;
        }

        private string MakeStringForFilteredQuestionsQuery(List<Tag> Tags, string IdSchoolSubject,
            string IdQuestionType, Topic QuestionsTopic, bool QueryManyTopics, bool TagsAnd)
        {
            string query = "SELECT DISTINCT Questions.idQuestion" +
                            " FROM Questions";
            if (Tags != null && Tags.Count > 0)
            {
                // must join info from table Questions_Tags
                string queryTags = " JOIN Questions_Tags ON Questions.idQuestion=Questions_Tags.idQuestion";

                // make an IN clause, useful for both queries
                string InClause = " WHERE Questions_Tags.idTag IN(";
                foreach (Tag tag in Tags)
                {
                    InClause += "" + tag.IdTag.ToString() + ",";
                }
                InClause = InClause.Substring(0, InClause.Length - 1);
                InClause += ")";

                // (se http://howto.philippkeller.com/2005/04/24/Tags-Database-schemas/, "Toxi" solution)
                if (!TagsAnd)
                {
                    // The tags are evaluated in Union (OR) 
                    // limits the query only to those questions that have been associated to at least one of the tags in the list
                    queryTags += InClause;
                }
                else
                {
                    // The tags are in intersection (AND) 
                    queryTags += InClause;
                    queryTags += " GROUP BY Questions.idQuestion";
                    queryTags += " HAVING COUNT(Questions.idQuestion)=" + Tags.Count;
                }
                query += queryTags;
            }
            if (IdSchoolSubject != "")
            {
                // if we have already added the SQL for tags, we don't need a where
                if (Tags != null && Tags.Count > 0)
                    query += " AND idSchoolSubject ='" + SqlVal.SqlString(IdSchoolSubject) + "'";
                else
                    query += " WHERE idSchoolSubject ='" + SqlVal.SqlString(IdSchoolSubject) + "'";
            }
            if (IdQuestionType != null && IdQuestionType != "")
            {
                if (IdSchoolSubject != "" || Tags.Count > 0)
                    query += " AND idQuestionType ='" + SqlVal.SqlString(IdQuestionType) + "'";
                else
                    query += " WHERE idQuestionType ='" + SqlVal.SqlString(IdQuestionType) + "'";
            }
            if (QuestionsTopic != null)
            {
                if (!QueryManyTopics)
                {
                    if (IdSchoolSubject != "" || Tags.Count > 0 || IdQuestionType != "")
                        query += " AND idTopic=" + QuestionsTopic.Id + "";
                    else
                        query += " WHERE idTopic=" + QuestionsTopic.Id + "";
                }
                else
                {
                    string queryApplicableTopics = "SELECT idTopic FROM Topics" +
                        " WHERE Topics.leftNode BETWEEN " + QuestionsTopic.LeftNodeOld +
                        " AND " + QuestionsTopic.RightNodeOld;
                    // query the passed Topic, plus all its descendants in the tree
                    if (IdSchoolSubject != "" || Tags.Count > 0 || IdQuestionType != "")
                        query += " AND Questions.IdTopic IN (" + queryApplicableTopics + ")";
                    else
                        query += " WHERE Questions.IdTopic IN (" + queryApplicableTopics + ")";
                }
            }
            return query;
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

        internal List<Tag> GetTagsContaining(string Pattern)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Tag> TagList = new List<Tag>();

            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT *" +
                    " FROM Tags" +
                    " WHERE Tag LIKE '%" + SqlVal.SqlString(Pattern) + "%'" +
                    ";";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Tag t = new Tag();
                    t.IdTag = (int)dRead["IdTag"];
                    t.TagName = (string)dRead["tag"];
                    t.Desc = (string)dRead["Desc"];

                    TagList.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return TagList;
        }

        internal int? CreateNewTag(Tag CurrentTag)
        {
            // trova una chiave da assegnare alla nuova domanda
            CurrentTag.IdTag = NextKey("Tags", "IdTag");
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Tags " +
                    "(IdTag, tag, Desc) " +
                    "Values (" + CurrentTag.IdTag + "," +
                    "'" + CurrentTag.TagName + "'," +
                    "'" + CurrentTag.Desc + "'" +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return CurrentTag.IdTag;
        }

        internal void SaveTag(Tag CurrentTag)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Tags " +
                    " SET IdTag=" + CurrentTag.IdTag + "," +
                    " tag=" + "'" + CurrentTag.TagName + "'," +
                    " Desc=" + "'" + CurrentTag.Desc + "'" +
                    " WHERE idTag=" + CurrentTag.IdTag +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal List<Tag> TagsOfAQuestion(int? IdQuestion)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Tag> l = new List<Tag>();
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT * " +
                    " FROM Questions_Tags, Tags" +
                    " WHERE Tags.IdTag = Questions_Tags.IdTag " +
                    " AND Questions_Tags.idQuestion=" + IdQuestion +
                    " ORDER BY Tags.tag;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Tag t = new Tag();
                    t.Desc = (string)dRead["Desc"];
                    t.IdTag = (int)dRead["IdTag"];
                    t.TagName = (string)dRead["tag"];
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }

            return l;
        }

        internal void AddTagToQuestion(int? IdQuestion, int? IdTag)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Questions_Tags " +
                    "(idQuestion, IdTag) " +
                    "Values (" + IdQuestion + "," +
                    IdTag +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal void AddAnswerToQuestion(int? idQuestion, int? idAnswer)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Answers" +
                    " SET idAnswer=" + idAnswer +
                    " WHERE idQuestion =" + idQuestion +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal int CreateAnswer(Answer currentAnswer)
        {
            // trova una chiave da assegnare alla nuova domanda
            int codice = NextKey("Answers", "idAnswer");
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Answers" +
                    " (idAnswer,idQuestion,showingOrder,text,errorCost,isCorrect,isOpenAnswer)" +
                    " Values (" + codice +
                    "," +  SqlVal.SqlInt(currentAnswer.IdQuestion) +
                    "," +  SqlVal.SqlInt(currentAnswer.ShowingOrder) +
                    ",'" + SqlVal.SqlString(currentAnswer.Text) + "'" +
                    "," + SqlVal.SqlDouble(currentAnswer.ErrorCost) +
                    "," + SqlVal.SqlBool(currentAnswer.IsCorrect) +
                    "," + SqlVal.SqlBool(currentAnswer.IsOpenAnswer) +
                    ");";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return codice;
        }
        internal void SaveAnswer(Answer currentAnswer)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Answers" +
                    " SET idAnswer=" + currentAnswer.IdAnswer + "," +
                    " idQuestion=" + currentAnswer.IdQuestion + "," +
                    " isCorrect='" + SqlVal.SqlBool(currentAnswer.IsCorrect) + "'," +
                    " isOpenAnswer='" + SqlVal.SqlBool(currentAnswer.IsOpenAnswer) + "'," +
                    " Text='" + SqlVal.SqlString(currentAnswer.Text) + "'," +
                    " errorCost=" + SqlVal.SqlDouble(currentAnswer.ErrorCost.ToString()) + "" +
                    " WHERE idAnswer = " + currentAnswer.IdAnswer +
                    ";";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
        }

        internal List<Answer> GetAnswersOfAQuestion(int? idQuestion)
        {
            List<Answer> l = new List<Answer>();
            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = dl.Connect())
            {
                string query = "SELECT *" +
                    " FROM Answers" +
                    " WHERE idQuestion=" + idQuestion +
                    " ORDER BY showingOrder;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Answer t = new Answer();
                    t.IdAnswer = (int)dRead["idAnswer"];
                    t.IdQuestion = (int)dRead["idQuestion"];
                    t.ShowingOrder = (int)dRead["showingOrder"];
                    t.Text = (string)dRead["text"];
                    t.IdAnswer = (int)dRead["idAnswer"];
                    t.ErrorCost = (int)dRead["errorCost"];
                    t.IsCorrect = SafeDb.SafeBool(dRead["isCorrect"]);
                    t.IsOpenAnswer = SafeDb.SafeBool(dRead["isOpenAnswer"]);

                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal List<Image> GetAllImagesShownToAClassDuringLessons(Class Class, SchoolSubject Subject,
            DateTime DateStart = default(DateTime), DateTime DateFinish = default(DateTime))
        {
            List<Image> images = new List<Image>();

            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = dl.Connect())
            {
                cmd = conn.CreateCommand();
                string query;
                query = "SELECT * FROM Images" +
                        " JOIN Lessons_Images ON Images.idImage=Lessons_Images.idImage" +
                        " JOIN Lessons ON Lessons.idLesson=Lessons_Images.idLesson" +
                        " WHERE Lessons.idClass=" + Class.IdClass +
                        " AND Lessons.idSchoolSubject='" + Subject.IdSchoolSubject + "'";
                if (DateStart != default(DateTime) && DateFinish != default(DateTime))
                    query += " AND Lessons.date BETWEEN " +
                    SqlVal.SqlDate(DateStart) + " AND " + SqlVal.SqlDate(DateFinish);
                query += ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Image i = new Image();
                    i.IdImage = (int)dRead["IdImage"];
                    i.Caption = (string)dRead["Caption"];
                    i.RelativePathAndFilename = (string)dRead["ImagePath"];

                    images.Add(i);
                }
                cmd.Dispose();
                dRead.Dispose();
            }
            return images;
        }

        internal List<string> GetCaptionsOfThisImage(string FileName)
        {
            List<string> captions = new List<string>();

            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = dl.Connect())
            {
                cmd = conn.CreateCommand();
                string query;
                query = "SELECT Caption FROM Images" +
                        " WHERE imagePath LIKE '%" + FileName + "%'";
                query += ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    captions.Add((string)dRead["Caption"]);
                }
                cmd.Dispose();
                dRead.Dispose();
            }
            return captions;
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

            using (DbConnection conn = dl.Connect())
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
                            types += "\"" + SafeDb.SafeString(dRead.GetDataTypeName(i)) + "\"\t";
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
                            values += "\"" + SafeDb.SafeString(dRead.GetValue(i).ToString()) + "\"\t";
                        }
                        fileContent += values.Substring(0, values.Length - 1) + "\r\n";
                    }
                    else
                    {

                    }
                    y++;
                }
                TextFile.StringToFile(Commons.PathDatabase + "\\" + TableName + ".tsv", fileContent, false);
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

            using (DbConnection conn = dl.Connect())
            {
                dAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                dSet = new DataSet("GetTable");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                t.WriteXml(Commons.PathDatabase + "\\" + TableName + ".xml",
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
            using (DbConnection conn = dl.Connect())
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
                //                valuesString += "'" + SqlVal.SqlString(dati[row, col]) + "',";
                //            else if (fieldTypes[col].IndexOf("INT") >= 0)
                //                valuesString +=  SqlVal.SqlInt(dati[row, col]) + ",";
                //            else if (fieldTypes[col].IndexOf("REAL") >= 0)
                //                valuesString += SqlFloat(dati[row, col]) + ",";
                //            else if (fieldTypes[col].IndexOf("FLOAT") >= 0)
                //                valuesString += SqlFloat(dati[row, col]) + ",";
                //            else if (fieldTypes[col].IndexOf("DATE") >= 0)
                //                valuesString += SqlVal.SqlDate(dati[row, col]) + ",";
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
            using (DbConnection conn = dl.Connect())
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
                                    cmd.CommandText += "'" + SqlVal.SqlString(row[c.ColumnName].ToString()) + "',";
                                    break;
                                };
                            case TypeCode.DateTime:
                                {
                                    DateTime? d = SafeDb.SafeDateTime(row[c.ColumnName]);
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

        internal void DeleteOneStudentFromClass(int? IdDeletingStudent, int? IdClass)
        {
            using (DbConnection conn = dl.Connect())
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

        internal void EraseAllStudentsOfAClass(Class Class)
        {
            using (DbConnection conn = dl.Connect())
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

        private Nullable<int> GetStudentsPhotoId(int? idStudent, string schoolYear, DbConnection conn)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idStudentsPhoto FROM StudentsPhotos_Students " +
                "WHERE idStudent=" + idStudent + " AND idSchoolYear=" + schoolYear + "" +
                ";";
            return (int?)cmd.ExecuteScalar();
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
        internal School GetSchool(string OfficialSchoolAbbreviation)
        {
            // !!!! TODO read school info from the database !!!!
            School news = new School();
            // the next should be a real integer id, 
            news.IdSchool = Commons.IdSchool; 
            news.Name = "IS Pascal Comandini";
            news.Desc = "Istituto Di Istruzione Superiore Pascal-Comandini, Cesena";
            news.OfficialSchoolAbbreviation = Commons.IdSchool;
            return news;
        }
        internal int CreateNewTopic(Topic NewTopic)
        {
            int nextId;
            using (DbConnection conn = dl.Connect())
            {
                nextId = NextKey("Topics", "idTopic");

                DbCommand cmd = conn.CreateCommand();
                // aggiunge la foto alle foto (cartella relativa, cui verrà aggiunta la path delle foto)
                cmd.CommandText = "INSERT INTO Topics " +
                "(idTopic,name,desc,leftNode,rightNode,parentNode,childNumber)" +
                "Values " +
                "(" + nextId + ",'" + SqlVal.SqlString(NewTopic.Name) + "','" +
                SqlVal.SqlString(NewTopic.Desc) + "'," +  SqlVal.SqlInt(NewTopic.LeftNodeNew.ToString()) + "," +
                 SqlVal.SqlInt(NewTopic.RightNodeNew.ToString()) + "," +  SqlVal.SqlInt(NewTopic.ParentNodeNew.ToString()) +
                "," + SqlVal.SqlInt(NewTopic.ChildNumberNew.ToString()) +
                ");";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return nextId;
        }
        internal void EraseAllTopics()
        {
            using (DbConnection conn = dl.Connect())
            {   // erase all the topics
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Topics;";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        /// <summary>
        /// Gets the record of the Topic from the database, 
        /// </summary>
        /// <param name="dRead"></param>
        /// <returns></returns>
        internal Topic GetTopicFromRow(DbDataReader dRead)
        {
            Topic t = new Topic();
            t.Id = SafeDb.SafeInt(dRead["IdTopic"]);
            t.Name = SafeDb.SafeString(dRead["name"]);
            t.Desc = SafeDb.SafeString(dRead["desc"]);
            t.LeftNodeOld = SafeDb.SafeInt(dRead["leftNode"]);
            t.LeftNodeNew = -1;
            t.RightNodeOld = SafeDb.SafeInt(dRead["rightNode"]);
            t.RightNodeNew = -1;
            t.ParentNodeOld = SafeDb.SafeInt(dRead["parentNode"]);
            t.ParentNodeNew = -1;
            t.ChildNumberOld = SafeDb.SafeInt(dRead["childNumber"]);
            t.ChildNumberNew = -1;
            t.Changed = false;

            return t;
        }
        internal Topic GetTopicById(int? idTopic)
        {
            Topic t = new Topic();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " WHERE idTopic=" + idTopic;
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    t = GetTopicFromRow(dRead);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return t;
        }
        internal List<Topic> GetTopics()
        {
            List<Topic> lt = new List<Topic>();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " ORDER BY IdTopic;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    lt.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return lt;
        }
        internal List<Topic> GetTopicsNotDoneFromThisTopic(Class Class, Topic Topic,
            SchoolSubject Subject)
        {
            // node numbering according to Modified Preorder Tree Traversal algorithm
            List<Topic> l = new List<Topic>();
            using (DbConnection conn = dl.Connect())
            {
                // find descendant topics that aren't done  
                DbCommand cmd = conn.CreateCommand();
                //!!!! TODO aggiustare la logica
                string query = "SELECT *" +
                    " FROM Topics" +
                    " LEFT JOIN Lessons_Topics ON Lessons_Topics.idTopic = Topics.idTopic" +
                    " JOIN Lessons ON Lessons_Topics.idLesson = Lessons.IdLesson" +
                    " WHERE leftNode BETWEEN " + Topic.LeftNodeOld +
                    " AND " + Topic.RightNodeOld +
                    " AND Lessons_Topics.idLesson IS null" +
                    " AND Lessons.idClass = " + Class.IdClass +
                    " AND Lessons.idSchoolSubject ='" + Subject.IdSchoolSubject + "'" +
                    " ORDER BY leftNode ASC;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal List<Topic> GetTopicsDoneFromThisTopic(Class Class, Topic StartTopic,
            SchoolSubject Subject)
        {
            // node order according to Modified Preorder Tree Traversal algorithm
            List<Topic> l = new List<Topic>();
            if (Class == null)
                return l;
            using (DbConnection conn = dl.Connect())
            {
                // find descendant topics that are done  
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " JOIN Lessons_Topics ON Lessons_Topics.idTopic = Topics.idTopic " +
                    " JOIN Lessons ON Lessons_Topics.idLesson = Lessons.idLesson" +
                    " WHERE leftNode BETWEEN " + StartTopic.LeftNodeOld +
                    " AND " + StartTopic.RightNodeOld;
                if (Class != null)
                    query += " AND Lessons.idClass = " + Class.IdClass; 
                if(Subject != null)
                    query += " AND Lessons.idSchoolSubject ='" + Subject.IdSchoolSubject + "'" +
                    " ORDER BY leftNode ASC;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal List<Topic> GetAllTopicsDoneInClassAndSubject(Class Class,
            SchoolSubject Subject, 
            DateTime DateStart = default(DateTime), DateTime DateFinish = default(DateTime))
        {
            // node order according to Modified Preorder Tree Traversal algorithm
            List<Topic> l = new List<Topic>();
            using (DbConnection conn = dl.Connect())
            {
                // find topics that are done in a lesson of given class about and given subject 
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Topics" +
                    " JOIN Lessons_Topics ON Lessons_Topics.idTopic = Topics.idTopic " +
                    " JOIN Lessons ON Lessons_Topics.idLesson = Lessons.idLesson" +
                    " JOIN Classes ON Classes.idClass = Lessons.idClass" +
                    " WHERE Lessons.idClass = " + Class.IdClass +
                    " AND Lessons.idSchoolSubject ='" + Subject.IdSchoolSubject + "'";
                if (DateStart != default(DateTime) && DateFinish != default(DateTime))
                    query += " AND Lessons.date BETWEEN " +
                    SqlVal.SqlDate(DateStart) + " AND " + SqlVal.SqlDate(DateFinish); 
                    query += " ORDER BY Lessons.date ASC;";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    l.Add(t);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }
        internal List<Topic> GetTopicsDoneInPeriod(Class currentClass, SchoolSubject currentSubject,
            DateTime DateFrom, DateTime DateTo)
        {
            List<Topic> lt = new List<Topic>();
            using (DbConnection conn = dl.Connect())
            {
                DateTo = DateTo.AddDays(1); // add one day for lesson after 0 and to midnight 
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT Topics.idTopic,Topics.name,Topics.desc,Topics.LeftNode,Topics.RightNode," +
                    "Topics.ParentNode, Topics.childNumber, Lessons.date,Lessons.idSchoolSubject" +
                    " FROM Topics" +
                    " JOIN Lessons_Topics ON Lessons_Topics.IdTopic=Topics.IdTopic" +
                    " JOIN Lessons ON Lessons_Topics.IdLesson=Lessons.IdLesson" +
                    " WHERE Lessons.IdClass=" + currentClass.IdClass +
                    " AND Lessons.idSchoolSubject='" + currentSubject.IdSchoolSubject + "'";
                if (DateFrom == Commons.DateNull)
                {
                    query += " AND (Lessons.Date BETWEEN '" + DateFrom.ToString("yyyy-MM-dd") + "'" +
                        " AND '" + DateTo.ToString("yyyy-MM-dd") + "')";
                }
                query += " ORDER BY Lessons.date DESC" +
                ";";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    t.Id = (int)dRead["IdTopic"];
                    t.Name = (string)dRead["name"];
                    t.Desc = (string)dRead["desc"];
                    //t.LeftNodeNew = -1;
                    //t.RightNodeNew = -1;
                    t.Date = (DateTime)dRead["date"]; // taken fron the Lessons table 

                    // determine the path while still in the database
                    // if we don't, determination from the outside would be too costly 
                    query = "SELECT idTopic, name, desc, leftNode, rightNode" +
                        " FROM Topics" +
                        " WHERE leftNode <=" + t.LeftNodeOld +
                        " AND rightNode >=" + t.RightNodeOld +
                        " ORDER BY leftNode ASC;)";
                    cmd = new SQLiteCommand(query);
                    cmd.Connection = conn;
                    DbDataReader dRead1 = cmd.ExecuteReader();
                    string path = "";
                    while (dRead1.Read())
                    {
                        path += ((string)dRead1["name"]).Trim() + "|";
                    }
                    //t.Path = path;
                    t.Changed = false;
                    lt.Add(t);
                    dRead1.Dispose();
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return lt;
        }
        internal int GetTopicDescendantsNumber(int? LeftNode, int? RightNode)
        {
            // node numbering according to Modified Preorder Tree Traversal algorithm
            return ((int)RightNode - (int)LeftNode - 1) / 2;
        }
        internal void UpdateTopic(Topic t, DbConnection conn)
        {
            bool leaveConnectionOpen = true;
            if (conn == null)
            {
                conn = dl.Connect();
                leaveConnectionOpen = false;
            }
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Topics" +
                " SET" +
                " name='" + SqlVal.SqlString(t.Name) + "'" +
                ",desc='" + SqlVal.SqlString(t.Desc) + "'" +
                ",parentNode=" + t.ParentNodeNew +
                ",leftNode=" + t.LeftNodeNew +
                ",rightNode=" + t.RightNodeNew +
                ",childNumber=" + t.ChildNumberNew +
                " WHERE idTopic=" + t.Id +
                ";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (!leaveConnectionOpen)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        internal void InsertTopic(Topic t, DbConnection Conn)
        {
            if (t.Id == null || t.Id == 0)
            {
                bool leaveConnectionOpen = true;
                if (Conn == null)
                {
                    Conn = dl.Connect();
                    leaveConnectionOpen = false;
                }
                DbCommand cmd = Conn.CreateCommand();

                cmd.CommandText = "SELECT MAX(IdTopic) FROM Topics;";
                var temp = cmd.ExecuteScalar();
                if (!(temp is DBNull))
                    t.Id = Convert.ToInt32(temp) + 1;
                cmd.CommandText = "INSERT INTO Topics" +
                    " (idTopic,name,desc,leftNode,rightNode,parentNode,childNumber)" +
                    " Values (" +
                    t.Id.ToString() +
                    ",'" + SqlVal.SqlString(t.Name) + "'" +
                    ",'" + SqlVal.SqlString(t.Desc) + "'" +
                    "," + t.LeftNodeNew + "" +
                    "," + t.RightNodeNew + "" +
                    "," + t.ParentNodeNew + "" +
                    "," + t.ChildNumberNew + "" +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (!leaveConnectionOpen)
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }
        }
        internal void SaveTopicsFromScratch(List<Topic> ListTopics)
        {
            ////////BackgroundCanStillSaveTopicsTree = true;
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Topics;";
                cmd.ExecuteNonQuery();
                int key;
                cmd.CommandText = "SELECT MAX(IdTopic) FROM Topics;";
                var temp = cmd.ExecuteScalar();
                if (temp is DBNull)
                    key = 0;
                else
                    key = (int)temp;
                foreach (Topic t in ListTopics)
                {   // insert new nodes
                    {
                        cmd.CommandText = "INSERT INTO Topics" +
                           " (idTopic,name,desc,parentNode,leftNode,rightNode,parentNode)" +
                           " Values (" +
                           (++key).ToString() +
                            ",'" + SqlVal.SqlString(t.Name) + "'" +
                            ",'" + SqlVal.SqlString(t.Desc) + "'" +
                            "," + t.ParentNodeNew + "" +
                            "," + t.LeftNodeNew + "" +
                            "," + t.RightNodeNew + "" +
                            "," + t.ParentNodeNew + "" +
                            ");";
                        cmd.ExecuteNonQuery();
                    }
                }
                cmd.Dispose();
            }
        }
        internal GradeType GetGradeType(string IdGradeType)
        {
            GradeType gt = null;
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM GradeTypes";
                cmd.CommandText += " WHERE idGradeType ='" + IdGradeType + "'";
                cmd.CommandText += ";";
                dRead = cmd.ExecuteReader();
                dRead.Read();
                gt = GetGradeTypeFromRow(dRead);
                dRead.Dispose();
                cmd.Dispose();
            }
            return gt;
        }
        private GradeType GetGradeTypeFromRow(DbDataReader Row)
        {
            if (Row.HasRows)
            {
                GradeType gt = new GradeType();
                gt.IdGradeType = (string)Row["idGradeType"];
                gt.IdGradeTypeParent = SafeDb.SafeString(Row["IdGradeTypeParent"]);
                gt.IdGradeCategory = (string)Row["IdGradeCategory"];
                gt.Name = (string)Row["Name"];
                gt.DefaultWeight = (double)Row["DefaultWeight"];
                gt.Desc = (string)Row["Desc"];
                return gt;
            }
            return null;
        }

        internal List<GradeType> GetListGradeTypes()
        {
            List<GradeType> lg = new List<GradeType>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM GradeTypes;";
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    GradeType gt = GetGradeTypeFromRow(dRead);
                    lg.Add(gt);
                }
                dRead.Dispose();
                cmd.Dispose();
                return lg;
            }
        }

        internal List<QuestionType> GetListQuestionTypes(bool IncludeANullObject)
        {
            List<QuestionType> l = new List<QuestionType>();
            if (IncludeANullObject)
            {
                QuestionType qt = new QuestionType();
                qt.IdQuestionType = "";
                l.Add(qt);
            }
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM QuestionTypes;";
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    QuestionType o = new QuestionType();
                    o.Name = (string)dRead["Name"];
                    o.IdQuestionType = (string)dRead["IdQuestionType"];
                    o.Desc = (string)dRead["Desc"];
                    o.IdQuestionType = (string)dRead["IdQuestionType"];
                    l.Add(o);
                }
                dRead.Dispose();
                cmd.Dispose();
                return l;
            }
        }

        internal int NewLesson(Lesson Lesson)
        {
            int key;
            using (DbConnection conn = dl.Connect())
            {
                key = NextKey("Lessons", "idLesson");
                Lesson.IdLesson = key;
                // add new record to Lessons table
                DbCommand cmd = conn.CreateCommand();
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Lessons" +
                " (idLesson, date, idClass, idSchoolSubject, idSchoolYear, note) " +
                "Values (" +
                "" + Lesson.IdLesson + "" +
                "," + SqlVal.SqlDate(Lesson.Date) + "" +
                "," + Lesson.IdClass + "" +
                ",'" + Lesson.IdSchoolSubject + "'" +
                ",'" + Lesson.IdSchoolYear + "'" +
                ",'" + SqlVal.SqlString(Lesson.Note) + "'" +
                ");";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return key;
        }
        internal void SaveLesson(Lesson Lesson)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Lessons" +
                " SET" +
                " date=" + SqlVal.SqlDate(Lesson.Date) + "," +
                " idClass=" + Lesson.IdClass + "," +
                " idSchoolSubject='" + Lesson.IdSchoolSubject + "'," +
                " idSchoolYear='" + Lesson.IdSchoolYear + "'," +
                " note='" + SqlVal.SqlString(Lesson.Note) + "'" +
                " WHERE idLesson=" + Lesson.IdLesson +
                ";";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
        }
        internal object GetTopicsOfOneLessonOfClass(Class Class, Lesson Lesson)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter dAdapt;
                DataSet dSet = new DataSet();
                string query = "SELECT Topics.* FROM Lessons" +
                    " LEFT JOIN Lessons_Topics ON Lessons.IdLesson = Lessons_Topics.idLesson" +
                    " LEFT JOIN Topics ON Topics.idTopic = Lessons_Topics.idTopic" +
                    " WHERE idSchoolSubject='" + Lesson.IdSchoolSubject + "'" +
                    " AND Lessons.idSchoolYear='" + Lesson.IdSchoolYear + "'" +
                    " AND Lessons.idClass='" + Class.IdClass + "'" +
                    " AND Lessons.idLesson='" + Lesson.IdLesson + "'" +
                    //" GROUP BY Lessons.idLesson" +
                    " ORDER BY Lessons.date DESC" +
                    ";";
                dAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                dSet = new DataSet("GetOnLessonOfClass");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                dAdapt.Dispose();
                dSet.Dispose();
            }
            return t;
        }
        internal DataTable GetLessonsOfClass(Class Class, Lesson Lesson)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                DataAdapter dAdapt;
                DataSet dSet = new DataSet();
                string query = "SELECT * FROM Lessons" +
                    " WHERE idSchoolSubject='" + Lesson.IdSchoolSubject + "'" +
                    " AND Lessons.idSchoolYear='" + Lesson.IdSchoolYear + "'" +
                    " AND Lessons.idClass='" + Class.IdClass + "'" +
                    //" GROUP BY Lessons.idLesson" +
                    " ORDER BY Lessons.date DESC" +
                    ";";
                dAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                dSet = new DataSet("GetLessonsOfClass");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                dAdapt.Dispose();
                dSet.Dispose();
            }
            return t;
        }
        internal Lesson GetLastLesson(Lesson CurrentLesson)
        {
            using (DbConnection conn = dl.Connect())
            {
                List<Couple> couples = new List<Couple>();
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                Lesson l;
                string query;
                query = "SELECT * FROM Lessons" +
                        " WHERE idClass=" + CurrentLesson.IdClass.ToString() +
                        " AND idSchoolSubject='" + CurrentLesson.IdSchoolSubject + "'" +
                        " AND idSchoolYear='" + CurrentLesson.IdSchoolYear + "'" +
                        " ORDER BY Date DESC LIMIT 1;";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                l = new Lesson();
                while (dRead.Read())
                {
                    l.IdLesson = (int)dRead["idLesson"];
                    l.Date = (DateTime)dRead["Date"];
                    l.IdClass = (int)dRead["idClass"];
                    l.IdSchoolSubject = (string)dRead["idSchoolSubject"];
                    l.Note = (string)dRead["note"];

                    break;
                }
                cmd.Dispose();
                dRead.Dispose();
                return l;
            }
        }
        internal Lesson GetLessonInDate(Class Class, string IdSubject,
            DateTime Date)
        {
            Lesson less = new Lesson();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query;
                query = "SELECT * FROM Lessons" +
                        " WHERE idClass=" + Class.IdClass.ToString() +
                        " AND idSchoolSubject='" + IdSubject + "'" +
                        " AND date BETWEEN " + SqlVal.SqlDate(Date.ToString("yyyy-MM-dd")) +
                        " AND " + SqlVal.SqlDate(Date.AddDays(1).ToString("yyyy-MM-dd")) +
                        " LIMIT 1;";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    less.IdLesson = (int)dRead["idLesson"];
                    less.Date = (DateTime)dRead["Date"];
                    less.IdClass = (int)dRead["idClass"];
                    less.IdSchoolSubject = (string)dRead["idSchoolSubject"];
                    less.Note = (string)dRead["note"];

                    break; // there should be only one record in the query result 
                }
                cmd.Dispose();
                dRead.Dispose();
            }
            return less;
        }
        internal void EraseLesson(int? IdLesson, bool AlsoEraseImageFiles)
        {
            using (DbConnection conn = dl.Connect())
            {
                // erase existing links topic-lesson
                DbCommand cmd = conn.CreateCommand();
                string query = "DELETE FROM Lessons_Topics" +
                        " WHERE idLesson=" + IdLesson.ToString() +
                        ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                // erase images' files if permitted
                if (AlsoEraseImageFiles)
                {
                    // !! TODO !! find the images that aren't linked to another lesson and delete
                    // the files if EraseImageFiles is set 
                    throw new NotImplementedException();
                }

                // erase existing links images-lesson
                cmd = conn.CreateCommand();
                query = "DELETE FROM Lessons_Images" +
                        " WHERE idLesson=" + IdLesson.ToString() +
                        ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                // erase the lesson's row from lessons
                cmd = conn.CreateCommand();
                query = "DELETE FROM Lessons" +
                        " WHERE idLesson=" + IdLesson.ToString() +
                        ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal void SaveTopicsOfLesson(int? IdLesson, List<Topic> topicsOfTheLesson)
        {
            using (DbConnection conn = dl.Connect())
            {
                // erase existing links topic-lesson
                DbCommand cmd = conn.CreateCommand();
                string query = "DELETE FROM Lessons_Topics" +
                        " WHERE idLesson=" + IdLesson.ToString() +
                        ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                int insertionOrder = 1;
                foreach (Topic t in topicsOfTheLesson)
                {
                    // insert links topic-lesson, one at a time 
                    cmd.CommandText = "INSERT INTO Lessons_Topics" +
                    " (idLesson, idTopic, insertionOrder)" +
                    " Values (" +
                    "" + IdLesson + "" +
                    "," + t.Id +
                    "," + insertionOrder++ +
                    ");";
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }

                    catch (Exception e)
                    {
                        {
                            // if it isn't UNIQUE, then it is error (to cure!!!!)
                            // but actually it doesn't matter too much, because
                            // the lesson is already linked to the topic anyway.. 


                        }
                    }
                }
                cmd.Dispose();
            }
        }
        internal List<Topic> GetTopicsOfLesson(int? IdLesson, List<Topic> topicsOfTheLesson)
        {
            if (IdLesson == null)
            {
                return null; 
            }
            // order by ensures that the order of the result is the order of insertion 
            // in the database (that was the same of the tree traversal) 
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                DbDataReader dRead;
                string query;
                query = "SELECT * FROM Topics" +
                        " JOIN Lessons_Topics ON Topics.idTopic=Lessons_Topics.idTopic" +
                        " WHERE Lessons_Topics.idLesson=" + IdLesson +
                        " ORDER BY insertionOrder" +
                        ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Topic t = GetTopicFromRow(dRead);
                    topicsOfTheLesson.Add(t);
                }
                cmd.Dispose();
                dRead.Dispose();
            }
            return topicsOfTheLesson;
        }
        internal List<Image> GetLessonsImagesList(Lesson Lesson)
        {
            if (Lesson.IdLesson == null)
                return null;

            List<Image> imagesOfTheLesson = new List<Image>();

            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                DbDataReader dRead;
                string query;
                query = "SELECT * FROM Images" +
                        " JOIN Lessons_Images ON Images.idImage=Lessons_Images.idImage" +
                        " WHERE Lessons_Images.idLesson=" + Lesson.IdLesson +
                        ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Image i = new Image();
                    i.IdImage = (int)dRead["IdImage"];
                    i.Caption = (string)dRead["Caption"];
                    i.RelativePathAndFilename = (string)dRead["ImagePath"];

                    imagesOfTheLesson.Add(i);
                }
                cmd.Dispose();
                dRead.Dispose();
            }
            return imagesOfTheLesson;
        }
        /// <summary>
        /// Creates a new Image in Images and links it to the lesson
        /// If the image has an id != 0, it exists and is not created 
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="Lesson"></param>
        /// <returns></returns>
        internal int? LinkOneImage(Image Image, Lesson Lesson)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query;
                if (Image.IdImage == 0)
                {
                    Image.IdImage = NextKey("Images", "IdImage");
                    query = "INSERT INTO Images" +
                    " (idImage, imagePath, caption)" +
                    " Values (" + Image.IdImage + ",'" +
                    SqlVal.SqlString(Image.RelativePathAndFilename) + "','" +
                    SqlVal.SqlString(Image.Caption) + "'" +
                    ");";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                query = "INSERT INTO Lessons_Images" +
                    " (idImage, idLesson)" +
                    " Values (" + Image.IdImage + "," + Lesson.IdLesson + "" +
                    ");";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            return Image.IdImage;
        }

        internal void RemoveImageFromLesson(Lesson Lesson, Image Image,
            bool AlsoEraseImageFile)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query;
                query = "DELETE FROM Lessons_Images" +
                    " WHERE idImage=" +
                    Image.IdImage +
                    ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                if (AlsoEraseImageFile)
                {

                    query = "DELETE FROM Images" +
                        " WHERE idImage=" +
                        Image.IdImage +
                        ";";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    try
                    {
                        File.Delete(Commons.PathImages + "\\" + Image.RelativePathAndFilename);
                    }
                    catch (Exception ex)
                    {
                        Commons.ErrorLog("DbLayer|RemoveImageFromLesson|" +
                            Commons.PathImages + "\\" + Image.RelativePathAndFilename +
                            ".\r\n" + ex.Message + ex.StackTrace, true);
                    }
                }
                cmd.Dispose();
            }
        }

        internal void SaveImage(Image Image)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query;
                query = "UPDATE Images" +
                    " SET caption='" + SqlVal.SqlString(Image.Caption) + "'" +
                    " WHERE idImage=" +
                    Image.IdImage +
                    ";";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
        }

        internal Image FindImageWithGivenFile(string PathAndFileNameOfImage)
        {
            Image i = new Image();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                DbDataReader dRead;
                string query;
                query = "SELECT * FROM Images" +
                        " WHERE Images.imagePath='" +
                        SqlVal.SqlString(PathAndFileNameOfImage.Remove(0, Commons.PathImages.Length + 1)) +
                        "';";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                dRead.Read(); // just one record ! 
                if (!dRead.HasRows)
                    return null;
                i.IdImage = (int)dRead["IdImage"];
                i.Caption = (string)dRead["Caption"];
                i.RelativePathAndFilename = (string)dRead["ImagePath"];
                cmd.Dispose();
                dRead.Dispose();
            }
            return i;
        }
        internal List<SchoolPeriod> GetSchoolPeriodsOfDate(DateTime Date)
        {
            List<SchoolPeriod> l = new List<SchoolPeriod>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *" +
                    " FROM SchoolPeriods" +
                    " WHERE " + SqlVal.SqlDate(Date) +
                    " BETWEEN dateStart and dateFinish" +
                    ";";
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    SchoolPeriod p = GetOneSchoolPeriodFromRow(dRead);
                    l.Add(p);
                }
            }
            return l;
        }

        internal List<SchoolPeriod> GetSchoolPeriods(string IdSchoolYear)
        {
            List<SchoolPeriod> l = new List<SchoolPeriod>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM SchoolPeriods " +
                    "WHERE idSchoolYear=" + IdSchoolYear +
                    " OR IdSchoolYear IS null OR IdSchoolYear=''" +
                    ";";
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    SchoolPeriod p = GetOneSchoolPeriodFromRow(dRead);
                    l.Add(p);
                }
            }
            return l;
        }

        internal SchoolPeriod GetOneSchoolPeriodFromRow(DbDataReader Row)
        {
            SchoolPeriod p = new SchoolPeriod();
            p.IdSchoolPeriodType = SafeDb.SafeString(Row["idSchoolPeriodType"]);
            if (p.IdSchoolPeriodType != "N")
            {
                p.DateFinish = SafeDb.SafeDateTime(Row["dateFinish"]);
                p.DateStart = SafeDb.SafeDateTime(Row["dateStart"]);
            }
            p.Name = SafeDb.SafeString(Row["name"]);
            p.Desc = SafeDb.SafeString(Row["desc"]);
            p.IdSchoolPeriod = SafeDb.SafeString(Row["idSchoolPeriod"]);
            p.IdSchoolYear = SafeDb.SafeString(Row["idSchoolYear"]);
            return p;
        }
        internal Test GetTestFromRow(DbDataReader Row)
        {
            Test t = new Test();
            t.IdTest = SafeDb.SafeInt(Row["idTest"]);
            t.Name = SafeDb.SafeString(Row["name"]);
            t.Desc = SafeDb.SafeString(Row["desc"]);
            t.IdSchoolSubject = SafeDb.SafeString(Row["IdSchoolSubject"]);
            t.IdTestType = SafeDb.SafeString(Row["IdTestType"]);
            t.IdSchoolSubject = SafeDb.SafeString(Row["IdSchoolSubject"]);
            t.IdTopic = SafeDb.SafeInt(Row["IdTopic"]);

            return t;
        }
        internal Test GetTest(int? IdTest)
        {
            Test t = new Test();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM Tests " +
                    "WHERE IdTest=" + IdTest +
                    ";";
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    t = GetTestFromRow(dRead);
                }
            }
            return t;
        }
        internal List<Test> GetTests()
        {
            List<Test> list = new List<Test>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * " +
                    "FROM Tests " +
                    //"WHERE idSchoolYear=" + IdSchoolYear +
                    //" OR IdSchoolYear IS null OR IdSchoolYear=''" +
                    ";";
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    Test t = GetTestFromRow(dRead);
                    list.Add(t);
                }
            }
            return list;
        }

        internal void SaveTest(Test TestToSave)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                if (TestToSave.IdTest == 0 || TestToSave.IdTest == null)
                {   // create new record
                    int nextId = NextKey("Tests", "idTest");

                    cmd.CommandText = "INSERT INTO Tests " +
                    "(idTest,name,desc,IdSchoolSubject,IdTestType,IdTopic" +
                    ")" +
                    "Values " +
                    "(" + nextId + ",'" + SqlVal.SqlString(TestToSave.Name) + "','" +
                    SqlVal.SqlString(TestToSave.Desc) + "','" + SqlVal.SqlString(TestToSave.IdSchoolSubject) + "'," +
                     SqlVal.SqlInt(TestToSave.IdTestType) + "," +  SqlVal.SqlInt(TestToSave.IdTopic) +
                    ");";
                }
                else
                {   // update old record
                    cmd.CommandText = "UPDATE Tests" +
                    " SET name='" + SqlVal.SqlString(TestToSave.Name) + "'," +
                    "desc='" + SqlVal.SqlString(TestToSave.Desc) + "'" +
                    ",IdSchoolSubject=" + SqlVal.SqlString(TestToSave.IdSchoolSubject) +
                    ",IdTestType=" +  SqlVal.SqlInt(TestToSave.IdTestType) +
                    ",IdTopic=" +  SqlVal.SqlInt(TestToSave.IdTopic) +
                    ")" +
                    " WHERE idTest=" + TestToSave.IdTest +
                    ";";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal List<Question> GetAllQuestionsOfATest(int? IdTest)
        {
            List<Question> lq = new List<Question>();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *" +
                    " FROM Questions" +
                    " JOIN Tests_Questions ON Tests_Questions.IdQuestion=Questions.IdQuestion" +
                    " WHERE Tests_Questions.idTest=" + IdTest +
                    ";";
                DbDataReader dRead;
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    Question q = GetQuestionFromRow(dRead);
                    lq.Add(q);
                }
            }
            return lq;
        }
        internal void AddQuestionToTest(Test Test, Question Question)
        {
            using (DbConnection conn = dl.Connect())
            {
                // get the code of the previous photo
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Tests_Questions" +
                    " (IdTest, IdQuestion)" +
                    " Values" +
                    " (" + Test.IdTest + "," + Question.IdQuestion + ")" +
                    "; ";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal void SaveStudentsAnswer(Student Student, Test Test, Answer Answer,
            bool StudentsBoolAnswer, string StudentsTextAnswer)
        {
            // TODO put this UI matter into form's code 
            if (Student == null)
            {
                MessageBox.Show("Scegliere un allievo");
                return; 
            }
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // find if an answer has already been given
                int? IdStudentsAnswer = StudentHasAnswered(Answer.IdAnswer, Test.IdTest, Student.IdStudent);
                if (IdStudentsAnswer != null)
                {   // update answer
                    cmd.CommandText = "UPDATE StudentsAnswers" +
                    " SET idStudent=" +  SqlVal.SqlInt(Student.IdStudent) + "," +
                    "idAnswer=" +  SqlVal.SqlInt(Answer.IdAnswer) + "," +
                    "studentsBoolAnswer=" + SqlVal.SqlBool(StudentsBoolAnswer) + "," +
                    "studentsTextAnswer='" + SqlVal.SqlString(StudentsTextAnswer) + "'," +
                    "IdTest=" +  SqlVal.SqlInt(Test.IdTest) +
                    "" +
                    " WHERE IdStudentsAnswer=" + Answer.IdAnswer +
                    ";";
                }
                else
                {   // create answer
                    int nextId = NextKey("StudentsAnswers", "IdStudentsAnswer");

                    cmd.CommandText = "INSERT INTO StudentsAnswers " +
                    "(idStudentsAnswer,idStudent,idAnswer,studentsBoolAnswer," +
                    "studentsTextAnswer,IdTest" +
                    ")" +
                    "Values " +
                    "(" + nextId + "," +  SqlVal.SqlInt(Student.IdStudent) + "," +
                     SqlVal.SqlInt(Answer.IdAnswer) + "," + SqlVal.SqlBool(StudentsBoolAnswer) + ",'" +
                    SqlVal.SqlString(StudentsTextAnswer) + "'," +
                     SqlVal.SqlInt(Test.IdTest) +
                    ");";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        private int? StudentHasAnswered(int? IdAnswer, int? IdTest, int? IdStudent)
        {
            int? key;
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT idStudentsAnswer" +
                    " FROM StudentsAnswers" +
                    " WHERE idStudent=" + IdStudent +
                    " AND IdTest=" + IdTest + "" +
                    " AND IdAnswer=" + IdAnswer + "" +
                    ";";
                cmd.CommandText = query;
                //idStudentsAnswer cmd.ExecuteScalar() != null;
                key = (int?)cmd.ExecuteScalar();
            }
            return key;
        }
        internal List<StudentsAnswer> GetAllAnswersOfAStudentToAQuestionOfThisTest(
            int? IdStudent, int? IdQuestion, int? IdTest)
        {
            List<StudentsAnswer> list = new List<StudentsAnswer>(); 
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM StudentsAnswers" +
                    " JOIN Answers ON Answers.idAnswer = StudentsAnswers.idAnswer" +
                    " JOIN Questions ON Questions.IdQuestion = Answers.IdQuestion" +
                    " JOIN Tests_Questions ON Questions.IdQuestion = Tests_Questions.IdQuestion" +
                    " WHERE StudentsAnswers.idStudent=" + IdStudent +
                    " AND Questions.IdQuestion=" + IdQuestion + "" +
                    " AND Tests_Questions.IdTest=" + IdTest + "" +
                    ";";

                cmd.CommandText = query;
                DbDataReader dRead;
                dRead = cmd.ExecuteReader();

                while (dRead.Read())
                {
                    StudentsAnswer a = GetStudentsAnswerFromRow(dRead);
                    list.Add(a);
                }
            }
            return list;
        }

        private StudentsAnswer GetStudentsAnswerFromRow(DbDataReader Row)
        {
            StudentsAnswer a = new StudentsAnswer();
            a.IdAnswer = SafeDb.SafeInt(Row["IdAnswer"]);
            a.IdStudent = SafeDb.SafeInt(Row["IdStudent"]);
            a.IdStudentsAnswer = SafeDb.SafeInt(Row["IdStudentsAnswer"]);
            a.IdTest = SafeDb.SafeInt(Row["IdTest"]);
            a.StudentsBoolAnswer = SafeDb.SafeBool(Row["StudentsBoolAnswer"]);
            a.StudentsTextAnswer = SafeDb.SafeString(Row["StudentsTextAnswer"]);

            return a;
        }

        internal List<Student> GetAllStudentsThatAnsweredToATest(Test Test, Class Class)
        {
            List<Student> list = new List<Student>();
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT DISTINCT StudentsAnswers.IdStudent" +
                    " FROM StudentsAnswers" +
                    " JOIN Classes_Students ON StudentsAnswers.IdStudent=Classes_Students.IdStudent" +
                    " JOIN Students ON Classes_Students.IdStudent=Students.IdStudent" +
                    " WHERE StudentsAnswers.IdTest=" + Test.IdTest + "" +
                    " AND Classes_Students.IdClass=" + Class.IdClass + "" +
                    " ORDER BY Students.LastName, Students.FirstName, Students.IdStudent " +
                    ";";
                cmd.CommandText = query;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    int? idStudent = SafeDb.SafeInt(dRead["idStudent"]);
                    Student s = GetStudent(idStudent);
                    list.Add(s);
                }
            }
            return list;
        }
       
        internal List<Answer> GetAllCorrectAnswersToThisQuestionOfThisTest(int? IdQuestion, int? IdTest)
        {
            List<Answer> list = new List<Answer>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT Answers.*" +
                    " FROM Answers" +
                    " JOIN Questions ON Questions.IdQuestion=Answers.IdQuestion" +
                    " JOIN Tests_Questions ON Questions.IdQuestion=Tests_Questions.IdQuestion" +
                    " WHERE Questions.IdQuestion=" + IdQuestion + "" +
                    " AND Tests_Questions.IdTest=" + IdTest + "" +
                    " ORDER BY idAnswer" +
                    ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Answer a = GetAnswerFromRow(dRead);
                    list.Add(a);
                }
            }
            return list;
        }
        
        internal Answer GetAnswerFromRow(DbDataReader Row)
        {
            Answer a = new Answer();
            a.IdAnswer = SafeDb.SafeInt(Row["IdAnswer"]);
            a.IdQuestion = SafeDb.SafeInt(Row["IdQuestion"]);
            a.ShowingOrder = SafeDb.SafeInt(Row["ShowingOrder"]);
            a.Text = SafeDb.SafeString(Row["Text"]);
            a.ErrorCost = SafeDb.SafeInt(Row["ErrorCost"]);
            a.IsCorrect = SafeDb.SafeBool(Row["IsCorrect"]);
            a.IsOpenAnswer = SafeDb.SafeBool(Row["IsOpenAnswer"]);
            a.IsMutex = SafeDb.SafeBool(Row["IsMutex"]);

            return a;
        }

        internal List<StudentAnnotation> AnnotationsAboutThisStudent(Student currentStudent, string IdSchoolYear, 
            bool IncludeOnlyActiveAnnotations)
        {
            if (currentStudent == null)
                return null; 
            List<StudentAnnotation> la = new List<StudentAnnotation>();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM StudentsAnnotations" +
                    " WHERE StudentsAnnotations.idStudent=" + currentStudent.IdStudent;
                if (IdSchoolYear != null && IdSchoolYear != "")
                    query += " AND idSchoolYear=" + IdSchoolYear;
                if (IncludeOnlyActiveAnnotations)
                    query += " AND isActive=true";
                query += " ORDER BY instantTaken DESC, instantClosed DESC";
                query += ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    StudentAnnotation a = GetAnnotationFromRow(dRead);
                    la.Add(a);
                }
            }
            return la;
        }

        private StudentAnnotation GetAnnotationFromRow(DbDataReader Row)
        {
            StudentAnnotation a = new StudentAnnotation();
            a.IdAnnotation = SafeDb.SafeInt(Row["idAnnotation"]);
            a.IdStudent = SafeDb.SafeInt(Row["idStudent"]);
            a.IdSchoolYear = SafeDb.SafeString(Row["idSchoolYear"]);
            a.Annotation = SafeDb.SafeString(Row["annotation"]);
            a.InstantTaken = SafeDb.SafeDateTime(Row["instantTaken"]);
            a.InstantClosed = SafeDb.SafeDateTime(Row["instantClosed"]);
            a.IsActive = SafeDb.SafeBool(Row["isActive"]);
            return a;
        }

        internal int? SaveAnnotation(StudentAnnotation Annotation, Student s)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "";
                // find if an answer has already been given
                if (Annotation.IdAnnotation != null && Annotation.IdAnnotation != 0)
                {   // update answer
                    query = "UPDATE StudentsAnnotations" +
                    " SET" +
                    " idStudent=" + SqlVal.SqlInt(s.IdStudent) + "," +
                    " idSchoolYear='" + SqlVal.SqlString(Annotation.IdSchoolYear) + "'," +
                    " instantTaken=" + SqlVal.SqlDate(Annotation.InstantTaken) + "," +
                    " instantClosed=" + SqlVal.SqlDate(Annotation.InstantClosed) + "," +
                    " isActive=" + SqlVal.SqlBool(Annotation.IsActive) + "," +
                    " annotation='" + SqlVal.SqlString(Annotation.Annotation) + "'" +
                    " WHERE idStudent=" +  SqlVal.SqlInt(s.IdStudent) +
                    ";";
                }
                else
                {
                    Annotation.InstantTaken = DateTime.Now;
                    Annotation.IsActive = true; 
                    // create answer on database
                    int? nextId = NextKey("StudentsAnnotations", "IdAnnotation");
                    Annotation.IdAnnotation = nextId;

                    query = "INSERT INTO StudentsAnnotations " +
                    "(idAnnotation, idStudent, annotation,instantTaken," +
                    "instantClosed,isActive";
                    if (Annotation.IdSchoolYear != null && Annotation.IdSchoolYear != "")
                        query += ",idSchoolYear";
                    query += ")";
                    query += " Values(";
                    query += "" + SqlVal.SqlInt(Annotation.IdAnnotation) + ",";
                    query += "" + SqlVal.SqlInt(s.IdStudent) + ",";
                    query += "'" + SqlVal.SqlString(Annotation.Annotation) + "'";
                    query += "," + SqlVal.SqlDate(Annotation.InstantTaken);
                    query += "," + SqlVal.SqlDate(Annotation.InstantClosed);
                    query += "," + SqlVal.SqlBool(Annotation.IsActive);
                    if (Annotation.IdSchoolYear != null && Annotation.IdSchoolYear != "")
                        query += ",'" + SqlVal.SqlString(Annotation.IdSchoolYear) + "'";
                    query += ");";
                }
                cmd.CommandText = query; 
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return Annotation.IdAnnotation; 
        }

        internal StudentAnnotation GetAnnotation(int? IdAnnotation)
        {
            StudentAnnotation a;
            if (IdAnnotation == null)
                return null; 
            a = new StudentAnnotation();
            using (DbConnection conn = dl.Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM StudentsAnnotations" +
                    " WHERE IdAnnotation=" + IdAnnotation;
                query += ";";
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                dRead.Read(); 
                a = GetAnnotationFromRow(dRead);
                cmd.Dispose(); 
            }
            return a;
        }

        internal DataTable GetStudentsWithNoMicrogrades(Class Class, string IdGradeType, string IdSchoolSubject, 
            DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = dl.Connect())
            {
                // find the macro grade type of the micro grade
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idGradeTypeParent " +
                    "FROM GradeTypes " +
                    "WHERE idGradeType='" + IdGradeType + "'; ";
                string idGradeTypeParent = (string)cmd.ExecuteScalar();

                string query = "SELECT Students.idStudent, LastName, FirstName FROM Students" +
                    " JOIN Classes_Students ON Students.idStudent=Classes_Students.idStudent" +
                    " WHERE Students.idStudent NOT IN" +
                    "(";
                query += "SELECT DISTINCT Students.idStudent" +
                " FROM Classes_Students" +
                " LEFT JOIN Grades ON Students.idStudent=Grades.idStudent" +
                " JOIN Students ON Classes_Students.idStudent=Students.idStudent" +
                " WHERE Classes_Students.idClass =" + Class.IdClass +
                " AND Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                " AND (Grades.idGradeType='" + IdGradeType + "'" +
                " OR Grades.idGradeType IS NULL)" +
                " AND Grades.idSchoolSubject='" + IdSchoolSubject + "'" +
                " AND Grades.value IS NOT NULL AND Grades.value <> 0" +
                " AND Grades.Timestamp BETWEEN " + SqlVal.SqlDate(DateFrom) + " AND " + SqlVal.SqlDate(DateTo) +
                ")";
                query += " AND Classes_Students.idClass=" + Class.IdClass;
                query += ";";
                DataAdapter DAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                DataSet DSet = new DataSet("ClosedMicroGrades");

                DAdapt.Fill(DSet);
                t = DSet.Tables[0];

                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }

        internal void EraseAnnotationById(int? IdAnnotation)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                    " WHERE idAnnotation=" + SqlVal.SqlInt(IdAnnotation) +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal void EraseAnnotationByText(string AnnotationText, Student Student)
        {
            using (DbConnection conn = dl.Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                    " WHERE annotation='" + SqlVal.SqlString(AnnotationText) + "'" +
                    " AND idStudent=" + SqlVal.SqlInt(Student.IdStudent) +
                    ";";
                    cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        #endregion
    }
}
