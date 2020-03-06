using Bookmarked.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class BookDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset PublishedDate { get; set; }
        public ICollection<UserBookJoin> UserBookJoins { get; set; }
    }
}
