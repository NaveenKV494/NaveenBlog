using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaveenBlog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace NaveenBlog.Data.DBContext
{
    public class BlogDbContext: DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<BookReviews> BookReviews { get; set; }
        public DbSet<BookRecom> BookRecoms { get; set; }
    }
}
