using AppDesktop.Entity;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static string token;

        public string Token { get => token; set => token = value; }

        public static async Task<string> Get(string uri)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = await httpClient.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> Post(object data, string uri)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent stringcontent = new StringContent(JsonSerializer.Serialize(data, GetJsonOptions()),Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, stringcontent);

            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> PostLogin(Authentifier authentifier, string uri)
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
             
            var json = JsonSerializer.Serialize(authentifier);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, stringContent);

            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> PostImage(MultipartFormDataContent form, string uri)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

            HttpResponseMessage response = await httpClient.PostAsync(uri, form);

            return await response.Content.ReadAsStringAsync();
        }

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
