using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models.DTO
{
    public class AdminReviewParam : PagingModelBase
    {
        public int Status { get; set; }
        public string? sortDirection { get; set; } = "ASC";
    }
}
