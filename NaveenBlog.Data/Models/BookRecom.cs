using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaveenBlog.Data.Models
{
    public class BookRecom
    {
        [Key]
        public int BookRecomId { get; set; }
        public string BookRecomTitle { get; set; }
        public string BookRecomAuthor { get; set; }
        public string BookRecomDesc { get; set; }

        public string BookRecomImgUrl { get; set; }
    }
}
