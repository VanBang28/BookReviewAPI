using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models.DTO
{
    public class RegisterRequest
    {
        public Guid UserId { get; set; }
        [DisplayName("Họ tên")]
        public string FullName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
