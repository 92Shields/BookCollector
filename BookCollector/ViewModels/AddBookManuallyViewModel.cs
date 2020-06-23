using BookCollector.Helpers;
using BookCollector.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace BookCollector.ViewModels
{
    public class AddBookManuallyViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        private Book _newBook;
        public Book NewBook
        {
            get { return _newBook; }
            set
            {
                _newBook = value;
                OnPropertyChanged();
            }
        }

        public AddBookManuallyViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.NewBook = new Book();
        }

        public async void AddBookManually()
        {
            Book book = new Book();
            var test = NewBook.Title;

            var errorMessage = BookHelper.ValidateBookEntry(book);

            await this.Navigation.PushAsync(new MainPage());
        }

        public async void CancelAddBookManually()
        {
            await this.Navigation.PushAsync(new MainPage());
        }
    }
}
