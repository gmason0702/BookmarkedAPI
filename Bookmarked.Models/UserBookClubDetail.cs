using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class UserBookClubDetail
    {
        public string UserName { get; set; }
        public string BookClubName { get; set; }
        public int BookClubId { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
