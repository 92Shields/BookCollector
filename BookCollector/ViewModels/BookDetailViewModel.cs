using BookCollector.Helpers;
using BookCollector.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookCollector.ViewModels
{
    public class BookDetailViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public Book Book { get; set; }
        public bool IsLoanedToVisible
        {
            get { return Book.LendingStatus == Models.LendingStatus.Loaned;
    }
        }
        public List<string> Conditions
        {
            get
            {
                return Enum.GetNames(typeof(BookCondition)).Select(b => b.SplitCamelCase()).ToList();
            }
        }

        public List<string> LendingStatus
        {
            get
            {
                return Enum.GetNames(typeof(LendingStatus)).Select(b => b.SplitCamelCase()).ToList();
            }
        }

        public List<string> Locations
        {
            get
            {
                var locations = new List<string>();
                locations.Add("Unlisted");
                locations.AddRange(App.Database.GetLocationsAsync().Result.Select(x => x.Name).ToList());
                return locations;
            }
        }

        public string SelectedLocation
        {
            get
            {
                return Book.LocationId != Guid.Empty && Book.LocationId != null ? App.Database.GetLocationAsync((Guid)Book.LocationId).Result.Name : "Unlisted";

            }
        }

        public int SelectedLocationIndex
        {
            get
            {
                int retVal = 0;
                foreach (var location in Locations)
                {
                    if (location == SelectedLocation) return retVal;
                    retVal++;
                }
                return -1;
            }
        }

        public BookDetailViewModel(INavigation navigation, Guid bookId)
        {
            this.Navigation = navigation;
            this.Book = App.Database.GetBookAsync(bookId).Result;
        }

        public async Task DeleteBook()
        {
            await App.Database.DeleteBookAsync(Book);
            await Navigation.PopAsync();
        }

        public async Task UpdateTitle(string title)
        {
            Book.Title = title;
            await UpdateBook();
        }

        public async Task UpdateAuthor(string author)
        {
            Book.Author = author;
            await UpdateBook();
        }

        public async Task UpdateIsbn(string isbn)
        {
            Book.Isbn = long.Parse(isbn);
            await UpdateBook();
        }

        public async Task UpdatePublisher(string publisher)
        {
            Book.Publisher = publisher;
            await UpdateBook();
        }

        public async Task UpdateEdition(string edition)
        {
            Book.Edition = int.Parse(edition);
            await UpdateBook();
        }

        public async Task UpdatePublishDate(DateTime publishDate)
        {
            Book.PublishDate = publishDate;
            await UpdateBook();
        }

        public async Task UpdatePageCount(string pageCount)
        {
            Book.PageCount = int.Parse(pageCount);
            await UpdateBook();
        }

        public async Task UpdateLocation(string locationName)
        {
            if (locationName != "Unlisted")
            {
                Book.LocationId = App.Database.GetLocationsAsync().Result.FirstOrDefault(x => x.Name == locationName).Id;
            } else
            {
                Book.LocationId = null;
            }
            await UpdateBook();
        }

        public async Task UpdateSigned(bool signed)
        {
            Book.Signed = signed;
            await UpdateBook();
        }

        public async Task UpdateProof(bool proof)
        {
            Book.Proof = proof;
            await UpdateBook();
        }

        public async Task UpdatePurchasePrice(string purchasePrice)
        {
            Book.PurchasePrice = decimal.Parse(purchasePrice);
            await UpdateBook();
        }

        public async Task UpdateValuation(string valuation)
        {
            Book.Valuation = decimal.Parse(valuation);
            await UpdateBook();
        }

        public async Task UpdateRating(string rating)
        {
            Book.Rating = int.Parse(rating);
            await UpdateBook();
        }

        public async Task UpdateCondition(string condition)
        {
            Book.Condition = (Models.BookCondition)Enum.Parse(typeof(Models.BookCondition), condition.Replace(" ", ""));
            await UpdateBook();
        }

        public async Task UpdateLendingStatus(string lendingStatus)
        {
            Book.LendingStatus = (Models.LendingStatus)Enum.Parse(typeof(Models.LendingStatus), lendingStatus.Replace(" ", ""));
            if (Book.LendingStatus == Models.LendingStatus.NotLoaned)
            {
                Book.LoanedTo = "";
            }
            await UpdateBook();
            OnPropertyChanged("IsLoanedToVisible");
        }

        public async Task UpdateLoanedTo(string LoanedTo)
        {
            Book.LoanedTo = LoanedTo;
            await UpdateBook();
        }

        private async Task UpdateBook()
        {
            var errorMessage = new StringBuilder();
            errorMessage.Append(BookHelper.ValidateBookRequiredFields(Book));
            if (string.IsNullOrEmpty(errorMessage.ToString()))
            {
                await App.Database.UpdateBookAsync(Book);
            }
            else
            {
                
            }
        }
    }
}
