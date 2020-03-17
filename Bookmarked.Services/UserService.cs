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
    public class UserService
    {
        private readonly Guid _userId;
        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<UserDetail> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Select(
                        e =>
                        new UserDetail
                        {
                            Id = e.Id,
                            Email = e.Email,
                            UserName = e.UserName
                        }
                    );
                return query.ToArray();
            }
        }

        public UserDetail GetUserByUserName(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserName == userName);

                return
                    new UserDetail
                    {
                        Id = entity.Id,
                        Email = entity.Email,
                        UserName = entity.UserName
                    };
            }
        }

        public bool EditUser(UserEdit modelEdit)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.Id == modelEdit.Id);
                entity.FirstName = modelEdit.FirstName;
                entity.LastName = modelEdit.LastName;
                entity.Email = modelEdit.Email;
                entity.UserName = modelEdit.UserName;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.UserName == userName);
                ctx.Users.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
