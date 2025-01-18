namespace NaveenBlogUI.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublishedYear { get; set; }
        public string Review { get; set; }

        public string CoverImageUrl { get; set; }
    }
}
