using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookCollector.Models
{
    public class Filter
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PageCount { get; set; }
        public LendingStatus LendingStatus { get; set; }
        public string LoanedTo { get; set; }
        public Guid LocationId { get; set; }
        public ReadStatus ReadStatus { get; set; }
        public bool Signed { get; set; }
        public bool Proof { get; set; }
        public int Edition { get; set; }
        public DateTime PublishDate { get; set; }
        public int Rating { get; set; }
    }
}
