using Dapper;
using BooksReview.Common.Constants;
using BooksReview.Common;
using BooksReview.Common.Models;
using BooksReview.DL.Database;
using BooksReview.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace BooksReview.DL.Repository
{
    public class UserDL : BaseDL<User>, IUserDL
    {
        public UserDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        public User getByEmail(string email)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByEmail, "User");

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_Email", email);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryFirstOrDefault<User>(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);

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

        public User getByEmailAndPassword(string email, string password)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByEmailAndPassword, "user");

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_email", email);
                parametes.Add($"p_password", password);
                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryFirstOrDefault<User>(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);
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
    }
}
