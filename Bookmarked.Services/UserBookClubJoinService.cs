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

        private readonly Guid _userId;
        public UserBookClubJoinService(Guid id)
        {
            _userId = id;
        }
        public bool CreateUserBookClubJoin(UserBookClubJoinCreate model)
        {
            var entity = new UserBookClubJoin()
            {

                OwnerId = _userId,
                UserName=model.UserName,
                BookClubName=model.BookClubName,

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
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new UserBookClubJoinListItem
                    {
                        Id=e.Id,
                        ReaderId = e.ReaderId,                        
                    }

                        );
                return query.ToArray();
            }
        }
    }
}

