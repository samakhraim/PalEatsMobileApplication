using PalEats.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PalEats.Services;

namespace PalEats.ViewModels
{
    internal class SearchPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Dish> searchResult;
        public ObservableCollection<Dish> SearchResult
        {
            get { return searchResult; }
            set
            {
                searchResult = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; set; }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged();
            }
        }

        private SearchPageServices searchServices;

        public SearchPageViewModel()
        {
            SearchResult = new ObservableCollection<Dish>();
            searchServices = new SearchPageServices();

            SearchCommand = new Command(async () => await Search());
        }

        private async Task Search()
        {
            SearchResult.Clear();

            var searchResults = await searchServices.Search(SearchText);

            foreach (var result in searchResults)
            {
                SearchResult.Add(result);
            }
        }
    }
}