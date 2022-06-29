using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using UMelusiTrack.Services;
using Xamarin.Forms;

namespace UMelusiTrack.ViewModel
{
    public class SignupViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string name;
        public string surname;
        public string username;
        public string password;        
        public string confirmPassword;
        public bool agreement;


        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public bool Agreement
        {
            get { return agreement; }
            set {
                agreement = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Done"));
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Surname"));
            }
        }
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SignupSubmitCommand { get; set; }
        public SignupViewModel()
        {
            SignupSubmitCommand = new Command(OnSubmitAsync);
        }
        public async void OnSubmitAsync()
        {
            Regex names = new Regex("[^a-zA-Z]");
            if (string.IsNullOrEmpty(Username)
                && string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(ConfirmPassword)
                && string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Surname) && !Agreement)
            {
                MessagingCenter.Send(this, "Signup Alert", "Please fill-up the form");
            }

            else
            {
                if(!names.IsMatch(Name) && !names.IsMatch(Surname))
                {
                    await App.Current.MainPage.Navigation.PushAsync(new SignPage());
                }
                    

                else
                    MessagingCenter.Send(this, "Signup Alert", "Name and surname must be letters only");

            }


        }

    }    
}