using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaveenBlog.Data.Models;
using NaveenBlog.Service.Abstractions;

namespace NaveenBlog.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class PostsController : ControllerBase
        {
            private readonly IPostService _postService;

            public PostsController(IPostService postService)
            {
                _postService = postService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
            {
                var posts = await _postService.GetAllPostsAsync();
                return Ok(posts);
            }
            [HttpGet("quotes")]
            public async Task<ActionResult<IEnumerable<Post>>> GetQuotes()
            {
                var quotes = await _postService.GetPostsByCategoryAsync("Quote");
                return Ok(quotes);
            }

            [HttpGet("poems")]
            public async Task<ActionResult<IEnumerable<Post>>> GetPoems()
            {
                var poems = await _postService.GetPostsByCategoryAsync("Poem");
                return Ok(poems);
            }

            [HttpGet("shortstories")]
            public async Task<ActionResult<IEnumerable<Post>>> GetShortStories()
            {
                var stories = await _postService.GetPostsByCategoryAsync("Short Story");
                return Ok(stories);
            }

            [HttpGet("articles")]
            public async Task<ActionResult<IEnumerable<Post>>> GetArticles()
            {
                var articles = await _postService.GetPostsByCategoryAsync("Article");
                return Ok(articles);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Post>> GetPost(int id)
            {
                var post = await _postService.GetPostByIdAsync(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }

            [HttpPost]
            public async Task<ActionResult> CreatePost(Post post)
            {
                await _postService.AddPostAsync(post);
                return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdatePost(int id, Post post)
            {
                if (id != post.Id)
                {
                    return BadRequest();
                }
                await _postService.UpdatePostAsync(post);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePost(int id)
            {
                await _postService.DeletePostAsync(id);
                return NoContent();
            }
        }
    
}
