using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PalEats.ViewModels;
using System.Globalization;
using System.Linq;
using PalEats.Services;
using PalEats.Models;

namespace PalEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubcategoryPage : ContentPage
    {
        SubcategoryPageViewModel viewModel;
        public SubcategoryPage(string categoryName, int categoryId)
        {
            InitializeComponent();
            viewModel = new SubcategoryPageViewModel(categoryId);
            viewModel.CategoryName = categoryName;
            BindingContext = viewModel;
        }

    }




}

