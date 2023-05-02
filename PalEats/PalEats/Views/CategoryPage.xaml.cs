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
            NavigationPage.SetHasBackButton(this, false);

        }

        private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var collectionView = sender as CollectionView;
            var selectedCategory = e.CurrentSelection.FirstOrDefault() as Category;

            if (selectedCategory != null)
            {
                collectionView.SelectedItem = null;

                string pageTitle =null;
                switch (selectedCategory.CategoryId)
                {
                    case 3:
                        pageTitle = "Sweets";
                        break;
                    case 2:
                        pageTitle = "Breakfast";
                        break;
                    case 4:
                        pageTitle = "Appetizers";
                        break;
                    case 1:
                        pageTitle = "Main Dish";
                        break;
                }

                await Navigation.PushAsync(new SubcategoryPage(pageTitle, selectedCategory.CategoryId));
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

