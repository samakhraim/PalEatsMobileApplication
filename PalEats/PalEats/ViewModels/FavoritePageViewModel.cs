using PalEats.Models;
using PalEats.Services;
using PalEats.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PalEats.ViewModels
{
    public class FavoritePageViewModel : INotifyPropertyChanged
    {
        private readonly FavoritePageServices favoritePageServices;

        public FavoritePageViewModel()
        {
            favoritePageServices = new FavoritePageServices();
            Task.Run(() => this.LoadFavoritePageAsync()).Wait();

        }
        private List<Dish> dish = new List<Dish>();
        public List<Dish> dishs
        {
            get { return dish; }
            set
            {
                dish = value;
                OnPropertyChanged(nameof(Dish));
            }
        }
        public async Task LoadFavoritePageAsync()
        {
            try
            {
                dishs = await favoritePageServices.GetFavoritepageAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while loading recipes: {ex.Message}");
                Debug.WriteLine($"Inner exception: {ex.InnerException.Message}");

                await App.Current.MainPage.DisplayAlert("Error", "An error occurred while loading recipes. Please try again later.", "OK");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    
    }
}
