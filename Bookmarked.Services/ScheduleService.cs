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
    public class ScheduleService
    {
        private readonly Guid _userId;
        public ScheduleService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateSchedule(ScheduleCreate model)
        {
            var ctx = new ApplicationDbContext();
            //int scheduleItemId = ctx.BookScheduleItems.Single(e => e.ScheduleItemTitle == model.ScheduleItemTitle).ScheduleItemId;
            int bookClubId = ctx.BookClubs.Single(e => e.Name == model.BookClubName).BookClubId;
            int bookId = ctx.Books.Single(e => e.Name == model.BookName).Id;
            var entity = new Schedule()
            {
                OwnerId = _userId,
                ScheduleName = model.ScheduleName,
                //ScheduleItemTitle = model.ScheduleItemTitle,
                //ScheduleItemId = scheduleItemId,
                BookClubName = model.BookClubName,
                BookClubId = bookClubId,
                BookName = model.BookName,
                BookId = bookId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,

            };
            using (ctx)
            {
                ctx.Schedules.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public ScheduleDetail GetScheduleByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Schedules
                    .Single(e => e.ScheduleName == name);
                return
                    new ScheduleDetail
                    {
                        Id = entity.Id,
                        //ScheduleItemTitle = entity.ScheduleItemTitle,
                        BookName = entity.BookName,
                        BookClubName = entity.BookClubName,
                        //StartDate = entity.ScheduleItem.StartDate,
                        //EndDate = entity.ScheduleItem.EndDate,
                        StartDate = entity.StartDate,
                        EndDate = entity.EndDate,
                    };
            }
        }
        public bool UpdateScheduleByName(ScheduleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Schedules
                    .Single(e => e.ScheduleName == model.ScheduleName);
                entity.BookName = model.BookName;
                entity.BookClubName = model.BookClubName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteScheduleByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Schedules
                    .Single(e => e.ScheduleName == name);
                ctx.Schedules.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
