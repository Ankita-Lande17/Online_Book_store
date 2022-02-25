using System;
using System.Collections.Generic;

namespace NS.OBS.Data.Entities
{
    public partial class BookDetail
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
    }
}
