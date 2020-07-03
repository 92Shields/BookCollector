using BookCollector.Models;
using BookCollector.Pages;
using BookCollector.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace BookCollector
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel;

        public MainPage()
        {
            InitializeComponent();
            this.ViewModel = new MainViewModel(Navigation);
            BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            this.ViewModel = new MainViewModel(Navigation);
            BindingContext = this.ViewModel;
        }

        async void AddButton_Click(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Add Book", "Cancel", null, "Manually", "From ISBN");

            switch (action)
            {
                case "Manually":
                    await this.ViewModel.NavigateAddBookManually();
                    break;

                case "From ISBN":
                    await this.ViewModel.NavigateAddBookIsbn();
                    break;
            }
        }

        async void SelectBookDetail_Click(object sender, EventArgs e)
        {
            ListView list = (ListView)sender;
            Book selectedBook = (Book)list.SelectedItem;

            await this.ViewModel.NavigateBookDetail(selectedBook.Id);
        }
    }
}
