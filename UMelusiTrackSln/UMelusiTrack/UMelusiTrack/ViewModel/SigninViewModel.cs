using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using UMelusiTrack.Services;
using UMelusiTrack.Services.Interfaces;
using UMelusiTrack.Views;
using Xamarin.Forms;

namespace UMelusiTrack.ViewModel 
{
    public class SigninViewModel : INotifyPropertyChanged
    {
       /// private IAuthentication _authenticationService;
        public event PropertyChangedEventHandler PropertyChanged;
        public string username;
      
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        public string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SubmitCommand { get; set; }

        public SigninViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public async void OnSubmit()
        {
            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password))
            {
                MessagingCenter.Send(this, "Login Alert", "Please fill-up the form");
            }
            else if (string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                MessagingCenter.Send(this, "Login Alert", "Please enter username the form");
            }
            else if (!string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password))
            {
                MessagingCenter.Send(this, "Login Alert", "Please enter password the form");
            }
            else 
            {
               
                AuthenticationService _authenticationService = new AuthenticationService();

                var response = await _authenticationService.Authenticate(Username, Password);

                if (response != null)
                {

                    InMemoryDataCache.AuthenticatedFarmer = response.AuthenticatedFarmer;
                    //var login = await db.Login(Username, Password);

                    if (response.Authenticated == true)
                    {
                        await App.Current.MainPage.Navigation.PushAsync(new MainPage2());
                    }

                    else
                    {
                        MessagingCenter.Send(this, "Login Alert", "Wrong username or password");
                    }
                }

            }

        }
    }
}
