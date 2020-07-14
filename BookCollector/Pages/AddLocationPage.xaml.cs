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
            string errorMessage = await ViewModel.AddLocation();
            if (string.IsNullOrEmpty(errorMessage))
            {
                errorLabel.Text = "";
                errorLabel.IsVisible = false;
                await ViewModel.NavigateToLocations();
            }
            else
            {
                errorLabel.Text = errorMessage;
                errorLabel.IsVisible = true;
            }
        }

        async void CancelAddLocation(object sender, EventArgs e)
        {
            await ViewModel.NavigateToLocations();
        }
    }
}
