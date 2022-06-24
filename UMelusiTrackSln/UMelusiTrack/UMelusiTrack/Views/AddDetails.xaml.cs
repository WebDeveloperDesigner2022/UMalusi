using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDetails : ContentPage
    {
        public AddDetails()
        {
            InitializeComponent();
            var livestocks = new livestock();
            BindingContext = livestocks;
        }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        var livestocks = (livestock)BindingContext;
        livestockDatabase database = await livestockDatabase.Instance;
        await database.SaveItemAsync(livestocks);
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

    private void browse(object sender, EventArgs e)
    {
        // Task<Stream> GetImageStreamAsync();
    }
}

    
}