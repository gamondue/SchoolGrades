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
    class AnswersGradesAndStudentData
    {
        DataLayer dl = new DataLayer();

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
                if (Grade == null || Grade.IdGrade == null || Grade.IdGrade == 0)
                {
                    Grade.IdGrade = NextKey("Grades", "idGrade");
                    cmd.CommandText = "INSERT INTO Grades " +
                    "(idGrade, idGradeType, idGradeParent, idStudent, value, weight, " +
                    "cncFactor,idSchoolYear, timestamp, idQuestion,idSchoolSubject) " +
                    "Values (" + Grade.IdGrade +
                    ",'" + SqlVal.SqlString(Grade.IdGradeType) + "'" +
                    "," + SqlVal.SqlInt(Grade.IdGradeParent.ToString()) + "" +
                    "," + Grade.IdStudent + "" +
                    "," + SqlVal.SqlDouble(Grade.Value) + "" +
                    "," + SqlVal.SqlDouble(Grade.Weight) + "" +
                    "," + SqlVal.SqlDouble(Grade.CncFactor) + "" +
                    ",'" + SqlVal.SqlString(Grade.IdSchoolYear) + "'" +
                    ",'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace('.', ':') + "'" +
                    "," + SqlVal.SqlInt(Grade.IdQuestion.ToString()) + "" +
                    ",'" + Grade.IdSchoolSubject + "'" +
                    ");";
                }
                else
                {
                    cmd.CommandText = "UPDATE Grades " +
                    "SET" +
                    " idGrade=" + SqlVal.SqlInt(Grade.IdGrade.ToString()) + "" +
                    ",idGradeType='" + SqlVal.SqlString(Grade.IdGradeType) + "'" +
                    ",idGradeParent=" + SqlVal.SqlInt(Grade.IdGradeParent.ToString()) + "" +
                    ",idStudent=" + SqlVal.SqlInt(Grade.IdStudent.ToString()) + "" +
                    ",idSchoolYear='" + SqlVal.SqlString(Grade.IdSchoolYear) + "'" +
                    ",timestamp='" + SqlVal.SqlString(((DateTime)Grade.Timestamp).ToString("yyyy-MM-dd HH:mm:ss")) + "'" +
                    ",idQuestion='" + SqlVal.SqlInt(Grade.IdQuestion.ToString()) + "'" +
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
                    "," + SqlVal.SqlInt(currentAnswer.IdQuestion) +
                    "," + SqlVal.SqlInt(currentAnswer.ShowingOrder) +
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
    }
}
