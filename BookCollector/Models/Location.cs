using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookCollector.Models
{
    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
