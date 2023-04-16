using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PalEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubcategoryPage : ContentPage
    {

        public SubcategoryPage(int SelectedCategory)
        {
            InitializeComponent();
            string title = "This is the Category with the following ID : " + SelectedCategory.ToString();
            CurrentCategory.Text = title;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}