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
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
            var signupVM = new SignupViewModel();
            // BindingContext = new SigningDataModel();
            MessagingCenter.Subscribe<SignupViewModel, string>(this, "Signup Alert", (sender, username)=>{
                DisplayAlert("", username, "ok");
            });
            this.BindingContext = signupVM;
            firstname.Completed += (object sender, EventArgs e) =>
            {
                firstname.Focus();
            };
            lastname.Completed += (object sender, EventArgs e) =>
            {
                lastname.Focus();
            };
            username.Completed += (object sender, EventArgs e) =>
            {
                username .Focus();
            };
            password.Completed += (object sender, EventArgs e) =>
            {
                password.Focus();

            };
            confpassword.Completed += (object sender, EventArgs e) =>
            {
                signupVM.SignupSubmitCommand.Execute(null);
            }; 
        }

        /* private async void Signup_Clicked(object sender, EventArgs e)
         {
             var data = (SigningDataModel)BindingContext;
             UmelusiDB database = await UmelusiDB.Instance;
             await database.SaveItemAsync(data);
             await Navigation.PopAsync();
         }*/
    }
}