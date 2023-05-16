using PalEats.Models;
using PalEats.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PalEats.ViewModels
{
    internal class ShoppingListPageViewModel : INotifyPropertyChanged
    {
        public ShoppingListPageViewModel(List<Ingredients> ingredients)
        {
            Ingredients = ingredients;
            foreach (var ingredient in Ingredients)
            {
                ingredient.IsChecked = true;
            }
            SaveCommand = new Command(async () => await SaveToShoppingCartAsync());
        }

        public Command SaveCommand { get; set; }

        private async Task SaveToShoppingCartAsync()
        {
            ShoppingListPageServices shoppingListPageServices = new ShoppingListPageServices();
            try
            {
                await shoppingListPageServices.AddToShoppingList(Ingredients);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error saving shopping list: " + ex.Message);
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to save shopping list. Message: " + ex.Message, "OK");
            }
            await Application.Current.MainPage.Navigation.PopModalAsync();
            await Application.Current.MainPage.DisplayAlert("Success", "Ingredients saved!", "OK");

        }
        public int IngredientsHeight
        {
            get
            {
                return Ingredients.Count * 33;
                ;
            }
            set {; }
        }
        private List<Ingredients> ingredients = new List<Ingredients>();
        public List<Ingredients> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
