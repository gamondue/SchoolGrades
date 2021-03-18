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
        DataLayer.DataLayer dl = new DataLayer.DataLayer();

        #region users' management
        internal User GetUser(string Username)
        {
            return dl.GetUser(Username);
        }
        internal bool UserHasLoginPermission(string Username, string Password, string HashCalcolato)
        {
            //TODO Sostituisci il codice del metodo implementando l'utilizzo dell'hash
            byte[] byteOrigine;
            byte[] byteNuovoHash;
            byte[] byteOrigineDaConfrontare;
            byte[] byteHashDaConfrontare;
            bool hashEquivalenti = false;

            User uFromDb = GetUser(Username);

            byteOrigine = ASCIIEncoding.ASCII.GetBytes(Password);
            byteNuovoHash = new MD5CryptoServiceProvider().ComputeHash(byteOrigine);
            byteOrigineDaConfrontare = ASCIIEncoding.ASCII.GetBytes(HashCalcolato);
            byteHashDaConfrontare = new MD5CryptoServiceProvider().ComputeHash(byteOrigineDaConfrontare);

            if (byteNuovoHash.Length == byteHashDaConfrontare.Length)
            {
                for(int i = 0; (i < byteNuovoHash.Length) && (byteNuovoHash[i] == byteHashDaConfrontare[i]); i++)
                {
                    if(i == byteNuovoHash.Length)
                    {
                        hashEquivalenti = true;
                    }
                }
                
            }

            if (uFromDb != null && Username == uFromDb.Username && hashEquivalenti == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal bool IsUserAllowed(User CredentialsFromUser)
        {
            User CredentialsFromDatabase = ReadCredentialsFromDatabase(CredentialsFromUser);
            return (CredentialsFromDatabase.Password == CalculateHash(CredentialsFromUser.Password)
                && CredentialsFromDatabase.Username == CredentialsFromUser.Username);
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
            User u = new User("ugo", "pina");
            return u;
        }
        internal string CalculateHash(string ClearTextPassword)
        {
            // https://www.mattepuffo.com/blog/articolo/2496-calcolo-hash-sha256-in-csharp.html

            //Creazione di un hash tramite la spiegazione fornita dal sito
            SHA256 hash = SHA256.Create();
            byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(ClearTextPassword));
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
        #endregion
    }
}
