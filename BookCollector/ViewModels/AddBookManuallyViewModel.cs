using BookCollector.Helpers;
using BookCollector.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        private BookCondition _selectedCondition;
        public BookCondition SelectedCondition
        {
            get
            {
                return _selectedCondition;
            }
            set
            {
                _selectedCondition = SelectedCondition;
            }
        }

        public List<string> Conditions
        {
            get
            {
                return Enum.GetNames(typeof(BookCondition)).Select(b => b.SplitCamelCase()).ToList();
            }
        }


        public AddBookManuallyViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.NewBook = new Book();
        }

        public async void AddBookManually()
        {
            var errorMessage = BookHelper.ValidateBookEntry(NewBook);

            await this.Navigation.PushAsync(new MainPage());
        }

        public async void CancelAddBookManually()
        {
            await this.Navigation.PushAsync(new MainPage());
        }
    }
}
