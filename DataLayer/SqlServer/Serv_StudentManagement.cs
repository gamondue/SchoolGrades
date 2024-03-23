using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SchoolGrades
{
    internal partial class SqlServer_DataLayer : DataLayer
    {
        internal override Student CreateStudentFromStringMatrix(string[,] StudentData, int? StudentRow)
        {
            // look if exists a student with same name, last name, birth date and place
            Student s = new Student();
            s.RegisterNumber = StudentData[(int)StudentRow, 0];
            s.LastName = StudentData[(int)StudentRow, 1];
            s.FirstName = StudentData[(int)StudentRow, 2];
            s.BirthDate = Safe.DateTime(StudentData[(int)StudentRow, 3]);
            s.Residence = StudentData[(int)StudentRow, 4];
            s.Origin = StudentData[(int)StudentRow, 5];
            s.Email = StudentData[(int)StudentRow, 6];
            s.BirthPlace = StudentData[(int)StudentRow, 7];
            s.Eligible = false;

            Student existingStudent = GetStudent(s);
            if (existingStudent == null)
            {
                // not found an existing student: find a key for the new student
                s.IdStudent = NextKey("Students", "idStudent");
                CreateStudent(s);
            }
            else
            {
                // student already exists, uses old data in the fields from the file that are empty
                // LastName, FirstName, BirthDate and BirthPlace are equal! 
                s.IdStudent = existingStudent.IdStudent;
                if (s.Residence == "") s.Residence = existingStudent.Residence;
                if (s.Origin == "") s.Origin = existingStudent.Origin;
                if (s.Email == "") s.Email = existingStudent.Email;
                if (s.RegisterNumber == "") s.RegisterNumber = existingStudent.RegisterNumber;
                s.Origin = StudentData[(int)StudentRow, 5];
                s.Email = StudentData[(int)StudentRow, 6];
                s.Eligible = false;
                UpdateStudent(s);
            }
            return s;
        }
        internal override Student GetStudent(Student StudentToFind)
        {
            Student s;
            using (DbConnection conn = Connect())
            {
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT *" +
                    " FROM Students" +
                    " WHERE lastName=" + SqlString(StudentToFind.LastName) +
                    " AND firstName=" + SqlString(StudentToFind.FirstName) +
                    " AND (birthDate=" + SqlDate(StudentToFind.BirthDate) + " OR birthDate=NULL)" +
                    //" AND (birthPlace=" + SqlDate(StudentToFind.BirthPlace) + " OR birthPlace=NULL)" +
                    ";";
                dRead = cmd.ExecuteReader();
                dRead.Read();
                if (dRead.HasRows)
                    s = GetStudentFromRow(dRead);
                else
                    s = null;
                dRead.Dispose();
                cmd.Dispose();
            }
            return s;
        }
        internal override DataTable GetStudentsWithNoMicrogrades(Class Class, string IdGradeType, string IdSchoolSubject,
            DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = Connect())
            {
                // find the macro grade type of the micro grade
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT idGradeTypeParent " +
                    "FROM GradeTypes " +
                    "WHERE idGradeType='" + IdGradeType + "'; ";
                string idGradeTypeParent = (string)cmd.ExecuteScalar();

                string query = "SELECT Students.idStudent, LastName, FirstName, disabled FROM Students" +
                                    " JOIN Classes_Students ON Students.idStudent=Classes_Students.idStudent" +
                                    " WHERE Students.idStudent NOT IN" +
                                    "(";
                query += "SELECT DISTINCT Students.idStudent" +
                " FROM Classes_Students" +
                " LEFT JOIN Grades ON Students.idStudent=Grades.idStudent" +
                " JOIN Students ON Classes_Students.idStudent=Students.idStudent" +
                " WHERE Classes_Students.idClass =" + Class.IdClass +
                " AND (Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                " OR Grades.idSchoolYear='" + Class.SchoolYear.Replace("-", "") + "'" + // TEMPORARY: delete after 
                ")" +
                " AND (Grades.idGradeType='" + IdGradeType + "'" +
                " OR Grades.idGradeType IS NULL)" +
                " AND Grades.idSchoolSubject='" + IdSchoolSubject + "'" +
                " AND Grades.value IS NOT NULL AND Grades.value <> 0" +
                " AND Grades.Timestamp BETWEEN " + SqlDate(DateFrom) + " AND " + SqlDate(DateTo) +
                ")" +
                " AND NOT Students.disabled";
                query += " AND Classes_Students.idClass=" + Class.IdClass;
                query += ";";
                DataAdapter DAdapt = new SqlDataAdapter(query, (SqlConnection)conn);
                DataSet DSet = new DataSet("ClosedMicroGrades");

                DAdapt.Fill(DSet);
                t = DSet.Tables[0];

                DAdapt.Dispose();
                DSet.Dispose();
            }
            return t;
        }
        internal override List<Student> GetAllStudentsThatAnsweredToATest(SchoolTest Test, Class Class)
        {
            List<Student> list = new List<Student>();
            using (DbConnection conn = Connect())
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
                    int? idStudent = Safe.Int(dRead["idStudent"]);
                    Student s = GetStudent(idStudent);
                    list.Add(s);
                }
            }
            return list;
        }
        internal override int? SaveStudent(Student Student)
        {
            if (Student.IdStudent != null)
                return UpdateStudent(Student);
            else
                return CreateStudent(Student);
        }
        internal override int? CreateStudent(Student Student)
        {
            // trova una chiave da assegnare al nuovo studente
            int idStudent = NextKey("Students", "idStudent");
            Student.IdStudent = idStudent;
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Students " +
                    "(idStudent,lastName,firstName,residence,origin," +
                    "email,birthDate,birthPlace,disabled,hasSpecialNeeds) " +
                    "VALUES (" + SqlInt(Student.IdStudent) + "," +
                    SqlString(Student.LastName) + "," +
                    SqlString(Student.FirstName) + "," +
                    SqlString(Student.Residence) + "," +
                    SqlString(Student.Origin) + "," +
                    SqlString(Student.Email) + "," +
                    SqlDate(Student.BirthDate.ToString()) + "," +
                    SqlString(Student.BirthPlace) + "," +
                    "false," +
                    "false" +
                    ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return idStudent;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Student">The student we want to update</param>
        /// <param name="conn">Optional connection that is used if present</param>
        internal override int? UpdateStudent(Student Student, DbCommand cmd = null)
        {
            DbConnection conn;
            bool leaveConnectionOpen = true;
            if (cmd == null)
            {
                conn = Connect();
                cmd = conn.CreateCommand();
                leaveConnectionOpen = false;
            }
            cmd.CommandText = "UPDATE Students " +
                "SET" +
                " idStudent=" + Student.IdStudent +
                ",lastName=" + SqlString(Student.LastName) +
                ",firstName=" + SqlString(Student.FirstName) +
                ",residence=" + SqlString(Student.Residence) +
                ",birthDate=" + SqlDate(Student.BirthDate.ToString()) + "" +
                ",email=" + SqlString(Student.Email) +
                //",schoolyear=" + SqlString(Student.SchoolYear) + 
                ",origin=" + SqlString(Student.Origin) +
                ",birthPlace=" + SqlString(Student.BirthPlace) +
                ",drawable=" + SqlBool(Student.Eligible) + "" +
                ",disabled=" + SqlBool(Student.Disabled) + "" +
                ",hasSpecialNeeds=" + SqlBool(Student.HasSpecialNeeds) + "" +
                ",VFCounter=" + SqlInt(Student.RevengeFactorCounter) + "" +
                " WHERE idStudent=" + Student.IdStudent +
                ";";
            cmd.ExecuteNonQuery();
            if (Student.RegisterNumber != null && Student.RegisterNumber != "")
            {
                cmd.CommandText = "UPDATE Classes_Students" +
                    " SET" +
                    " registerNumber=" + Student.RegisterNumber +
                    " WHERE idStudent=" + Student.IdStudent +
                    " AND idClass=" + Student.IdClass;
                cmd.ExecuteNonQuery();
            }
            if (!leaveConnectionOpen)
            {
                cmd.Dispose();
                //conn.Close();
                //conn.Dispose();
            }
            return Student.IdStudent;
        }
        //internal override void SaveStudentsOfList(List<Student> studentsList, DbConnection conn)
        //{
        //    foreach (Student s in studentsList)
        //    {
        //        SaveStudent(s, conn);
        //    }
        //}
        internal override Student GetStudent(int? IdStudent)
        {
            Student s = new Student();
            using (DbConnection conn = Connect())
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
        internal override Student GetStudentFromRow(DbDataReader Row)
        {
            Student s = new Student();
            s.IdStudent = (int)Row["IdStudent"];
            s.LastName = Safe.String(Row["LastName"]);
            s.FirstName = Safe.String(Row["FirstName"]);
            s.Residence = Safe.String(Row["Residence"]);
            s.Origin = Safe.String(Row["Origin"]);
            s.Email = Safe.String(Row["Email"]);
            if (Safe.DateTime(Row["birthDate"]) != null)
                s.BirthDate = Safe.DateTime(Row["birthDate"]);
            s.BirthPlace = Safe.String(Row["birthPlace"]);
            s.Eligible = Safe.Bool(Row["drawable"]);
            s.Disabled = Safe.Bool(Row["disabled"]);
            s.HasSpecialNeeds = Safe.Bool(Row["hasSpecialNeeds"]);
            s.RevengeFactorCounter = Safe.Int(Row["VFCounter"]);
            return s;
        }
        internal override DataTable GetStudentsSameName(string LastName, string FirstName)
        {
            DataTable t;
            using (DbConnection conn = Connect())
            {
                DataAdapter dAdapt;
                DataSet dSet = new DataSet();
                string query = "SELECT Students.IdStudent, Students.lastName, Students.firstName," +
                    " Classes.abbreviation, Classes.idSchoolYear" +
                    " FROM Students" +
                    " LEFT JOIN Classes_Students ON Students.idStudent = Classes_Students.idStudent " +
                    " LEFT JOIN Classes ON Classes.idClass = Classes_Students.idClass " +
                    " WHERE Students.lastName " + SqlLikeStatement(LastName) + "" +
                    " AND Students.firstName " + SqlLikeStatement(FirstName) + "" +
                    ";";
                dAdapt = new SqlDataAdapter(query, (SqlConnection)conn);
                dSet = new DataSet("GetStudentsSameName");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                dSet.Dispose();
                dAdapt.Dispose();
            }
            return t;
        }
        internal override DataTable FindStudentsLike(string LastName, string FirstName)
        {
            DataTable t;
            using (DbConnection conn = Connect())
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
                    query += "WHERE Students.lastName " + SqlLikeStatement(LastName) + "";
                    if (FirstName != "" && FirstName != null)
                    {
                        query += " AND Students.firstName " + SqlLikeStatement(FirstName) + "";
                    }
                }
                else
                {
                    if (FirstName != "" && FirstName != null)
                    {
                        query += " WHERE Students.firstName " + SqlLikeStatement(FirstName) + "";
                    }
                }
                query += ";";
                dAdapt = new SqlDataAdapter(query, (SqlConnection)conn);
                dSet = new DataSet("GetStudentsSameName");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                dSet.Dispose();
                dAdapt.Dispose();
            }
            return t;
        }
        internal override void PutStudentInClass(int? IdStudent, int? IdClass)
        {
            using (DbConnection conn = Connect())
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
        internal override List<Student> GetStudentsOfClass(int? IdClass, DbCommand cmd)
        {
            DbConnection conn;
            List<Student> l = new List<Student>();
            bool leaveConnectionOpen = true;
            if (cmd == null)
            {
                conn = Connect();
                cmd = conn.CreateCommand();
                leaveConnectionOpen = false;
            }
            DbDataReader dRead;
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
            dRead.Close();
            if (!leaveConnectionOpen)
            {
                cmd.Dispose();
                //conn.Close();
                //conn.Dispose();
            }
            return l;
        }
        internal override List<Student> GetStudentsOfClassList(string Scuola, string Anno,
            string SiglaClasse, bool IncludeNonActiveStudents)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Student> ls = new List<Student>();
            using (DbConnection conn = Connect())
            {
                string query = "SELECT registerNumber, Classes.idSchoolYear, " +
                               "Classes.abbreviation, Classes.idClass, Classes.idSchool, " +
                               "Students.*" +
                " FROM Students" +
                " JOIN Classes_Students ON Students.idStudent=Classes_Students.idStudent" +
                " JOIN Classes ON Classes.idClass=Classes_Students.idClass" +
                " WHERE Classes.idSchoolYear=" + SqlString(Anno) +
                " AND Classes.abbreviation=" + SqlString(SiglaClasse);
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
                    s.ClassAbbreviation = (string)dRead["abbreviation"];
                    // read the properties from other tables
                    s.IdClass = (int)dRead["idClass"];
                    s.RegisterNumber = Safe.String(dRead["registerNumber"]);
                    ls.Add(s);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return ls;
        }
        internal override List<int> GetIdStudentsNonGraded(Class Class,
            GradeType GradeType, SchoolSubject SchoolSubject)
        {
            List<int> keys = new List<int>();

            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = Connect())
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
                    keys.Add((int)Safe.Int(dRead["idStudent"]));
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return keys;
        }
        internal override void ToggleDisabledFlagOneStudent(Student Student)
        {
            // if Disabled is null I want it to be true after method
            if (Student.Disabled == null)
                Student.Disabled = false;
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Students" +
                           " Set" +
                           " disabled = NOT " + Student.Disabled +
                           " WHERE IdStudent =" + Student.IdStudent +
                           ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal override Nullable<int> GetStudentsPhotoId(int? idStudent, string schoolYear, DbConnection conn)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idStudentsPhoto FROM StudentsPhotos_Students " +
                "WHERE idStudent=" + idStudent + " AND (idSchoolYear=" + SqlString(schoolYear) + "" +
                " OR idSchoolYear=" + SqlString(schoolYear.Replace("-", "")) + // !!!! TEMPORARY: for compatibility with old database. erase this line in future 
                ")" +
                ";";
            return (int?)cmd.ExecuteScalar();
        }
        internal override int? StudentHasAnswered(int? IdAnswer, int? IdTest, int? IdStudent)
        {
            int? key;
            using (DbConnection conn = Connect())
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
        internal override List<Student> GetStudentsOnBirthday(Class Class, DateTime Date)
        {
            List<Student> list = new List<Student>();
            // strip daytime from date 
            string monthAndYear = Date.Month.ToString("00") + "-" + Date.Day.ToString("00");

            DbDataReader dRead;
            DbCommand cmd;
            using (DbConnection conn = Connect())
            {
                string query = "SELECT * " +
                " FROM Students" +
                " JOIN Classes_Students ON Students.idStudent=Classes_Students.idStudent" +
                " WHERE Classes_Students.idClass=" + Class.IdClass +
                " AND strftime('%m-%d',Students.BirthDate)='" + monthAndYear + "'" +
                ";";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Student s = GetStudentFromRow(dRead);
                    list.Add(s);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return list;
        }
        internal override void SaveStudentsAnswer(Student Student, SchoolTest Test, Answer Answer,
            bool StudentsBoolAnswer, string StudentsTextAnswer)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // find if an answer has already been given
                int? IdStudentsAnswer = StudentHasAnswered(Answer.IdAnswer, Test.IdTest, Student.IdStudent);
                if (IdStudentsAnswer != null)
                {   // update answer
                    cmd.CommandText = "UPDATE StudentsAnswers" +
                    " SET idStudent=" + SqlInt(Student.IdStudent) + "," +
                    "idAnswer=" + SqlInt(Answer.IdAnswer) + "," +
                    "studentsBoolAnswer=" + SqlBool(StudentsBoolAnswer) + "," +
                    "studentsTextAnswer=" + SqlString(StudentsTextAnswer) + "," +
                    "IdTest=" + SqlInt(Test.IdTest) +
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
                    "(" + nextId + "," + SqlInt(Student.IdStudent) + "," +
                     SqlInt(Answer.IdAnswer) + "," + SqlBool(StudentsBoolAnswer) + "," +
                     SqlString(StudentsTextAnswer) + "," +
                     SqlInt(Test.IdTest) +
                    ");";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
    }
}
