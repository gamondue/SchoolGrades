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
        // create the next after the program that is using this has read the configuration file 
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

        /// <summary>
        /// Metodo costruttore base del BusinessLayer
        /// </summary>
        internal BusinessLayer()
        {
        }

        #region Serie di proprietà per cambiare le varie informazioni dell'utente
        //Proprietà per l'Username dell'utente
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

        //Proprietà per la Password dell'utente
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

        //Proprietà per il Nome dell'utente
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

        //Proprietà per il Cognome dell'utente
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

        //Proprietà per la Descrizione dell'utente
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

        //Proprietà per l'Email dell'utente
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

        /// <summary>
        /// Sostituzione dell'uso della password dell'utente con gli Hash. Permette di confrontare i dati dell'utente con quelli presente nell'oggetto Utente del programma
        /// </summary>
        /// <param name="Username">Username inserita dall'utente</param>
        /// <param name="Password">Password inserita dall'utente</param>
        /// <param name="HashCalcolato">Hash calcolato dal metodo CalculateHash</param>
        /// <returns></returns>
        internal bool UserHasLoginPermission(string Username, string Password, string HashCalcolato)
        {
            //Dichiarazione degli Hash di lavoro
            byte[] byteOrigine;
            byte[] byteNuovoHash;
            byte[] byteOrigineDaConfrontare;
            byte[] byteHashDaConfrontare;
            bool hashEquivalenti = false;

            User uFromDb = GetUser(Username);

            //Associazione dati dell'Username con gli Hash dichiarati precedentemente
            byteOrigine = ASCIIEncoding.ASCII.GetBytes(Password);
            byteNuovoHash = new MD5CryptoServiceProvider().ComputeHash(byteOrigine);
            byteOrigineDaConfrontare = ASCIIEncoding.ASCII.GetBytes(HashCalcolato);
            byteHashDaConfrontare = new MD5CryptoServiceProvider().ComputeHash(byteOrigineDaConfrontare);

            if (byteNuovoHash.Length == byteHashDaConfrontare.Length) //Se il vecchio Hash e il nuovo Hash sono uguali
            {
                for (int i = 0; (i < byteNuovoHash.Length) && (byteNuovoHash[i] == byteHashDaConfrontare[i]); i++)
                {
                    if (i == byteNuovoHash.Length)
                    {
                        hashEquivalenti = true;
                    }
                }

            }

            //Nel caso i dati dell'utente combacino con quelli degli hash viene restituito come risultato un booleano true
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
        /// <summary>
        /// Aggiorna i dati presenti con quelli all'interno dell'oggetto Utente
        /// </summary>
        /// <param name="User">Utente con il quale aggiornare i dati correnti</param>
        internal void UpdateUser(User User)
        {
            dl.UpdateUser(User); //Aggiorna l'utente
            //Sostituzione del valore di ogni campo di classe
            _usernameUtente = User.Username;
            _passwordUtente = User.Password;
            _emailUtente = User.Email;
            _descriptionUtente = User.Description;
            _firstNameUtente = User.FirstName;
            _lastNameUtente = User.LastName;
        }

        /// <summary>
        /// Aggiorna la password dell'utente
        /// </summary>
        /// <param name="User">Oggetto Utente dal quale reperire la password</param>
        internal void ChangePassword(User User)
        {
            dl.ChangePassword(User); //Cambia la password dell'utente
            _passwordUtente = User.Password;
        }

        /// <summary>
        /// Crea un nuovo utente, assegnando ad ogni campo di classe il suo corrispettivo valore
        /// </summary>
        /// <param name="User"></param>
        internal void CreateUser(User User)
        {
            dl.CreateUser(User); //Crea l'utente
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
        /// <summary>
        /// Calcola l'Hash della password inserita utilizzando il metodo espresso nel link all'interno del metodo
        /// </summary>
        /// <param name="ClearTextPassword">Stringa di cui calcolare l'Hash</param>
        /// <returns></returns>
        internal string CalculateHash(string ClearTextPassword)
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
