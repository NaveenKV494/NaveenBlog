using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaveenBlog.Data.Models;
using NaveenBlog.Data.Repositories.Abstractions;
using NaveenBlog.Service.Abstractions;

namespace NaveenBlog.Service.Implementations
{
    public class BookRecomService: IBookRecomService
    {
        private readonly IBookRecomRepository _repository;
        public BookRecomService(IBookRecomRepository recomRepository) 
        {
            _repository = recomRepository;
        }

        public async Task AddBookRecomAsync(BookRecom bookRecom)
        {
            await _repository.AddBookRecomAsync(bookRecom);
        }

        public async Task DeleteBookRecomAsync(int bookRecomId)
        {
            await _repository.DeleteBookRecomAsync(bookRecomId);
        }

        public async Task<IEnumerable<BookRecom>> GetAllBookRecomsAsync()
        {
            return await _repository.GetAllBookRecomsAsync();
        }

        public async Task<BookRecom> GetBookRecomAsync(int bookRecomId)
        {
            return await _repository.GetBookRecomAsync(bookRecomId);
        }

        public async Task UpdateBookRecomAsync(BookRecom bookRecom)
        {
            await _repository.UpdateBookRecomAsync(bookRecom);
        }
    }
}
