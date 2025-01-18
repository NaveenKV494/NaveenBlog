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
    public class BookRecomsController : ControllerBase
    {
        private readonly BlogDbContext _context;

        public BookRecomsController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: api/BookRecoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookRecom>>> GetBookRecoms()
        {
            var result = await _context.BookRecoms.ToListAsync();
            return Ok(result);
        }

        // GET: api/BookRecoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookRecom>> GetBookRecom(int id)
        {
            var bookRecom = await _context.BookRecoms.FindAsync(id);

            if (bookRecom == null)
            {
                return NotFound();
            }

            return bookRecom;
        }

        // PUT: api/BookRecoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookRecom(int id, BookRecom bookRecom)
        {
            if (id != bookRecom.BookRecomId)
            {
                return BadRequest();
            }

            _context.Entry(bookRecom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookRecomExists(id))
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

        // POST: api/BookRecoms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookRecom>> PostBookRecom(BookRecom bookRecom)
        {
            _context.BookRecoms.Add(bookRecom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookRecom", new { id = bookRecom.BookRecomId }, bookRecom);
        }

        // DELETE: api/BookRecoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookRecom(int id)
        {
            var bookRecom = await _context.BookRecoms.FindAsync(id);
            if (bookRecom == null)
            {
                return NotFound();
            }

            _context.BookRecoms.Remove(bookRecom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookRecomExists(int id)
        {
            return _context.BookRecoms.Any(e => e.BookRecomId == id);
        }
    }
}
