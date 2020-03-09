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
    public class UserBookJoinService
    {
        private readonly Guid _userId;
        public UserBookJoinService(Guid userId)
        {
            _userId = userId;
        public UserBookJoinService(Guid id)
        {
            _userId = id;
        }
        public bool CreateUserBookJoin(UserBookJoinCreate model)
        {
            var ctx = new ApplicationDbContext();
            int bookId = ctx.Books.Single(e => e.Name == model.BookName).Id;
            string userId = ctx.Users.Single(e => e.UserName == model.UserName).Id;
            var entity = new UserBookJoin()
            {


                UserName=model.UserName,

            string userId = ctx.Users.Single(e => e.UserName == model.ReaderUserName).Id;
            var entity = new UserBookJoin()
            {
                ReaderId=userId,
                OwnerId = _userId,
                BookId = bookId,
                Rating=model.Rating,
                CreatedUtc = DateTimeOffset.UtcNow
            };
            using (ctx)
            {
                ctx.UserBookJoins.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserBookListItem> GetUserBook()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .UserBookJoins
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new UserBookListItem
                    {
                        Id = e.Id,

                        ReaderId=e.ReaderId,
                        BookId = e.BookId,
                        Rating=e.Rating
                        ReaderId = e.ReaderId,
                        BookId = e.BookId,
                        Rating = e.Rating

                        //Username=e.UserName,
                        BookId = e.BookId
                    }
                        );
                return query.ToArray();
            }
        }
    }
}
