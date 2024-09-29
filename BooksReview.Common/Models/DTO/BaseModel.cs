using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models.DTO
{
    public class BaseModel
    {
        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime created_at { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string created_by { get; set; }

        /// <summary>
        /// Người sửa gần nhất
        /// </summary>
        public string modified_by{ get; set; }

        /// <summary>
        /// Thời gian sửa gần nhất
        /// </summary>
        public DateTime modified_at { get; set; }
    }
}
