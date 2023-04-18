using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PalEats.Views;
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


            MainPage = new NavigationPage(new RecipePage());
            MessagingCenter.Subscribe<RecipePage,ShareInfo>(this, "ShareRecipe", OnShareRecipe);


        }
        private async void OnShareRecipe(RecipePage sender, ShareInfo information)
        {
            string ingredients = string.Join("\n", information.Ingredients.Select(i => i.Description));
            string preparation = string.Join("\n\n", information.Preparation);
            await Share.RequestAsync(new ShareTextRequest
            {
                Title = "Share Recipe",
                Text = $"PalEats represents\t\t{information.DishName}\n\n{information.Description}\n\nIngredients:\t\tFor {information.NumberOfPeople}\n{ingredients}\n\nPreperation:\n{preparation}"
            });
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