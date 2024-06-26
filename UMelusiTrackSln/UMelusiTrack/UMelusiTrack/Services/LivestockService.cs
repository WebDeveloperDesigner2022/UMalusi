﻿using Newtonsoft.Json;
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
    public class LivestockService 
    {
        static LivestockService _instance;

        public static LivestockService Instance =>
            _instance ?? (_instance = new LivestockService());

        private HttpClient _httpClient;

        public LivestockService()
        {
            IHttpNativeHandler service = DependencyService.Get<IHttpNativeHandler>();
            _httpClient = new HttpClient(service.GetHttpClientHandler());
        }

        public async Task<Livestock> RegisterLivestock(Farmer farmer,  string livestockName, string dob, string color, byte[] image, int farmerid, int livestockTypeid)
        {
            var uri = new Uri(AppConfigurationService.Instance.uMalusiServerUrl + "api/Livestock");

            try
            {
                var request = new Livestock() { LivestockName = livestockName, DOB = dob, Color = color, Image = image, FarmerId = farmerid, LivestockTypeId = livestockTypeid  };

                request.Farmer = farmer;
                request.FarmerId = farmer.FarmerId;
                

                var requestJson = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();

                    var livestock = JsonConvert.DeserializeObject<Livestock>(contentResponse);

                    return livestock;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;

        }

        public async Task<List<Livestock>> GetLivestockByFarmerId(int farmerId )
        {
            //  api/Livestock/byfarmerid?farmerId=2

            var uri = new Uri(AppConfigurationService.Instance.uMalusiServerUrl + "api/Livestock/byfarmerid?farmerId=" + farmerId);

            try
            {
         
                var response = await _httpClient.GetStringAsync(uri);

                    var livestock = JsonConvert.DeserializeObject<List<Livestock>>(response);

                    return livestock;
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return new List<Livestock>();

        }

    }
}
