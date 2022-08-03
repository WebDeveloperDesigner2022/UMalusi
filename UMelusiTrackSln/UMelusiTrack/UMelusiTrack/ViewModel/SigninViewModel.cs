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
        private IAuthentication _authenticationService;
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
                // var db = await UmelusiDB.Instance;

                // var login = await db.Login(Username, Password);

                AuthenticationService _authenticationService = new AuthenticationService();

                var user = await _authenticationService.Authenticate(Username, Password);

                //var login = await db.Login(Username, Password);

                if (user == true)
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
