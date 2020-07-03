using BookCollector.ViewModels;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace BookCollector.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBookIsbnPage : ContentPage
    {
        private AddBookIsbnViewModel ViewModel;

        public AddBookIsbnPage()
        {
            InitializeComponent();
            this.ViewModel = new AddBookIsbnViewModel(Navigation);
            BindingContext = this.ViewModel;
        }

        public async void ScanIsbn_Click(object sender, EventArgs e)
        {
            try
            {
                var options = new MobileBarcodeScanningOptions
                {
                    AutoRotate = false,
                    UseFrontCameraIfAvailable = false,
                    TryHarder = true
                };

                var overlay = new ZXingDefaultOverlay
                {
                    TopText = "Please scan barcode",
                    BottomText = "Align the barcode within the frame"
                };

                var scanner = new ZXingScannerPage(options, overlay);

                await Navigation.PushModalAsync(scanner);

                scanner.OnScanResult += (result) =>
                {
                    // Stop scanning
                    scanner.IsScanning = false;

                    // Pop the page and show the result
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Navigation.PopModalAsync(true);
                        //DisplayAlert("Scanned Barcode", result.Text, "OK");
                        isbnEntry.Text = result.Text;
                    });

                };

            }
            catch (Exception ex)
            {

            }
        }

        public async void Confirm_Click(object sender, EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                await ViewModel.GetBookDetails(isbnEntry.Text);

                var confirmationText = new StringBuilder();
                confirmationText.Append($"Title: {ViewModel.NewBook.Title}\n");
                confirmationText.Append($"Author: {ViewModel.NewBook.Author}\n");
                confirmationText.Append($"ISBN: {ViewModel.NewBook.Isbn}\n");
                confirmationText.Append($"Publisher: {ViewModel.NewBook.Publisher}\n");
                confirmationText.Append($"Publish date: {ViewModel.NewBook.PublishDate}\n");
                confirmationText.Append($"Page count: {ViewModel.NewBook.PageCount}");

                bool answer = await DisplayAlert("Are the details correct?", confirmationText.ToString(), "Yes", "No");

                if (answer)
                {
                    isbnEntry.Text = "";
                    await ViewModel.AddNewBook();
                    await ViewModel.NavigateBookDetails();
                }
                else
                {
                    await DisplayAlert("Alert", "Please check the ISBN code or add the book manually.", "OK");
                }
            }
            else
            {
                // no internet so show warning
                await DisplayAlert("Alert", "No internet connectivity, please resolve and try again.", "OK");
            }
        }
    }
}