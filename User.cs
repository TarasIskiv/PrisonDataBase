using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonDataBaseWpfApp
{
    public class User
    {
        public int id { get; set; }
        private string login;
        private string password;
        private string email;
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        

        public User() { }

        public User(string log, string pass, string email)
        {
            login = log;
            password = pass;
            this.email = email;
        }

        public override string ToString()
        {
            return $"Id : {id}\tLogin : {login}\tEmail : {email}";
        }

    }
}
