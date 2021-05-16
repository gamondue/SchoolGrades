using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.DbClasses
{
    class User
    {
        //Campi di classe
        string username;
        string firstName;
        string lastName;
        string password;
        string description;
        string email;
        DateTime? create_time;
        string salt;
        int? idUserCategory;

        //Proprietà per ogni campo di classe
        public string Username { get => username; set => username = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }
        public string Description { get => description; set => description = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Email { get => email; set => email = value; }
        public DateTime? CreationTime { get => create_time; set => create_time = value; }
        public DateTime? LastChange { get; internal set; }
        public DateTime? LastPasswordChange { get; internal set; }
        public string Salt { get => salt; set => salt = value; }
        public int? IdUserCategory { get => idUserCategory; set => idUserCategory = value; }
        public bool? IsEnabled { get; internal set; }

        /// <summary>
        /// Metodo costruttore di un Utente base con l'inserimento di un username e di una password
        /// </summary>
        /// <param name="Username">Username dell'utente</param>
        /// <param name="Password">Password dell'utente</param>
        public User(string Username, string Password)
        {
            //Nel caso l'utente non abbia nessuna username e password viene creata una eccezione
            if ((Username == null) || (Password == null))
                throw new Exception("Username o password non accettabile");
            //Sostituzione del valore del campo di classe con il nuovo valore
            this.username = Username;
            this.password = Password;
        }

        public User(string Username, string Password, string Description, string LastName, string FirstName, string Email)
        {
            //Nel caso l'utente non abbia una delle informazioni necessarie per la creazione viene inviata una nuova eccezione
            if ((Username == null) || (Password == null) || (Description == null) || (LastName == null) || (FirstName == null) || (Email == null))
                throw new Exception("Informazioni ricevute non accettabili");
            //Sostituzione del valore del campo di classe con il nuovo valore
            this.username = Username;
            this.password = Password;
            this.description = Description;
            this.lastName = LastName;
            this.firstName = FirstName;
            this.Email = Email;
        }
    }
}
