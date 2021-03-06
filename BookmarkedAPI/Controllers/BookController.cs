﻿using Bookmarked.Models;
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
    //[Authorize]
    public class BookController : ApiController
    {
        
        public IHttpActionResult Get()
        {

            BookService bookService = CreateBookService();
            var books = bookService.GetBooks();
            return Ok(books);

        }

        public IHttpActionResult GetAll(int id)
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetAllBooks(id);
            return Ok(books);
        }


        public IHttpActionResult GetByName(string name)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookByName(name);
            return Ok(book);
        }
        public IHttpActionResult GetByGenre(string genre)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookByGenre(genre);
            return Ok(book);
        }
        public IHttpActionResult GetByAuthor(string author)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookByAuthor(author);
            return Ok(book);
        }

        public IHttpActionResult Post(BookCreate book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookService();
            if (!service.CreateBook(book))
                return InternalServerError();

            return Ok(book);
            //return CreatedAtRoute("DefaultApi", new { name = book.Name }, book);
            //var bookCreate = new BookCreate()
            //{
            //    Name = book.Name,
            //    Author = book.Author,
            //    Genre = book.Genre
            //};
            //return CreatedAtRoute("DefaultApi", new { name = book.Name }, bookCreate);

        }

        public IHttpActionResult Put(BookEdit modelEdit)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var service = CreateBookService();

            if (!service.EditBook(modelEdit))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult PutByValue(string propertyValue, string bookName, string newValue)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookService();

            if (!service.UpdateBook(propertyValue,bookName,newValue))
                return InternalServerError();

            return Ok();

        }

        [Authorize(Roles ="Admin")]
        public IHttpActionResult Delete(int bookId)
        {
            var service = CreateBookService();
            if (!service.DeleteBook(bookId))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult DeleteByName(string bookName)
        {
            var service = CreateBookService();
            if (!service.DeleteBookByName(bookName))
                return InternalServerError();

            return Ok();
        }

        private BookService CreateBookService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var bookService = new BookService(userId);
            //return bookService;

            //var bookService = new BookService(Guid.NewGuid());
            //return bookService;
            Guid userId = new Guid();
            if (!User.Identity.IsAuthenticated)
            {
                userId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            }
            else
            {
                userId = Guid.Parse(User.Identity.GetUserId());
            }
            var bookService = new BookService(userId);
            //var bookService = new BookService(Guid.NewGuid());
           
            return bookService;
        }
    }
}
