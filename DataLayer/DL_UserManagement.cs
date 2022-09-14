using SchoolGrades.BusinessObjects;
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
                u = new User(Safe.String(dRead["username"]),
                    Safe.String(dRead["password"]));
                u.Description = Safe.String(dRead["description"]);
                u.LastName = Safe.String(dRead["lastName"]);
                u.FirstName = Safe.String(dRead["firstName"]);
                u.Email = Safe.String(dRead["email"]);
                //u.Password = Safe.SafeString(dRead["password"]);
                u.LastChange = Safe.DateTime(dRead["lastChange"]);
                u.LastPasswordChange = Safe.DateTime(dRead["lastPasswordChange"]);
                u.CreationTime = Safe.DateTime(dRead["creationTime"]);
                u.Salt = Safe.String(dRead["salt"]);
                u.IdUserCategory = Safe.Int(dRead["idUserCategory"]);
                u.IsEnabled = Safe.Bool(dRead["isEnabled"]);
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
                    " password=" + SqlString(User.Password) + "," +
                    " lastPasswordChange=" + SqlDate(DateTime.Now) + "," +
                    " salt=" + SqlString(User.Salt) + "" +
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
                string now = SqlDate(DateTime.Now);
                cmd.CommandText = "INSERT INTO Users " +
                "(username, lastName, firstName, email," +
                "password,creationTime,lastChange,lastPasswordChange,salt,idUserCategory,isEnabled)" +
                "Values " +
                "(" + SqlString(User.Username) + "," + SqlString(User.LastName) + "," + SqlString(User.FirstName) + "," +
                SqlString(User.Email) + "," + SqlString(User.Password) + "," +
                now + "," + now + "," + now + "," + SqlString(User.Salt) + "," +
                User.IdUserCategory + ", TRUE" + 
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
                    " description=" + SqlString(User.Description) + "," +
                    " lastName=" + SqlString(User.LastName) + "," +
                    " firstName=" + SqlString(User.FirstName) + "," +
                    " email=" + SqlString(User.Email) + "," +
                    //" password=" + SqlString(User.Password) + "," +
                    " lastChange=" + SqlDate(DateTime.Now) + "," +
                    //" lastPasswordChange=" + SqlDate(DateTime.Now) + "," +
                    //" creationTime=" + SqlDate(User.CreationTime)  + "," +
                    " salt=" + SqlString(User.Salt) + "," +
                    " isEnabled=" + SqlBool(User.IsEnabled) +
                    " idUserCategory=" + SqlInt(User.IdUserCategory) +
                    " WHERE username='" + User.Username + "'" +
                ";";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
    }
}
