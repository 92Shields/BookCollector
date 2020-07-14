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
    public class LocationsViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ObservableCollection<Location> Locations { get; set; }

        public LocationsViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Locations = new ObservableCollection<Location>(App.Database.GetLocationsAsync().Result);
        }

        public async Task NavigateAddLocation()
        {
            await Navigation.PushAsync(new AddLocationPage());
        }

        public async Task NavigateLocationDetails(Guid locationId)
        {
            await Navigation.PushAsync(new LocationDetailPage(locationId));
        }
    }
}
