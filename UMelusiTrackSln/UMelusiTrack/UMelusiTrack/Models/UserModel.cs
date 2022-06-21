using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using UMelusiTrack.Services;
using Xamarin.Forms;

namespace UMelusiTrack.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string username;
        UmelusiDB umelusiDB;
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

        public UserModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public void OnSubmit()
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
                MessagingCenter.Send(this, "Login Alert", Username + " & " + Password);
                umelusiDB = new UmelusiDB();


            }

        }
    }
}
