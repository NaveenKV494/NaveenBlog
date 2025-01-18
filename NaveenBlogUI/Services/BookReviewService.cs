using System.Net.Http.Json;
using System.Net.NetworkInformation;
using NaveenBlogUI.Models;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using Newtonsoft.Json;
using NaveenBlogUI.Pages;

namespace NaveenBlogUI.Services
{
    public class BookReviewService
    {
        private readonly HttpClient _http;

        public List<BookReview> BookReviews { get; private set; } = new List<BookReview>();

        public BookReviewService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadReviewAsync()
        {
            try
            {
                var response = await _http.GetAsync("api/BookReviews");
                response.EnsureSuccessStatusCode();
                if (response.Content != null)
                {
                    BookReviews =JsonConvert.DeserializeObject<List<BookReview>>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading book reviews: {ex.Message}");
            }
        }

    }
}