using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class Like : BaseModel
    {
        public Guid like_id { get; set; }
        public Guid review_id { get; set; }
        public Guid user_id { get; set; }
        [NotMapped]
        public string fullname { get; set; }
    }
}
