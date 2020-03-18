using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class BookClubBookListItem
    {
        public int Id { get; set; }
        public string ScheduleName { get; set; }
        public string BookName { get; set; }
        public string BookClubName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}