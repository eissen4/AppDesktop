using System;
using System.Collections.Generic;
using System.Text;

namespace AppDesktop.ApiConnection
{
    public class Register
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Register(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email; 
        }
    }
}
