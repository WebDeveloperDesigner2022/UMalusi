using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Services;
using UMelusiTrack.ViewModel;
using UMelusiTrackApi.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDetails : ContentPage
    {
        bool isNewLivestock;
        public AddDetails(bool isNew = false)
        {
            InitializeComponent();
            isNewLivestock = isNew;

            var vm = new LivestockViewModel();

            BindingContext = vm;
        }

        private async void browse(object sender, EventArgs e)
        {
            // TODO delete this line
 
            var imageFile = await MediaPicker.PickPhotoAsync();
            if (imageFile != null)
            {
                using (var fileStream = await imageFile.OpenReadAsync())
                using (var memoryStream = new MemoryStream())
                {
                    await fileStream.CopyToAsync(memoryStream);
                    var imageBytes = memoryStream.ToArray();

          //          lie.Image = imageBytes;

                    var vm = (LivestockViewModel) BindingContext;

                    if (vm != null)
                    {
                        vm.Image = imageBytes;
                    }



                }
            }
        }


        /*       async void OnSaveClicked(object sender, EventArgs e)
               {
                   var livestocks = (Livestock)BindingContext;
                 //  await App.ILivestock.SaveTaskAsync(livestocks, isNewLivestock);
                   await Navigation.PopAsync();

               }

               async void OnDeleteClicked(object sender, EventArgs e)
               {
                   var livestocks = (livestock)BindingContext;
                   livestockDatabase database = await livestockDatabase.Instance;
                   await database.DeleteItemAsync(livestocks);
                   await Navigation.PopAsync();

               }

               async void OnCancelClicked(object sender, EventArgs e)
               {
                   await Navigation.PopAsync();
               }

               private async void browse(object sender, EventArgs e)
               {
                   // TODO delete this line
                   var lie = new Livestock();

                   var imageFile = await MediaPicker.PickPhotoAsync();
                   using (var fileStream = await imageFile.OpenReadAsync())
                   using (var memoryStream = new MemoryStream())
                   {
                       await fileStream.CopyToAsync(memoryStream);
                       var imageBytes = memoryStream.ToArray();

                       lie.Image = imageBytes;
                   }
               }
        */
    }


}