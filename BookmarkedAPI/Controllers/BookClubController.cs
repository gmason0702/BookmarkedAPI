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
    public class BookClubController : ApiController
    {
        public IHttpActionResult Get()
        {
            BookClubService bookClubService = CreateBookClubService();
            var notes = bookClubService.GetBookClubs();
            return Ok(notes);
        }
        public IHttpActionResult Get(int id)
        {
            BookClubService noteService = CreateBookClubService();
            var note = noteService.GetBookClubById(id);
            return Ok(note);
        }
        public IHttpActionResult Post(BookClubCreate bookClub)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookClubService();

            if (!service.CreateBookClub(bookClub))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(BookClubEdit book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookClubService();

            if (!service.UpdateBookClub(book))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int bookClubId)
        {
            var service = CreateBookClubService();
            if (!service.DeleteBookClub(bookClubId))
                return InternalServerError();

            return Ok();
        }

        private BookClubService CreateBookClubService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bookClubService = new BookClubService(userId);
            return bookClubService;
        }
    }
}
