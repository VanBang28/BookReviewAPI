using BooksReview.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class UserToken
    {
        [Key]
        public Guid user_token_id { get; set; }

        public Guid user_id { get; set; }
        public EnumRole enum_role { get; set; }

        public string username { get; set; }

        [NotMapped]
        public bool is_remember_password { get; set; }

        public string token { get; set; }

        public DateTime expired_at { get; set; }

        public DateTime created_at { get; set; }
        [NotMapped]
        public DateTime time_update_expired_date_to_DB { get; set; }

        [NotMapped]
        public string language { get; set; } = "vn";

        public string ip_address { get; set; }

        [NotMapped]
        public string countries_code { get; set; }
    }
}
