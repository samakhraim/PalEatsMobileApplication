using PalEats.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using PalEats.Models;
using System.Linq;


namespace PalEats
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SignInPage());
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


