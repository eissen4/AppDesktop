using System;
using System.Collections.Generic;
using System.Text;

namespace AppDesktop.ApiConnection
{
    class TokenResponse
    {
        public string token;
        public string Token { get => token; set => token = value; }
        
        public TokenResponse(string newToken)
        {
            token = newToken;
        }
    }
}
