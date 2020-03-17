using Bookmarked.Data;
using BookmarkedAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class UserBookDetail
    {
        public int Id { get; set; }
        public string ReaderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
