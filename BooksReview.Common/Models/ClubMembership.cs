using BooksReview.Common.Enums;
using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models
{
    public class ClubMembership : BaseModel
    {
        [Key]
        public Guid club_membership_id { get; set; }
        public Guid club_id { get; set; }
        public Guid user_id { get; set; }
        public ClubRole role { get; set; }
    }
}
