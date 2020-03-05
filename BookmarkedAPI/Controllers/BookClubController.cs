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
        public IHttpActionResult Post(BookClubCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookClubService();

            if (!service.CreateBookClub(note))
                return InternalServerError();

            return Ok();
        }
        private BookClubService CreateBookClubService()
        {
            var userId = Convert.ToInt32(User.Identity.GetUserId());
            var noteService = new BookClubService(userId);
            return noteService;
        }
    }
}
