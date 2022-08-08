using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.DAL
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
