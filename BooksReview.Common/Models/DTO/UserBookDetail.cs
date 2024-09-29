using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models.DTO
{
    public class UserBookDetail
    {
        public Guid book_id { get; set; }
        public Guid user_id { get; set; }
        public string fullname { get; set; }
        public bool is_follow { get; set; }
        public Guid? follow_id { get; set; }
        public int total_book { get; set; }
        public int total_follow { get; set; }
        public int total_rating { get; set; }
        public int total_rating_1 { get; set; }
        public int total_rating_2 { get; set; }
        public int total_rating_3 { get; set; }
        public int total_rating_4 { get; set; }
        public int total_rating_5 { get; set; }
    }
}
