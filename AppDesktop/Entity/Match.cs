using System;
using System.Collections.Generic;
using System.Text;

namespace AppDesktop.Entity
{
    public class Match
    {
        public string _id;
        public string team;
        public string opponent;
        public int scoreOne;
        public int scoreTwo;
        public DateTime date;

        public string _Id { get => _id; set => _id = value; }
        public string Team { get => team; set => team = value; }    
        public string Opponent { get => opponent; set => opponent = value; }
        public int ScoreOne { get => scoreOne; set => scoreOne = value; }
        public int ScoreTwo { get => scoreTwo; set => scoreTwo = value; }
        public DateTime Date { get => date; set => date = value; }  
    }
}
