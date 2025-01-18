using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaveenBlog.Data.Models;

namespace NaveenBlog.Service.Abstractions
{
    public interface IBookReviewService
    {
        Task<IEnumerable<BookReviews>> GetAllReviewsAsync();
        Task<BookReviews> GetReviewByIdAsync(int id);
        Task AddReviewAsync(BookReviews reviews);
        Task UpdateReviewAsync(BookReviews reviews);
        Task DeleteReviewAsync(int id);
    }
}
