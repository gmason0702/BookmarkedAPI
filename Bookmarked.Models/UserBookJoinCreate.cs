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
        public ApplicationUser Reader { get; set; }
        public Book Book { get; set; }


    }
}
