using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Models;
using UMelusiTrack.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignPage : ContentPage
    {
        public UserModel userModel;
        public SignPage()
        {
            InitializeComponent();
            userModel = new UserModel();
            
            MessagingCenter.Subscribe<UserModel, string>(this, "Login Alert", (sender, username) =>
            {
                DisplayAlert("", username, "Ok");
            });
            this.BindingContext = userModel;

            entUsername.Completed += (object sender, EventArgs e) =>
            {
                entPassword.Focus();
            };

            entPassword.Completed += (object sender, EventArgs e) =>
            {
                userModel.SubmitCommand.Execute(null);

            };
        }

        private async void Signup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }
    }
}