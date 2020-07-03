using BookCollector.Helpers;
using BookCollector.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public BookDetailViewModel(INavigation navigation, Guid bookId)
        {
            this.Navigation = navigation;
            this.Book = App.Database.GetBookAsync(bookId).Result;
        }

        public async Task DeleteBook()
        {
            await App.Database.DeleteBookAsync(Book);
            await Navigation.PushAsync(new MainPage());
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

        public async Task UpdateLocation(string locationId)
        {
            Book.LocationId = Guid.Parse(locationId);
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
            await UpdateBook();
        }

        public async Task UpdateLentTo(string lentTo)
        {
            Book.LentTo = lentTo;
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
