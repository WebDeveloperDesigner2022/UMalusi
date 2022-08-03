using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Globalization;

namespace GeofenceTester
{
    public  class GeoFenceTest
    {

        string UDID = "89047b39-623f-4c35-d21f-daae0617b058";
        string SUBSCRIPTION_KEY = "zrZKz5tVp3CZsombqLRVAWZ98T0W71VkwQwxfo4QgDA";


        public async Task Run()
        {
           


            var cow = new Livestock();
            cow.LivestockId = "cow001";
            

            cow.Lon = 18.623971939086914;
            cow.Lat = -33.93018613610004;

 




            var isInFence = await IsLivestockWithinFence(cow, UDID, SUBSCRIPTION_KEY);



            Console.WriteLine(isInFence);
        }

        /*public async Task<string> GetAddrAsync(HttpClient client, string subscriptionKey, string query)
        {

            string aUri = "https://atlas.microsoft.com/search/address/reverse/json?zrZKz5tVp3CZsombqLRVAWZ98T0W71VkwQwxfo4QgDA&api-version=1.0&query={1}";
            string url = string.Format(aUri, SUBSCRIPTION_KEY, query);

            HttpResponseMessage AdrsResponse = await client.GetAsync(url);

            string AdrsResponseBody = await AdrsResponse.Content.ReadAsStringAsync();
            dynamic adrsData = JsonConvert.DeserializeObject(AdrsResponseBody);
            string address = adrsData?.addresses?[0]?.address?.freeformAddress;

            return address;
        }
        */

        public async Task<bool> IsLivestockWithinFence(Livestock livestock, string udid,  string subscriptionKey)
        {

            using (var client = new HttpClient())
            {


                CultureInfo culture = new CultureInfo("en-US");

                string gUri = "https://atlas.microsoft.com/spatial/geofence/json?subscription-key={0}&api-version=1.0&deviceId={1}&isAsync=false&udId={2}&lat={3}&lon={4}&searchBuffer=2&mode=EnterAndExit";

                string geoUri = string.Format(gUri, subscriptionKey, livestock.LivestockId, udid, livestock.Lat.ToString(culture), livestock.Lon.ToString(culture));

                HttpResponseMessage response = await client.GetAsync(geoUri);
                string responseBody = await response.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject(responseBody);
                int distance = data?.geometries[0]?.distance;

                if (distance > 0)
                    return false;
                else
                    return true;


                //static dynamic data = JsonConvert.DeserializeObject(File.ReadAllText(@"geofencedata/coOrds.json"));
                //static Array locations = data["feature"][0]["geometry"]["coordinates"];
                //static List<List<double>> coordList = locations.ToObject<List<List<double>>>();

            }
        }
    }
}
