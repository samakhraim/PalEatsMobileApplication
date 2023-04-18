using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalEats.Models;
using PalEats.Services;
using PalEats.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace PalEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        int id;
        private RecipePageViewModel viewModel = new RecipePageViewModel();
        public RecipePage(int id)
        {
            InitializeComponent();
            this.id = id;
            var recipe = viewModel.Recipe;

        }
        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void ShareButton_Clicked(object sender, EventArgs e)
        {

            ShareInfo information = new ShareInfo()
            {
                DishName = viewModel.Recipe.DishName,
                Description = viewModel.Recipe.Description,
                NumberOfPeople = viewModel.Recipe.NumberOfPeople,
                Ingredients = viewModel.Ingredients,
                Preparation = viewModel.Preparation
            };
            MessagingCenter.Send(this, "ShareRecipe", information);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<RecipePage, Recipe>(this, "ShareRecipe");
        }
    }
}