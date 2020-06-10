using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookCollector.Models
{
    public class Settings
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Currency Currency { get; set; }
    }
}
