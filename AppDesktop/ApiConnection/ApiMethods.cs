using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppDesktop.ApiConnection
{
    public class ApiMethods
    {
        public static readonly HttpClient httpClient = new HttpClient();
        public string token;
        private static string URL = "http://localhost:3000/";

        public string Token { get => token; set => token = value; }

        public static async Task<string> Get(string uri)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2MjdhOGM3MWI2NDIwNGZhYWEwZjFkNzkiLCJpYXQiOjE2NTM0MDkyODZ9.qphhTlJws2vSABZl1rNr7elbmW23WpD6vMP61ACp3e0");

            HttpResponseMessage response = await httpClient.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }

        //public static async Task<string> Post(string uri, object data)
        //{
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2MjdhOGM3MWI2NDIwNGZhYWEwZjFkNzkiLCJpYXQiOjE2NTMzMjU5MjR9.WhWmdFsea2iTBut-vdW0PqsrgYDNKNQu6TrYT3U1ctM");
        //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    StringContent stringContent = new(JsonSerializer.Serialize(data, GetJsonOptions()));
        //    HttpResponseMessage response = await httpClient.PostAsync(uri, stringContent);
        //}

        //public static async Task<string> Login(string username, string password)
        //{
        //    string uri = URL + "login";
        //    Authentifier auth = new Authentifier(username, password); 
        //}

        internal static JsonSerializerOptions GetJsonOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            return options;
        }
    }
}
