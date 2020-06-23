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
            string errorMessage = "";
            
            if (String.IsNullOrEmpty(book.Title))
            {
                errorMessage += "Please enter a title.&#x0a;";
            }
            if (String.IsNullOrEmpty(book.Author))
            {
                errorMessage += "Please enter an author.&#x0a;";
            }
            return errorMessage;
        }
    }
}
