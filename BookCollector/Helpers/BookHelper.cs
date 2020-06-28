using BookCollector.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookCollector.Helpers
{
    public static class BookHelper
    {
        public static string ValidateBookEntry(Book book)
        {
            var errorMessage = new StringBuilder();

            errorMessage.Append(ValidateBookRequiredFields(book));

            return errorMessage.ToString();
        }

        public static string ValidateBookRequiredFields(Book book)
        {
            var errorMessage = new StringBuilder();

            if (String.IsNullOrEmpty(book.Title))
            {
                errorMessage.Append("Please enter a title.&#x0a;");
            }
            if (String.IsNullOrEmpty(book.Author))
            {
                errorMessage.Append("Please enter an author.&#x0a;");
            }
            return errorMessage.ToString();
        }
    }
}
