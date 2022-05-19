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

        public static async Task<string> Get(string uri)
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("auth-token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2MjdhOGM3MWI2NDIwNGZhYWEwZjFkNzkiLCJpYXQiOjE2NTI4OTU5MDJ9.rynJzsxgp8wMphIrRykAT-EX_YpGwAwRP49nkRvWtic");

            HttpResponseMessage response = await httpClient.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }

        internal static JsonSerializerOptions GetJsonOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            return options;
        }
    }
}
