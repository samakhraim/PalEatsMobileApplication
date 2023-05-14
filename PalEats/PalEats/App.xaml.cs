using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using PalEats.Models;
using System.Linq;
using System.Threading.Tasks;
using PalEats.Views;
using System.Diagnostics;

[assembly: ExportFont("Lato-Black.ttf", Alias = "Lato-Black")]


namespace PalEats
{
    public partial class App : Application
    {
        public int currentUser { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SignInPage());
        }

        protected override void OnStart()
        {
            base.OnStart();
            CheckInternetConnection(null, null);
            Connectivity.ConnectivityChanged += CheckInternetConnection;
        }


        protected override void OnSleep()
        {
            base.OnSleep();
            Connectivity.ConnectivityChanged -= CheckInternetConnection;
        }

        protected override void OnResume()
        {
            base.OnResume();
            Connectivity.ConnectivityChanged += CheckInternetConnection;
        }


        private async void CheckInternetConnection(object sender, ConnectivityChangedEventArgs e)
        {

            while (true)
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Current.MainPage.DisplayAlert("No Internet Connection", "Please check your internet connection and try again.", "Retry");
                    await Task.Delay(1000);
                }
                else
                {
                    break;
                }
            }
        }
    }
}