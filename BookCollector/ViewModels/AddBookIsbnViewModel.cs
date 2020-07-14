using BookCollector.Models;
using BookCollector.Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookCollector.ViewModels
{
    class AddBookIsbnViewModel
    {
        public INavigation Navigation { get; set; }
        public long? IsbnEntry { get; set; }
        public Book NewBook { get; set; }

        public AddBookIsbnViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }

        public async Task<string> GetBookDetails(string isbn)
        {
            var errorMessage = new StringBuilder();
            var url = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JObject.Parse(content);
                int test = (int)result["totalItems"];
                if ((int)result["totalItems"] != 0)
                {
                    var bookDetails = result["items"][0]["volumeInfo"];
                    NewBook = new Book
                    {
                        Isbn = long.Parse(isbn),
                        Title = (string)bookDetails["title"],
                        Author = (string)bookDetails["authors"][0],
                        Publisher = (string)bookDetails["publisher"],
                        PublishDate = (DateTime.TryParse((string)bookDetails["publishedDate"], out var dt) ? dt : (DateTime?)null),
                        PageCount = (int)bookDetails["pageCount"],
                        CoverUrl = (string)bookDetails["imageLinks"]["thumbnail"],
                        CoverSmallUrl = (string)bookDetails["imageLinks"]["smallThumbnail"],
                        LendingStatus = Models.LendingStatus.NotLoaned
                    };
                }
                else
                {
                    errorMessage.Append("Book could not be found, please try again or enter the details manually.");
                }
            }
            return errorMessage.ToString();
        }

        public async Task AddNewBook()
        {
            await App.Database.AddBookAsync(NewBook);
        }

        public async Task NavigateBookDetails()
        {
            await Navigation.PushAsync(new BookDetailPage(NewBook.Id));
        }
    }
}
