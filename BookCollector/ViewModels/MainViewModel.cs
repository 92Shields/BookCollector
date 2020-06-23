using BookCollector.Models;
using BookCollector.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace BookCollector.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            _books = new ObservableCollection<Book>(App.Database.GetBooksAsync().Result);
        }

        public async void AddBookManually()
        {
            await Navigation.PushAsync(new AddBookManuallyPage());
        }

        public async void AddBookIsbn()
        {
            await Navigation.PushAsync(new AddBookIsbnPage());
        }

    }
}
