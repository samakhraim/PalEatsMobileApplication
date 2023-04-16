using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalEats.Models;
using PalEats.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace PalEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        int id;
        public RecipePage(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}