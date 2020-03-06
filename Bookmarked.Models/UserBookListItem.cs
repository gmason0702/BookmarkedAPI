using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class UserBookListItem
    {
        public int Id { get; set; }
        public string ReaderId { get; set; }
        public int BookId { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }
    }
}
