using Bookmarked.Data;
using BookmarkedAPI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class UserBookJoinCreate
    {
        [Required]
        public string UserName { get; set; }
        public string BookName { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
