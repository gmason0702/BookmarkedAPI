using BookmarkedAPI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Data
{
    public class BookClub
    {
        [Key]

        public int BookClubId { get; set; }
        public Guid OwnerId { get; set; }//Should this be a Guid? I think Id is stored as a string in ApplicaitonUser 
        //- so maybe this can be string too - it would need to be changed lots of places (Nick)
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int BookId { get; set; }
        public virtual ICollection<UserBookClubJoin> ReaderList { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}

