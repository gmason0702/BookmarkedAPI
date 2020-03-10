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
    public class UserBookClubJoin
    {
     [Key]   
        public int Id { get; set; }
        public Guid OwnerId { get; set; }//Should this be a Guid? I think Id is stored as a string in ApplicaitonUser 
        //- so maybe this can be string too - it would need to be changed lots of places (Nick)
        public string ReaderId { get; set; }
        [ForeignKey("ReaderId")]
        //navigation property-return type is the class that the Foreign key is relating to         
        public virtual ApplicationUser Reader { get; set; }
        public string UserName { get; set; }//I don't think this is needed because the UserName exists in the Reader Object (Nick)
        public string BookClubName { get; set; }//I don't think this is needed because the BookClubName exists in the BookClub Object (Nick)
        public int BookClubId { get; set; }
        [ForeignKey("BookClubId")]
        public virtual BookClub Club { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
