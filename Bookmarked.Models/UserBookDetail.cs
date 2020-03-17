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
        private int _count;
        //Eventually needs moved to user class -Alec
        public int RatingCount
        {
            get
            {
                var ctx = new ApplicationDbContext();
                _count = 0;
                foreach (UserBookJoin join in ctx.UserBookJoins)
                {
                    if (join.ReaderId == ReaderId)
                    {
                        _count++;
                    }
                }
                return _count;

            }
        }
    }
}
