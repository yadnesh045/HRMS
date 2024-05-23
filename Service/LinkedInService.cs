using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace HRMS.Service
{
    public class LinkedInService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public LinkedInService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetAccessTokenAsync(string code)
        {
            var tokenEndpoint = _configuration["LinkedIn:TokenEndpoint"];
            var clientId = _configuration["LinkedIn:ClientId"];
            var clientSecret = _configuration["LinkedIn:ClientSecret"];
            var redirectUri = _configuration["LinkedIn:RedirectUri"];

            var requestContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri", redirectUri),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            });

            var response = await _httpClient.PostAsync(tokenEndpoint, requestContent);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseJson = JObject.Parse(responseContent);
            return responseJson["access_token"].ToString();
        }

        public async Task PostJobAsync(string accessToken, string jobDetailsJson)
        {
            var postJobEndpoint = _configuration["LinkedIn:PostJobEndpoint"];

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var content = new StringContent(jobDetailsJson, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(postJobEndpoint, content);

            // Log the response if it's not successfulz
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error posting job: {response.StatusCode} - {responseBody}");
            }

            response.EnsureSuccessStatusCode();
        }
    }
}
