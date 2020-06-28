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
    public partial class BookDetailPage : ContentPage
    {
        private BookDetailViewModel ViewModel;

        public BookDetailPage(Guid bookId)
        {
            InitializeComponent();
            this.ViewModel = new BookDetailViewModel(Navigation, bookId);
            BindingContext = this.ViewModel;
        }
    }
}