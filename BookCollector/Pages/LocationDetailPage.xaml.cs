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
    public partial class LocationDetailPage : ContentPage
    {
        private LocationDetailViewModel ViewModel;

        public LocationDetailPage(Guid locationId)
        {
            InitializeComponent();
            this.ViewModel = new LocationDetailViewModel(Navigation, locationId);
            BindingContext = this.ViewModel;
        }

        public async void DeleteLocation_Click(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Are you sure?", "Cancel", null, "Confirm");

            switch (action)
            {
                case "Confirm":

                    await this.ViewModel.DeleteLocation();
                    break;
            }
        }

        public async void EditName_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title: "Name", message: "", cancel: "Cancel", initialValue: name.Text);
            if (String.IsNullOrEmpty(result)) return;
            await ViewModel.UpdateName(result);
            name.Text = result;
        }

        public async void EditAddress_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title: "Address", message: "", initialValue: address.Text);
            await ViewModel.UpdateAddress(result);
            address.Text = result;
        }
        public async void EditDetails_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title: "Details", message: "", initialValue: details.Text);
            await ViewModel.UpdateDetails(result);
            details.Text = result;
        }
    }
}