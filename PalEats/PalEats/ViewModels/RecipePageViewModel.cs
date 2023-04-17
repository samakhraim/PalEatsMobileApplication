using PalEats.Models;
using PalEats.Services;
using PalEats.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace PalEats.ViewModels
{
    public class RecipePageViewModel : INotifyPropertyChanged
    {
        private readonly RecipeServices recipeServices;

        public RecipePageViewModel()
        {
            recipeServices = new RecipeServices();

            Task.Run(() => this.LoadRecipesAsync()).Wait();
            Task.Run(() => this.LoadIngredientsAsync()).Wait();
            FavoriteButtonClicked = new Command(async () => await AddToFavoriteAsync());

        }
        public List<String> Preparation
        {
            get
            {
                String[] prep = Recipe.Preparation.Split('.');
                List<String> result = new List<String>();
                for (int i = 0; i < prep.Length - 1; i++)
                {
                    result.Add((i + 1) + ". " + prep[i]);
                }

                return result;
            }
            set {; }
        }
        public string NumberOfPeople
        {
            get { return "Serves " + Recipe.NumberOfPeople; }
            set {; }
        }
        public ICommand FavoriteButtonClicked { get; private set; }

        public int IngredientsHeight
        {
            get
            {
                return Ingredients.Count * 27;
                ;
            }
            set {; }
        }
        private RecipeModel recipe = new RecipeModel();
        public RecipeModel Recipe
        {
            get { return recipe; }
            set
            {
                recipe = value;
                OnPropertyChanged(nameof(Recipe));
            }
        }
        public async Task LoadRecipesAsync()
        {
            try
            {
                Recipe = await recipeServices.GetRecipesAsync(6876);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while loading recipes: {ex.Message}");

                await App.Current.MainPage.DisplayAlert("Error", "An error occurred while loading recipes. Please try again later.", "OK");
            }
        }
        private List<IngredientsModel> ingredients = new List<IngredientsModel>();
        public List<IngredientsModel> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }
        public async Task LoadIngredientsAsync()
        {
            try
            {
                Ingredients = await recipeServices.GetIngredientsAsync(6876);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while loading recipes: {ex.Message}");

                await App.Current.MainPage.DisplayAlert("Error", "An error occurred while loading recipes. Please try again later.", "OK");
            }
        }

        private async Task AddToFavoriteAsync()
        {
            try
            { 
                var favoriteService = new FavoriteServices();

                var result = await favoriteService.AddFavoriteAsync(4,Recipe.DishId);

                if (result > 0)
                {
                }
                else if (result == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "you already added this recipe to your favaorite", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "add to favorite failed", "OK");
                }
            }
            catch (ArgumentException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Error", "An error occurred while adding to favorite", "OK");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}