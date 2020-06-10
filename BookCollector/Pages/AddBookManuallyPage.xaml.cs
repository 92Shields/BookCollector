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
        public AddBookManuallyPage()
        {
            InitializeComponent();
        }

        async void AddBookManually(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void CancelAddBookManually(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}