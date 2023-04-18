using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalEats.Models;
using PalEats.Services;
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
    }
}