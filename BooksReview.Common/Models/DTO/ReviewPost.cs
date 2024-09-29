using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models.DTO
{
    public class ReviewPost : BaseModel
    {
        public Guid review_id { get; set; }
        public Guid book_id { get; set; }
        public Guid user_id { get; set; }
        public int rating { get; set; } = 0;
        public float avg_rate { get; set; } = 0;
        public string review_text { get; set; }
        public int likes_count { get; set; } = 0;
        public int dislikes_count { get; set; } = 0;
        public string book_name { get; set; }
        public string fullname { get; set; }
        public string author_name { get; set; }
        public Guid author_id { get; set; }
        public string genre { get; set; }
        public string isbn { get; set; }
        public string book_review { get; set; }
        public string description { get; set; }
        public DateTime? publication_date { get; set; }

        public string image_book { get;}
        public string image_user_post { get; } = "https://scontent-hkg1-1.xx.fbcdn.net/v/t1.30497-1/453178253_471506465671661_2781666950760530985_n.png?stp=dst-png_s100x100&_nc_cat=1&ccb=1-7&_nc_sid=136b72&_nc_eui2=AeGpZ9xP7vfQEtNZSmy-med5Wt9TLzuBU1Ba31MvO4FTUCaAK06xG209jvqjoHJFwnZj8grqxZ_SdcE6Q2mhK5Fw&_nc_ohc=PBlN3lEt5FwQ7kNvgFWbu1K&_nc_ht=scontent-hkg1-1.xx&_nc_gid=ARzhuy2jx52s2mqe-HbGdJ_&oh=00_AYAWbc_jVNmi2wD7fkjee5pZ_-w6S0Q2qAFV7c8DOXqq2Q&oe=670E65FA";
        public int list_type { get;}
        public Guid? book_list_item_id { get;}
        public string user_rating { get;}

        public string comments { get; set; }

        public string likes { get; set; }

        public int count_like { get; set; }
        public int count_comment { get; set; }
        public int status { get; set; }
    }
}
