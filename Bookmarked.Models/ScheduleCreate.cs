using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class ScheduleCreate
    {
        public string ScheduleName { get; set; }
        public string ScheduleItemTitle { get; set; }
        public string BookName { get; set; }
        public string BookClubName { get; set; }
    }
}
