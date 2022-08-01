using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Services;
using UMelusiTrack.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Manage : ContentPage
    {
        public LivestockViewModel registerLivestockVM = new LivestockViewModel();
        public Manage()
        {
            InitializeComponent();
            registerLivestockVM = new LivestockViewModel();

            MessagingCenter.Subscribe<LivestockViewModel, string>(this, "Register Livestock Alert", (sender, livestockname) => {
                DisplayAlert("", livestockname, "ok");
            });
            this.BindingContext = registerLivestockVM;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
           // listView.ItemsSource = await App.ILivestock.GetTasksAsync();

            /* livestockDatabase database = await livestockDatabase.Instance;
             listView.ItemsSource = await database.GetItemsAsync();*/

        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Manage
            {
                BindingContext = new livestock()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Manage
                {
                    BindingContext = e.SelectedItem as livestock
                });
            }
        }

        private void register(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddDetails());
        }

        private void arrowbtn(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage2());
        }
       
    }
}