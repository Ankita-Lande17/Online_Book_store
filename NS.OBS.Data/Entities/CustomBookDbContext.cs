using Microsoft.EntityFrameworkCore;
using NS.OBS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.OBS.Data.Entities
{
    public partial class BookDBContext : DbContext
    {
        public DbSet<BookModel> CustomBookModel { get; set; }
    }
}
