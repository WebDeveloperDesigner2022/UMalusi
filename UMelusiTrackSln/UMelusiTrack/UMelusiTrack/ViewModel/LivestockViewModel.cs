using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UMelusiTrack.Services;
using UMelusiTrack.Services.Interfaces;
using UMelusiTrack.Views;
using UMelusiTrackApi.Models;
using Xamarin.Forms;

namespace UMelusiTrack.ViewModel
{
    public class LivestockViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Livestock> _liveStocks;

        public ObservableCollection<Livestock> Livestocks
        {
            get { return _liveStocks; }
            set { _liveStocks = value;

                PropertyChanged(this, new PropertyChangedEventArgs("Livestocks"));
            }
        }

        
        // private ILivestock _livestockService;
        public event PropertyChangedEventHandler PropertyChanged;
        public string livestockName;
        public string dob;
        public string gender;
        public string color;
        public byte[] image;
        public int farmerId;
        public int trackerId;
        public int livestockTypeId;

        public string LivestockName
        {
            get { return livestockName; }
            set
            {
                livestockName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LivestockName"));
            }
        }

        public string DOB
        {
            get { return dob; }
            set
            {
                dob = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DOB"));
            }
        }
        /*public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Gender"));
            }
        }*/
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Color"));
            }
        }
        public byte[] Image
        {
            get { return image; }
            set
            {
                image = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Image"));
            }
        }

        public int FarmerId
        {
            get { return farmerId; }
            set
            {
                farmerId = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FarmerId"));
            }
        }
        public int TrackerId
        {
            get { return trackerId; }
            set
            {
                trackerId = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TrackerId"));
            }
        }

        public int LivestockTypeId
        {
            get { return livestockTypeId; }
            set
            {
                livestockTypeId = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LivestockTypeId"));
            }
        }
        public ICommand RegisterLivestockSubmitCommand { get; set; }
        public LivestockViewModel()
        {
            RegisterLivestockSubmitCommand = new Command(OnSubmitAsync);
        }
        public async void OnSubmitAsync()
        {

         //   if (IsValidated())
            
                await RegisterLivestock();

                await App.Current.MainPage.Navigation.PushAsync(new Manage());
            
        }

        public async Task RefreshDataAsync()
        {
            
            LivestockService _livestockService = new LivestockService();

            var farmer = InMemoryDataCache.AuthenticatedFarmer;
            var livestocks = await _livestockService.GetLivestockByFarmerId(farmer.FarmerId);
                      
           
            Livestocks = new ObservableCollection<Livestock>(livestocks);
        }

        public async Task RegisterLivestock()
        {
            try
            {
                LivestockService _livestockService = new LivestockService();

                var farmer = InMemoryDataCache.AuthenticatedFarmer;

                var livestock = await _livestockService.RegisterLivestock(farmer, LivestockName = this.LivestockName, DOB = this.DOB,
                    
                    Color = this.Color, Image = this.Image, FarmerId = this.FarmerId, LivestockTypeId = this.LivestockTypeId);
                // Names = this.Names, Password = this.Password, Surname = this.Surname, Username = this.Username, AzureMapId = this.AzureMapId, AuthenticationId = this.AuthenticationId                

                if (livestock != null)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new Manage());
                }

                else
                {
                    MessagingCenter.Send(this, "Livestock Alert", "Fill in all detils");
                }
            }
            catch { }

        }
    }
}
