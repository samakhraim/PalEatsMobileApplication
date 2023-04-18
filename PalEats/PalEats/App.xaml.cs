using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PalEats.Views;
namespace PalEats

{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new RecipePage(6873));
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