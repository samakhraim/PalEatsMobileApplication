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
        public int currentUser { get; set; }

        public App()
        {
            InitializeComponent();

        }

        protected override void OnStart()
        {
            var newNavigation = new NavigationPage(new SignInPage());
            MainPage = newNavigation;

        }
        protected override void OnSleep()
        {

        }
        protected override void OnResume()
        {
        }

    }

}


