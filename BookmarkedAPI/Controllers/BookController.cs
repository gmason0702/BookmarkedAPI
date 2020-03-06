using Bookmarked.Models;
using Bookmarked.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookmarkedAPI.Controllers
{
    [Authorize]
    public class BookController : ApiController
    {
        public IHttpActionResult Get()
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBooks();
            return Ok(books);
        }

        public IHttpActionResult GetByName(string name)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookByName(name);
            return Ok();
        }
        public IHttpActionResult GetByGenre(string genre)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookByGenre(genre);
            return Ok(book);
        }

        public IHttpActionResult Post(BookCreate book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookService();
            if (!service.CreateBook(book))
                return InternalServerError();

            return Ok();
        }



        private BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bookService = new BookService(userId);
            return bookService;
        }
    }
}
