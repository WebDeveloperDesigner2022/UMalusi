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
    public class LivestockPositionService
    {
        static LivestockPositionService _instance;

        public static LivestockPositionService Instance =>
            _instance ?? (_instance = new LivestockPositionService());

        private HttpClient _httpClient;

        public LivestockPositionService()
        {
            IHttpNativeHandler service = DependencyService.Get<IHttpNativeHandler>();
            _httpClient = new HttpClient(service.GetHttpClientHandler());
        }

        public async Task<LivestockPosition> LivestockPosition(string livestockName, double latitude, double longitude, DateTime dateTime, int livestockid)
        {
            var uri = new Uri(AppConfigurationService.Instance.uMalusiServerUrl + "api/LivestockPosition");

            try
            {
                var request = new LivestockPosition() { LivestockName = livestockName, Latitude = latitude, Longitude = longitude, DateTime = dateTime, LivestockId = livestockid };

                var requestJson = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();

                    var valueResponse = JsonConvert.DeserializeObject<LivestockPosition>(contentResponse);

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
