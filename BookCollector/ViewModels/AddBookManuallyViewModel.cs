using BookCollector.Helpers;
using BookCollector.Models;
using BookCollector.Services;
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

        public List<string> Conditions
        {
            get
            {
                return Enum.GetNames(typeof(BookCondition)).Select(b => b.SplitCamelCase()).ToList();
            }
        }

        public List<Location> Locations
        {
            get
            {
                return App.Database.GetLocationsAsync().Result.OrderBy(x => x.Name).ToList();
            }
        }

        public string SelectedLocation { get; set; }


        public AddBookManuallyViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.NewBook = new Book();
        }

        public async Task<string> AddBookManually()
        {
            AddLocationToBook();
            var errorMessage = BookHelper.ValidateBookEntry(NewBook);

            if (String.IsNullOrEmpty(errorMessage))
            {
                await App.Database.AddBookAsync(NewBook);
            }

            return errorMessage;
        }

        public async void CancelAddBookManually()
        {
            await this.Navigation.PopModalAsync();
        }

        public async Task NavigateMainPage()
        {
            await Navigation.PopModalAsync();
        }

        private void AddLocationToBook()
        {
            Guid? selectedLocationId = null;

            if (!string.IsNullOrEmpty(SelectedLocation))
            {
                selectedLocationId = App.Database.GetLocationsAsync().Result.FirstOrDefault(x => x.Name == SelectedLocation).Id;
            }
            
            NewBook.LocationId = selectedLocationId == Guid.Empty ? (Guid?)Guid.Empty : (Guid?)selectedLocationId;

        }
    }
}
