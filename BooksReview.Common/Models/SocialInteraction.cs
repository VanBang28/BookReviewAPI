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
    public class SocialInteraction : BaseModel
    {
        [Key]
        public Guid social_interaction_id { get; set; }
        public Guid user_id { get; set; }
        public InteractionType interaction_type { get; set; }
        public Guid post_id { get; set; }

    }
}
