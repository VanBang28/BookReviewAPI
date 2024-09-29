using BooksReview.Common.Models;
using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.BL.Interfaces
{
    public interface IReviewService : IBaseService<Review>
    {
        public object GetReviewPost(PagingModel paramFilter);
        public object AdminReview(AdminReviewParam param);
        public ServiceResult UpdateStatus(Review enity);
    }
}
