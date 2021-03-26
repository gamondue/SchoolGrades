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

        //Campi di classe per modifica informazioni utente
        string _usernameUtente;
        string _passwordUtente;
        string _descriptionUtente;
        string _emailUtente;
        string _firstNameUtente;
        string _lastNameUtente;

        #region users' management
        /// <summary>
        /// Metodo costruttore del BusinessLayer con tutte le informazioni dell'utente
        /// </summary>
        /// <param name="username">Username dell'utente</param>
        /// <param name="password">Password dell'utente</param>
        /// <param name="email">E-mail dell'utente</param>
        /// <param name="description">Descrizione impostata dall'utente</param>
        /// <param name="firstName">Nome dell'utente</param>
        /// <param name="lastName">Cognome dell'utente</param>
        internal BusinessLayer(string username, string password, string email, string description, string firstName, string lastName)
        {
            _usernameUtente = username;
            _passwordUtente = password;
            _emailUtente = email;
            _descriptionUtente = description;
            _firstNameUtente = firstName;
            _lastNameUtente = lastName;
        }

        #region Serie di proprietà per cambiare le varie informazioni dell'utente
        internal string Username
        {
            get
            {
                return _usernameUtente;
            }
            set
            {
                _usernameUtente = value;
            }
        }

        internal string Password
        {
            get
            {
                return _passwordUtente;
            }
            set
            {
                _passwordUtente = value;
            }
        }

        internal string FirstName
        {
            get
            {
                return _firstNameUtente;
            }
            set
            {
                _firstNameUtente = value;
            }
        }

        internal string LastName
        {
            get
            {
                return _lastNameUtente;
            }
            set
            {
                _lastNameUtente = value;
            }
        }

        internal string Description
        {
            get
            {
                return _descriptionUtente;
            }
            set
            {
                _descriptionUtente = value;
            }
        }

        internal string Email
        {
            get
            {
                return _emailUtente;
            }
            set
            {
                _emailUtente = value;
            }
        }
        #endregion

        internal User GetUser(string Username)
        {
            return dl.GetUser(Username);
        }
        internal bool UserHasLoginPermission(string Username, string Password, string HashCalcolato)
        {
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
                for (int i = 0; (i < byteNuovoHash.Length) && (byteNuovoHash[i] == byteHashDaConfrontare[i]); i++)
                {
                    if (i == byteNuovoHash.Length)
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
        #region Modifiche all'utente e alla password vengono automaticamente salvate nei campi di classe
        internal void UpdateUser(User User)
        {
            dl.UpdateUser(User);
            _usernameUtente = User.Username;
            _passwordUtente = User.Password;
            _emailUtente = User.Email;
            _descriptionUtente = User.Description;
            _firstNameUtente = User.FirstName;
            _lastNameUtente = User.LastName;
        }

        internal void ChangePassword(User User)
        {
            dl.ChangePassword(User);
            _passwordUtente = User.Password;
        }
        internal void CreateUser(User User)
        {
            dl.CreateUser(User);
            _usernameUtente = User.Username;
            _passwordUtente = User.Password;
            _emailUtente = User.Email;
            _descriptionUtente = User.Description;
            _firstNameUtente = User.FirstName;
            _lastNameUtente = User.LastName;
        }
        #endregion
        private User ReadCredentialsFromDatabase(User CredentialsFromUser)
        {
            User u = new User(CredentialsFromUser.Username, CredentialsFromUser.Password);
            return u;
        }
        private User WriteCredentialsToDatabase(User CredentialsFromUser)
        {
            User u = new User(CredentialsFromUser.Username, CredentialsFromUser.Password);
            return u;
        }
        private string CalculateHash(string ClearTextPassword)
        {
            // https://www.mattepuffo.com/blog/articolo/2496-calcolo-hash-sha256-in-csharp.html

            //Creazione di un hash tramite la spiegazione fornita dal sito
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
