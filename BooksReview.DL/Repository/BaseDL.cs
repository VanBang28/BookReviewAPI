using Dapper;
using BooksReview.Common;
using BooksReview.Common.Constants;
using BooksReview.Common.Models.DTO;
using BooksReview.DL.Database;
using BooksReview.DL.Interfaces;
using MySqlConnector;
using System.Data;
using System.Reflection;
using BooksReview.Commons;
using BooksReview.Common.Models;
using System.Text.RegularExpressions;

namespace BooksReview.DL.Repository
{
    public class BaseDL<Entity> : IBaseDL<Entity>
    {
        #region Field
        protected string tableName;
        protected IDatabaseConnection _databaseConnection;
        #endregion

        #region Contructor
        /// <summary>
        /// Khởi tạo kết nối DB
        /// </summary>
        public BaseDL(IDatabaseConnection databaseConnection)
        {
            tableName = typeof(Entity).Name;
            _databaseConnection = databaseConnection;
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parametersFilter">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        public virtual PagingResult<Entity> GetByFilter(dynamic parametersFilter)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByFilter, tableName);

                var parameters = new DynamicParameters();
                parameters.Add("@TotalRecords",dbType: DbType.Int32,direction: ParameterDirection.Output);
                foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
                }

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryMultiple(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);
                var data = new PagingResult<Entity>()
                {
                    Data = result.Read<Entity>().ToList(),
                    CustomData = result.Read<CustomData>().ToList(),
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
        public virtual PagingResult<Entity> SearchData(dynamic parametersFilter)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.SearchData, tableName);

                var parameters = new DynamicParameters();
                parameters.Add("@TotalRecords",dbType: DbType.Int32,direction: ParameterDirection.Output);
                foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
                }

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryMultiple(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);
                var data = new PagingResult<Entity>()
                {
                    Data = result.Read<Entity>().ToList(),
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
        /// <summary>
        /// Lấy thông tin theo mã
        /// </summary>
        /// <param name="EntityCode">Mã đối tượng</param>
        /// <returns>Trả về Id đối tượng</returns>
        public virtual Guid GetByCode(string EntityCode)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByCode, tableName);

                // Add param
                var parameters = new DynamicParameters();
                parameters.Add($"p_{tableName}Code", EntityCode);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                Guid result = _databaseConnection.QueryFirstOrDefault<Guid>(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);

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

        /// <summary>
        /// Lấy thông tin theo tên
        /// </summary>
        /// <param name="EntityName">Tên đối tượng</param>
        /// <returns>Trả về Id đối tượng</returns>
        public Guid GetByName(string EntityName)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByName, tableName);

                // Add param
                var parameters = new DynamicParameters();
                parameters.Add($"p_{tableName}Name", EntityName);

                // Mở kết nối
                _databaseConnection.Open();

                Guid result = _databaseConnection.QueryFirstOrDefault<Guid>(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);

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

        /// <summary>
        /// Lấy ra 1 nhân viên theo Id
        /// </summary>
        /// <param name="id">Id nhân viên</param>
        /// <returns>Thông tin 1 nhân viên</returns>
        public virtual Entity GetById(Guid id)
        {
            try
            {
                string query = $"select * from `{tableName}` where {ConvertPascalToLowerCase(tableName)}_id = '{id}'";
                // Mở kết nối
                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryFirstOrDefault<Entity>(query, null);

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

        /// <summary>
        /// Thêm 
        /// </summary>
        /// <param name="entity">Thông tin nhân viên cần thêm</param>
        /// <returns>true - false</returns>
        public virtual bool Insert(Entity entity, bool isByServiceOther = false)
        {
            try
            {
                // Mở kết nối
                var entitys = new List<Entity>() { entity };
                if (!isByServiceOther)
                {
                    _databaseConnection.Open();
                    // Xử lý thêm dữ liệu trong stored
                    _databaseConnection.Transaction();
                    _databaseConnection.BeginTransaction();
                }
                //int res = _databaseConnection.Execute(storedProducedureName, param: parameters, commandType: CommandType.StoredProcedure);
                int res = _databaseConnection.InsertRecords(entitys);

                if(res > 0)
                {
                    CustomAfterInsert(entity);
                }
                if (!isByServiceOther)
                {
                    _databaseConnection.CommitTransaction();
                    // Đóng kết nối
                    _databaseConnection.Close();
                }
                //Trả kết quả về
                return res == 0 ? false : true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public virtual void CustomAfterInsert(Entity entity) { }

        /// <summary>
        /// Hàm thêm propery cần thiết
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <param name="isInsert">Insert hoặc update</param>
        /// <param name="entityId">Id ban ghi insert</param>
        /// <returns>Đối tượng đầy đủ</returns>
        public virtual Entity AddProperties(dynamic entity, bool isInsert, Guid? entityId, out Guid newId)
        {

            entity.modified_at = DateTime.Now;
            if (isInsert)
            {
                entity.created_at = DateTime.Now;
                entity.GetType().GetProperty($"{(typeof(Entity).Name)}_id".ConvertPascalToLowerCase()).SetValue(entity, Guid.NewGuid(), null);
            }
            else entity.GetType().GetProperty($"{(typeof(Entity).Name)}_id".ConvertPascalToLowerCase()).SetValue(entity, entityId, null);

            newId = entity.GetType().GetProperty($"{(typeof(Entity).Name)}_id".ConvertPascalToLowerCase()).GetValue(entity, null);

            return entity;
        }

        /// <summary>
        /// Cập nhập
        /// </summary>
        /// <param name="entity">Thông tin nhân viên cần cập nhập</param>
        /// <returns>true - false</returns>
        public bool Update(Entity entity)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.Update, tableName);

                // Chuẩn bị parameters cho stored produce
                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(entity));
                }

                // Mở kết nối
                _databaseConnection.Open();

                int res = _databaseConnection.Execute(storedProducedureName, param: parameters, commandType: CommandType.StoredProcedure);

                // Đóng kết nối
                _databaseConnection.Close();

                //Trả kết quả về
                return res == 0 ? false : true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">Id đối tượng cần xóa</param>
        /// <returns>true - false</returns>
        public virtual bool DeleteRecords(List<Guid> listGuid)
        {
            try
            {
                bool result = true;

                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.DeleteRecords, typeof(Entity).Name);

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_{tableName}Ids", string.Join(",", listGuid));

                // Mở kết nối
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                // Xử lý xóa dữ liệu trong stored
                int numberDeleted = _databaseConnection.DeleteRecords(tableName, listGuid);

                if (numberDeleted == listGuid.Count) _databaseConnection.CommitTransaction();
                else
                {
                    _databaseConnection.RollbackTransaction();
                    result = false;
                }

                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }


        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">Id đối tượng cần xóa</param>
        /// <returns>true - false</returns>
        public virtual bool DeleteUpdateRecords(List<Guid> listGuid)
        {
            try
            {
                bool result = true;

                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.DeleteRecords, tableName);

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_{tableName}Ids", string.Join(",", listGuid));

                // Mở kết nối
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                // Xử lý xóa dữ liệu trong stored
                int numberDeleted = _databaseConnection.DeleteUpdateRecords(tableName, listGuid);

                if (numberDeleted == listGuid.Count) _databaseConnection.CommitTransaction();
                else
                {
                    _databaseConnection.RollbackTransaction();
                    result = false;
                }

                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
        public bool LockUpRecords(List<Guid> listGuid)
        {
            try
            {
                bool result = true;

                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();
                // Xử lý xóa dữ liệu trong stored
                int numberDeleted = _databaseConnection.LockUpRecords(tableName, listGuid);

                if (numberDeleted == listGuid.Count) _databaseConnection.CommitTransaction();
                else
                {
                    _databaseConnection.RollbackTransaction();
                    result = false;
                }
                // Đóng kết nối
                _databaseConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
        private string ConvertPascalToLowerCase(string input)
        {
            // Tách chuỗi dựa vào ký tự viết hoa và thay thế bằng _
            string separatedWords = Regex.Replace(input, "(\\B[A-Z])", "_$1");
            // Chuyển thành chữ thường
            return separatedWords.ToLower();
        }
        #endregion
    }
}
