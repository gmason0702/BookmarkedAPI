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
        private readonly int _id;
        public UserBookJoinService(int id)
        {
            _id = id;
        }
        public bool CreateUserBookJoin(UserBookJoinCreate model)
        {
            var entity = new UserBookJoin()
            {

                Id = _id,
                Book= model.Book,
                Reader = model.Reader,
                Rating=model.Rating,
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
                    .Where(e => e.Id == _id)
                    .Select(e => new UserBookListItem
                    {
                        Id = e.Id,
                        ReaderId = e.ReaderId,
                        BookId = e.BookId
                    }

                        );
                return query.ToArray();
            }
        }
    }
}
