using BookCollector.Helpers;
using BookCollector.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<string> AddBookManually()
        {
            var errorMessage = BookHelper.ValidateBookEntry(NewBook);

            if (String.IsNullOrEmpty(errorMessage))
            {
                await App.Database.AddBookAsync(NewBook);
            }

            return errorMessage;
        }

        public async void CancelAddBookManually()
        {
            await this.Navigation.PushAsync(new MainPage());
        }

        public async Task NavigateMainPage()
        {
            await this.Navigation.PushAsync(new MainPage());
        }
    }
}
