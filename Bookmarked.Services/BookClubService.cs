using Bookmarked.Data;
using Bookmarked.Models;
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
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
