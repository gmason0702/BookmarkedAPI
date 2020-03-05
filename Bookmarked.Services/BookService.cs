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
    public class BookService
    {
        private readonly int _userId;
        public BookService(int userId)
        {
            _userId = userId;
        }
        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    Name = model.Name,
                    Author = model.Author,
                    Genre = model.Genre,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Books
                    .Where(e => e.Id == _userId)
                    .Select(
                        e =>
                        new BookListItem
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Author = e.Author,
                            UserBookJoins = e.UserBookJoins

                        }
                    );
                return query.ToArray();
            }
        }
        public BookDetail GetBookByName(string name)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Name == name);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Author = entity.Author,
                        Genre = entity.Genre,
                        CreatedUtc = entity.CreatedUtc,
                        PublishedDate = entity.PublishedDate,
                        UserBookJoins = entity.UserBookJoins
                    };
            }
        }
        public BookDetail GetBookByGenre(string genre)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Books
                    .Single(e => e.Genre == genre);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Author = entity.Author,
                        Genre = entity.Genre,
                        CreatedUtc = entity.CreatedUtc,
                        PublishedDate = entity.PublishedDate,
                        UserBookJoins = entity.UserBookJoins
                    };
            }
        }
    }
}
