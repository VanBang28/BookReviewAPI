using BooksReview.Common.Constants;
using BooksReview.Common;
using BooksReview.Common.Models;
using BooksReview.DL.Database;
using BooksReview.DL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksReview.Common.Enums;
using BooksReview.Common.Models.DTO;
using static Dapper.SqlMapper;
using System.Reflection;
using System.Net;

namespace BooksReview.DL.Repository
{
    public class BookDL : BaseDL<Book>,IBookDL
    {
        private readonly IBookListDL _bookListDL;
        private readonly IBookListItemDL _bookListItemDL;
        public BookDL(IDatabaseConnection databaseConnection, IBookListDL bookListDL, IBookListItemDL bookListItemDL) : base(databaseConnection)
        {
            _bookListDL = bookListDL;
            _bookListItemDL = bookListItemDL;
        }

        public virtual PagingResult<Book> SearchBook(dynamic parametersFilter)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.SearchBook, tableName);

                var parameters = new DynamicParameters();
                parameters.Add("@TotalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);
                foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
                }

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryMultiple(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);
                var data = new PagingResult<Book>()
                {
                    Data = result.Read<Book>().ToList(),
                    Total = parameters.Get<int>("@TotalRecords")
                };
                // Đóng kết nối
                _databaseConnection.Close();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
        public Book getByISBN(string email)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByISBN, "Book");

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_ISBN", email);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryFirstOrDefault<Book>(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);


                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }



        public ReviewBookUser GetReviewBookUser(Guid bookId, Guid userId)
        {
            try
            {
                string query = $"select * from reviewbookuser where book_id = '{bookId}' and user_id = '{userId}'";
                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryFirstOrDefault<ReviewBookUser>(query, null);
                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public bool UpdateUserReviewStartBook(ReviewBookUser reviewBookUser)
        {
            try
            {
                string query = $"update reviewbookuser set rating = {reviewBookUser.rating} where book_id = '{reviewBookUser.book_id}' and user_id = '{reviewBookUser.user_id}'";
                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Execute(query, null);
                // Đóng kết nối
                _databaseConnection.Close();

                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public override void CustomAfterInsert(Book book)
        {
            var bookList = new BookList()
            {
                book_list_id = Guid.NewGuid(),
                user_id = book.user_id,
                list_type = (int)ListType.Read,
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
            };
            _bookListDL.Insert(bookList,true);
            var bookListItem = new BookListItem()
            {
                book_list_item_id = Guid.NewGuid(),
                book_id = book.book_id,
                book_list_id = bookList.book_list_id,
                created_at = DateTime.Now,
                modified_at = DateTime.Now
            };
            _bookListItemDL.Insert(bookListItem,true);
        }

        public object GetBooks(dynamic parametersFilter)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByCode, tableName);

                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
                }

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryMultiple(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);
                
                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public void UpdateAVGStartBook(Guid bookId)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.UpdateAVGStartBook, tableName);
                var parametes = new DynamicParameters();
                parametes.Add($"p_{tableName}Id", bookId);
                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryMultiple(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);

                // Đóng kết nối
                _databaseConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public object GetBookDetail(Guid id, Guid user_id)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetBookDetail, tableName);
                var parametes = new DynamicParameters();
                parametes.Add($"p_{tableName}Id", id);
                parametes.Add($"p_UserId", user_id);
                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryMultiple(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);
                var data = new 
                {
                    Data = result.Read<Book>().FirstOrDefault(),
                    DataUserBookDetail = result.Read<UserBookDetail>().FirstOrDefault(),
                };
                // Đóng kết nối
                _databaseConnection.Close();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public int UpdateStatus(Guid book_id, int status)
        {
            try
            {
                string query = $"update book set status =  {status} where book_id = '{book_id}'";
                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Execute(query, null);
                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public object AdminBook(AdminReviewParam param)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.AdminBook, tableName);

                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in param.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(param));
                }
                parameters.Add("@TotalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryMultiple(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);
                var data = new PagingResult<Book>()
                {
                    Data = result.Read<Book>().ToList(),
                    Total = parameters.Get<int>("@TotalRecords")
                };
                // Đóng kết nối
                _databaseConnection.Close();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
    }
}
