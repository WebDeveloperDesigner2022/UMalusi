using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UMelusiTrack
{
    public partial class ShopPage : ContentPage
    {
        public ShopPage()
        {
            InitializeComponent();
        }

        private async void cancelBtn(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void saveBtn(object sender, EventArgs e)
        {

        }
    }
}
