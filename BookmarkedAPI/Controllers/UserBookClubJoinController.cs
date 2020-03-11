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
    public class UserBookClubJoinController : ApiController
    {
        //GET METHOD
        //public IHttpActionResult Get()
        //{
        //    UserBookClubJoinService userBookClubJoinService = CreateUserBookClubJoinService();
        //    var bookClubJoin = userBookClubJoinService.GetUserBookClub();
        //    return Ok(bookClubJoin);
        //}
        public IHttpActionResult GetDetails()
        {
            UserBookClubJoinService userBookClubJoinService = CreateUserBookClubJoinService();
            var userBookClubJoin = userBookClubJoinService.GetUserBookClubDetails();
            return Ok(userBookClubJoin);
        }
        public IHttpActionResult GetAllDetails(int id)
        {
            UserBookClubJoinService userBookClubJoinService = CreateUserBookClubJoinService();
            var userBookClubJoin = userBookClubJoinService.GetAllUserBookClubDetails(id);
            return Ok(userBookClubJoin);
        }
        public IHttpActionResult GetAllBookClubsOfUser(string userName)
        {
            UserBookClubJoinService userBookClubService = CreateUserBookClubJoinService();
            var userBookClubJoin = userBookClubService.GetAllBookClubsOfUser(userName);
            return Ok(userBookClubJoin);
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
        public IHttpActionResult Put(UserBookClubJoinEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserBookClubJoinService();

            if (!service.UpdateUserBookClubJoin(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int joinId)
        {
            var service = CreateUserBookClubJoinService();
            if (!service.DeleteUserBookClubJoin(joinId))
                return InternalServerError();

            return Ok();
        }
        private UserBookClubJoinService CreateUserBookClubJoinService()
        {
            var Id = Guid.Parse(User.Identity.GetUserId());
            var noteService = new UserBookClubJoinService(Id);
            return noteService;
        }
    }
}

