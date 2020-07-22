﻿using BookCollector.Models;
using BookCollector.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookCollector.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public SortType SortType { get; set; }

        public MainViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            SortType = SortType.TitleAsc;
            Books = new ObservableCollection<Book>();
            RefreshBookList();
        }

        public async Task NavigateAddBookManually()
        {
            await Navigation.PushAsync(new AddBookManuallyPage());
        }

        public async Task NavigateAddBookIsbn()
        {
            await Navigation.PushAsync(new AddBookIsbnPage());
        }

        public async Task NavigateBookDetail(Guid bookId)
        {
            try
            {
                await Navigation.PushAsync(new BookDetailPage(bookId));
            }
            catch (Exception ex)
            {
                var exx = ex.Message;
            }
        }

        public async Task NavigateLocations()
        {
            await Navigation.PushAsync(new LocationsPage());
        }

        public void RefreshBookList()
        {
            List<Book> books = App.Database.GetBooksAsync().Result.ToList();
            Books.Clear();
            foreach (var book in SortBooks(books))
            {
                Books.Add(book);
            }
        }

        private List<Book> SortBooks(List<Book> books)
        {
            switch (SortType)
            {
                case SortType.AuthorAsc:
                    return books.OrderBy(x => x.Author).ToList();

                case SortType.AuthorDesc:
                    return books.OrderByDescending(x => x.Author).ToList();

                case SortType.TitleAsc:
                    return books.OrderBy(x => x.Title).ToList();

                case SortType.TitleDesc:
                    return books.OrderByDescending(x => x.Title).ToList();

                default:
                    return books.OrderBy(x => x.Title).ToList();

            }
        }
    }
}
