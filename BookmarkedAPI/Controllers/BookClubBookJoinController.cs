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
    public class BookClubBookJoinController : ApiController
    {
        public IHttpActionResult Get()
        {
            BookClubBookJoinService bookClubBookJoinService = CreateBookClubBookJoinService();
            var bookClubBookJoin = bookClubBookJoinService.GetBookClubBook();
            return Ok(bookClubBookJoin);
        }

        public IHttpActionResult Post(BookClubBookJoinCreate bookClubBookJoin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookClubBookJoinService();

            if (!service.CreateBookClubBookJoin(bookClubBookJoin))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(BookClubBookJoinEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookClubBookJoinService();

            if (!service.UpdateBookClubBookJoin(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int Id)
        {
            var service = CreateBookClubBookJoinService();
            if (!service.DeleteBookClubBookJoin(Id))
                return InternalServerError();

            return Ok();
        }
        private BookClubBookJoinService CreateBookClubBookJoinService()
        {
            var Id = Guid.Parse(User.Identity.GetUserId());
            var bookClubBookService = new BookClubBookJoinService(Id);
            return bookClubBookService;
        }
    }
}
