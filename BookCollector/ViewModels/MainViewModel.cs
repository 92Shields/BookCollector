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
        public ObservableCollection<Book> Books { get; set; }

        public MainViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Books = new ObservableCollection<Book>(App.Database.GetBooksAsync().Result);
        }

        public async void NavigateAddBookManually()
        {
            await Navigation.PushAsync(new AddBookManuallyPage());
        }

        public async void NavigateAddBookIsbn()
        {
            await Navigation.PushAsync(new AddBookIsbnPage());
        }

    }
}
