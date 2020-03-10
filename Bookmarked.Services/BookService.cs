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
        private readonly Guid _userId;
        public BookService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    Name = model.Name,
                    OwnerId = _userId,
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
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new BookListItem
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Author = e.Author,
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
                        .Single();
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
        public IEnumerable<BookListItem> GetBookByGenre(string genre)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Books
                    .Where(e => e.Genre == genre)
                    .Select(e =>
                       new BookListItem
                       {
                           Id = e.Id,
                           Name = e.Name,
                           Author = e.Author,
                           
                       }
                        );
                return entity.ToArray();
                    
            }
        }
        public bool UpdateBook(BookEdit model)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Books
                    .Single(e => e.Id == model.Id);
                entity.Name = model.Name;
                entity.Author = model.Author;
                entity.Genre = model.Genre;
                entity.PublishedDate = model.PublishedDate;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBook(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Books
                    .Single(e => e.Id == bookId);
                ctx.Books.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
