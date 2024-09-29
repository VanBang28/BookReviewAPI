using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class Post : BaseModel
    {
        [Key]
        public Guid post_id { get; set; }
        public Guid user_id { get; set; }
        public string content { get; set; }
        public string image_url { get; set; }

    }
}
