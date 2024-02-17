using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace SchoolGrades
{
    internal partial class SqLite_DataLayer : DataLayer
    {
        internal override Grade GetGrade(int? IdGrade)
        {
            Grade g = null;
            using (DbConnection conn = Connect())
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
        internal override void SaveMacroGrade(int? IdStudent, int? IdParent,
            double Grade, double Weight, string IdSchoolYear,
            string IdSchoolSubject)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                // creazione del macrovoto nella tabella dei voti  
                cmd.CommandText = "UPDATE Grades " +
                    "SET IdStudent=" + SqlInt(IdStudent) +
                    ",value=" + SqlDouble(Grade) +
                    ",weight=" + SqlDouble(Weight) +
                    ",idSchoolYear='" + IdSchoolYear + "'" +
                    ",idSchoolSubject='" + IdSchoolSubject +
                    "',timestamp ='" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace('.', ':') + "' " +
                    "WHERE idGrade = " + IdParent +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal override void GetGradeAndStudentFromIdGrade(ref Grade Grade, ref Student Student)
        {
            using (DbConnection conn = Connect())
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
                dRead.Dispose();
                cmd.Dispose();
            }
        }
        internal override double GetDefaultWeightOfGradeType(string IdGradeType)
        {
            double d;
            using (DbConnection conn = Connect())
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
        /// <summary>
        /// Gets all the grades of a students of a specified IdGradeType that are the sons 
        /// of another grade which has value greater than zero
        /// </summary>
        /// <param Name="IdStudent"></param> student's Id
        internal override DataTable GetMicroGradesOfStudentWithMacroOpen(int? IdStudent, string IdSchoolYear,
            string IdGradeType, string IdSchoolSubject)
        {
            using (DbConnection conn = Connect())
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
        internal override DataTable GetSubGradesOfGrade(int? IdGrade)
        {
            DataTable t;
            using (DbConnection conn = Connect())
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
        internal override Student GetWeightedAveragesOfStudent(Student Student, string stringKey1, string stringKey2, DateTime value1, DateTime value2)
        {

            //List<StudentAndGrade> l = new List<StudentAndGrade>(); 

            //using (DbConnection conn = Connect())
            //{
            //    DataAdapter dAdapt;
            //    DataSet dSet = new DataSet();

            //    string query = "SELECT Grades.idGrade, Students.idStudent,lastName,firstName," +
            //" SUM(Grades.value * Grades.weight)/SUM(Grades.weight) AS 'Weighted average'" +
            //// weighted RMS (Root Mean Square) as defined here:   
            //// https://stackoverflow.com/questions/10947180/weighted-standard-deviation-in-sql-server-without-aggregation-error
            //// !!!! fix the calculation of weighted RMS 
            ////",SQRT( SUM(Grades.weight * SQUARE(Grades.value)) / SUM(Grades.weight) - SQUARE(SUM(Grades.weight * Grades.value) / SUM(Grades.weight)) )  AS 'Weighted RMS'" +
            //",COUNT() AS 'Grades Count'" +
            //" FROM Grades" +
            //" JOIN Students" +
            //" ON Students.idStudent=Grades.idStudent" +
            //" JOIN Classes_Students" +
            //" ON Classes_Students.idStudent=Students.idStudent" +
            //" WHERE Classes_Students.idClass =" + Class.IdClass +
            //" AND Grades.idSchoolYear='" + Class.SchoolYear + "'" +
            //" AND Grades.idGradeType = '" + IdGradeType + "'" +
            //" AND Grades.idSchoolSubject = '" + IdSchoolSubject + "'" +
            //" AND Grades.Value > 0" +
            //" AND Grades.Timestamp BETWEEN " + SqlDate(DateFrom) + " AND " + SqlDate(DateTo) +
            //" GROUP BY Students.idStudent" +
            //" ORDER BY 'Weighted average';";
            //    //" ORDER BY lastName, firstName, Students.idStudent;";
            //    dAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
            //    dSet = new DataSet("GetUnfixedGradesInTheYear");
            //    dAdapt.Fill(dSet);
            //    t = dSet.Tables[0];

            //    dSet.Dispose();
            //    dAdapt.Dispose();
            //}
            return Student;
        }
        internal override DataTable GetGradesOfClass(Class Class,
             string IdGradeType, string IdSchoolSubject,
             DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = Connect())
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
                " AND (Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                " OR Grades.idSchoolYear='" + Class.SchoolYear.Replace("-", "") + "'" +
                " )" +
                " AND Grades.idGradeType = '" + IdGradeType + "'" +
                " AND Grades.idSchoolSubject = '" + IdSchoolSubject + "'" +
                " AND Grades.Value > 0" +
                " AND Grades.Timestamp BETWEEN " + SqlDate(DateFrom) + " AND " + SqlDate(DateTo) +
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
        /// <summary>
        /// Gets the number of microquestions that haven't yet a global grade
        /// </summary>
        /// <param Name="id"></param>
        /// <returns></returns>
        internal override List<Grade> CountNonClosedMicroGrades(Class Class, GradeType GradeType)
        {
            DbDataReader dRead;
            DbCommand cmd;
            List<Grade> ls = new List<Grade>();
            using (DbConnection conn = Connect())
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
        internal override Grade LastOpenGradeOfStudent(Student Student, string IdSchoolYear,
            SchoolSubject SchoolSubject, string IdGradeType)
        {
            DbDataReader dRead;
            DbCommand cmd;
            Grade g = new Grade();
            using (DbConnection conn = Connect())
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Grades.* FROM Grades" +
                    " WHERE Grades.idStudent=" + Student.IdStudent.ToString() +
                    " AND Grades.idSchoolSubject='" + SchoolSubject.IdSchoolSubject + "'" +
                    " AND Grades.idGradeType='" + IdGradeType + "'" +
                    " AND Grades.idSchoolYear='" + IdSchoolYear + "'" +
                    " AND (Grades.value=0 OR Grades.value IS NULL)" +
                    " ORDER BY Grades.idGrade DESC;";
                // !!!! changed name from LastGradeOfStudent and query changed,that was WRONG, this change must be brought to every branch !!!!
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
        internal override void CloneGrade(DataRow Riga)
        {
            using (DbConnection conn = Connect())
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
                SqlDouble(Riga["value"]) + "," +
                SqlDouble(Riga["weight"]) + ",'" +
                SqlDouble(Riga["cncFactor"]) + ",'" +
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
        internal override List<GradeType> GetListGradeTypes()
        {
            List<GradeType> lg = new List<GradeType>();
            using (DbConnection conn = Connect())
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
        internal override void DeleteValueOfGrade(int IdGrade)
        {
            using (DbConnection conn = Connect())
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
        internal override GradeType GetGradeTypeFromRow(DbDataReader Row)
        {
            if (Row.HasRows)
            {
                GradeType gt = new GradeType();
                gt.IdGradeType = (string)Row["idGradeType"];
                gt.IdGradeTypeParent = Safe.String(Row["IdGradeTypeParent"]);
                gt.IdGradeCategory = (string)Row["IdGradeCategory"];
                gt.Name = (string)Row["Name"];
                gt.DefaultWeight = (double)Row["DefaultWeight"];
                gt.Desc = (string)Row["Desc"];
                return gt;
            }
            return null;
        }
        internal override GradeType GetGradeType(string IdGradeType)
        {
            GradeType gt = null;
            using (DbConnection conn = Connect())
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
        internal override void SaveGradeValue(int? id, double? grade)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Grades" +
                " SET value=" + SqlDouble(grade) +
                " WHERE idGrade=" + id +
                ";";
                cmd.ExecuteNonQuery();
            }
        }
        internal override void EraseGrade(int? KeyGrade)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Grades" +
                    " WHERE idGrade=" + KeyGrade +
                    ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal override Grade GetGradeFromRow(DbDataReader Row)
        {
            Grade g = new Grade();
            g.IdGrade = (int)Row["idGrade"];
            g.IdGradeParent = Safe.Int(Row["idGradeParent"]);
            g.IdStudent = Safe.Int(Row["idStudent"]);
            g.IdGradeType = Safe.String(Row["IdGradeType"]);
            g.IdSchoolSubject = Safe.String(Row["IdSchoolSubject"]);
            //g.IdGradeTypeParent = Safe.SafeString(Row["idGradeTypeParent"]);
            g.IdQuestion = Safe.Int(Row["idQuestion"]);
            g.Timestamp = (DateTime)Row["timestamp"];
            g.Value = Safe.Double(Row["value"]);
            g.Weight = Safe.Double(Row["weight"]);
            g.CncFactor = Safe.Double(Row["cncFactor"]);
            g.IdSchoolYear = Safe.String(Row["idSchoolYear"]);
            //g.DummyInt = (int)Row["dummyInt"]; 
            return g;
        }
        internal override DataTable GetGradesOfStudent(Student Student, string SchoolYear, string IdGradeType, string IdSchoolSubject, DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = Connect())
            {
                string query = "SELECT DISTINCT Grades.idGrade,datetime(Grades.timeStamp)," +
                "Grades.value AS 'grade', Grades.weight," +
                "Questions.text,lastName,firstName," +
                " Grades.idGradeParent" +
                " FROM Grades" +
                " JOIN Students" +
                " ON Students.idStudent=Grades.idStudent" +
                " JOIN Classes_Students" +
                " ON Classes_Students.idStudent=Students.idStudent" +
                " LEFT JOIN Questions" +
                " ON Grades.idQuestion=Questions.idQuestion" +
                " WHERE Students.idStudent=" + Student.IdStudent +
                " AND (Grades.idSchoolYear='" + SchoolYear + "'" +
                " OR Grades.idSchoolYear='" + SchoolYear.Replace("-", "") + "'" +
                ")" +
                " AND Grades.idGradeType='" + IdGradeType + "'" +
                " AND Grades.idSchoolSubject='" + IdSchoolSubject + "'" +
                " AND Grades.Value > 0" +
                " AND Grades.Timestamp BETWEEN " + SqlDate(DateFrom) + " AND " + SqlDate(DateTo) +
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
        internal override object GetGradesWeightsOfStudentOnOpenGrades(Student currentStudent, string stringKey1, string stringKey2, DateTime value1, DateTime value2)
        {
            throw new NotImplementedException();
        }
        internal override DataTable GetWeightedAveragesOfClassByGradesFraction(Class Class,
            string IdGradeType, string IdSchoolSubject, DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = Connect())
            {
                string query = "SELECT Grades.idGrade,Students.idStudent,lastName,firstName" +
                ",SUM(weight)/100 AS 'GradesFraction', 1 - SUM(weight)/100 AS LeftToCloseAssesments" +
                ",COUNT() AS 'GradesCount'" +
                " FROM Classes_Students" +
                " LEFT JOIN Grades ON Students.idStudent=Grades.idStudent" +
                " JOIN Students ON Classes_Students.idStudent=Students.idStudent" +
                " WHERE Classes_Students.idClass =" + Class.IdClass +
                " AND (Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                " OR Grades.idSchoolYear='" + Class.SchoolYear.Replace("-", "") + "'" + // TEMPORARY line for compatibility
                ")" +
                " AND (Grades.idGradeType='" + IdGradeType + "'" +
                " OR Grades.idGradeType IS NULL)" +
                " AND Grades.idSchoolSubject='" + IdSchoolSubject + "'" +
                " AND Grades.value IS NOT NULL AND Grades.value <> 0" +
                " AND Grades.Timestamp BETWEEN " + SqlDate(DateFrom) + " AND " + SqlDate(DateTo) +
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
        internal override DataTable GetGradesWeightedAveragesOfClassByAverage(Class Class, string IdGradeType,
            string IdSchoolSubject, DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            //List<StudentAndGrade> l = new List<StudentAndGrade>(); 

            using (DbConnection conn = Connect())
            {
                DataAdapter dAdapt;
                DataSet dSet = new DataSet();

                string query = "SELECT Grades.idGrade, Students.idStudent,lastName,firstName," +
            " SUM(Grades.value * Grades.weight)/SUM(Grades.weight) AS 'Weighted average'" +
            // weighted RMS (Root Mean Square) as defined here: 
            // https://stackoverflow.com/questions/10947180/weighted-standard-deviation-in-sql-server-without-aggregation-error
            // !!!! fix the calculation of weighted RMS 
            //",SQRT( SUM(Grades.weight * SQUARE(Grades.value)) / SUM(Grades.weight) - SQUARE(SUM(Grades.weight * Grades.value) / SUM(Grades.weight)) )  AS 'Weighted RMS'" +
            ",COUNT() AS 'Grades Count'" +
            " FROM Grades" +
            " JOIN Students" +
            " ON Students.idStudent=Grades.idStudent" +
            " JOIN Classes_Students" +
            " ON Classes_Students.idStudent=Students.idStudent" +
            " WHERE Classes_Students.idClass =" + Class.IdClass +
            " AND (Grades.idSchoolYear='" + Class.SchoolYear + "'" +
            " OR Grades.idSchoolYear='" + Class.SchoolYear.Replace("-", "") + "'" +
            ")" +
            " AND Grades.idGradeType = '" + IdGradeType + "'" +
            " AND Grades.idSchoolSubject = '" + IdSchoolSubject + "'" +
            " AND Grades.Value > 0" +
            " AND Grades.Timestamp BETWEEN " + SqlDate(DateFrom) + " AND " + SqlDate(DateTo) +
            " GROUP BY Students.idStudent" +
            " ORDER BY 'Weighted average';";
                //" ORDER BY lastName, firstName, Students.idStudent;";
                dAdapt = new SQLiteDataAdapter(query, (SQLiteConnection)conn);
                dSet = new DataSet("GetUnfixedGradesInTheYear");
                dAdapt.Fill(dSet);
                t = dSet.Tables[0];

                dSet.Dispose();
                dAdapt.Dispose();
            }
            return t;
        }
        internal override List<StudentAndGrade> GetListGradesWeightedAveragesOfClassByName(Class Class, string IdGradeType,
            string IdSchoolSubject, DateTime DateFrom, DateTime DateTo)
        {
            //DataTable t;
            List<StudentAndGrade> l = new List<StudentAndGrade>();

            using (DbConnection conn = Connect())
            {
                string query = "SELECT Grades.idGrade, Students.idStudent,lastName,firstName," +
                " SUM(Grades.value * Grades.weight)/SUM(Grades.weight) AS 'Weighted average'" +
                // weighted RMS (Root Mean Square) as defined here: 
                // https://stackoverflow.com/questions/10947180/weighted-standard-deviation-in-sql-server-without-aggregation-error
                // !!!! fix the calculation of weighted RMS 
                //",SQRT( SUM(Grades.weight * SQUARE(Grades.value)) / SUM(Grades.weight) - SQUARE(SUM(Grades.weight * Grades.value) / SUM(Grades.weight)) )  AS 'Weighted RMS'" +
                ",COUNT() AS 'Grades Count'" +
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
                " AND Grades.Timestamp BETWEEN " + SqlDate(DateFrom) + " AND " + SqlDate(DateTo) +
                " GROUP BY Students.idStudent" +
                " ORDER BY lastName, firstName, Students.idStudent;";
                DbDataReader dRead;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    StudentAndGrade sg = new StudentAndGrade();

                    sg.Student.IdStudent = Safe.Int(dRead["idStudent"]);
                    sg.Student.LastName = Safe.String(dRead["lastName"]);
                    sg.Student.FirstName = Safe.String(dRead["firstName"]);
                    sg.Grade.IdGrade = Safe.Int(dRead["idGrade"]);
                    sg.WeightedAverage = Safe.Double(dRead["Weighted average"]);
                    //sg.WeightedRms = Safe.Double(dRead["Weighted RMS"]); // when RMS calculation in fixed, reenact this statement 
                    sg.GradesCount = Safe.Int(dRead["Grades Count"]);

                    l.Add(sg);
                }
                dRead.Dispose();
            }
            return l;
        }
        internal override DataTable GetUnfixedGrades(Student Student, string IdSchoolSubject,
            double Threshold)
        {
            DataTable t;
            using (DbConnection conn = Connect())
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
        /// <summary>
        /// Gets all the grades of a students of a specified IdGradeType that are the sons 
        /// of another grade which has value NOT null AND NOT equal to zero
        /// </summary>
        /// <param name="IdStudent"></param>
        /// <param name="IdSchoolYear"></param>
        /// <param name="IdGradeType"></param>
        /// <param name="IdSchoolSubject"></param>
        /// <returns></returns>
        internal override DataTable GetMacroGradesOfStudentClosed(int? IdStudent, string IdSchoolYear,
            string IdGradeType, string IdSchoolSubject)
        {
            DataTable t;
            using (DbConnection conn = Connect())
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
        internal override int CreateMacroGrade(ref Grade Grade, Student Student, string IdMicroGradeType)
        {
            int key = NextKey("Grades", "idGrade");
            using (DbConnection conn = Connect())
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
                "," + SqlDouble(weight) + "" +
                ",0" +
                ",'" + Grade.IdSchoolYear + "'," +
                SqlDate(System.DateTime.Now) + "" +
                ",'" + Grade.IdSchoolSubject +
                "');";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return key;
        }
        internal override int? SaveMicroGrade(Grade Grade)
        {
            using (DbConnection conn = Connect())
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
                    "," + SqlString(Grade.IdGradeType) + "" +
                    "," + SqlInt(Grade.IdGradeParent.ToString()) + "" +
                    "," + Grade.IdStudent + "" +
                    "," + SqlDouble(Grade.Value) + "" +
                    "," + SqlDouble(Grade.Weight) + "" +
                    "," + SqlDouble(Grade.CncFactor) + "" +
                    "," + SqlString(Grade.IdSchoolYear) + "" +
                    //"," + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace('.', ':') + "" +
                    "," + SqlDate(System.DateTime.Now) + "" +
                    "," + SqlInt(Grade.IdQuestion.ToString()) + "" +
                    ",'" + Grade.IdSchoolSubject + "'" +
                    ");";
                }
                else
                {
                    cmd.CommandText = "UPDATE Grades " +
                    "SET" +
                    " idGrade=" + SqlInt(Grade.IdGrade.ToString()) + "" +
                    ",idGradeType=" + SqlString(Grade.IdGradeType) + "" +
                    ",idGradeParent=" + SqlInt(Grade.IdGradeParent.ToString()) + "" +
                    ",idStudent=" + SqlInt(Grade.IdStudent.ToString()) + "" +
                    ",idSchoolYear=" + SqlString(Grade.IdSchoolYear) + "" +
                    ",timestamp=" + SqlDate((DateTime)Grade.Timestamp) + "" +
                    ",idQuestion=" + SqlInt(Grade.IdQuestion.ToString()) + "" +
                    ",idSchoolSubject=" + SqlString(Grade.IdSchoolSubject) + "" +
                    ",value=" + SqlDouble(Grade.Value) + "" +
                    ",weight=" + SqlDouble(Grade.Weight) + "" +
                    ",cncFactor=" + SqlDouble(Grade.CncFactor) + "" +
                    " WHERE idGrade=" + SqlInt(Grade.IdGrade.ToString()) +
                    ";";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return Grade.IdGrade;
        }
        internal override object GetGradesWeightedAveragesOfStudent(Student currentStudent,
            string stringKey1, string stringKey2, DateTime value1, DateTime value2)
        {
            throw new NotImplementedException();
        }
        internal override List<Couple> GetGradesOldestInClass(Class Class,
            GradeType GradeType, SchoolSubject SchoolSubject)
        {
            List<Couple> couples = new List<Couple>();
            using (DbConnection conn = Connect())
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
                        c.Value = Safe.DateTime(dRead["InstantLastQuestion"]);
                    else
                        c.Value = now;
                    couples.Add(c);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return couples;
        }
        internal override DataTable GetGradesWeightsOfClassOnOpenGrades(Class Class,
            string IdGradeType, string IdSchoolSubject, DateTime DateFrom, DateTime DateTo)
        {
            DataTable t;
            using (DbConnection conn = Connect())
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
                " AND (Grades.idSchoolYear='" + Class.SchoolYear + "'" +
                " OR Grades.idSchoolYear='" + Class.SchoolYear.Replace("-", "") + "'" +
                ")" +
                " AND (Grades.idGradeType='" + IdGradeType + "'" +
                " OR Grades.idGradeType IS NULL)" +
                " AND Grades.idSchoolSubject='" + IdSchoolSubject + "'" +
                " AND Grades.value IS NOT NULL AND Grades.value <> 0" +
                " AND Grades.Timestamp BETWEEN " + SqlDate(DateFrom) + " AND " + SqlDate(DateTo) +
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
    }
}
