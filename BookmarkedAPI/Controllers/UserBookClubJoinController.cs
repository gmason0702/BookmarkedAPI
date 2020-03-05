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
    public class UserBookClubJoinController : ApiController
    {
        //GET METHOD
        public IHttpActionResult Get()
        {
            UserBookClubJoinService userBookClubJoinService = CreateUserBookClubJoinService();
            var bookClubJoin = userBookClubJoinService.GetUserBookClub();
            return Ok(bookClubJoin);
        }
        public IHttpActionResult Post(UserBookClubJoinCreate bookClubjoin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserBookClubJoinService();

            if (!service.CreateUserBookClubJoin(bookClubjoin))
                return InternalServerError();

            return Ok();
        }
        private UserBookClubJoinService CreateUserBookClubJoinService()
        {
            var Id = int.Parse(User.Identity.GetUserId());
            var noteService = new UserBookClubJoinService(Id);
            return noteService;
        }
    }
}

