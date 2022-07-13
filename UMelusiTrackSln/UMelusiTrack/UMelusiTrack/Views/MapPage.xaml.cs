using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private object txtLatitude;
        private object txtLongitude;

        public MapPage()
        {
            InitializeComponent();
            DisplayCurrentLocation();
            //this.NavigationCacheMode = NavigationCacheMode.Required;

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
      
        /*private void geofence(object sender, EventArgs e)
        {
            
           try
            {
                var newPoint = new Geopoint(new BasicGeoposition()
                {
                    Latitude = double.Parse(LatitudeText.Text),
                    Longitude = double.Parse(LongitudeText.Text)
                });
                var geofence = new Geofence(NameText.Text, new Geocircle(newPoint.Position, double.Parse(RadiusText.Text)),
                    MonitoredGeofenceStates.Entered | MonitoredGeofenceStates.Exited,
                    false, TimeSpan.FromSeconds(10));
                GeofenceMonitor.Current.Geofences.Add(geofence);
            }
            catch (Exception ex)
            {
                new MessageDialog("Exception thrown: " + ex.Message).ShowAsync();
            }
        }*/
       /* private void NewGeofence(string id, double latitude, double longitude, double radius)
        {
           
            var position = new BasicGeoposition
            {
                Latitude = latitude,
                Longitude = longitude
            };

            
            var geocircle = new Geocircle(position, radius);

       
            const MonitoredGeofenceStates mask = MonitoredGeofenceStates.Entered;

          
            var dwellTime = TimeSpan.FromSeconds(5);

         
            var geofence = new Geofence(id, geocircle, mask, false, dwellTime);

            if (!GeofenceMonitor.Current.Geofences.Contains(geofence))
                GeofenceMonitor.Current.Geofences.Add(geofence);
        }*/




    }
}
    
