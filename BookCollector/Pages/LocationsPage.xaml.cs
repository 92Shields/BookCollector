using BookCollector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookCollector.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationsPage : ContentPage
    {
        private LocationsViewModel ViewModel;

        public LocationsPage()
        {
            InitializeComponent();
            this.ViewModel = new LocationsViewModel(Navigation);
            BindingContext = this.ViewModel;
        }
        
        async void SelectLocation_Click(object sender, EventArgs e)
        {

        }

        async void AddLocation_Click(object sender, EventArgs e)
        {
            await ViewModel.NavigateAddLocation();
        }
    }
}