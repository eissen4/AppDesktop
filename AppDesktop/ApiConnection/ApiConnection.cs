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

        public static async Task<string> Login(string username, string password)
        {
            string uri = URL + "/login";

            Authentifier authentifier = new Authentifier(username, password);

            string token = await ApiMethods.PostLogin(authentifier, uri);

            return token;
        }

        public static async Task<List<Team>> GetTeamAsync()
        {
            string uri = URL + "/team/getTeamPerToken";

            string teamJson = await ApiMethods.Get(uri);

            List<Team> team = JsonSerializer.Deserialize<List<Team>>(teamJson, ApiMethods.GetJsonOptions());
            return team;
        }

        public static async Task<List<Match>> GetMatchesAsync(string team)
        {
            string uri = URL + "/match/getAllMatchesFromTeam" + team;

            string matchJson = await ApiMethods.Get(uri);

            List<Match> matches = JsonSerializer.Deserialize<List<Match>>(matchJson, ApiMethods.GetJsonOptions());
            return matches;
        }

        public static async Task PostTeamAsync(string name)
        {
            NewTeamRequest team = new NewTeamRequest(name);
            string uri = URL + "/team";
            string response = await ApiMethods.Post(team, uri);
        }

        public static async void PostPlayerAsync(Player player)
        {
            string uri = URL + "/player";
            string response = await ApiMethods.Post(player, uri);   
        }
    }
}
