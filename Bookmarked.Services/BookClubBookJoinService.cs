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
                BookId = bookId,
                BookClubName = model.BookClubName,
                BookName = model.BookName,
                ScheduleName = model.ScheduleName,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                CreatedUtc = DateTimeOffset.Now
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
                        Id = e.Id,
                        ScheduleName = e.ScheduleName,
                        BookName = e.BookName,
                        BookClubName = e.BookClubName,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate,
                    }

                        );
                return query.ToArray();
            }
        }
        public bool UpdateBookClubBookJoin(BookClubBookJoinEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .BookClubBookJoins
                    .Single(e => e.ScheduleName == model.ScheduleName);
                entity.BookId= ctx.Books.FirstOrDefault(x => x.Name == model.BookName).Id;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.BookName = model.BookName;
                entity.BookClubId= ctx.BookClubs.FirstOrDefault(x => x.Name == model.BookClubName).BookClubId;
                entity.BookClubName = model.BookClubName;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBookClubBookJoin(string scheduleName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .BookClubBookJoins
                    .Single(e => e.ScheduleName == scheduleName);
                ctx.BookClubBookJoins.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
