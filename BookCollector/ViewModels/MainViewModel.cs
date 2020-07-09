using BookCollector.Models;
using BookCollector.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookCollector.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ObservableCollection<Book> Books { get; set; }

        public MainViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Books = new ObservableCollection<Book>(App.Database.GetBooksAsync().Result);
        }

        public async Task NavigateAddBookManually()
        {
            await Navigation.PushAsync(new AddBookManuallyPage());
        }

        public async Task NavigateAddBookIsbn()
        {
            await Navigation.PushAsync(new AddBookIsbnPage());
        }

        public async Task NavigateBookDetail(Guid bookId)
        {
            await Navigation.PushAsync(new BookDetailPage(bookId));
        }

        public async Task NavigateLocations()
        {
            await Navigation.PushAsync(new LocationsPage());
        }
    }
}
