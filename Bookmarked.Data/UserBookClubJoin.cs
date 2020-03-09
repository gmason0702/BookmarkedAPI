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
        
        public string ReaderId { get; set; }
        [ForeignKey("ReaderId")]
        //navigation property-return type is the class that the Foreign key is relating to         
        public virtual ApplicationUser Reader { get; set; }
        public int BookClubId { get; set; }
        [ForeignKey("BookClubId")]
        public virtual BookClub Club { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
