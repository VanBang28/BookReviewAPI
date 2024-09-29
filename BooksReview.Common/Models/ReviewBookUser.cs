using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class ReviewBookUser : BaseModel
    {
        public Guid book_id { get; set; }
        public Guid user_id { get; set; }
        public int? rating { get; set; }
    }
}
