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

        public string Username 
        {
            get => username;
            set
            {
                if (value == null)
                    throw new Exception("Inserire uno UserName!");
                username = value;
            } 
        }
        public string LastName 
        { 
            get => lastName;
            set
            {
                if (value == null)
                    throw new Exception("Inserire un Cognome!");
                lastName = value;
            }
        }
        public string FirstName 
        { 
            get => firstName;
            set
            {
                if (value == null)
                    throw new Exception("Inserire un Nome!");
                firstName = value;
            }
        }
        public string Password { get => password; set => password = value; }
        public string Description 
        { 
            get => description;
            set
            {
                if (value == null)
                    throw new Exception("Inserire una Descrizione!");
                description = value;
            }
        }
        private int idUserType;
        public string Email { get => email; set => email = value; }
        public DateTime? CreationTime { get => create_time; set => create_time = value; }
        public DateTime? LastChange { get; internal set; }
        public DateTime? LastPasswordChange { get; internal set; }
        public string Salt { get => salt; set => salt = value; }
        public int? IdUserCategory { get => idUserCategory; set => idUserCategory = value; }
        public bool? IsEnabled { get; internal set; }
        public int IdUserType { get => idUserType; set => idUserType = value; }

        public User(string Username, string Password)
        {
            this.username = Username;
            this.password = Password;
        }

        public User(string userName, string firstName, string lastName, string desc, string email)
        {
            Username = userName;
            FirstName = firstName;
            LastName = lastName;
            Description = desc;
            CreationTime = DateTime.Now;
            LastChange = DateTime.Now;
            LastPasswordChange = DateTime.Now;
            Email = email;
        }

        public override string ToString()
        {
            return $" {Username} : {Description}";
        }
    }
}
