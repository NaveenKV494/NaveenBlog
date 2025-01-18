using System.Net.Http.Json;
using NaveenBlogUI.Models;
using Newtonsoft.Json;

public class WritingService
{
    private readonly HttpClient _httpClient;

    public WritingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Post>> GetQuotesAsync()
    {
        return await GetPostsByCategoryAsync("quotes");
    }

    public async Task<List<Post>> GetPoemsAsync()
    {
        return await GetPostsByCategoryAsync("poems");
    }

    public async Task<List<Post>> GetShortStoriesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/posts/shortstories");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Post>>(content) ?? new List<Post>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching short stories: {ex.Message}");
            return new List<Post>();
        }
    }


    public async Task<List<Post>> GetArticlesAsync()
    {
        return await GetPostsByCategoryAsync("articles");
    }

    private async Task<List<Post>> GetPostsByCategoryAsync(string category)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/posts/{category}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Post>>(content) ?? new List<Post>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching {category}: {ex.Message}");
            return new List<Post>();
        }
    }
}
