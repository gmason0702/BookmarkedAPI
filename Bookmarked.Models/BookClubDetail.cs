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
        public virtual ICollection<UserBookClubJoin> ReaderList { get; set; }
        public string CurrentlyReading
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    DateTimeOffset now = DateTimeOffset.Now;
                    foreach (BookClubBookJoin bCBJ in ctx.BookClubBookJoins)
                    {
                        if (bCBJ.BookClubId == BookClubId)
                        {
                            if (bCBJ.StartDate <= now && now <= bCBJ.EndDate)
                            {
                                string scheduledBookName = bCBJ.BookName;
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
