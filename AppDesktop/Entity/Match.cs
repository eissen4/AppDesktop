using System;
using System.Collections.Generic;
using System.Text;

namespace AppDesktop.Entity
{
    public class Match
    {
        public string _id;
        public string opponent;
        public int scoreOne;
        public int scoreTwo;

        public string Id { get => _id; set => _id = value; }
        public string Opponent { get => opponent; set => opponent = value; }
        public int ScoreOne { get => scoreOne; set => scoreOne = value; }
        public int ScoreTwo { get => scoreTwo; set => scoreTwo = value; }

    }
}
