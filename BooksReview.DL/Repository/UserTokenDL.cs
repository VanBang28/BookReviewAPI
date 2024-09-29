using Dapper;
using BooksReview.Common;
using BooksReview.Common.Constants;
using BooksReview.Common.Models;
using BooksReview.DL.Database;
using BooksReview.DL.Interfaces;
using System.Data;
using System.Reflection;

namespace BooksReview.DL.Repository
{
    public class UserTokenDL : BaseDL<UserToken>, IUserTokenDL
    {
        public UserTokenDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        public bool DeleleToken(string token)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.DeleteByToken, "UserToken");

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_Token", token);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Execute(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);

                // Đóng kết nối
                _databaseConnection.Close();

                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public UserToken GetUserByToken(string token)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByToken, "UserToken");

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_Token", token);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                UserToken result = _databaseConnection.QueryFirstOrDefault<UserToken>(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);

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
