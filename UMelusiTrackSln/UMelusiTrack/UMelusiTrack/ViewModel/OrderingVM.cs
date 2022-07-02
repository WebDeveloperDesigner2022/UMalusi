using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UMelusiTrack.Models;
using UMelusiTrack.Services;
using Xamarin.Forms;

namespace UMelusiTrack.ViewModel
{
    public class OrderingVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string name;
        public string surname;
        public int quantity;
        public string refence_number;
        public string delivery_options;
        public string delivery_address;
        public string contact_number;
        public string email_address;

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
        public string Refence_number 
        {
            get { return refence_number; }
            set
            {
                refence_number = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Refence_number"));
            }
        }
        public string Delivery_options
        {
            get { return delivery_options; }
            set
            {
                delivery_options = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Delivery_options"));
            }
        }
        public string Delivery_address 
        {
            get { return delivery_address; }
            set
            {
                delivery_address = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Delivery_address"));
            }
        }
        public string Contact_number 
        {
            get { return contact_number; }
            set
            {
                contact_number = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Contact_number"));
            }
        }
        public string Email_address 
        {
            get { return email_address; }
            set
            {
                email_address = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email_address"));
            }
        }

        public ICommand SignupSubmitCommand { get; set; }
        public OrderingVM()
        {
            SignupSubmitCommand = new Command(OnSubmitAsync);
        }

        public void OnSubmitAsync()
        {

            if (IsValidated())
            {
                SaveOrderAsync();

            }
        }

        public bool IsValidated()
        {
            if (string.IsNullOrEmpty(Name)
               && string.IsNullOrEmpty(Surname) 
               && string.IsNullOrEmpty(Refence_number)
               && string.IsNullOrEmpty(Delivery_options) 
               && string.IsNullOrEmpty(Delivery_address) 
               && string.IsNullOrEmpty(Contact_number)
               && string.IsNullOrEmpty(Email_address)
               && Quantity == 0)
            {
                MessagingCenter.Send(this, "Ordering Alert", "Please fill-up the form");
                return false;
            }

            else if (string.IsNullOrEmpty(Name)
               || string.IsNullOrEmpty(Surname)
               || string.IsNullOrEmpty(Refence_number)
               || string.IsNullOrEmpty(Delivery_options)
               || string.IsNullOrEmpty(Delivery_address)
               || string.IsNullOrEmpty(Contact_number)
               || string.IsNullOrEmpty(Email_address)
               || Quantity == 0)
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

        public async void SaveOrderAsync()
        {
            OrderingDb db = new OrderingDb();
            var data = new OrderingModels()
            {
                Name = this.Name,
                Surname = this.Surname,
                Quantity = this.Quantity,
                Refence_number = this.Refence_number,
                Delivery_options = this.Delivery_options,
                Delivery_address = this.Delivery_address,
                Contact_number = this.Contact_number,
                Email_address = this.Email_address
            };
            await db.SaveItemAsync(data);
        }
    }
}
