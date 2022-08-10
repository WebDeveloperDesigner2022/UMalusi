using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Services;
using UMelusiTrack.ViewModel;
using UMelusiTrackApi.Models;
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

            var vm = (LivestockViewModel)BindingContext;

            if (vm != null)
            {
                await vm.RefreshDataAsync();
            }

           //Items = new List<TodoItem>();
          // listView.ItemsSource = await RefreshDataAsync();

            /* livestockDatabase database = await livestockDatabase.Instance;
             listView.ItemsSource = await database.GetItemsAsync();*/

          }


        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Manage
            {
                BindingContext = new Livestock()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
             await Navigation.PushAsync(new AddDetails
             {
                    BindingContext = e.SelectedItem as Livestock
             });
            
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