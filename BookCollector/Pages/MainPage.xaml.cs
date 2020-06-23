using BookCollector.Models;
using BookCollector.Pages;
using BookCollector.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
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
            base.OnAppearing();
        }

        async void AddButton_Click(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Add Book", "Cancel", null, "Manually", "Scan ISBN");

            switch (action)
            {
                case "Manually":
                    this.ViewModel.AddBookManually();
                    break;

                case "Scan ISBN":
                    this.ViewModel.AddBookIsbn();
                    break;
            }
        }
    }
}
