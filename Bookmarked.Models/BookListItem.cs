using Bookmarked.Data;
using BookmarkedAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarked.Models
{
    public class BookListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public ICollection<UserBookJoin> UserBookJoins { get; set; }//just for now

        public double? AvgRating
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    double sum = 0;
                    double count = 0;
                    foreach (UserBookJoin join in ctx.UserBookJoins)
                    {
                        if (join.BookId == Id)
                        {
                            sum += join.Rating;
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        return null;
                    }
                    double average = sum / count;
                    return average;
                }
            }
        }
    }
}
