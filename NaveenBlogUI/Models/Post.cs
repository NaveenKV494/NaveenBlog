namespace NaveenBlogUI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Language { get; set; }
        public DateTime DateCreated { get; set; }
        public string Category { get; set; }
    }
}
