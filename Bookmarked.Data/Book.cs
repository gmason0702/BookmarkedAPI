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
    public class Book
    {
        [Key]

        public int Id { get; set; }
        public Guid OwnerId { get; set; }//Should this be a Guid? I think Id is stored as a string in ApplicaitonUser 
        //- so maybe this can be string too - it would need to be changed lots of places (Nick)
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public DateTimeOffset PublishedDate { get; set; }
        public virtual ICollection<UserBookJoin> UserBookJoins { get; set; }
        public virtual ICollection<BookClubBookJoin> BookClubBookJoins { get; set; }//Added this 3/10 (Nick)
    }
}
