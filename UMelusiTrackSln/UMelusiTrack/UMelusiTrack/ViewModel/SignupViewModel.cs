using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using UMelusiTrack.Models;
using UMelusiTrack.Services;
using UMelusiTrack.Services.Interfaces;
using Xamarin.Forms;

namespace UMelusiTrack.ViewModel
{
    public class SignupViewModel : INotifyPropertyChanged
    {
        private IFarmer _farmerService;
        public event PropertyChangedEventHandler PropertyChanged;
        public string name;
        public string surname;
        public string username;
        public string password;
        public string azureMapId;
        public int authenticationId;
        public string confirmPassword;
        public bool agreement;
        Regex names = new Regex("[^a-zA-Z]");

        public string Names 
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Names"));
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

        public string AzureMapId
        {
            get { return azureMapId; }
            set
            {
                 azureMapId = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AzureMapId"));
            }
        }

        public int AuthenticationId
        {
            get { return authenticationId; }
            set
            {
                authenticationId = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AuthenticationId"));
            }
        }

        public ICommand SignupSubmitCommand { get; set; }
        public SignupViewModel()
        {
            SignupSubmitCommand = new Command(OnSubmitAsync);
        }
        public async void OnSubmitAsync()
        {
            
            if (IsValidated())
            {
                await SaveSignUp();

                await App.Current.MainPage.Navigation.PushAsync(new MainPage2());
            }           
        }

        public bool IsValidated()
        {
            if (string.IsNullOrEmpty(Username)
               && string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(ConfirmPassword)
               && string.IsNullOrEmpty(Names) && string.IsNullOrEmpty(Surname) && !Agreement)
            {
                MessagingCenter.Send(this, "Signup Alert", "Please fill-up the form");
                return false;
            }
            else
            {
                if (!names.IsMatch(Names) && !names.IsMatch(Surname))
                {
                    return true;
                }
                MessagingCenter.Send(this, "Signup Alert", "Name and surname must be letters only");

            }
            return false;
        }

        public async Task SaveSignUp()
        {
            try
            {
                FarmerService _farmerService = new FarmerService();

                var user = await _farmerService.Farmer( Names = this.Names, Password = this.Password, Surname = this.Surname, Username = this.Username, AzureMapId = this.AzureMapId, AuthenticationId = this.AuthenticationId);
                // Names = this.Names, Password = this.Password, Surname = this.Surname, Username = this.Username, AzureMapId = this.AzureMapId, AuthenticationId = this.AuthenticationId                

                if (user != null)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new MainPage2());
                } 

                else
                {
                    MessagingCenter.Send(this, "SignUp Alert", "Fill in all detils");
                }
            }
            catch { }



            //UmelusiDB database = await UmelusiDB.Instance;

            //var data = new SigningDataModel() { Done = this.Agreement, Name = this.Name, Password = this.Password, Surname = this.Surname, Username = this.Username, AzureMapId = this.AzureMapId, AuthenticationId = this.AuthenticationId };

            // await _farmerService.SaveItemAsync(user);

            // ONLY EXAMPLE

            // var positionService = new LivestockPositionService();
            // positionService.LivestockPosition()




        }

    } 
    
   /* public class CustomerName {
        private string _value;
        public string Value { get { return _value; } set { _value = value; } }
    }*/
}