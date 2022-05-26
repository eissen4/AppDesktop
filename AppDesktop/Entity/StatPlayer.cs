using System;
using System.Collections.Generic;
using System.Text;

namespace AppDesktop.Entity
{
    public class StatPlayer
    {
        public string _id { get; set; }
        public string team { get; set; }
        public string match { get; set; }
        public string opponent { get; set; }
        public DateTime date { get; set; }
        public int points { get; set; }
        public int rebounds { get; set; }
        public int assists { get; set; }
    }
}
