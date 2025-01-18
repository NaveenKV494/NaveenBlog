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
    public class BookReviewService: IBookReviewService
    {
        private readonly IBookReviewRepository _reviewRepository;
        public BookReviewService(IBookReviewRepository reviewRepository) 
        {
            _reviewRepository = reviewRepository;
        }

        public async Task AddReviewAsync(BookReviews reviews)
        {
            await _reviewRepository.AddReviewAsync(reviews);
        }

        public async Task DeleteReviewAsync(int id)
        {
            await _reviewRepository.DeleteReviewAsync(id);
        }

        public async Task<IEnumerable<BookReviews>> GetAllReviewsAsync()
        {
            return await _reviewRepository.GetAllReviewsAsync();
        }

        public async Task<BookReviews> GetReviewByIdAsync(int id)
        {
            return await _reviewRepository.GetReviewByIdAsync(id);
        }

        public async Task UpdateReviewAsync(BookReviews reviews)
        {
            await _reviewRepository.UpdateReviewAsync(reviews);
        }
    }
}
