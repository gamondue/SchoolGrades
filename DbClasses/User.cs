using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.DbClasses
{
    class User
    {
        string username;
        string firstName;
        string lastName;
        string password;
        string description;
        string email;
        DateTime? create_time;
        string salt;
        int? idUserCategory;

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

        public User(string Username, string Password)
        {
            if ((Username == null) || (Password == null))
                throw new Exception("Username o password non accettabile");
            this.username = Username;
            this.password = Password;
        }

        public User(string Username, string Password, string Description, string LastName, string FirstName, string Email)
        {
            if ((Username == null) || (Password == null) || (Description == null) || (LastName == null) || (FirstName == null) || (Email == null))
                throw new Exception("Informazioni ricevute non accettabili");
            this.username = Username;
            this.password = Password;
            this.description = Description;
            this.lastName = LastName;
            this.firstName = FirstName;
            this.Email = Email;
        }
    }
}
