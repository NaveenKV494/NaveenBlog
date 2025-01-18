using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaveenBlog.Data.Models
{
    public class BookReviews
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublishedYear { get; set; }
        public string Review {  get; set; }


        public string CoverImageUrl { get; set; }
    }
}
