using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NaveenBlog.Data.DBContext;
using NaveenBlog.Data.Migrations;
using NaveenBlog.Data.Models;
using NaveenBlog.Data.Repositories.Abstractions;

namespace NaveenBlog.Data.Repositories.Implementations
{
    public class BookRecomRepository: IBookRecomRepository
    {
        private readonly BlogDbContext _context;
        public BookRecomRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddBookRecomAsync(BookRecom bookRecom)
        {
            _context.BookRecoms.AddAsync(bookRecom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookRecomAsync(int bookRecomId)
        {
            var bookrecom = await _context.BookRecoms.FindAsync(bookRecomId);
            if (bookrecom != null)
            {
                _context.BookRecoms.Remove(bookrecom);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<BookRecom>> GetAllBookRecomsAsync()
        {
            return await _context.BookRecoms.ToListAsync();
        }

        public async Task<BookRecom> GetBookRecomAsync(int bookRecomId)
        {
           return await _context.BookRecoms.FindAsync(bookRecomId);
        }

        public async Task UpdateBookRecomAsync(BookRecom bookRecom)
        {
            _context.BookRecoms.Update(bookRecom);
            await _context.SaveChangesAsync();
        }
    }
}
