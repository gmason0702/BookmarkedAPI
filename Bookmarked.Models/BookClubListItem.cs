using Bookmarked.Data;
using BookmarkedAPI.Data;
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
        public DateTimeOffset CreatedUtc { get; set; }
        public string ScheduledBookName
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    DateTimeOffset now = DateTimeOffset.Now;
                    foreach (Schedule schedule in ctx.Schedules)
                    {
                        while (schedule.BookClubId == BookClubId)
                        {
                            if (schedule.StartDate <= now && now <= schedule.EndDate)
                            {
                                string scheduledBookName = schedule.BookName;
                                return scheduledBookName;
                            }
                        }
                    }
                }
                return null;
            }
        }
    }
}