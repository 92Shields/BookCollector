using BookCollector.Models;
using BookCollector.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookCollector.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public SortType SortType { get; set; }
        public Filter Filter { get; set; }
        public List<Location> Locations
        {
            get
            {
                return App.Database.GetLocationsAsync().Result.OrderBy(x => x.Name).ToList();
            }
        }
        public string SelectedLocation { get; set; }
        public int SelectedLocationIndex
        {
            get
            {
                int retVal = 0;
                foreach (var location in Locations)
                {
                    if (location.Name == SelectedLocation) return retVal;
                    retVal++;
                }
                return -1;
            }
        }
        public string LendingStatus { get; set; }

        public int LendingStatusSelectedIndex { get; set; }

        public MainViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            SortType = SortType.TitleAsc;
            Books = new ObservableCollection<Book>();
            Filter = new Filter();
            RefreshBookList();
        }

        public async Task NavigateAddBookManually()
        {
            await Navigation.PushModalAsync(new AddBookManuallyPage());
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
            books = FilterBooks(books);
            books = SortBooks(books);
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }

        public async void ExportCsv()
        {
            var books = await App.Database.GetBooksAsync();
            books = FilterBooks(books);
            books = SortBooks(books);

            string path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BooksExport.csv");

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Title, Author, Isbn, Publisher, Publis hDate");

                foreach (var book in books)
                {
                    sw.WriteLine(book.Title + "," + book.Author + "," + book.Isbn + "," + book.Publisher + "," + book.PublishDate);
                }
            }

        }

        private List<Book> FilterBooks(List<Book> books)
        {
            if (Filter.DateAddedFrom != null)
            {
                books = books.Where(x => x.DateAdded >= Filter.DateAddedFrom).ToList();
            }
            
            if (Filter.DateAddedTo != null)
            {
                books = books.Where(x => x.DateAdded <= Filter.DateAddedTo).ToList();
            }

            if (!string.IsNullOrEmpty(Filter.Author))
            {
                books = books.Where(x => x.Author == Filter.Author).ToList();
            }

            if (!string.IsNullOrEmpty(Filter.Publisher))
            {
                books = books.Where(x => x.Publisher == Filter.Publisher).ToList();
            }

            if (Filter.PageCountFrom != null)
            {
                books = books.Where(x => x.PageCount >= Filter.PageCountFrom).ToList();
            }

            if (Filter.PageCountTo != null)
            {
                books = books.Where(x => x.PageCount <= Filter.PageCountTo).ToList();
            }

            if (Filter.LendingStatus != null)
            {
                books = books.Where(x => x.LendingStatus == Filter.LendingStatus).ToList();
            }

            if (!string.IsNullOrEmpty(Filter.LoanedTo))
            {
                books = books.Where(x => x.LoanedTo == Filter.LoanedTo).ToList();
            }

            if (Filter.LocationId != null && Filter.LocationId != Guid.Empty)
            {
                books = books.Where(x => x.LocationId == Filter.LocationId).ToList();
            }

            if (Filter.ReadStatus != null)
            {
                books = books.Where(x => x.ReadStatus == Filter.ReadStatus).ToList();
            }

            if (Filter.Signed != null)
            {
                books = books.Where(x => x.Signed == Filter.Signed).ToList();
            }

            if (Filter.Proof != null)
            {
                books = books.Where(x => x.Proof == Filter.Proof).ToList();
            }

            if (Filter.Edition != null)
            {
                books = books.Where(x => x.Edition == Filter.Edition).ToList();
            }

            if (Filter.PublishDateFrom != null)
            {
                books = books.Where(x => x.PublishDate >= Filter.PublishDateFrom).ToList();
            }

            if (Filter.PublishDateTo != null)
            {
                books = books.Where(x => x.PublishDate <= Filter.PublishDateTo).ToList();
            }

            if (Filter.Rating != null)
            {
                books = books.Where(x => x.Rating == Filter.Rating).ToList();
            }

            return books;
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

        public void AddLocationToFilter()
        {
            Guid? selectedLocationId = null;

            if (!string.IsNullOrEmpty(SelectedLocation))
            {
                selectedLocationId = App.Database.GetLocationsAsync().Result.FirstOrDefault(x => x.Name == SelectedLocation).Id;
            }

            Filter.LocationId = selectedLocationId == Guid.Empty ? (Guid?)Guid.Empty : (Guid?)selectedLocationId;
        }

        public void AddLendingStatusToFilter()
        {
            switch (LendingStatus)
            {
                case "Loaned":
                    Filter.LendingStatus = Models.LendingStatus.Loaned;
                    break;
                case "Not Loaned":
                    Filter.LendingStatus = Models.LendingStatus.NotLoaned;
                    break;
                default:
                    Filter.LendingStatus = null;
                    break;
            }
        }
    }
}
