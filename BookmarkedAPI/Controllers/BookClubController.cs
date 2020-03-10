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
            BookClubService bookClubService = CreateBookClubService();
            var note = bookClubService.GetBookClubById(id);
            return Ok(note);
        }
        public IHttpActionResult Get(string name)
        {
            BookClubService bookClubService = CreateBookClubService();
            var bookClubName = bookClubService.GetBookClubByName(name);
            return Ok(bookClubName);
        }
       // [Authorize(Roles = "User")]
        public IHttpActionResult Post(BookClubCreate bookClub)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookClubService();

            if (!service.CreateBookClub(bookClub))
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
