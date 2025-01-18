using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaveenBlog.Data.Models;

namespace NaveenBlog.Service.Abstractions
{
    public interface IBookRecomService
    {
        Task<IEnumerable<BookRecom>> GetAllBookRecomsAsync();
        Task<BookRecom> GetBookRecomAsync(int bookRecomId);
        Task AddBookRecomAsync(BookRecom bookRecom);
        Task UpdateBookRecomAsync(BookRecom bookRecom);
        Task DeleteBookRecomAsync(int bookRecomId);
    }
}
