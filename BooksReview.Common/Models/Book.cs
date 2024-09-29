using BooksReview.Common.Models.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class Book : BaseModel
    {
        [Key]
        public Guid book_id { get; set; }
        public string book_name { get; set; }
        public string author_name { get; set; }
        public Guid author_id { get; set; }
        public string genre { get; set; }
        public string isbn { get; set; }
        public string book_review { get; set; }
        public string description { get; set; }
        public DateTime? publication_date { get; set; }
        public decimal avg_rate { get; set; }
        [NotMapped]
        public string cover_image { get; set; }
        public Guid user_id { get; set; }
        [NotMapped]
        public int list_type { get; set; }
        [NotMapped]
        public Guid book_list_item_id { get; set; }
        [NotMapped]
        public decimal user_rating { get; set; }
        [NotMapped]
        public string user_image { get; set; }
        [NotMapped]
        public int status { get; set; }
            [NotMapped]
        public string fullname { get; set; }
    }
}
