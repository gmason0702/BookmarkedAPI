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
        private readonly int _userId;
        public BookClubService(int userId)
        {
            _userId = userId;
        }
        public bool CreateBookClub(BookClubCreate model)
        {
            var entity =
                new BookClub()
                {
                    Name = model.Name,
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
                        .Where(e => e.BookClubId == _userId)
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
                        .Single(e => e.BookClubId == id && e.BookClubId == _userId);
                return
                    new BookClubDetail
                    {
                        BookClubId = entity.BookClubId,
                        Name = entity.Name,
                        Description = entity.Description,
                    };
            }
        }
    }
}
