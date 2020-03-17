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
        private readonly Guid _userId;
        public UserBookJoinService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateUserBookJoin(UserBookJoinCreate model)
        {
            var ctx = new ApplicationDbContext();
            int bookId = ctx.Books.Single(e => e.Name == model.BookName).Id;
            string userId = ctx.Users.Single(e => e.UserName == model.UserName).Id;
            var entity = new UserBookJoin()
            {

                UserName = model.UserName,
                ReaderId = userId,
                OwnerId = _userId,
                BookId = bookId,
                BookName=model.BookName,
                Rating = model.Rating,
                Review=model.Review,
                CreatedUtc = DateTimeOffset.UtcNow
            };
            using (ctx)
            {
                ctx.UserBookJoins.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //public IEnumerable<UserBookListItem> GetUserBooks()//commenting out for now because you can only have on get - probably don't need this
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query = ctx
        //            .UserBookJoins
        //            .Where(e => e.OwnerId == _userId)
        //            .Select(e => new UserBookListItem
        //            {
        //                Id = e.Id,
        //                ReaderId=e.ReaderId,
        //                BookId = e.BookId,
        //                Rating=e.Rating,
        //                //Username=e.UserName,
        //            }
        //                );
        //        return query.ToArray();
        //    }
        //}
        //public IEnumerable<UserBookListItem> GetAllUserBooks(int id)//commenting out for now because you can only have on get - probably don't need this
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query = ctx
        //            .UserBookJoins
        //            .Where(e => e.Id > id)
        //            .Select(e => new UserBookListItem
        //            {
        //                Id = e.Id,
        //                ReaderId = e.ReaderId,
        //                BookId = e.BookId,
        //                Rating = e.Rating,
        //                //Username=e.UserName,
        //            }
        //                );
        //        return query.ToArray();
        //    }
        //}
        public IEnumerable<UserBookDetail> GetUserBookDetails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .UserBookJoins
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new UserBookDetail
                    {
                        Id = e.Id,
                        ReaderId = e.ReaderId,
                        FirstName = ctx.Users.FirstOrDefault(x => x.Id == e.ReaderId).FirstName,
                        LastName = ctx.Users.FirstOrDefault(x => x.Id == e.ReaderId).LastName,
                        UserName = ctx.Users.FirstOrDefault(x => x.Id == e.ReaderId).UserName,
                        BookId = e.BookId,
                        BookName = ctx.Books.FirstOrDefault(x => x.Id == e.BookId).Name,
                        Author = ctx.Books.FirstOrDefault(x => x.Id == e.BookId).Author,
                        Rating = e.Rating,
                        Review = e.Review,
                    }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<UserBookRating> GetAllRatingsByUser(string user)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .UserBookJoins
                    .Where(e => e.UserName == user)
                    .Select(e => new UserBookRating
                    {
                        UserName = ctx.Users.FirstOrDefault(x => x.Id == e.ReaderId).UserName,
                        BookName = ctx.Books.FirstOrDefault(x => x.Id == e.BookId).Name,
                        Rating = e.Rating,
                        Review = e.Review,
                    }
                    );
                return query.ToArray();
            }
        }
        public IEnumerable<UserBookDetail> GetUserBookDetailsByUserName(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .UserBookJoins
                    .Where(e => e.ReaderId == ctx.Users.FirstOrDefault(y => y.UserName == userName).Id)
                    .Select(e => new UserBookDetail
                    {
                        Id = e.Id,
                        ReaderId = e.ReaderId,
                        FirstName = ctx.Users.FirstOrDefault(x => x.Id == e.ReaderId).FirstName,
                        LastName = ctx.Users.FirstOrDefault(x => x.Id == e.ReaderId).LastName,
                        UserName = ctx.Users.FirstOrDefault(x => x.Id == e.ReaderId).UserName,
                        BookId = e.BookId,
                        BookName = ctx.Books.FirstOrDefault(x => x.Id == e.BookId).Name,
                        Author = ctx.Books.FirstOrDefault(x => x.Id == e.BookId).Author,
                        Rating = e.Rating,
                        Review = e.Review
                    }
                        );
                return query.ToArray();
            }
        }
        public IEnumerable<UserBookRating> GetAllRatingsByUser(string username)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .UserBookJoins
                    .Where(e => e.UserName == username)
                    .Select(e => new UserBookRating
                    {
                        UserName=ctx.Users.FirstOrDefault(x=>x.Id==e.ReaderId).UserName,
                        BookName=ctx.Books.FirstOrDefault(x=>x.Id==e.BookId).Name,
                        Rating=e.Rating
                    }

                    );
                return query.ToArray();
            }
        }
        public IEnumerable<UserBookDetail> GetAllUserBookDetails(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .UserBookJoins
                    .Where(e => e.Id > id)
                    .Select(e => new UserBookDetail
                    {
                        Id = e.Id,
                        ReaderId = e.ReaderId,
                        FirstName = ctx.Users.FirstOrDefault(x => x.Id == e.ReaderId).FirstName,
                        LastName = ctx.Users.FirstOrDefault(x => x.Id == e.ReaderId).LastName,
                        UserName = ctx.Users.FirstOrDefault(x => x.Id == e.ReaderId).UserName,
                        BookId = e.BookId,
                        BookName = ctx.Books.FirstOrDefault(x => x.Id == e.BookId).Name,
                        Author = ctx.Books.FirstOrDefault(x => x.Id == e.BookId).Author,
                        Rating = e.Rating,
                        Review = e.Review
                    }
                        );
                return query.ToArray();
            }
        }


        public bool UpdateUserBookJoin(UserBookJoinEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UserBookJoins
                    .Single(e => e.Id == model.JoinId);
                entity.ReaderId = ctx.Users.FirstOrDefault(x => x.UserName == model.UserName).Id;
                entity.BookId = ctx.Books.FirstOrDefault(y => y.Name == model.BookName).Id;
                entity.UserName = model.UserName;
                entity.BookName = model.BookName;
                entity.Rating = model.Rating;
                entity.Review = model.Review;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUserBookJoin(int joinId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UserBookJoins
                    .Single(e => e.Id == joinId);
                ctx.UserBookJoins.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
