using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models.DTO
{
    public class GetDetailParam
    {
        public Guid id { get; set; }
        public Guid user_id { get; set; }
    }
}
