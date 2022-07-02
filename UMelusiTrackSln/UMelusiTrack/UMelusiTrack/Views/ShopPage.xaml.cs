using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.ViewModel;
using Xamarin.Forms;

namespace UMelusiTrack
{
    public partial class ShopPage : ContentPage
    {
        public ShopPage()
        {
            var vm = new OrderingVM();
            InitializeComponent();
            MessagingCenter.Subscribe<OrderingVM, string>(this, "Ordering Alert", (sender, username) => {
                DisplayAlert("", username, "ok");
            });
            this.BindingContext = vm;
        }

        private void CancelBtn(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
