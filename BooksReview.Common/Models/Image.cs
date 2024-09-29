using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class Image : BaseModel
    {
        [Key]
        public Guid image_id { get; set; }
        public string image_name { get; set; }
        public string image_link { get; set; }
        public Guid object_id { get; set; }
        public int is_default { get; set; }
    }
}
