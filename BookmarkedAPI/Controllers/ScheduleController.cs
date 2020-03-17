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
    public class ScheduleController : ApiController
    {
        public IHttpActionResult Get(string scheduleName)
        {
            ScheduleService scheduleService = CreateScheduleService();
            var schedule = scheduleService.GetScheduleByName(scheduleName);
            return Ok(schedule);
        }
        public IHttpActionResult Post(ScheduleCreate schedule)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateScheduleService();

            if (!service.CreateSchedule(schedule))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(ScheduleEdit schedule)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateScheduleService();

            if (!service.UpdateScheduleByName(schedule))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateScheduleService();

            if (!service.DeleteScheduleByName(name))
                return InternalServerError();

            return Ok();
        }
        private ScheduleService CreateScheduleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bookScheduleItemService = new ScheduleService(userId);
            return bookScheduleItemService;
        }
    }
}