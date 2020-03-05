using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Data
{
    public class BookClub
    {
        [Key]
        public int BookClubId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public virtual ICollection<UserBookClubJoin> ReaderList { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
