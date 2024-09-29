using BooksReview.Common.Models;
using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace BooksReview.BL.Interfaces
{
    public interface IBookService : IBaseService<Book>
    {
        public object GetBookDetail(Guid id, Guid user_id);
        public object SearchBook(dynamic parameters);
        public ServiceResult UpdateStatusRead(Book enity);
        public object GetBooks(dynamic parameters);

        public ServiceResult UserReviewStartBook(ReviewBookUser reviewBookUser);


        public ServiceResult UpdateStatus(Book enity);
        public object AdminBook(AdminReviewParam param);
    }
}
