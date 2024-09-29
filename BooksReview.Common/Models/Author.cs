using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class Author : BaseModel
    {
        public Guid author_id { get; set; }  // ID tác giả (khóa chính)
        public string fullname { get; set; }  // Tên tác giả
        public string description { get; set; }  // Tiểu sử (tùy chọn)
        public DateTime? date_of_birth { get; set; }  // Ngày sinh (có thể để trống)
        public string nationality { get; set; }  // Quốc tịch
    }
}
