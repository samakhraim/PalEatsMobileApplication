using PalEats.Models;
using PalEats.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PalEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMenuPage : ContentPage
    {
        public FlyoutMenuPage()
        {
            InitializeComponent();
            SetLoginStatus();
            App.LoginStatusUpdated += OnLoginStatusUpdated; // Subscribe to the login status updated event
            ListView.ItemSelected += OnMenuItemSelected;
        }

        void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutMenuItem;

            if (item == null)
                return;

            if (item.Title == "Log Out")
            {
                ((App)Application.Current).LogOut();
                // After logout, navigate to the sign-in page
                Navigation.PushAsync(new SignInPage());
            }
            else
            {
                // Navigate to the target page
                Navigation.PushAsync((Page)Activator.CreateInstance(item.TargetPage));
            }

            // Deselect the item
            ListView.SelectedItem = null;
        }

        private void SetLoginStatus()
        {
            var app = (App)Application.Current;
            if (app.CurrentUser > 0)
            {
                LoginStatusLabel.Text = app.CurrentUserEmail;
            }
            else
            {
                LoginStatusLabel.Text = "Guest";
            }
        }

        private void OnLoginStatusUpdated(object sender, EventArgs e)
        {
            SetLoginStatus();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            App.LoginStatusUpdated -= OnLoginStatusUpdated; // Unsubscribe from the login status updated event
        }
    }
}
