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
    public class TrackerService
    {
        static TrackerService _instance;

        public static TrackerService Instance =>
            _instance ?? (_instance = new TrackerService());

        private HttpClient _httpClient;

        public TrackerService()
        {
            IHttpNativeHandler service = DependencyService.Get<IHttpNativeHandler>();
            _httpClient = new HttpClient(service.GetHttpClientHandler());
        }
        public async Task<Tracker> Tracker(string description)
        {
            var uri = new Uri(AppConfigurationService.Instance.uMalusiServerUrl + "api/Tracker");

            try
            {
                var request = new Tracker() {Description = description };

                var requestJson = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();

                    var valueResponse = JsonConvert.DeserializeObject<Tracker>(contentResponse);

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
