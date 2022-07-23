using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Services;
using UMelusiTrack.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignPage : ContentPage
    {
        public SigninViewModel userModel;
        public  SignPage()
        {
            InitializeComponent();
            userModel = new SigninViewModel();
            
            MessagingCenter.Subscribe<SigninViewModel, string>(this, "Login Alert", (sender, username) =>
            {
                DisplayAlert("", username, "Ok");

                 //Navigation.PushAsync(new MainPage());
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

        private async void TestBtn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TestDBPage());
        }
    }
}