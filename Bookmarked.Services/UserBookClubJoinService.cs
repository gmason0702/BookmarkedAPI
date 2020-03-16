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
            string description = ctx.BookClubs.Single(e => e.Name == model.BookClubName).Description;
            var entity = new UserBookClubJoin()
            {
                OwnerId = _userId,
                UserName = model.UserName,
                ReaderId = userId,
                BookClubId = bookClubId,
                BookClubName = model.BookClubName,
                CreatedUtc = DateTimeOffset.UtcNow,
                Description = description
            };
            using (ctx)
            {
                ctx.UserBookClubJoins.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserBookClubDetail> GetUserBookClubDetails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .UserBookClubJoins
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new UserBookClubDetail
                    {
                        UserName = ctx.Users.FirstOrDefault(x => x.Id == e.ReaderId).UserName,
                        BookClubId = e.BookClubId,
                        BookClubName = ctx.BookClubs.FirstOrDefault(x => x.BookClubId == e.BookClubId).Name,
                        Description = ctx.BookClubs.FirstOrDefault(x => x.BookClubId == e.BookClubId).Description,
                        CreatedUtc = e.CreatedUtc,
                    }
                        );
                return query.ToArray();
            }
        }
        public IEnumerable<UserBookClubDetail> GetAllUserBookClubDetails(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .UserBookClubJoins
                    .Where(e => e.Id > id)
                    .Select(e => new UserBookClubDetail
                    {
                        UserName = ctx.Users.FirstOrDefault(x => x.Id == e.ReaderId).UserName,
                        BookClubId = e.BookClubId,
                        BookClubName = ctx.BookClubs.FirstOrDefault(x => x.BookClubId == e.BookClubId).Name,
                        Description = ctx.BookClubs.FirstOrDefault(x => x.BookClubId == e.BookClubId).Description,
                        CreatedUtc = e.CreatedUtc,
                    }
                        );
                return query.ToArray();
            }
        }
        public IEnumerable<BookClubDetail> GetAllBookClubsOfUser(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .UserBookClubJoins
                    .Where(e => e.UserName == userName)
                .Select(e => new BookClubDetail
                {
                    Name = e.BookClubName,
                    BookClubId = e.BookClubId,
                    Description = e.Description,
                }
                );
                return query.ToArray();
            }
        }
        public ICollection<BookClubUsers> GetUsersByBookClub(string bookClubName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UserBookClubJoins
                        .Where(e => e.BookClubName == bookClubName)
                        .Select(
                            e =>
                                new BookClubUsers
                                {
                                    UserName = e.UserName,
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
                    .Single(e => e.Id == model.JoinId);
                entity.ReaderId = ctx.Users.FirstOrDefault(x => x.UserName == model.UserName).Id;
                entity.BookClubId = ctx.BookClubs.FirstOrDefault(y => y.Name == model.BookClubName).BookClubId;
                entity.UserName = model.UserName;
                entity.BookClubName = model.BookClubName;
                entity.Description = ctx.BookClubs.FirstOrDefault(z => z.BookClubId == 
                ctx.BookClubs.FirstOrDefault(y => y.Name == model.BookClubName).BookClubId).Description;
                entity.ModifiedUtc = DateTimeOffset.Now;

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

