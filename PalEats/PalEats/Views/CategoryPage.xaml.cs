using PalEats.Models;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PalEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
        }
        private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var collectionView = sender as CollectionView;
            var selectedCategory = e.CurrentSelection.FirstOrDefault() as Category;

            if (selectedCategory != null)
            {
                collectionView.SelectedItem = null;
                await Navigation.PushAsync(new SubcategoryPage(selectedCategory.CategoryId));
            }
        }
        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}