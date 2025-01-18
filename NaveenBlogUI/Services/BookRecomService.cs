using System.Net.Http.Json;
using System.Net.NetworkInformation;
using NaveenBlogUI.Models;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using Newtonsoft.Json;

namespace NaveenBlogUI.Services
{
    public class BookRecomService
    {
        private readonly HttpClient _http;

        public List<BookRecom> BookRecoms { get; private set; } = new List<BookRecom>();

        public BookRecomService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadRecomAsync()
        {
            try
            {
                var response = await _http.GetAsync("api/BookRecoms");
                response.EnsureSuccessStatusCode();
                if (response.Content != null)
                {
                    BookRecoms = JsonConvert.DeserializeObject<List<BookRecom>>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading book reviews: {ex.Message}");
            }
        }
    }
}