using Bookmarked.Models;
using Bookmarked.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BookmarkedAPI.Controllers
{
    public class BookScheduleItemController : ApiController
    {
        public IHttpActionResult Get(string title)
        {
            BookScheduleItemService bookScheduleItemService = CreateBookScheduleItemService();
            var scheduleItem = bookScheduleItemService.GetBookScheduleItemByTitle(title);
            return Ok(scheduleItem);
        }
        public IHttpActionResult Post(BookScheduleItemCreate bookScheduleItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateBookScheduleItemService();

            if (!service.CreateBookScheduleItem(bookScheduleItem))
                return InternalServerError();

            return Ok();
        }

        private BookScheduleItemService CreateBookScheduleItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bookScheduleItemService = new BookScheduleItemService(userId);
            return bookScheduleItemService;
        }
    }
}