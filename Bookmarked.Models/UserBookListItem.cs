﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class UserBookListItem
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ReaderId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
