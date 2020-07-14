using BookCollector.Models;
using BookCollector.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookCollector.ViewModels
{
    public class LocationDetailViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public Location Location { get; set; }

        public LocationDetailViewModel(INavigation navigation, Guid locationId)
        {
            this.Navigation = navigation;
            this.Location = App.Database.GetLocationAsync(locationId).Result;
        }

        public async Task DeleteLocation()
        {
            await App.Database.DeleteLocationAsync(Location);
            await Navigation.PushAsync(new LocationsPage());
        }

        public async Task UpdateName(string name)
        {
            Location.Name = name;
            await UpdateLocation();
        }

        public async Task UpdateAddress(string address)
        {
            Location.Address = address;
            await UpdateLocation();
        }

        public async Task UpdateDetails(string details)
        {
            Location.Details = details;
            await UpdateLocation();
        }

        private async Task UpdateLocation()
        {
            if (string.IsNullOrEmpty(Location.Name))
            {

            }
            else
            {
                await App.Database.UpdateLocationAsync(Location);
            }
        }
    }
}
