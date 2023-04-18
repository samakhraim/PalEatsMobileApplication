using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalEats.Models;
using PalEats.ViewModels;
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