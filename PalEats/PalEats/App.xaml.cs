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

            MainPage = new RecipePage();


        }
        protected override void OnStart()
        {
            var rootPage = new RecipePage();
            var navigationPage = new NavigationPage(rootPage);
            MainPage = navigationPage;

        }
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {

        }
    }
}
