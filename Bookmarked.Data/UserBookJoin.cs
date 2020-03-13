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
    public class UserBookJoin
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }//I don't think this is necessary because the Username exists in the ApplicationUser object (Nick)
        public Guid OwnerId { get; set; }//Should this be a Guid? I think Id is stored as a string in ApplicaitonUser 
        //- so maybe this can be string too - it would need to be changed lots of places (Nick)
        public string ReaderId { get; set; }
        public string BookName { get; set; }//I don't think this is necessary because the BookName exists in the Book object (Nick)
        [ForeignKey("ReaderId")]
        //navigation property-return type is the class that the Foreign key is relating to         
        public virtual ApplicationUser Reader { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public int Rating { get; set; }
    }
}





