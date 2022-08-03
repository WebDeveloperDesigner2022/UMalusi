using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmalusiGeofenceSln
{
    public  class GeoFence
    {

        string UDID = "7ae1a31d-ad7c-444d-51fc-f505b1ab417e";
        string SUBSCRIPTION_KEY = "75p4ixeZVA2MPSM3TtFKX8mqpHfw_D8RdnC2jrmWlds";
        
        public async Task Run()
        {
            var client = new HttpClient();

            var cow = new Livestock();
            cow.LivestockId = "cow001";
            cow.Lon = -77.04438328742981;
            cow.Lat = 38.909644092180656;


            await GetGeoAsync(cow, client, SUBSCRIPTION_KEY);

        }

        public async Task<string> GetAddrAsync(HttpClient client, string subscriptionKey, string query)
        {

            string aUri = "https://atlas.microsoft.com/search/address/reverse/json?subscription-key={0}&api-version=1.0&query={1}";
            string url = string.Format(aUri, SUBSCRIPTION_KEY, query);

            HttpResponseMessage AdrsResponse = await client.GetAsync(url);

            string AdrsResponseBody = await AdrsResponse.Content.ReadAsStringAsync();
            dynamic adrsData = JsonConvert.DeserializeObject(AdrsResponseBody);
            string address = adrsData?.addresses?[0]?.address?.freeformAddress;

            return address;
        }

        public async Task GetGeoAsync(Livestock livestock, HttpClient client, string subscriptionKey)
        {
            string gUri = "https://atlas.microsoft.com/spatial/geofence/json?subscription-key={0}&api-version=1.0&deviceId={1}&isAsync=false&udId={2}&lat={3}&lon={4}&searchBuffer=2&mode=EnterAndExit";
            string geoUri = string.Format(gUri, subscriptionKey, livestock.LivestockId, UDID, livestock.Lat.ToString(), livestock.Lon.ToString());

            HttpResponseMessage response = await client.GetAsync(geoUri);
            string responseBody = await response.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(responseBody);
            int distance = data?.geometries[0]?.distance;

            Console.WriteLine($"Location: [{livestock.Lat}, {livestock.Lon}], Distance: {distance}");

        }
    }
}
