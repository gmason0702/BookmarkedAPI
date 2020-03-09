using Bookmarked.Data;
using Bookmarked.Models;
using BookmarkedAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Services
{
    public class UserBookClubJoinService
    {

        private readonly int _id;
        public UserBookClubJoinService(int id)
        {
            _id = id;
        }
        public bool CreateUserBookClubJoin(UserBookClubJoinCreate model)
        {
            var entity = new UserBookClubJoin()
            {

                Id = _id,

                Reader = model.Reader,
                CreatedUtc = DateTimeOffset.UtcNow
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserBookClubJoins.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserBookClubJoinListItem> GetUserBookClub()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .UserBookClubJoins
                    .Where(e => e.Id == _id)
                    .Select(e => new UserBookClubJoinListItem
                    {
                        Id = e.Id,
                        ReaderId = e.ReaderId,                        
                    }

                        );
                return query.ToArray();
            }
        }
    }
}

