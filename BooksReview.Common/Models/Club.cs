using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class Club : BaseModel
    {
        [Key]
        public Guid club_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Guid creator_id { get; set; }
    }
}
