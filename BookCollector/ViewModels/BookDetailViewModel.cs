using BookCollector.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookCollector.ViewModels
{
    public class BookDetailViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public Book Book { get; set; }

        public BookDetailViewModel(INavigation navigation, Guid bookId)
        {
            this.Navigation = navigation;
            this.Book = App.Database.GetBookAsync(bookId).Result;
        }
    }
}
