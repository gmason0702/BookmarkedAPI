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
            var ctx = new ApplicationDbContext();
            int bookClubId = ctx.BookClubs.Single(e => e.Name == model.BookClubName).BookClubId;
            string userId = ctx.Users.Single(e => e.UserName == model.UserName).Id;
            var entity = new UserBookClubJoin()
            {
                OwnerId = _userId,
                UserName=model.UserName,
                ReaderId=userId,
                BookClubId=bookClubId,
                BookClubName=model.BookClubName,
                CreatedUtc = DateTimeOffset.UtcNow
            };
            using (ctx)
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
        public bool UpdateUserBookClubJoin(UserBookClubJoinEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UserBookClubJoins
                    .Single(e => e.Id == model.Id);
                entity.UserName = model.UserName;
                entity.BookClubName = model.BookClubName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteUserBookClubJoin(int joinId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UserBookClubJoins
                    .Single(e => e.Id == joinId);
                ctx.UserBookClubJoins.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

