using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;

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

        public DataTable ConnectGrid(string query)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=" + dbName + ";version=3;new=False;datetimeformat=CurrentCulture");
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

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
                dRead.Read();
                t = GetUserFromRow(dRead);
                dRead.Dispose();
                cmd.Dispose();
            }
            return t;
        }

        internal List<User> GetAllUsers()
        {
            List<User> l = new List<User>();
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                string query = "SELECT *" +
                    " FROM Users";
                cmd = new SQLiteCommand(query);
                cmd.Connection = conn;
                DbDataReader dRead = cmd.ExecuteReader();
                while (dRead.Read())
                {
                    User u = GetUserFromRow(dRead);
                    l.Add(u);
                }
                dRead.Dispose();
                cmd.Dispose();
            }
            return l;
        }

        #region Ovveride di getuser. (prova)
        internal DataTable GetUserByUserId(string id)
        {
            string query = "SELECT * FROM Users where Username = " + id;
            return ExecuteQuery(query);
        }

        public DataTable ExecuteQuery(string query)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source = " + dbName + ";version=3;new=False;datetimeformat=CurrentCulture");
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        #endregion

        private User GetUserFromRow(DbDataReader dRead)
        {
            User u = null;
            if (dRead.HasRows)
            {
                u = new User(SafeDb.SafeString(dRead["username"]),
                    SafeDb.SafeString(dRead["password"]));
                u.Description = SafeDb.SafeString(dRead["description"]);
                u.LastName = SafeDb.SafeString(dRead["lastName"]);
                u.FirstName = SafeDb.SafeString(dRead["firstName"]);
                u.Email = SafeDb.SafeString(dRead["email"]);
                //u.Password = SafeDb.SafeString(dRead["password"]);
                //u.LastChange = SafeDb.SafeDateTime(dRead["lastChange"]);
                u.LastPasswordChange = SafeDb.SafeDateTime(dRead["lastPasswordChange"]);
                u.CreationTime = SafeDb.SafeDateTime(dRead["creationTime"]);
                u.Salt = SafeDb.SafeString(dRead["salt"]);
                u.IdUserCategory = SafeDb.SafeInt(dRead["idUserCategory"]);
                u.IsEnabled = SafeDb.SafeBool(dRead["isEnabled"]);
            }
            return u;
        }

        internal void ChangePassword(User User)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Users" +
                    " Set" +
                    " password='" + SqlVal.SqlString(User.Password) + "'," +
                    " lastPasswordChange=" + SqlVal.SqlDate(DateTime.Now) + "," +
                    " salt='" + SqlVal.SqlString(User.Salt) + "'" +
                    " WHERE username='" + User.Username + "'" +
                ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        internal void CreateUser(User User)
        {
            using (DbConnection conn = Connect())
            {
                List<User> nUser = new List<User>();
                nUser = GetAllUsers();
                foreach(User user in nUser)
                {
                    if (nUser.Equals(user.Username))
                    {
                        throw new Exception("Username already exists.");
                    }
                }
                DbCommand cmd = conn.CreateCommand();
                // !!!! TODO !!!!

                // create row in table 
                string? now = SqlVal.SqlDate(DateTime.Now);
                cmd.CommandText = "INSERT INTO Users " +
                "(username, lastName, firstName, email," +
                "password,creationTime,lastChange,lastPasswordChange,salt,idUserCategory,isEnabled)" +
                "Values " +
                "('" + SqlVal.SqlString(User.Username) + "','" + 
                SqlVal.SqlString(User.LastName) + "','" + 
                SqlVal.SqlString(User.FirstName) + "','" +
                SqlVal.SqlString(User.Email) + "','" + 
                SqlVal.SqlString(User.Password) + "'," +
                now + "," + now + "," + now + ",'" + 
                SqlVal.SqlString(User.Salt) + "','" +
                SqlVal.SqlString(User.IdUserCategory.ToString()) + "', TRUE" +
                ");";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        internal void UpdateUser(User User)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Users" +
                    " Set" +
                    " description='" + SqlVal.SqlString(User.Description) + "'," +
                    " lastName='" + SqlVal.SqlString(User.LastName) + "'," +
                    " firstName='" + SqlVal.SqlString(User.FirstName) + "'," +
                    " email='" + SqlVal.SqlString(User.Email) + "'," +
                    //" password=" + SqlVal.SqlString(User.Password) + "'," +
                    " lastChange=" + SqlVal.SqlDate(DateTime.Now) + "," +
                    //" lastPasswordChange=" + SqlVal.SqlDate(DateTime.Now) + "," +
                    //" creationTime=" + SqlVal.SqlDate(User.CreationTime)  + "," +
                    " salt='" + SqlVal.SqlString(User.Salt) + "'," +
                    " isEnabled=" + SqlVal.SqlBool(User.IsEnabled) +
                    " idUserCategory=" + SqlVal.SqlInt(User.IdUserCategory) +
                    " WHERE username='" + User.Username + "'" +
                ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        #region Override updateUser con parameters (Prova).
        internal void UpdateUserOverride(string username, string lastname, string firstname, string password, string email, string description, DateTime last, DateTime lastpassw, DateTime creation, string salt, bool isenabled, int idusercateogry)
        {
            using (DbConnection conn = Connect())
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Users" +
                    " Set" +
                    " description='" + SqlVal.SqlString(description) + "'," +
                    " lastName='" + SqlVal.SqlString(lastname) + "'," +
                    " firstName='" + SqlVal.SqlString(firstname) + "'," +
                    " email='" + SqlVal.SqlString(email) + "'," +
                    " password=" + SqlVal.SqlString(password) + "'," +
                    " lastChange=" + SqlVal.SqlDate(last) + "," +
                    " lastPasswordChange=" + SqlVal.SqlDate(lastpassw) + "," +
                    " creationTime=" + SqlVal.SqlDate(creation) + "," +
                    " salt='" + SqlVal.SqlString(salt) + "'," +
                    " isEnabled=" + SqlVal.SqlBool(isenabled) +
                    " idUserCategory=" + SqlVal.SqlInt(idusercateogry) +
                    " WHERE username='" + username + "'" +
                ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        #endregion

    }
}
