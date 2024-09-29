using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models.DTO
{
    public class PagingModelBase
    {
        /// <summary>
        /// Số trang trên 1 page
        /// </summary>
        public int pageSize { get; set; } = 20;

        /// <summary>
        /// Vị trí page
        /// </summary>
        public int pageNumber { get; set; } = 1;

        /// <summary>
        /// Text tìm kiếm
        /// </summary>
        public string? textSearch { get; set; }
    }
}
