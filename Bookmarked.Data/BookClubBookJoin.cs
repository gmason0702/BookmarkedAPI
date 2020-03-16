using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Data
{
    public class BookClubBookJoin
    {
        [Key]
        public int Id { get; set; }
        public Guid OwnerId { get; set; }//Should this be a Guid? I think Id is stored as a string in ApplicaitonUser 
        //- so maybe this can be string too - it would need to be changed lots of places (Nick)
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        public string BookName { get; set; }//I don't think this is necessary because BookName exists in the Book Object (Nick)
        public int BookClubId { get; set; }

        [ForeignKey("BookClubId")]
        public virtual BookClub BookClub { get; set; }
        public string BookClubName { get; set; }//I don't think this is necessary because BookClubName exists in the BookClub Object (Nick)
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
