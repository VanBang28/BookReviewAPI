using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class Friendship : BaseModel
    {
        public Guid user_id { get; set; }
        public Guid friend_id { get; set; }

    }
}
