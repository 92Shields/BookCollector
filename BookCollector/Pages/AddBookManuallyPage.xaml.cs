using BookCollector.Helpers;
using BookCollector.Models;
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
    public partial class AddBookManuallyPage : ContentPage
    {

        private AddBookManuallyViewModel ViewModel;

        public AddBookManuallyPage()
        {
            InitializeComponent();
            this.ViewModel = new AddBookManuallyViewModel(Navigation);
            BindingContext = this.ViewModel;
        }

        public async void AddBookManually(object sender, EventArgs e)
        {
            ViewModel.SelectedLocation = LocationPicker.Items[LocationPicker.SelectedIndex];
            string errorMessage = await this.ViewModel.AddBookManually();

            if (string.IsNullOrEmpty(errorMessage))
            {
                errorLabel.Text = "";
                errorLabel.IsVisible = false;
                await ViewModel.NavigateMainPage();
            }
            else
            {
                errorLabel.Text = errorMessage;
                errorLabel.IsVisible = true;
            }
        }

        public void CancelAddBookManually(object sender, EventArgs e)
        {
            this.ViewModel.CancelAddBookManually();
        }
    }
}