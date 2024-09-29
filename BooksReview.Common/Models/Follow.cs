using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class Follow : BaseModel
    {
        public Guid follow_id { get; set; }
        public Guid follower_id { get; set; }
        public Guid followed_id { get; set; }
    }
}
