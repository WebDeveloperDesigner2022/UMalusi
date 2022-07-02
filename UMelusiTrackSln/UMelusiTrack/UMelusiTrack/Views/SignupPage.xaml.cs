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
        
        public SignupViewModel signupVM = new SignupViewModel();
        public SignupPage()
        {
            InitializeComponent(); 
          
            MessagingCenter.Subscribe<SignupViewModel, string>(this, "Signup Alert", (sender, username)=>{
                DisplayAlert("", username, "ok");
            });
            this.BindingContext = signupVM;
        }
    }
}