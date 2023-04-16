using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PalEats.Views;
using PalEats.ViewModels;

namespace PalEats

{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new SignUpPage();

            MainPage = new NavigationPage(new CategoryPage());


            LoadCategoriesAsync();

        }

        private async void LoadCategoriesAsync()
        {
            var categoryViewModel = new CategoryPageViewModel();
            await categoryViewModel.LoadCategoriesAsync();
        }
        protected override void OnStart()
        {

            var rootPage = new SignUpPage();
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
