using BooksReview.Common.Models;
using BooksReview.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace BooksReview.DL.Interfaces
{
    public interface IBookDL : IBaseDL<Book>
    {

        public object GetBookDetail(Guid id, Guid user_id);
        public PagingResult<Book> SearchBook(dynamic parameters);
        public Book getByISBN(string isbn);
        public object GetBooks(dynamic parameters);

        public ReviewBookUser GetReviewBookUser(Guid bookId, Guid userId);

        public bool UpdateUserReviewStartBook(ReviewBookUser reviewBookUser);

        public void UpdateAVGStartBook(Guid bookId);

        public int UpdateStatus(Guid book_id, int status);
        public object AdminBook(AdminReviewParam param);
    }
}
