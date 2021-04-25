using SchoolGrades.DbClasses;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;

namespace SchoolGrades
{
    internal partial class DataLayer
    {
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
                u.LastChange = SafeDb.SafeDateTime(dRead["lastChange"]);
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
                // check if username is existing. If exists, return null
                DbCommand cmd = conn.CreateCommand();
                // !!!! TODO !!!!

                // create row in table 
                string now = SqlVal.SqlDate(DateTime.Now);
                cmd.CommandText = "INSERT INTO Users " +
                "(username, lastName, firstName, email," +
                "password,creationTime,lastChange,lastPasswordChange,salt,idUserCategory,isEnabled)" +
                "Values " +
                "('" + SqlVal.SqlString(User.Username) + "','" + SqlVal.SqlString(User.LastName) + "','" + SqlVal.SqlString(User.FirstName) + "','" +
                SqlVal.SqlString(User.Email) + "','" + SqlVal.SqlString(User.Password) + "'," +
                now + "," + now + "," + now + ",'" + SqlVal.SqlString(User.Salt) + "','" +
                User.IdUserCategory + "', TRUE" + 
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
    }
}
