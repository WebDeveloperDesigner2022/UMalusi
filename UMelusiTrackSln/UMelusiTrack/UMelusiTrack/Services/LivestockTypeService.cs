using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Services.Interfaces;
using UMelusiTrackApi.Models;

namespace UMelusiTrack.Services
{
    public class LivestockTypeService
    {
        static LivestockTypeService _instance;

        public static LivestockTypeService Instance =>
            _instance ?? (_instance = new LivestockTypeService());

        private HttpClient _httpClient;

        public LivestockTypeService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<LivestockType> LivestockType(string description)
        {

                var uri = new Uri(AppConfigurationService.Instance.uMalusiServerUrl + "api/LivestockType");

                try
                {
                    var request = new LivestockType() { Description = description};

                    var requestJson = JsonConvert.SerializeObject(request);
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PostAsync(uri, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var contentResponse = await response.Content.ReadAsStringAsync();

                        var valueResponse = JsonConvert.DeserializeObject<LivestockType>(contentResponse);

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
