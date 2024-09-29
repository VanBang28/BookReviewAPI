using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class Vote : BaseModel
    {
        [Key]
        public Guid vote_id { get; set; }
        public Guid user_id { get; set; }
        public Guid post_id { get; set; }
        public Guid book_id { get; set; }
        public int star_number { get; set; }
        public string comment { get; set; }
    }
}
