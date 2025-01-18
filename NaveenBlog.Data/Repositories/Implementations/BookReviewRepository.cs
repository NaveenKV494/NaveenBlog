using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NaveenBlog.Data.DBContext;
using NaveenBlog.Data.Models;
using NaveenBlog.Data.Repositories.Abstractions;

namespace NaveenBlog.Data.Repositories.Implementations
{
    public class BookReviewRepository : IBookReviewRepository
    {
        private readonly BlogDbContext _context;

        public BookReviewRepository(BlogDbContext context)
        {
            _context = context;
        }
        
        public async Task AddReviewAsync(BookReviews reviews)
        {
            await _context.BookReviews.AddAsync(reviews);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var reviews = await _context.BookReviews.FindAsync(id);
            if (reviews != null)
            {
                _context.BookReviews.Remove(reviews);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<BookReviews>> GetAllReviewsAsync()
        {
            return await _context.BookReviews.ToListAsync();
        }

        public async Task<BookReviews> GetReviewByIdAsync(int id)
        {
            return await _context.BookReviews.FindAsync(id);
        }

        public async Task UpdateReviewAsync(BookReviews reviews)
        {
            _context.BookReviews.Update(reviews);
            await _context.SaveChangesAsync();
        }
    }
}
