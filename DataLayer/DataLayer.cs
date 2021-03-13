using SchoolGrades.DbClasses;
using System;
using System.Data.Common;
using System.Data.SQLite;

namespace SchoolGrades.DataLayer
{
    /// <summary>
    /// Data Access Layer: abstracts the access to dbms using to transfer data 
    /// DbClasses and ADO db classes (ADO should be avoided, if possible) 
    /// </summary>
    internal class DataLayer
    {
        private string dbName;

        #region constructors
        public DataLayer()
        {
            if (!System.IO.File.Exists(Commons.PathAndFileDatabase))
            {
                string err = @"[" + Commons.PathAndFileDatabase + " not in the current nor in the dev directory]";
                Commons.ErrorLog(err, true);
                //throw new System.IO.FileNotFoundException(err);
            }
            dbName = Commons.PathAndFileDatabase;
        }
        public DataLayer(string PathAndFile)
        {
            if (!System.IO.File.Exists(PathAndFile))
            {
                string err = @"[" + PathAndFile + " not in the current nor in the dev directory]";
                Commons.ErrorLog(err, true);
                throw new System.IO.FileNotFoundException(err);
            }
            dbName = PathAndFile;
        }
        #endregion

        #region properties

        public string NameAndPathDatabase
        {
            get { return dbName; }
            //set { nomeEPathDatabase = value; }
        }
        #endregion
        public DbConnection Connect()
        {
            DbConnection connection;
            try
            {
                connection = new SQLiteConnection("Data Source=" + dbName +
                                ";version=3;new=False;datetimeformat=CurrentCulture");
                ////////#if DEBUG
                ////////                // Get call stack
                ////////                StackTrace stackTrace = new StackTrace();
                ////////                // Get calling method name
                ////////                Commons.ErrorLog("Connect Method in: " + stackTrace.GetFrame(1).GetMethod().Name, false);
                ////////#endif
            }
            catch (Exception ex)
            {
                Commons.ErrorLog("Error connecting to the database: " + ex.Message + "\r\nFile SQLIte>: " + dbName + " " + "\n", true);
                connection = null;
            }
            connection.Open();
            return connection;
        }
        internal User GetUser(string Username)
        {
            User t = new User(Username, "");
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Users" +
                    " WHERE username='" + Username + "';";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    t = GetUserFromRow(dRead);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return t;
        }
        internal User GetUserFromRow(DbDataReader dRead)
        {
            User u = new User(SafeDb.SafeString(dRead["username"]),
                SafeDb.SafeString(dRead["password"]));
            u.LastName = SafeDb.SafeString(dRead["lastName"]);
            u.FirstName = SafeDb.SafeString(dRead["firstName"]);
            u.Salt = SafeDb.SafeString(dRead["salt"]);
            u.IdUserCategory = SafeDb.SafeInt(dRead["idUserCategory"]); 
            u.CreationTime = SafeDb.SafeDateTime(dRead["creationTime"]);

            return u;
        }
        internal void ChangePassword(User User)
        {
            throw new NotImplementedException();
        }
        internal void CreateUser(User User)
        {
            throw new NotImplementedException();
        }
    }
}
