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
                            Genre = e.Genre
                        }
                    );
                return query.ToArray();
            }
        }
        public IEnumerable<BookListItem> GetAllBooks(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Books
                    .Where(e => e.Id > id)
                    .Select(
                        e =>
                        new BookListItem
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Author = e.Author,
                            Genre = e.Genre
                        }
                    );
                return query.ToArray();
            }
        }
        public BookDetail GetBookByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
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
                           Genre = e.Genre,
                       }
                        );
                return entity.ToArray();

            }
        }
        public IEnumerable<BookListItem> GetBookByAuthor(string author)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Books
                    .Where(e => e.Author == author)
                    .Select(e =>
                        new BookListItem
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Author = e.Author,
                            Genre = e.Genre,
                        }
                        );
                return entity.ToArray();
            }
        }
        public bool EditBook(BookEdit modelEdit)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Books
                    .Single(e => e.Id == modelEdit.Id);
                entity.Name = modelEdit.Name;
                entity.Author = modelEdit.Author;
                entity.Genre = modelEdit.Genre;
                entity.PublishedDate = modelEdit.PublishedDate;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdateBook(BookUpdate modelUpdate)
        {

            if (modelUpdate.PropertyValue == "Name")
            {
                var book = GetBookByName(modelUpdate.BookName);

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Books
                        .Single(e => e.Id == book.Id);
                    entity.Name = modelUpdate.NewValue;
                    //entity.Author = book.Author;
                    //entity.Genre = book.Genre;
                    //entity.PublishedDate = book.PublishedDate;

                    return ctx.SaveChanges() == 1;
                }
            }
            else if (modelUpdate.PropertyValue == "Author")
            {
                var book = GetBookByName(modelUpdate.BookName);
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Books
                        .Single(e => e.Id == book.Id);
                    entity.Author = modelUpdate.NewValue;

                    return ctx.SaveChanges() == 1;
                }
            }
            else if (modelUpdate.PropertyValue=="Genre")
            {
                var book = GetBookByName(modelUpdate.BookName);
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Books
                        .Single(e => e.Id == book.Id);
                    entity.Genre = modelUpdate.NewValue;

                    return ctx.SaveChanges() == 1;

                }
            }
            return false;

        }

        public bool UpdateBookGenre(string oldGenre, string newGenre)
        {
            var book = GetBookByName(oldGenre);

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Books
                    .Single(e => e.Id == book.Id);
                entity.Name = newGenre;
                //entity.Author = book.Author;
                //entity.Genre = book.Genre;
                //entity.PublishedDate = book.PublishedDate;

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
