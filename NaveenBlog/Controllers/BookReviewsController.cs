using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NaveenBlog.Data.DBContext;
using NaveenBlog.Data.Models;

namespace NaveenBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReviewsController : ControllerBase
    {
        private readonly BlogDbContext _context;

        public BookReviewsController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: api/BookReviews
        [HttpGet]
        public async Task<IActionResult> GetBookReviews()
        {
            var result = await _context.BookReviews.ToListAsync();
            return Ok(result);
        }

        // GET: api/BookReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookReviews>> GetBookReviews(int id)
        {
            var bookReviews = await _context.BookReviews.FindAsync(id);

            if (bookReviews == null)
            {
                return NotFound();
            }

            return bookReviews;
        }

        // PUT: api/BookReviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookReviews(int id, BookReviews bookReviews)
        {
            if (id != bookReviews.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookReviews).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookReviewsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookReviews>> PostBookReviews(BookReviews bookReviews)
        {
            _context.BookReviews.Add(bookReviews);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookReviews", new { id = bookReviews.Id }, bookReviews);
        }

        // DELETE: api/BookReviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookReviews(int id)
        {
            var bookReviews = await _context.BookReviews.FindAsync(id);
            if (bookReviews == null)
            {
                return NotFound();
            }

            _context.BookReviews.Remove(bookReviews);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookReviewsExists(int id)
        {
            return _context.BookReviews.Any(e => e.Id == id);
        }
    }
}
