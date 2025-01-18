using System.Net.Http.Json;
using System.Net.NetworkInformation;
using NaveenBlogUI.Models;
using static System.Net.WebRequestMethods;
using System.Net.Http;

namespace NaveenBlogUI.Services
{
    public class PostService
    {
        private readonly HttpClient _http;

        public List<Post> Posts { get; private set; } = new List<Post>();


        public PostService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadPostsAsync()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<Post>>("http://localhost:5052/api/posts");
                if (response != null)
                {
                    Posts = response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading posts: {ex.Message}");
            }
        }

        public async Task AddPostAsync(Post NewPost)
        {
            var response = await _http.PostAsJsonAsync("http://localhost:5052/api/posts", NewPost);
            if (response.IsSuccessStatusCode)
            {
                await LoadPostsAsync();
            }
        }
        public async Task EditPostAsync(int postId, Post updatedPost)
        {
            var response = await _http.PutAsJsonAsync($"http://localhost:5052/api/posts/{postId}", updatedPost);
            if (response.IsSuccessStatusCode)
            {
                await LoadPostsAsync(); // Reload posts to reflect the changes
            }
        }



    }
}