using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BookCollector.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public long? Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int? Edition { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? PageCount { get; set; }
        public string CoverUrl { get; set; }
        public string CoverSmallUrl { get; set; }
        public LendingStatus LendingStatus { get; set; }
        public string LoanedTo { get; set; }
        public Guid? LocationId { get; set; }
        public ReadStatus ReadStatus { get; set; }
        public bool Signed { get; set; }
        public bool Proof { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? Valuation { get; set; }
        public string Notes { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? Rating { get; set; }
        public BookCondition Condition { get; set; }

        public Book()
        {
            UserId = null;
            Isbn = null;
            Title = "";
            Author = "";
            Publisher = "";
            Edition = null;
            PublishDate = null;
            PageCount = null;
            CoverUrl = "";
            CoverSmallUrl = "";
            LendingStatus = Models.LendingStatus.NotLoaned;
            LoanedTo = "";
            LocationId = null;
            ReadStatus = Models.ReadStatus.Unlisted;
            Signed = false;
            Proof = false;
            PurchasePrice = null;
            Valuation = null;
            Notes = "";
            DateAdded = null;
            Rating = null;
            Condition = Models.BookCondition.Unlisted;
        }
    }
}
