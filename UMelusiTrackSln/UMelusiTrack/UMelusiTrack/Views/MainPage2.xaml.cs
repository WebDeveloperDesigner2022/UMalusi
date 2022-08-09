using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.ViewModel;
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
            //            CreateFence();

            var vm = new MapGeoJsonViewModel(Navigation);

            BindingContext = vm;

        }

        private async void MyHerdButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Manage());
        }

        private async void BuyButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuyPage());
        }

        private async void AlertButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Alerts());
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
        private void CreateFence()
        {
            var vm = BindingContext as MapGeoJsonViewModel;

            if (vm != null)
            {

                var polygon = new Polygon();

                polygon.FillColor = Color.Red;
                polygon.StrokeColor = Color.Black;
                polygon.StrokeWidth = 2;

                if (vm.MapGeoFence != null)
                {
                    List<Position> positions = vm.MapGeoFence;

                    foreach (var position in positions)
                        polygon.Geopath.Add(position);
                }


                map.MapElements.Add(polygon);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CreateFence();

        }



        //  private void ManageButton(object sender, EventArgs e)
        //  {

        //  }

        //   private void AlertButton(object sender, EventArgs e)
        //  {

        //  }

        //   private void shopButton(object sender, EventArgs e)
        //   {

        //   }
    }

   
}