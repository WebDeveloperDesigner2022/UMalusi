using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void ManageButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Manage());
        }

        private async void shopButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuyPage());
        }

        private async void AlertButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Alerts());
        }

        private async void LocateButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }
    }
}