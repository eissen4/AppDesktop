using System;
using System.Collections.Generic;
using System.Text;

namespace AppDesktop.ApiConnection
{
    class LoginRequest
    {
        private string username;
        private string password;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public LoginRequest(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
