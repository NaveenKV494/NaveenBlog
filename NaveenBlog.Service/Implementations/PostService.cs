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
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllPostsAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetPostByIdAsync(id);
        }

        public async Task AddPostAsync(Post post)
        {
            await _postRepository.AddPostAsync(post);
        }

        public async Task UpdatePostAsync(Post post)
        {
            await _postRepository.UpdatePostAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepository.DeletePostAsync(id);
        }
        public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(string category)
        {
            return await _postRepository.GetPostsByCategoryAsync(category);
        }

        public async Task<IEnumerable<Post>> GetQuotesAsync()
        {
            return await _postRepository.GetPostsByCategoryAsync("Quote");
        }

        public async Task<IEnumerable<Post>> GetPoemsAsync()
        {
            return await _postRepository.GetPostsByCategoryAsync("Poem");
        }

        public async Task<IEnumerable<Post>> GetShortStoriesAsync()
        {
            return await _postRepository.GetPostsByCategoryAsync("Short Story");
        }

        public async Task<IEnumerable<Post>> GetArticlesAsync()
        {
            return await _postRepository.GetPostsByCategoryAsync("Article");
        }
    }
}
