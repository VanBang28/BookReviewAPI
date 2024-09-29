using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class Review : BaseModel
    {
        [Key]
        public Guid review_id { get; set; }
        public Guid book_id { get; set; }
        public Guid user_id { get; set; }
        [NotMapped]
        public int rating { get; set; } = 0;
        public string review_text { get; set; }
        public int likes_count { get; set; } = 0;
        public int dislikes_count { get; set; } = 0;
        [NotMapped]
        public int status { get; set; }

    }
}
