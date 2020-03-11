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
    public class UserBookClubJoinCreate
    {
        //[Required]
        //public ApplicationUser Reader { get; set; }
        //public BookClub BookClub { get; set; }

        public string UserName { get; set; }
        public string BookClubName { get; set; }
    }
}
