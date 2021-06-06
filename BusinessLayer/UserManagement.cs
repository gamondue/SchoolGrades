using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using SchoolGrades.DataLayer;
using SchoolGrades.DbClasses;

namespace SchoolGrades
{
    /// <summary>
    /// Business Layer: implements the business rules of the program indipendently from 
    /// the User's Interface 
    /// </summary>
    internal partial class BusinessLayer
    {
        // create the next after the program that is usung this has read the configuration file 

        #region users' management
        internal User GetUser(string Username)
        {
            return dl.GetUser(Username);
        }
        internal List<User> GetAllUsers()
        {
            return dl.GetAllUsers();
        }
        internal void UpdateUser(User User)
        {
            User.Password = CalculateHash(User.Password);
            // possible filter on user 
            dl.UpdateUser(User);
        }
        internal void ChangePassword(User User)
        {
            User.Password = CalculateHash(User.Password);
            dl.ChangePassword(User);
        }
        internal bool HasUserLoginPermission(string Username, string Password)
        {
            User uFromDb = GetUser(Username);

            if (uFromDb != null && Username == uFromDb.Username && Password == uFromDb.Password)
                return true;
            else
                return false;
        }
        internal bool IsUserAllowed(User CredentialsFromUser)
        {
            User CredentialsFromDatabase = GetUser(CredentialsFromUser.Username);
            return (CredentialsFromDatabase.Password == CalculateHash(CredentialsFromUser.Password) && CredentialsFromDatabase.Username == CredentialsFromUser.Username);
        }

        internal void CreateUser(User User)
        {
            User.Password = CalculateHash(User.Password);
            dl.CreateUser(User); 
        }
        //private User ReadCredentialsFromDatabase(User CredentialsFromUser)
        //{
        //    User u = new User("ugo", "pina");
        //    return u;
        //}
        //private User WriteCredentialsToDatabase(User CredentialsFromUser)
        //{
        //    User u = new User("ugo", "pina");
        //    return u;
        //}
        internal string CalculateHash(string ClearTextPassword)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(ClearTextPassword));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
        #endregion
    }
}
