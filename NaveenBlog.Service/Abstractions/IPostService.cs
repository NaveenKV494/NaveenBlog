using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaveenBlog.Data.Models;

namespace NaveenBlog.Service.Abstractions
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<IEnumerable<Post>> GetPostsByCategoryAsync(string category);
        Task<Post> GetPostByIdAsync(int id);
        Task AddPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
        Task<IEnumerable<Post>> GetQuotesAsync();
        Task<IEnumerable<Post>> GetPoemsAsync();
        Task<IEnumerable<Post>> GetShortStoriesAsync();
        Task<IEnumerable<Post>> GetArticlesAsync();
    }
}
