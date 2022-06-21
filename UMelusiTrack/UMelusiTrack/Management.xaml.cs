using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Management : ContentPage
    {
        public Management()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            livestockDatabase database = await livestockDatabase.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MangementInside
            {
                BindingContext = new livestock()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MangementInside
                {
                    BindingContext = e.SelectedItem as livestock
                });
            }
        }

        private void register(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MangementInside());
        }

        /*private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderingDetails());
        }*/
    }
}
