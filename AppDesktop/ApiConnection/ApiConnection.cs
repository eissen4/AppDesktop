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

        public static async Task<Team> GetTeamAsync()
        {
            string uri = URL + "/team/getTeamPerId/6284e727b2c0f9715c363bd0";

            string teamJson = await ApiMethods.Get(uri);

            Team team = JsonSerializer.Deserialize<Team>(teamJson, ApiMethods.GetJsonOptions());
            return team;
        }
    }
}
