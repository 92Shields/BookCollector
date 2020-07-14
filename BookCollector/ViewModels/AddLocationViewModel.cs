using BookCollector.Models;
using BookCollector.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookCollector.Pages
{
    public class AddLocationViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public Location NewLocation { get; set; }

        public AddLocationViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.NewLocation = new Location();
        }

        public async Task AddLocation()
        {
            string errorMessage = ValidateNewLocation();

            if (string.IsNullOrEmpty(errorMessage))
            {
                await App.Database.AddLocationAsync(NewLocation);
                await NavigateToLocations();
            }
        }

        public async Task NavigateToLocations()
        {
            await Navigation.PushAsync(new LocationsPage());
        }

        private string ValidateNewLocation()
        {
            StringBuilder errorMessage = new StringBuilder();

            if (String.IsNullOrEmpty(NewLocation.Name)) errorMessage.Append("Please enter a name for the location.");

            return errorMessage.ToString();
        }
    }
}
