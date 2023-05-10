using PalEats.ViewModel;
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
    public partial class FlyoutMenuPage : ContentPage
{
    public FlyoutMenuPage()
    {
        InitializeComponent();

        if (((App)App.Current).currentUser == 0)
        {
            // Set the user name to "Guest"
            BindingContext = new { UserName = "Guest" };
        }
        else
        {
            // Set the user name to the user's email address
            BindingContext = new { UserName = "user@example.com" };
        }
    }
}

}