using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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

        #region users' management
        internal User GetUser(string Username)
        {
            return dl.GetUser(Username);
        }
        internal List<User> GetAllUsers()
        {
            return dl.GetAllUsers(); 
        }
        internal bool UserHasLoginPermission(string Username, string Password)
        {
            User uFromDb = GetUser(Username);

            if (uFromDb != null && Username == uFromDb.Username && CalculateHash(Password) == uFromDb.Password)
                return true;
            else
                return false;
        }

        internal void UpdateUser(User User)
        {
            User.Password = CalculateHash(User.Password);
            dl.UpdateUser(User); 
        }

        internal void ChangePassword(User User)
        {
            User.Password = CalculateHash(User.Password);
            dl.ChangePassword(User); 
        }
        internal void CreateUser(User User)
        {
            User.Password = CalculateHash(User.Password);
            dl.CreateUser(User); 
        }

        private string CalculateHash(string ClearTextPassword)
        {
            SHA256 hash = SHA256.Create();
            byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(ClearTextPassword));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
        #endregion
    }
}
