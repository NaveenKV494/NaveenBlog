using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaveenBlog.Data.DBContext;
using NaveenBlog.Data.Models;
using NaveenBlog.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace NaveenBlog.Data.Repositories.Implementations
{
        public class PostRepository : IPostRepository
        {
            private readonly BlogDbContext _context;

            public PostRepository(BlogDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Post>> GetAllPostsAsync()
            {
                return await _context.Posts.ToListAsync();
            }

            public async Task<Post> GetPostByIdAsync(int id)
            {
                return await _context.Posts.FindAsync(id);
            }

            public async Task AddPostAsync(Post post)
            {
                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();
            }

            public async Task UpdatePostAsync(Post post)
            {
                _context.Posts.Update(post);
                await _context.SaveChangesAsync();
            }

            public async Task DeletePostAsync(int id)
            {
                var post = await _context.Posts.FindAsync(id);
                if (post != null)
                {
                    _context.Posts.Remove(post);
                    await _context.SaveChangesAsync();
                }
            }
            public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(string category)
            {
                return await _context.Posts.Where(p => p.Category == category).ToListAsync();
            }
    }
}
