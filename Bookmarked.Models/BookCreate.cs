using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class BookCreate
    {
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTimeOffset PublishedDate { get; set; }
    }
}
