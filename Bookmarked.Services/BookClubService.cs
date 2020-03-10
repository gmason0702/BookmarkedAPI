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
    public class BookClubService
    {
        private readonly Guid _userId;
        public BookClubService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateBookClub(BookClubCreate model)
        {
            var entity =
                new BookClub()
                {
                    Name = model.Name,
                    OwnerId = _userId,
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.BookClubs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BookClubListItem> GetBookClubs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .BookClubs
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new BookClubListItem
                                {
                                    BookClubId = e.BookClubId,
                                    Name = e.Name,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public BookClubDetail GetBookClubById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BookClubs
                        .Single(e => e.BookClubId == id);
                return
                    new BookClubDetail
                    {
                        BookClubId = entity.BookClubId,
                        Name = entity.Name,
                        Description = entity.Description,
                    };
            }
        }
        public BookClubDetail GetBookClubByName(string name)
        public bool UpdateBookClub(BookClubEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BookClubs
                        .Single(e => e.Name == name);
                return
                    new BookClubDetail
                    {
                        BookClubId = entity.BookClubId,
                        Name = entity.Name,
                        Description = entity.Description,
                    };
                    .BookClubs
                    .Single(e => e.BookClubId == model.BookClubId);
                entity.Name = model.Name;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBookClub(int bookClubId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .BookClubs
                    .Single(e => e.BookClubId == bookClubId);
                ctx.BookClubs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
