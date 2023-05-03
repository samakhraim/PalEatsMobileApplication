using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PalEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationComponent : ContentView
    {
        public NavigationComponent()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {


            await Navigation.PushModalAsync(new NavigationPage(new SearchPage()));


        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new NavigationPage(new CategoryPage()));


        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {


            if (((App)Application.Current).currentUser == 0)
            {
                bool answer = await Application.Current.MainPage.DisplayAlert("Favorite Page", "You are currently a guest. Do you want to sign in?", "Yes", "No");

                if (answer)
                {
                    await Navigation.PushAsync(new SignInPage());
                }
            }
            else
            {
                await Navigation.PushModalAsync(new NavigationPage(new FavoritePage()));
            }
        }


    }
}
