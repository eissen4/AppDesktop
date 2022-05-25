using System;
using System.Collections.Generic;
using System.Text;

namespace AppDesktop
{
    public class Team
    {
        public string _id;
        public string name;
        public string user;

        public string _Id { get => _id; set => _id = value; }
        public string Name { get => name; set => name = value; }
        public string User { get => user; set => user = value; }
    }
}
