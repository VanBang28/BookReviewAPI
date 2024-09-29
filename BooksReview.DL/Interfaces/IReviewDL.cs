using BooksReview.Common.Models;
using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.DL.Interfaces
{
    public interface IReviewDL : IBaseDL<Review>
    {
        public object GetReviewPost(PagingModel paramFilter);
        public object AdminReview(AdminReviewParam param);
        public int UpdateStatus(Guid review_id, int status);
    }
}
