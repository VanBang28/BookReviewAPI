using BooksReview.BL.Interfaces;
using BooksReview.Common.Enums;
using BooksReview.Common.Models;
using BooksReview.Common.Models.DTO;
using BooksReview.Common.Resources;
using BooksReview.DL.Interfaces;
using BooksReview.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.BL.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        public IBookDL _bookDL;
        public IBookListDL _bookListDL;
        public IBookListItemDL _bookListItemDL;
        public IBaseDL<ReviewBookUser> _reviewBookUserDL;
        public BookService(IBookDL bookDL, IBookListDL bookListDL, IBookListItemDL bookListItemDL, IBaseDL<ReviewBookUser> reviewBookUserDL) : base(bookDL)
        {
            _bookDL = bookDL;
            _bookListDL = bookListDL;
            _bookListItemDL = bookListItemDL;
            _reviewBookUserDL = reviewBookUserDL;
        }
        public virtual object SearchBook(object parameters)
        {
            return _bookDL.SearchBook(parameters);
        }
        public object GetBooks(dynamic parameters)
        {

            return _bookDL.GetBooks(parameters);
        }

        public ServiceResult UpdateStatusRead(Book book)
        {
            dynamic result = null;
            var bookList = _bookListDL.GetBookListByListType(book.list_type,book.user_id);
            if(bookList == null)
            {
                bookList = new BookList()
                {
                    book_list_id = Guid.NewGuid(),
                    list_type = book.list_type,
                    user_id = book.user_id,
                    modified_at = DateTime.Now,
                    created_at = DateTime.Now,
                };
                _bookListDL.Insert(bookList);
            }
            if(book.book_list_item_id == Guid.Empty)
            {
                var bookListItem = new BookListItem()
                {
                    book_list_item_id = Guid.NewGuid(),
                    book_id= book.book_id,
                    book_list_id = bookList.book_list_id,
                    modified_at = DateTime.Now,
                    created_at = DateTime.Now,
                };
                var res = _bookListItemDL.Insert(bookListItem);
                if (res)
                {
                    result = bookListItem.book_list_id;
                }
            }
            else
            {
                var res = _bookListItemDL.UpdateBookListItemType(book.book_list_item_id, bookList.book_list_id);
               if(res > 0)
                {
                    result = book.book_list_item_id;
                }
            }
            if (result != null)
                result = new ServiceResult(result);
            else result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);

            return result;
        }

        public ServiceResult UserReviewStartBook(ReviewBookUser reviewBookUser)
        {
            dynamic result = null;
            var rvBookUser = _bookDL.GetReviewBookUser(reviewBookUser.book_id, reviewBookUser.user_id);
            if (rvBookUser == null)
            {
                rvBookUser = new ReviewBookUser()
                {
                    book_id = reviewBookUser.book_id,
                    user_id = reviewBookUser.user_id,
                    rating = reviewBookUser.rating,
                    modified_at = DateTime.Now,
                    created_at = DateTime.Now,
                };
                _reviewBookUserDL.Insert(rvBookUser);
            }
            else
            {
                result = _bookDL.UpdateUserReviewStartBook(reviewBookUser);
            }

            // Update lại trung bình đánh giá sách
            _bookDL.UpdateAVGStartBook(reviewBookUser.book_id);
            if (result != null)
                result = new ServiceResult(result);
            else result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);

            return result;
        }

        public override void ValidateCustom(Book entity, bool isInsert = true)
        {
            if (isInsert)
            {
                var user = _bookDL.getByISBN(entity.isbn);
                if (user != null)
                {
                    listErrorValidate.Add("isbn", "isbn đã tồn tại");
                }
            }
        }

        public object GetBookDetail(Guid id, Guid user_id)
        {
            return _bookDL.GetBookDetail(id, user_id);
        }

        public ServiceResult UpdateStatus(Book book)
        {
            dynamic result;
            var res = _bookDL.UpdateStatus(book.book_id, book.status);
            if (res > 0)
                result = new ServiceResult(res > 0);
            else result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);

            return result;
        }
        public object AdminBook(AdminReviewParam param)
        {
            return _bookDL.AdminBook(param);
        }
    }
}
