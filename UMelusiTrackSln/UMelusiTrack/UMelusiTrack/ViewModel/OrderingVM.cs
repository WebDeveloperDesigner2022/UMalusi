﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UMelusiTrack.Models;
using UMelusiTrack.Services;
using UMelusiTrack.Services.Interfaces;
using Xamarin.Forms;

namespace UMelusiTrack.ViewModel
{
    public class OrderingVM : INotifyPropertyChanged
    {
        private IOrder _orderService;
        public event PropertyChangedEventHandler PropertyChanged;
        public string name;
        public string surname;
        public int quantity;
        public string refenceNo;
        public string deliveryAddress;
        public string contactNo;
        public string email;
        public int farmerId;

        public string Name 
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
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
        public int Quantity 
        {
            get { return quantity; }
            set
            {
                quantity = value;
                PropertyChanged(this, new PropertyChangedEventArgs("quantity"));
            }
        }
        public string ReferenceNo 
        {
            get { return refenceNo; }
            set
            {
                refenceNo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Refence_number"));
            }
        }
        public string DeliveryAddress 
        {
            get { return deliveryAddress; }
            set
            {
                deliveryAddress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Delivery_address"));
            }
        }
        public string ContactNo 
        {
            get { return contactNo; }
            set
            {
                contactNo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Contact_number"));
            }
        }
        public string Email 
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email_address"));
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

        public ICommand SignupSubmitCommand { get; set; }
        public OrderingVM()
        {
            SignupSubmitCommand = new Command(OnSubmitAsync);
        }

        public async void OnSubmitAsync()
        {

          //  if (IsValidated())
            {
                await SaveOrderAsync();
                await App.Current.MainPage.Navigation.PushAsync(new MainPage2());

            }
        }

        public bool IsValidated()
        {
            if (string.IsNullOrEmpty(Name)
               && string.IsNullOrEmpty(Surname)
               && string.IsNullOrEmpty(ReferenceNo)
               && string.IsNullOrEmpty(DeliveryAddress) 
               && string.IsNullOrEmpty(ContactNo)
               && string.IsNullOrEmpty(Email)
               && Quantity != 0)
            {
                MessagingCenter.Send(this, "Ordering Alert", "Please fill-up the form");
                return false;
            }

            else if (string.IsNullOrEmpty(Name)
               || string.IsNullOrEmpty(Surname)
               || string.IsNullOrEmpty(ReferenceNo)
               || string.IsNullOrEmpty(DeliveryAddress)
               || string.IsNullOrEmpty(ContactNo)
               || string.IsNullOrEmpty(Email)
               || Quantity != 0)
            {
                MessagingCenter.Send(this, "Ordering Alert", "Please fill-up every details");
                return false;
            }
            else
            {
                MessagingCenter.Send(this, "Ordering Alert", "Submition completed!");
                return true;                
            }
        }

        public async Task SaveOrderAsync()
        {
           try { 
            OrderService _orderService = new OrderService();
            var farmer = InMemoryDataCache.AuthenticatedFarmer;
            var data = await _orderService.Order(farmer, Name = this.Name, Surname = this.Surname, FarmerId = this.FarmerId, Quantity = this.Quantity, ReferenceNo = this.ReferenceNo, DeliveryAddress = this.DeliveryAddress, ContactNo = this.ContactNo, Email = this.Email);
           
            if (data != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new MainPage2());
            }

            else
            {
                MessagingCenter.Send(this, "Buy Alert", "Fill in all detils");
            }
        }
            catch { }
        }
    }
}
