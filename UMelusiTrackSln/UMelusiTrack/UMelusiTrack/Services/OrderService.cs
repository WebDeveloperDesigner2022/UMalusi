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
    public class OrderService
    {
        static OrderService _instance;

        public static OrderService Instance =>
            _instance ?? (_instance = new OrderService());

        private HttpClient _httpClient;

        public OrderService()
        {
            IHttpNativeHandler service = DependencyService.Get<IHttpNativeHandler>();
            _httpClient = new HttpClient(service.GetHttpClientHandler());
        }
        public async Task<Order> Order(Farmer farmer, string name, string surname, int farmerid, int quantity, string referenceNo, string deliveryAddress, string contactNo, string email)
        {
            var uri = new Uri(AppConfigurationService.Instance.uMalusiServerUrl + "api/Order");

            try
            {
                var request = new Order() { Name = name, Surname = surname, Quantity = quantity, ReferenceNo = referenceNo, DeliveryAddress = deliveryAddress, ContactNo = contactNo, Email = email, FarmerId = farmerid };

                request.Farmer = farmer;
                request.FarmerId = farmer.FarmerId;

                var requestJson = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();

                    var valueResponse = JsonConvert.DeserializeObject<Order>(contentResponse);

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
