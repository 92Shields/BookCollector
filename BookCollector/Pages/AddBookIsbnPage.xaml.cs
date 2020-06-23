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
    public partial class AddBookIsbnPage : ContentPage
    {
        private AddBookIsbnViewModel ViewModel;

        public AddBookIsbnPage()
        {
            InitializeComponent();
            this.ViewModel = new AddBookIsbnViewModel(Navigation);
            BindingContext = this.ViewModel;
        }
    }
}