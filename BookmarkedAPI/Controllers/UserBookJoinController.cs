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
        //public IHttpActionResult Get()//commenting out for now because you can only have on get - probably don't need this
        //{
        //    UserBookJoinService userBookJoinService = CreateUserBookJoinService();
        //    var bookJoin = userBookJoinService.GetUserBooks();
        //    return Ok(bookJoin);
        //}
        public IHttpActionResult GetDetails()
        {
            UserBookJoinService userBookJoinService = CreateUserBookJoinService();
            var bookJoin = userBookJoinService.GetUserBookDetails();
            return Ok(bookJoin);
        }

        //public IHttpActionResult GetAll(int id)//commenting out for now because you can only have on get - probably don't need this
        //{
        //    UserBookJoinService userBookJoinService = CreateUserBookJoinService();
        //    var bookJoin = userBookJoinService.GetAllUserBooks(id);
        //    return Ok(bookJoin);
        //}

        public IHttpActionResult GetAllDetails(int id)
        {
            UserBookJoinService userBookJoinService = CreateUserBookJoinService();
            var bookJoin = userBookJoinService.GetAllUserBookDetails(id);
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
