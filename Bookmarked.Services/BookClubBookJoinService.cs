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
    public class BookClubBookJoinService
    {
        private readonly Guid _userId;
        public BookClubBookJoinService(Guid id)
        {
            _userId = id;
        }

        public bool CreateBookClubBookJoin(BookClubBookJoinCreate model)
        {
            var ctx = new ApplicationDbContext();
            int bookClubId = ctx.BookClubs.Single(e => e.Name == model.BookClubName).BookClubId;
            int bookId = ctx.Books.Single(e => e.Name == model.BookName).Id;
            var entity = new BookClubBookJoin()
            {
                OwnerId = _userId,
                BookClubId = bookClubId,
                BookId=bookId,
                BookClubName = model.BookClubName,
            };
            using (ctx)
            {
                ctx.BookClubBookJoins.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BookClubBookListItem> GetBookClubBook()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .BookClubBookJoins
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new BookClubBookListItem
                    {
                        BookId = e.BookId,
                        BookClubId = e.BookClubId
                    }

                        );
                return query.ToArray();
            }
        }
    }
}
