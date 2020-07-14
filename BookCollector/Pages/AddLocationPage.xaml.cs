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
    public partial class AddLocationPage : ContentPage
    {
        private AddLocationViewModel ViewModel;

        public AddLocationPage()
        {
            InitializeComponent();
            this.ViewModel = new AddLocationViewModel(Navigation);
            BindingContext = this.ViewModel;
        }

        async void AddLocation(object sender, EventArgs e)
        {
            await ViewModel.AddLocation();
        }

        async void CancelAddLocation(object sender, EventArgs e)
        {
            await ViewModel.NavigateToLocations();
        }
    }
}
