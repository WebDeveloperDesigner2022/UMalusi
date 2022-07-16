using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrackApi.Models;

namespace UMelusiTrack.Services
{
    public class AuthenticationService
    {
        static AuthenticationService _instance;

        public static AuthenticationService Instance =>
            _instance ?? (_instance = new AuthenticationService());

        private HttpClient _httpClient;

        public AuthenticationService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var uri = new Uri(AppConfigurationService.Instance.uMalusiServerUrl + "api/Authentication");

            try
            {
                var request = new AuthRequest() { Username = username, Password = password };

                var requestJson = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();

                    var valueResponse = JsonConvert.DeserializeObject<bool>(contentResponse);

                    return valueResponse;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return false;
        }

    }
}
