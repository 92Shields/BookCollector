using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookCollector.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
