using Bookmarked.Data;
using BookmarkedAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class BookClubDetail
    {
        public int BookClubId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
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
                                string scheduledBookName = schedule.Book.Name;
                                return scheduledBookName;
                            }
                        }
                    }
                    return null;
                }
            }
        }
    }
}
