using BooksReview.Common.Enums;
using BooksReview.Common;
using BooksReview.Common.Models;
using BooksReview.DL.Database;
using BooksReview.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.DL.Repository
{
    public class BookListItemDL : BaseDL<BookListItem>, IBookListItemDL
    {
        protected IDatabaseConnection _databaseConnection;
        public BookListItemDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public int UpdateBookListItemType(Guid bookListItem, Guid bookList)
        {
            try
            {
                string query = $"update booklistitem set book_list_id = '{bookList}' where book_list_item_id = '{bookListItem}'";
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
    }
}
