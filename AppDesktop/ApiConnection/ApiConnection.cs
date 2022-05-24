using AppDesktop.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppDesktop.ApiConnection
{
    public static class ApiConnection
    {
        public static string URL = "http://localhost:3000";

        //public async Task<string> Login(string username, string password)
        //{
        //    string uri = URL + "/login";

        //    string token = "";

        //    return token;
        //}

        public static async Task<List<Team>> GetTeamAsync()
        {
            string uri = URL + "/team/getTeamPerToken";

            string teamJson = await ApiMethods.Get(uri);

            List<Team> team = JsonSerializer.Deserialize<List<Team>>(teamJson, ApiMethods.GetJsonOptions());
            return team;
        }

        public static async Task<List<Match>> GetMatchesAsync()
        {
            string uri = URL + "/match/getAllMatchesFromUser";

            string matchJson = await ApiMethods.Get(uri);

            List<Match> matches = JsonSerializer.Deserialize<List<Match>>(matchJson, ApiMethods.GetJsonOptions());
            return matches;
        }
    }
}
