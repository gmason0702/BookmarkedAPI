using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class UserBookJoinEdit
    {
        public int JoinId { get; set; }
        public string UserName { get; set; }
        public string BookName { get; set; }
        public int Rating { get; set; }
    }
}
