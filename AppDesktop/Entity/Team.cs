using System;
using System.Collections.Generic;
using System.Text;

namespace AppDesktop.Entity
{
    public class NewTeamRequest
    {
        public string name;

        public string Name { get => name; set => name = value; }

        public NewTeamRequest(string name)
        {
            Name = name;
        }
    }
}