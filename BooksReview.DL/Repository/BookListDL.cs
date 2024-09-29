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
using System.Data.Common;

namespace BooksReview.DL.Repository
{
    public class BookListDL : BaseDL<BookList>, IBookListDL
    {
        protected IDatabaseConnection _databaseConnection;
        public BookListDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public BookList GetBookListByListType(int listType,Guid userId)
        {
            try
            {
                string query = $"select * from booklist where list_type = {listType} and user_id = '{userId}'";
                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryFirstOrDefault<BookList>(query, null);
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
    }
}
