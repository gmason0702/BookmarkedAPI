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
    public class BookScheduleItemService
    {
        private readonly Guid _userId;
        public BookScheduleItemService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateBookScheduleItem(BookScheduleItemCreate model)
        {
            var ctx = new ApplicationDbContext();

            var entity = new BookScheduleItem()
            {
                OwnerId = _userId,
                ScheduleItemTitle = model.ScheduleItemTitle,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
            };
            using (ctx)
            {
                ctx.BookScheduleItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BookScheduleItemDetail> GetBookScheduleItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .BookScheduleItems
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                    new BookScheduleItemDetail
                    {
                        ScheduleItemId = e.ScheduleItemId,
                        ScheduleItemTitle = e.ScheduleItemTitle,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate,
                    }
                    );
                return query.ToArray();
            }
        }
        public BookScheduleItemDetail GetBookScheduleItemByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .BookScheduleItems
                    .Single(e => e.ScheduleItemTitle == title);
                return
                    new BookScheduleItemDetail
                    {
                        ScheduleItemTitle = entity.ScheduleItemTitle,
                        StartDate = entity.StartDate,
                        EndDate = entity.EndDate,
                    };
            }
        }
    }
}
