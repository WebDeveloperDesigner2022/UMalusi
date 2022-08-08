using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage2 : FlyoutPage
    {
        //Map map = new Map();
        public MainPage2()
        {
            InitializeComponent();
            flyout.listView.ItemSelected += OnSelectedItem;
            DisplayCurrentLocation();
            
        }
        void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                flyout.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
        public async void DisplayCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Position p = new Position(location.Latitude, location.Longitude);
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(p, Distance.FromKilometers(.444));
                    map.MoveToRegion(mapSpan);
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    map.Pins.Add(pin);

                }
            }
           
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
        /* public async void DisplayLivestockPosition()
         {

         }
        */
        Pin pin = new Pin
        {
            Label = "Cow11",
            Address = "The city with a boardwalk",
            Type = PinType.Place,
            Position = new Position(36.9628066, -122.0194722)
        };
        
        
        
        private void ManageButton(object sender, EventArgs e)
        {

        }

        private void AlertButton(object sender, EventArgs e)
        {

        }

        private void shopButton(object sender, EventArgs e)
        {

        }
    }
}