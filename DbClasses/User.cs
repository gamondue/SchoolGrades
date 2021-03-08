using System;
using System.Collections.Generic;
using System.Text;

namespace DbClasses
{
    class User
    {
        string username;
        string lastName;
        string firstName;
        string email;
        string password;
        DateTime create_time;
        string salt;
        int idUserCategory;

        public string Username { get => username; set => username = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }
    }
}
