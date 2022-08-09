using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void Signout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignPage());
        }

        private void Signup_Clicked(object sender, EventArgs e)
        {

        }

        private void Signout_Clicked(object sender, EventArgs e)
        {

        }

        private void signoutBtn(object sender, EventArgs e)
        {

        }
    }
}