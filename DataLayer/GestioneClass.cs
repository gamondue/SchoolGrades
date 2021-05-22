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
    class GestioneClass
    {
        DataLayer dl = new DataLayer();

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

    }
}
