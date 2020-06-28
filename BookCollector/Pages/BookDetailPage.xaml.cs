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
    public partial class BookDetailPage : ContentPage
    {
        private BookDetailViewModel ViewModel;

        public BookDetailPage(Guid bookId)
        {
            InitializeComponent();
            this.ViewModel = new BookDetailViewModel(Navigation, bookId);
            BindingContext = this.ViewModel;
        }

        public async void DeleteBook_Click(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Are you sure?", "Cancel", null, "Confirm");

            switch (action)
            {
                case "Confirm":
                    
                    await this.ViewModel.DeleteBook();
                    break;
            }
        }
    }
}