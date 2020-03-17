using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Data
{
    public class BookScheduleItem
    {
        [Key]
        public int ScheduleItemId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string ScheduleItemTitle { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
