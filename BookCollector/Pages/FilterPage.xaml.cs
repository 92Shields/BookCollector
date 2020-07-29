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
    public partial class FilterPage : ContentPage
    {
        public MainViewModel ViewModel { get; set; }

        public FilterPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.ViewModel = viewModel;
            BindingContext = this.ViewModel;
        }

        async void ApplyFilter_Click(object sender, EventArgs e)
        {
            ViewModel.RefreshBookList();
            await Navigation.PopModalAsync();
        }

        async void CancelFilter_Click(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}