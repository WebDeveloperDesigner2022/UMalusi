﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UMelusiTrack
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SignPage())
            {//6FBF7B
                //Color mintGreen =  Color.FromHex("");
                BackgroundColor = Color.FromHex("#62bd77"), BarBackgroundColor = Color.FromHex("#62bd77"),
            };
            
              
           
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
        }
    }
}
