using Bookmarked.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class BookClubCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserBookClubJoin> MyProperty { get; set; }
    }
}
