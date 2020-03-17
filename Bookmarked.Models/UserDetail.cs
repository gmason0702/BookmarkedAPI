using Bookmarked.Data;
using BookmarkedAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class UserDetail
    {
        public string Id { get; set; }
        public string FullName
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                    ctx
                        .Users
                        .Single(e => e.Id == Id);

                return entity.FirstName+" "+entity.LastName;
                }
            }
        }

        public string Email { get; set; }
        public string UserName { get; set; }
        private int _count;
        public int RatingCount
        {
            get
            {
                var ctx = new ApplicationDbContext();
                _count = 0;
                foreach (UserBookJoin join in ctx.UserBookJoins)
                {
                    if (join.ReaderId == Id)
                    {
                        _count++;
                    }
                }
                return _count;

            }
        }
    }
}
