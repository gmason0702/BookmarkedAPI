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
        public Guid OwnerId { get; set; }
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        public string BookName { get; set; }
        public int BookClubId { get; set; }

        [ForeignKey("BookClubId")]
        public virtual BookClub BookClub { get; set; }
        public string BookClubName { get; set; }

    }
}
