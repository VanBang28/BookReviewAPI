using BooksReview.Common.Enums;
using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class BookList : BaseModel
    {
        [Key]
        public Guid book_list_id { get; set; }
        public Guid user_id { get; set; }
        public int list_type { get; set; }
    }
}
