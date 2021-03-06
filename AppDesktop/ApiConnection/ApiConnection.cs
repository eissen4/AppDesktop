using AppDesktop.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
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
            try
            {
                string tokenResponse = await ApiMethods.PostLogin(authentifier, uri);
                TokenResponse token = JsonSerializer.Deserialize<TokenResponse>(tokenResponse, ApiMethods.GetJsonOptions());

                return token.Token;
            } catch
            {
                return null;
            }
            
        }
        public static async Task<Register> Register(string username, string password, string email)
        {
            string uri = URL + "/register";

            Register register = new Register(username, password, email);

            
            try
            {
                string registerResponseJson = await ApiMethods.PostRegister(register, uri);

                Register registerResponse = JsonSerializer.Deserialize<Register>(registerResponseJson, ApiMethods.GetJsonOptions());

                return registerResponse;
            } catch
            {
                return null;
            }
            
        }

        public static async Task<List<Team>> GetTeamAsync()
        {
            string uri = URL + "/team/getTeamPerToken";

            string teamJson = await ApiMethods.Get(uri);

            List<Team> team = JsonSerializer.Deserialize<List<Team>>(teamJson, ApiMethods.GetJsonOptions());
            return team;
        }

        internal static async Task<List<StatPlayer>> GetStatsMatchAsync(string matchId)
        {
            string uri = URL + "/statPlayerMatch/getAllStatsFromMatch/" + matchId;

            string statsJson = await ApiMethods.Get(uri);

            List<StatPlayer> stats = JsonSerializer.Deserialize<List<StatPlayer>>(statsJson, ApiMethods.GetJsonOptions());

            return stats;
        }

        internal static async Task<List<Exercise>> GetExercisesAsync()
        {
            string uri = URL + "/exercise";

            string exercisesJson = await ApiMethods.Get(uri);

            List<Exercise> exercises = JsonSerializer.Deserialize<List<Exercise>>(exercisesJson, ApiMethods.GetJsonOptions());

            return exercises;
        }

        internal static async Task<List<Exercise>> GetExercisesWorldAsync(string keys)
        {
            string uri = URL + "/exercise/getExerciseSearched/" + keys;

            string exercisesJson = await ApiMethods.Get(uri);

            List<Exercise> exercises = JsonSerializer.Deserialize<List<Exercise>>(exercisesJson, ApiMethods.GetJsonOptions());

            return exercises;
        }

        public static async Task<List<Match>> GetPlayerMatchesAsync(string playerId)
        {
            string uri = URL + "/player/getAllMatchesFromPlayer/" + playerId;

            string playerMatchesJson = await ApiMethods.Get(uri);

            List<Match> playerMatches = JsonSerializer.Deserialize<List<Match>>(playerMatchesJson, ApiMethods.GetJsonOptions());

            return playerMatches;
        }

        

        public async static Task<List<Player>> GetPlayersAsync(string teamId)
        {
            string uri = URL + "/team/getPlayersPerTeam/" + teamId;

            string playersJson = await ApiMethods.Get(uri);

            List<Player> players = JsonSerializer.Deserialize<List<Player>>(playersJson, ApiMethods.GetJsonOptions());

            return players;
        }

        public async static Task<List<StatPlayer>> GetPlayersStatsAsync(string playerId)
        {
            string uri = URL + "/statPlayerMatch/getAllStatsFromPlayer/" + playerId;

            string playerStatsJson = await ApiMethods.Get(uri);

            List<StatPlayer> playerStats = JsonSerializer.Deserialize<List<StatPlayer>>(playerStatsJson, ApiMethods.GetJsonOptions());

            return playerStats;
        }

        public static async Task<List<Match>> GetMatchesAsync(string team)
        {
            string uri = URL + "/match/getAllMatchesFromTeam/" + team;
            //string uri = URL + "/match";

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

        public static async Task PostStatPlayerAsync(StatPlayer statPlayer)
        {
            string uri = URL + "/statPlayerMatch";

            string response = await ApiMethods.Post(statPlayer, uri);
        }

        public static async void PostMatchAsync(Match newMatch)
        {
            string uri = URL + "/match";

            string response = await ApiMethods.Post(newMatch, uri);
        }
        public static async Task PostImage(string title, string description)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();

            string uri = URL + "/exercise";

            Exercise exercise = new Exercise();
            DateTime date = DateTime.Now;

            var fileStream = new FileStream("file.jpg", FileMode.Open);
            form.Add(new StringContent(title), "title");
            form.Add(new StringContent(date.ToString()), "imageUrl");
            form.Add(new StringContent(description), "description");
            form.Add(new StreamContent(fileStream), "file", "a.jpg");

            await ApiMethods.PostImage(form, uri);
        }

        public static async Task DeleteMatchAsync(string match)
        {
            string uri = URL + "/match/" + match;

            string response = await ApiMethods.Delete(uri);
        }
    }
}
