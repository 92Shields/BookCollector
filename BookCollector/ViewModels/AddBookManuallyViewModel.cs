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
        public Book NewBook { get; set; }

        public BookCondition SelectedCondition { get; set; }

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

            if (String.IsNullOrEmpty(errorMessage))
            {
                //add book
            }
            else
            {
                //display error
                return;
            }

            await this.Navigation.PushAsync(new MainPage());
        }

        public async void CancelAddBookManually()
        {
            await this.Navigation.PushAsync(new MainPage());
        }
    }
}
