using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text;

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
        internal DataLayer()
        {
            if (!System.IO.File.Exists(Commons.PathAndFileDatabase))
            {
                string err = @"[" + Commons.PathAndFileDatabase + " not in the current nor in the dev directory]";
                Commons.ErrorLog(err);
                throw new System.IO.FileNotFoundException(err);
            }
            dbName = Commons.PathAndFileDatabase;
        }
        internal DataLayer(string PathAndFile)
        {
            if (!System.IO.File.Exists(PathAndFile))
            {
                string err = @"[" + PathAndFile + " not in the current nor in the dev directory]";
                Commons.ErrorLog(err);
                throw new System.IO.FileNotFoundException(err);
            }
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
        internal void NewDatabase()
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
    }
}
