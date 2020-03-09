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
    public class UserBookJoinController : ApiController
    {
        //GET METHOD
        public IHttpActionResult Get()
        {
            UserBookJoinService userBookJoinService = CreateUserBookJoinService();
            var bookJoin = userBookJoinService.GetUserBook();
            return Ok(bookJoin);
        }
        public IHttpActionResult Post(UserBookJoinCreate bookjoin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserBookJoinService();

            if (!service.CreateUserBookJoin(bookjoin))
                return InternalServerError();

            return Ok();
        }
        private UserBookJoinService CreateUserBookJoinService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userBookService = new UserBookJoinService(userId);
            return userBookService;
        }
    }
}
