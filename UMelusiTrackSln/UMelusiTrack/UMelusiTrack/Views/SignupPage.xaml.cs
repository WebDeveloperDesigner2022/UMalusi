using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Models;
using UMelusiTrack.Services;
using UMelusiTrack.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
            BindingContext = new SigningDataModel();
        }

        private async void Signup_Clicked(object sender, EventArgs e)
        {
            var data = (SigningDataModel)BindingContext;
            UmelusiDB database = await UmelusiDB.Instance;
            await database.SaveItemAsync(data);
            await Navigation.PopAsync();
        }
    }
}