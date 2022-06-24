using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Manage : ContentPage
    {
        public Manage()
        {
            InitializeComponent();
        }

        protected async override  void OnAppearing()
        {
            base.OnAppearing();

            livestockDatabase database = await livestockDatabase.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
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
            Navigation.PushAsync(new Manage());
        }

        private void arrowbtn(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        /*private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderingDetails());
        }*/
    }

}