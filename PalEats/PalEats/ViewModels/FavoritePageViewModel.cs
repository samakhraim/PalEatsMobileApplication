using PalEats.Models;
using PalEats.Services;
using PalEats.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PalEats.ViewModels
{
    public class FavoritePageViewModel : INotifyPropertyChanged
    {
        private readonly FavoritePageServices favoritePageServices;

        public FavoritePageViewModel()
        {
            favoritePageServices = new FavoritePageServices();
            LoadFavoriteAsync();
        }
        private List<Recipe> categories = new List<Recipe>();

        public List<Dish> dishes
        {
            get { return dishes; }
            set
            {
                dishes = value;
                OnPropertyChanged(nameof(dishes));
            }
        }

        public async Task LoadFavoriteAsync()
        {
            try
            {
                dishes = await favoritePageServices.GetFavoriteDishesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while loading categories: {ex.Message}");

                await App.Current.MainPage.DisplayAlert("Error", "An error occurred while loading categories. Please try again later.", "OK");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
