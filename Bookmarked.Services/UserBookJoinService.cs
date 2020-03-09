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
        private readonly Guid _id;
        public UserBookJoinService(Guid id)
        {
            _id = id;
        }
        public bool CreateUserBookJoin(UserBookJoinCreate model)
        {
            var entity = new UserBookJoin()
            {

                OwnerId = _id,
                //Book= model.Book,
                UserName=model.UserName,
                CreatedUtc = DateTimeOffset.UtcNow
            };
            using (var ctx = new ApplicationDbContext())
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
                    .Where(e => e.OwnerId == _id)
                    .Select(e => new UserBookListItem
                    {
                        Id = e.Id,
                        //Username=e.UserName,
                        BookId = e.BookId
                    }

                        );
                return query.ToArray();
            }
        }
    }
}
