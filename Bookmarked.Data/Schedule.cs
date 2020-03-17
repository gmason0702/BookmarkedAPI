﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Data
{
    public class Schedule
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public string ScheduleName { get; set; }
        public string ScheduleItemTitle { get; set; }
        public int ScheduleItemId { get; set; }
        [ForeignKey("ScheduleItemId")]
        public virtual BookScheduleItem ScheduleItem { get; set; }
        public string BookName { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        public string BookClubName { get; set; }
        public int BookClubId { get; set; }
        [ForeignKey("BookClubId")]
        public virtual BookClub BookClub { get; set; }
    }
}
