using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Services.Interfaces;
using UMelusiTrackApi.Models;
using Xamarin.Forms;

namespace UMelusiTrack.Services
{
    public class FarmerService
    {
        static FarmerService _instance;

        public static FarmerService Instance =>
            _instance ?? (_instance = new FarmerService());

        private HttpClient _httpClient;

        public FarmerService()
        {
            IHttpNativeHandler service = DependencyService.Get<IHttpNativeHandler>();
            _httpClient = new HttpClient(service.GetHttpClientHandler());
        }

        public async Task<Farmer> Farmer(string names, string surname, string username, string password, string azureMapId , int authenticationId)
        {
            var uri = new Uri(AppConfigurationService.Instance.uMalusiServerUrl + "api/Farmer");

            try
            {
                var request = new Farmer() { Names = names, Surname = surname, Username = username, Password = password, AzureMapId = azureMapId };

                var requestJson = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();

                    var valueResponse = JsonConvert.DeserializeObject<Farmer>(contentResponse);

                    return valueResponse;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }
    }
}
