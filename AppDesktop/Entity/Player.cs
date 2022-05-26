using System;
using System.Collections.Generic;
using System.Text;

namespace AppDesktop.Entity
{
    public class Player
    {
        public string _id;
        public string name;
        public string team;
        public string height;
        public string weight;
        public string image;

        public string _Id { get => _id; set => _id = value; }
        public string Name { get => name; set => name = value; }
        public string Team { get => team; set => team = value; }
        public string Height { get => height; set => height = value; }
        public string Weight { get => weight; set => weight = value; }

        public string Image { get => image; set => image = value; }

        public Player() { }
    }
}
