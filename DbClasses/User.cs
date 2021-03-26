using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.DbClasses
{
    public class User
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
        //int idUserCategory;
        string? imageUrl;

        public string Username { get => username; set => username = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Password { get => password; set => password = value; }
        public string Description { get => description; set => description = value; }
        private int idUserType;
        public string Email { get => email; set => email = value; }
        public DateTime? CreationTime { get => create_time; set => create_time = value; }
        public DateTime? LastChange { get; internal set; }
        public DateTime? LastPasswordChange { get; internal set; }
        public string Salt { get => salt; set => salt = value; }
        public int? IdUserCategory { get => idUserCategory; set => idUserCategory = value; }
        //public int IdUserCategory { get => idUserCategory; set => idUserCategory = value; }
        public bool? IsEnabled { get; internal set; }
        public int IdUserType { get => idUserType; set => idUserType = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }

        public User() { }

        public User(string Username, string Password)
        {
            this.username = Username;
            this.password = Password;
        }

        public override string ToString()
        {
            return Username + ": "+ Description;
        }
    }
}
