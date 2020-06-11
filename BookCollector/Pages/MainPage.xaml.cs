using BookCollector.Models;
using BookCollector.Pages;
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
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetBooksAsync();
        }

        async void AddButton_Click(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Add Book", "Cancel", null, "Manually", "Scan ISBN");

            switch (action)
            {
                case "Manually":
                    await Navigation.PushAsync(new AddBookManuallyPage());
                    break;

                case "Scan ISBN":
                    await Navigation.PushAsync(new AddBookIsbnPage());
                    break;
            }
        }
    }
}
