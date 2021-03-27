using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using SchoolGrades.DataLayer;
using SchoolGrades.DbClasses;

namespace SchoolGrades.BusinessLayer
{
    /// <summary>
    /// Business Layer: implements the business rules of the program indipendently from 
    /// the User's Interface 
    /// </summary>
    internal class BusinessLayer
    {
        // create the next after the program that is usung this has read the configuration file 
        DataLayer.DataLayer dl = new DataLayer.DataLayer(); // must be instantiated after reading config file! 

        #region users' management.
        internal User GetUser(string Username)
        {
            return dl.GetUser(Username);
        }

        internal bool UserHasLoginPermission(string Username, string Password)
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

            return ((CredentialsFromDatabase.Password) == CalculateHash(CredentialsFromUser.Password) && CredentialsFromDatabase.Username == CredentialsFromUser.Username);
        }

        internal void UpdateUser(User User)
        {
            dl.UpdateUser(User); 
        }

        internal void ChangePassword(User User)
        {
            dl.ChangePassword(User); 
        }
        internal void CreateUser(User User)
        {
            dl.CreateUser(User); 
        }
        private User ReadCredentialsFromDatabase(User CredentialsFromUser)
        {
            User u = new User("ugo", "pina");
            return u;
        }
        private User WriteCredentialsToDatabase(User CredentialsFromUser)
        {
            User u = new User(CredentialsFromUser.Username, CredentialsFromUser.Password);
            return u;
        }
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
