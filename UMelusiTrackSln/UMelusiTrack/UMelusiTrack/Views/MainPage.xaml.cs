using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Views;
using Xamarin.Forms;

namespace UMelusiTrack
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

     
        private async void ManageButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Manage());
        }

        private async void shopButton(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new ShopPage());
        }

        private async void AlertButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Alerts());
        }

        private async void LocateButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }

        private void MenuButton(object sender, EventArgs e)
        {

        }
    }
}
