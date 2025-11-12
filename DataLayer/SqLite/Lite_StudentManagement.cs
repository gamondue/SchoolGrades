using Microsoft.Data.Sqlite;
using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SchoolGrades
{
    internal partial class SqLite_DataLayer : DataLayer
    {
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
        internal override List<Class> GetAllClassesOfStudent(Student s, DbCommand cmd)
        {
            List<Class> list = new ();
            string query = "SELECT *" +
                " FROM Classes" +
                " JOIN Classes_Students ON Classes_Students.IdClass = Classes.IdClass" +
                //" JOIN Students ON Classes_Students.IdStudent=Students.IdStudent" +
                " WHERE Classes_Students.IdStudent=" + s.IdStudent + "" +
                " ORDER BY Classes.IdSchoolYear" +
                ";";
            cmd.CommandText = query;
            DbDataReader dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                Class c = new();
                GetClassFromRow(c, dRead);
                list.Add(c);
            }
            dRead.Close();
            return list;
        }
        internal override List<Student> GetAllStudents(DbCommand cmd)
        {
            // get in a list all the students from database, using the db command passed
            List<Student> allStudents = new List<Student>();
            string query = "SELECT * FROM Students" +
                ";";
            cmd.CommandText = query;
            DbDataReader dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                Student s = GetStudentFromRow(dRead);
                allStudents.Add(s);
            }
            dRead.Close();
            return allStudents;
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
                " AND NOT disabled";
                query += " AND Classes_Students.idClass=" + Class.IdClass;
                query += ";";
                
                using (DbCommand queryCmd = conn.CreateCommand())
                {
                    queryCmd.CommandText = query;
                    using (DbDataReader reader = queryCmd.ExecuteReader())
                    {
                        t = new DataTable("ClosedMicroGrades");
                        t.Load(reader);
                    }
                }
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
        internal override void DeleteStudent(Student Student, bool DeleteAlsoInOtherTables)
        {
            if (Student.IdStudent == null)
                return;
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Students" +
                           " WHERE idStudent=" + Student.IdStudent +
                           ";";
                cmd.ExecuteNonQuery();
                if (DeleteAlsoInOtherTables)
                {
                    // delete the student also in the tables that have a field idStudent
                    cmd.CommandText = "DELETE FROM Grades" +
                       " WHERE idStudent=" + Student.IdStudent +
                       ";";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM Classes_Students" +
                       " WHERE idStudent=" + Student.IdStudent +
                       ";";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                       " WHERE idStudent=" + Student.IdStudent +
                       ";";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM StudentsAnswers" +
                       " WHERE idStudent=" + Student.IdStudent +
                       ";";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM StudentsPhotos_Students" +
                        " WHERE idStudent=" + Student.IdStudent +
                        ";";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM StudentsQuestions" +
                       " WHERE idStudent=" + Student.IdStudent +
                       ";";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM StudentsTests" +
                       " WHERE idStudent=" + Student.IdStudent +
                       ";";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM StudentsAnnotations" +
                       " WHERE idStudent=" + Student.IdStudent +
                       ";";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM Students_GradeTypes" +
                       " WHERE idStudent=" + Student.IdStudent +
                       ";";
                    cmd.ExecuteNonQuery();
                }
                cmd.Dispose();
            }
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
                    "(idStudent,lastName,firstName,city,origin" +
                    ",email,birthDate,birthPlace,telephone,mobileTelephone,gender" +
                    ",streetAddress,zipCode,county,state,hasSpecialNeeds,lastPhotoPath) " +
                    "VALUES (" + SqlInt(Student.IdStudent) + "," +
                    SqlString(Student.LastName) + "," +
                    SqlString(Student.FirstName) + "," +
                    SqlString(Student.City) + "," +
                    SqlString(Student.Origin) + "," +
                    SqlString(Student.Email) + "," +
                    SqlDate(Student.BirthDate.ToString()) + "," +
                    SqlString(Student.BirthPlace) + "," +
                    SqlString(Student.Telephone) + "," +
                    SqlString(Student.MobileTelephone) + "," +
                    SqlString(Student.Gender) + "," +
                    SqlString(Student.StreetAddress) + "," +
                    SqlString(Student.ZipCode) + "," +
                    SqlString(Student.County) + "," +
                    SqlString(Student.State) + "," +
                    SqlBool(Student.HasSpecialNeeds) + "," +
                    SqlString(Student.LastPhotoPath) + "" +
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
                ",city=" + SqlString(Student.City) +
                ",origin=" + SqlString(Student.Origin) +
                ",email=" + SqlString(Student.Email) +
                ",birthDate=" + SqlDate(Student.BirthDate.ToString()) +
                //",schoolyear=" + SqlString(Student.SchoolYear) + 
                ",birthPlace=" + SqlString(Student.BirthPlace) +
                ",telephone=" + SqlString(Student.Telephone) +
                ",mobileTelephone=" + SqlString(Student.MobileTelephone) +
                ",gender=" + SqlString(Student.Gender) +
                ",streetAddress=" + SqlString(Student.StreetAddress) +
                ",zipCode=" + SqlString(Student.ZipCode) +
                ",county=" + SqlString(Student.County) +
                ",state=" + SqlString(Student.State) +
                ",hasSpecialNeeds=" + SqlBool(Student.HasSpecialNeeds) +
                ",eligible=" + SqlBool(Student.Eligible) +
                ",revengeFactorCounter=" + SqlInt(Student.RevengeFactorCounter) +
                ",lastPhotoPath=" + SqlInt(Student.LastPhotoPath) +
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
                // ! this Student object has only the properties from the Students table
                // ! since the class is not passed, no information of the Student related to
                // ! the class can be included in this object
                dRead.Dispose();
                cmd.Dispose();
            }
            return s;
        }
        internal override Student GetStudentFromRow(DbDataReader Row)
        {
            Student s = new Student();
            if (Row != null)
            {
                s.IdStudent = Convert.ToInt32(Row["IdStudent"]);
                s.LastName = Safe.String(Row["LastName"]);
                s.FirstName = Safe.String(Row["FirstName"]);
                s.City = Safe.String(Row["city"]);
                s.Origin = Safe.String(Row["Origin"]);
                s.Email = Safe.String(Row["Email"]);
                if (Safe.DateTime(Row["birthDate"]) != null)
                    s.BirthDate = Safe.DateTime(Row["birthDate"]);
                s.BirthPlace = Safe.String(Row["birthPlace"]);
                s.Telephone = Safe.String(Row["telephone"]);
                s.MobileTelephone = Safe.String(Row["mobileTelephone"]);
                s.Gender = Safe.String(Row["gender"]);
                s.StreetAddress = Safe.String(Row["streetAddress"]);
                s.ZipCode = Safe.String(Row["zipCode"]);
                s.County = Safe.String(Row["county"]);
                s.State = Safe.String(Row["state"]);
                s.HasSpecialNeeds = Safe.Bool(Row["hasSpecialNeeds"]);
                s.Eligible = Safe.Bool(Row["eligible"]);
                s.RevengeFactorCounter = Safe.Int(Row["revengeFactorCounter"]);
                s.LastPhotoPath = Safe.String(Row["lastPhotoPath"]);
            }
            return s;
        }
        internal override List<Student> GetStudentsSameName(string LastName, string FirstName)
        {
            List<Student> t = new();
            using (DbConnection conn = Connect())
            {
                string query = "SELECT Students.IdStudent AS IdStudent, " +
                    "Students.lastName AS LastName, Students.firstName AS FirstName," +
                    " Classes.abbreviation AS ClassAbbreviation, Classes.idSchoolYear AS SchoolYear " +
                    " FROM Students" +
                    " LEFT JOIN Classes_Students ON Students.idStudent = Classes_Students.idStudent " +
                    " LEFT JOIN Classes ON Classes.idClass = Classes_Students.idClass " +
                    " WHERE Students.lastName=" + SqlString(LastName) + "" +
                    " AND Students.firstName=" + SqlString(FirstName) + "" +
                    " ORDER BY LastName, Students.IdStudent, Students.birthDate, FirstName, SchoolYear" +
                    ";";
                DbCommand cmd = conn.CreateCommand();
                cmd = new SqliteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Student s = new Student();
                    s.IdStudent = Safe.Int(dRead["IdStudent"]);
                    s.LastName = Safe.String(dRead["LastName"]);
                    s.FirstName = Safe.String(dRead["FirstName"]);
                    s.ClassAbbreviation = Safe.String(dRead["ClassAbbreviation"]);
                    s.SchoolYear = Safe.String(dRead["SchoolYear"]);
                    t.Add(s);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return t;
        }
        internal override List<Student> GetStudentsLike(Student Student)
        {
            List<Student> t = new();
            using (DbConnection conn = Connect())
            {
                string query = "SELECT Classes.abbreviation AS ClassAbbreviation,Classes.idSchoolYear AS SchoolYear" +
                    ",Students.*" +
                    " FROM Students" +
                    " LEFT JOIN Classes_Students ON Students.idStudent = Classes_Students.idStudent " +
                    " LEFT JOIN Classes ON Classes.idClass = Classes_Students.idClass ";
                AddWhereFilterString(ref query, "LastName", Student.LastName);
                AddWhereFilterString(ref query, "FirstName", Student.FirstName);
                AddWhereFilterString(ref query, "city", Student.City);
                AddWhereFilterString(ref query, "origin", Student.Origin);
                AddWhereFilterString(ref query, "email", Student.Email);
                //AddWhereFilterDateTime(ref query, "birthDate", Student.BirthDate);
                AddWhereFilterString(ref query, "birthPlace", Student.BirthPlace);
                AddWhereFilterString(ref query, "telephone", Student.Telephone);
                AddWhereFilterString(ref query, "mobileTelephone", Student.MobileTelephone);
                AddWhereFilterString(ref query, "Gender", Student.Gender);
                AddWhereFilterString(ref query, "streetAddress", Student.StreetAddress);
                AddWhereFilterString(ref query, "zipCode", Student.ZipCode);
                AddWhereFilterString(ref query, "county", Student.County);
                AddWhereFilterString(ref query, "state", Student.State);
                if (Student.HasSpecialNeeds!= null && Student.HasSpecialNeeds == true)
                    AddWhereFilterBool(ref query, "hasSpecialNeeds", Student.HasSpecialNeeds);
                //if (Student.Eligible != null && Student.Eligible == true)
                //    AddWhereFilterBool(ref query, "eligible", Student.Eligible);
                AddWhereFilterInt(ref query, "revengeFactorCounter", Student.RevengeFactorCounter);
                AddWhereFilterString(ref query, "lastPhotoPath", Student.LastPhotoPath);
                query += " COLLATE NOCASE";
                query += " ORDER BY Students.LastName COLLATE NOCASE" +
                        ",Students.FirstName COLLATE NOCASE,Students.IdStudent" +
                        ",Students.birthDate,SchoolYear";
                query += ";";
                DbCommand cmd = conn.CreateCommand();
                cmd = new SqliteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    Student s = GetStudentFromRow(dRead);
                    s.ClassAbbreviation = Safe.String(dRead["ClassAbbreviation"]);
                    s.SchoolYear = Safe.String(dRead["SchoolYear"]);
                    t.Add(s);
                }
                dRead.Dispose();
                cmd.Dispose();
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
        ////////internal override List<Student> GetStudentsOfClass(Class Class, DbCommand cmd)
        ////////{
        ////////    DbConnection conn;
        ////////    int? IdClass = Class.IdClass;
        ////////    List<Student> l = new List<Student>();
        ////////    bool leaveConnectionOpen = true;
        ////////    if (cmd == null)
        ////////    {
        ////////        conn = Connect();
        ////////        cmd = conn.CreateCommand();
        ////////        leaveConnectionOpen = false;
        ////////    }
        ////////    DbDataReader dRead;
        ////////    string query = "SELECT Students.*" +
        ////////        " FROM Students" +
        ////////        " JOIN Classes_Students ON Classes_Students.idStudent=Students.idStudent" +
        ////////        " WHERE Classes_Students.idClass=" + IdClass +
        ////////    ";";
        ////////    cmd.CommandText = query;
        ////////    dRead = cmd.ExecuteReader();
        ////////    while (dRead.Read())
        ////////    {
        ////////        Student s = GetStudentFromRow(dRead);
        ////////        l.Add(s);
        ////////    }
        ////////    dRead.Close();
        ////////    if (!leaveConnectionOpen)
        ////////    {
        ////////        cmd.Dispose();
        ////////        //conn.Close();
        ////////        //conn.Dispose();
        ////////    }
        ////////    return l;
        ////////}
        internal override List<Student> GetStudentsOfClass(Class Class, bool IncludeNonActiveStudents, DbCommand cmd = null)
        {
            DbConnection conn;
            int? IdClass = Class.IdClass;
            bool leaveConnectionOpen = true;
            if (cmd == null)
            {
                conn = Connect();
                cmd = conn.CreateCommand();
                leaveConnectionOpen = false;
            }
            DbDataReader dRead;
            List<Student> ls = new List<Student>();
            string query = "SELECT registerNumber, Classes.idSchoolYear, " +
                            "Classes.abbreviation, Classes.idClass, Classes.idSchool, " +
                            "Students.*,Classes_Students.disabled" +
            " FROM Students" +
            " JOIN Classes_Students ON Students.idStudent=Classes_Students.idStudent" +
            " JOIN Classes ON Classes.idClass=Classes_Students.idClass" +
            " WHERE Classes.idClass=" + SqlInt(Class.IdClass);
            if (!IncludeNonActiveStudents)
            {
                query += " AND (Classes_Students.disabled = 0 OR Classes_Students.disabled IS NULL)";
            }
            query += " COLLATE NOCASE";
            query += " ORDER BY Students.LastName COLLATE NOCASE," +
                " Students.FirstName COLLATE NOCASE, Students.birthDate";
            query += ";";
            cmd.CommandText = query;
            dRead = cmd.ExecuteReader();
            while (dRead.Read())
            {
                // get info from student table
                Student s = GetStudentFromRow(dRead);
                // add info gathered from other tables
                s.ClassAbbreviation = (string)dRead["abbreviation"];
                s.IdClass = Convert.ToInt32(dRead["idClass"]);
                s.RegisterNumber = Safe.String(dRead["registerNumber"]);
                s.Disabled = Safe.Bool(dRead["disabled"]);
                ls.Add(s);
            }
            dRead.Close();
            if (!leaveConnectionOpen)
            {
                cmd.Dispose();
                //conn.Close();
                //conn.Dispose();
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
        internal override void ToggleDisabledFlagOneStudent(Student Student, Class Class)
        {
            // if Disabled is null I want it to be true after method
            if (Student.Disabled == null)
                Student.Disabled = false;
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Classes_Students" +
                           " Set" +
                           " disabled = NOT " + Student.Disabled +
                           " WHERE IdStudent =" + Student.IdStudent +
                           " AND IdClass =" + Class.IdClass +
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
        internal override void CreateTableStudents()
        {
            throw new NotImplementedException();
        }
    }
}
