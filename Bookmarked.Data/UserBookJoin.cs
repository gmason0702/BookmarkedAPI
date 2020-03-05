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
        [ForeignKey("ReaderId")]
        public int ReaderId { get; set; }
        //navigation property-return type is the class that the Foreign key is relating to         
        public Reader Reader { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
