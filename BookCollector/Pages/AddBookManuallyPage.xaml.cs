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

        public void AddBookManually(object sender, EventArgs e)
        {
            this.ViewModel.AddBookManually();
        }

        public void CancelAddBookManually(object sender, EventArgs e)
        {
            this.ViewModel.CancelAddBookManually();
        }
    }
}