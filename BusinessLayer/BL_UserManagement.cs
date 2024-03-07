using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using SchoolGrades.BusinessObjects;
/// <summary>
/// Business Layer: implements the business rules of the program indipendently from 
/// the User's Interface
/// Porting code from DbAndBusinness class and classes within BusinessLayer is work in progress 
/// </summary>
namespace SchoolGrades
{
    /// <summary>
    /// Incapsulates the business rules for users' management
    /// part of the class that contains the code for managing users
    /// </summary>
    internal partial class BusinessLayer
    {
        #region users' management
        internal void CreateUser(User User)
        {
            dl.CreateUser(User);
        }
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
            // possible filter on user 
            dl.UpdateUser(User);
        }
        internal void ChangePassword(User User)
        {
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
        internal bool IsUserAllowedToLogin(User CredentialsFromUser)
        {
            User CredentialsFromDatabase = GetUser(CredentialsFromUser.Username);
            return (CredentialsFromDatabase.Password == CalculateHash(CredentialsFromUser.Password)
                && CredentialsFromDatabase.Username == CredentialsFromUser.Username);
        }
        #endregion
        /// <summary>
        /// Calculates a SHA256 hash of the string passed and returns it as a ???? base64 ???? string
        /// !!!! TODO Function to be done and moved to the Functions class !!!!
        /// </summary>
        /// <param name="ClearTextPassword"></param>
        /// <returns></returns>
        private string CalculateHash(string ClearTextPassword)
        {
            SHA256 hash = SHA256.Create();
            byte[] bytes = hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(ClearTextPassword));
            string risultato = string.Empty;
            foreach(byte b in bytes)
            {
                risultato += b.ToString();
            }
            return risultato;
        }
    }
}
