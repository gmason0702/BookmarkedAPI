using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class BookClubListItem
    {
        public int BookClubId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BookName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}