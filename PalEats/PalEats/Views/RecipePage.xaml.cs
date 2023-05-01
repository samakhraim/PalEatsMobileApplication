
using PalEats.Models;
using PalEats.ViewModels;
using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PalEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage

    {

        RecipePageViewModel viewModel;
        public RecipePage(int id)
        {
            InitializeComponent();
            viewModel = new RecipePageViewModel(id);
            BindingContext = viewModel;

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
            string ingredients = string.Join("\n", information.Ingredients.Select(i => i.Description));
            string preparation = string.Join("\n\n", information.Preparation);
            Share.RequestAsync(new ShareTextRequest
            {
                Title = "Share Recipe",
                Text = $"PalEats represents\t\t{information.DishName}\n\n{information.Description}\n\nIngredients:\t\tFor {information.NumberOfPeople}\n{ingredients}\n\nPreperation:\n{preparation}"
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<RecipePage, Recipe>(this, "ShareRecipe");
        }
    }
}