using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Models;
using UMelusiTrack.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestDBPage : ContentPage
    {
        public List<SigningDataModel> Details { get; set; }
        public TestDBPage()
        {
            InitializeComponent();
        }

         protected override async void OnAppearing()
        {
            base.OnAppearing();

            UmelusiDB database = await UmelusiDB.Instance;
            Details = await database.GetItemsAsync();

            BindingContext = this;

        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignPage
            {
                BindingContext = new SigningDataModel()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new SignPage
                {
                    BindingContext = e.SelectedItem as SigningDataModel
                });
            }
        }
    }
}