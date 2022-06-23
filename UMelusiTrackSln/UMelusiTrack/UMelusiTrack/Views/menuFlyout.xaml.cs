using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class menuFlyout : ContentPage
    {
        public ListView ListView;

        public menuFlyout()
        {
            InitializeComponent();

            BindingContext = new menuFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class menuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<menuFlyoutMenuItem> MenuItems { get; set; }

            public menuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<menuFlyoutMenuItem>(new[]
                {
                    new menuFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new menuFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new menuFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new menuFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new menuFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}