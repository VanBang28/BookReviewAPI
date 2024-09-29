using Dapper;
using BooksReview.Common;
using BooksReview.Common.Models;
using BooksReview.Commons;
using BooksReview.DL.Helpers;
using MySqlConnector;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using static Dapper.SqlMapper;
using System.ComponentModel.DataAnnotations;

namespace BooksReview.DL.Database
{

    /// <summary>
    /// Xử lý kết nối db
    /// </summary>
    public class DatabaseConnection : IDatabaseConnection
    {
        #region Field
        private MySqlConnection? _connection;
        protected MySqlTransaction? _transaction;
        #endregion

        #region Method
        /// <summary>
        /// Khởi tạo kết nối
        /// </summary>
        /// <returns>MySqlConnection</returns>
        public void Open()
        {
            _connection = new MySqlConnection(DatabaseContext.connectionString);
            _connection.Open();
        }

        /// <summary>
        /// Đóng state kết nối
        /// </summary>
        public void Close()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        /// <summary>
        /// transaction khởi tạo
        /// </summary>
        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        public MySqlTransaction? Transaction()
        {
            return _transaction;
        }

        /// <summary>
        /// transaction thực thi
        /// </summary>
        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public MySqlConnection? Connection()
        {
            return _connection;
        }

        /// <summary>
        /// transaction rollback
        /// </summary>
        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }
        /// <summary>
        /// Execute parameterized SQL.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        public GridReader QueryMultiple(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {

            var response = _connection.QueryMultiple(sql, param, transaction, commandTimeout, commandType);

            return response;
        }


        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <remarks>Note: the row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
        public T QueryFirstOrDefault<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            T response = _connection.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);

            return response;
        }

        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <remarks>Note: the row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
        public object QueryFirstOrDefault(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var response = _connection.QueryFirstOrDefault(sql, param, transaction, commandTimeout, commandType);

            return response; throw new NotImplementedException();
        }

        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        public int Execute(string sql, object? param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var response = _connection.Execute(sql, param, transaction, commandTimeout, commandType);

            return response;
        }

        /// <summary>
        /// Xóa nhiều bản ghi theo id
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="listId">List id</param>
        /// <returns>Số lượng bản ghi được xóa</returns>
        public int DeleteRecords(string tableName, List<Guid> listId)
        {
            string query = $"delete from `{tableName}` where {tableName.ToLower()}_id in (@Id)";

            int numberRecoredDeleted = _connection.Execute(query, listId.AsEnumerable().Select(i => new { Id = i }).ToList(), _transaction);

            return numberRecoredDeleted;
        }

        /// <summary>
        /// Xóa nhiều theo update
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="listId">List id</param>
        /// <returns>Số lượng bản ghi được xóa</returns>
        public int DeleteUpdateRecords(string tableName, List<Guid> listId)
        {
            string query = $"Update {tableName} set IsDelete = 1 where {tableName}Id in (@Id)";

            int numberRecoredDeleted = _connection.Execute(query, listId.AsEnumerable().Select(i => new { Id = i }).ToList(), _transaction);

            return numberRecoredDeleted;
        }

        /// <summary>
        /// Khoa
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="listId">List id</param>
        /// <returns>Số lượng bản ghi được xóa</returns>
        public int LockUpRecords(string tableName, List<Guid> listId)
        {
            string query = $"Update {tableName} set IsActive = !IsActive where {tableName}Id in (@Id)";

            int numberRecoredDeleted = _connection.Execute(query, listId.AsEnumerable().Select(i => new { Id = i }).ToList(), _transaction);

            return numberRecoredDeleted;
        }

        /// <summary>
        /// Import
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="dataTable">Dữ liệu bảng</param>
        /// <returns>Số lượng bản ghi được thêm</returns>
        //public int InsertRecords<T>(List<T> records, string queryCustom = "")
        //{
        //    try
        //    {
        //        int numberRecoredImportSuccess;
        //        List<string> queryListItem = new List<string>();
        //        var listPropery = new List<string>();

        //        // Lấy các property trong class
        //        foreach (var property in typeof(T).GetProperties())
        //        {
        //            // Loại bỏ các attribute không có trang bảng
        //            var attributes = property.GetCustomAttribute(typeof(NotMappedAttribute), false);
        //            if (attributes is null)
        //            {
        //                // Add properties
        //                listPropery.Add(property.Name);
        //            }
        //        }

        //        string query = $"INSERT INTO {typeof(T).Name.ToLower()} ({string.Join(", ", listPropery)}) VALUES";

        //        // Tạo các value query
        //        foreach (var entity in records)
        //        {
        //            List<string> listColumnRow = new List<string>();
        //            foreach (PropertyInfo property in entity.GetType().GetProperties())
        //            {
        //                var attributes = property.GetCustomAttribute(typeof(NotMappedAttribute), false);
        //                if (attributes is null)
        //                {
        //                    var value = property.GetValue(entity);

        //                    if (value != null && value.GetType().IsEnum)
        //                    {
        //                        listColumnRow.Add("'" + Convert.ToInt32(value) + "'");
        //                        continue;
        //                    }
        //                    else if (property.PropertyType == typeof(DateTime?) || property.PropertyType == typeof(DateTime))
        //                    {
        //                        if (value != null && !value.ObjToStr().Equals(""))
        //                        {
        //                            DateTime dateTime = DateTime.Parse(value.ObjToStr());
        //                            listColumnRow.Add("'" + dateTime.ToString("yyyy/MM/dd H:m:s") + "'");
        //                        }
        //                        else listColumnRow.Add("null");
        //                        continue;
        //                    }
        //                    else if (property.PropertyType == typeof(long?) || property.PropertyType == typeof(long))
        //                    {
        //                        if (value is null) listColumnRow.Add("null");
        //                        continue;
        //                    }

        //                    listColumnRow.Add("'" + property.GetValue(entity) + "'");
        //                }

        //            }
        //            string queryItem = "(" + String.Join(", ", listColumnRow) + ")";
        //            queryListItem.Add(queryItem);
        //        }

        //        query += String.Join(",", queryListItem);

        //        if (!queryCustom.Equals(""))
        //        {
        //            query += "; ";
        //            query += queryCustom;
        //        }

        //        // Mở kết nối
        //        //Open();
        //        //BeginTransaction();

        //        numberRecoredImportSuccess = _connection.Execute(query, null, _transaction);
        //        if (numberRecoredImportSuccess < 1) RollbackTransaction();
        //        //CommitTransaction();

        //        // Đóng kết nối
        //        //Close();

        //        return numberRecoredImportSuccess;
        //    }
        //    catch (Exception ex)
        //    {
        //        RollbackTransaction();
        //        Close();
        //        throw new MExceptionResponse(ex.Message);
        //    }
        //}

        public int InsertRecords<T>(List<T> records, string queryCustom = "")
        {
            try
            {
                int numberRecoredImportSuccess = 0;
                var listPropery = new List<string>();
                var propertyInfoList = typeof(T).GetProperties()
                    .Where(p => p.GetCustomAttribute(typeof(NotMappedAttribute), false) == null)
                    .ToList();

                // Lấy các property trong class
                foreach (var property in propertyInfoList)
                {
                    listPropery.Add(property.Name);
                }

                string query = $"INSERT INTO `{typeof(T).Name.ToLower()}` ({string.Join(", ", listPropery)}) VALUES";

                // Tạo các value query
                var queryListItem = new List<string>();
                var parameters = new DynamicParameters();

                int recordCount = 0;
                foreach (var entity in records)
                {
                    List<string> listColumnRow = new List<string>();
                    foreach (var property in propertyInfoList)
                    {
                        var value = property.GetValue(entity);

                        if (value != null && value.GetType().IsEnum)
                        {
                            listColumnRow.Add($"@Value{recordCount}_{property.Name}");
                            parameters.Add($"@Value{recordCount}_{property.Name}", Convert.ToInt32(value));
                        }
                        else if (property.PropertyType == typeof(DateTime?) || property.PropertyType == typeof(DateTime))
                        {
                            if (value != null && !value.ObjToStr().Equals(""))
                            {
                                DateTime dateTime = DateTime.Parse(value.ObjToStr());
                                listColumnRow.Add($"@Value{recordCount}_{property.Name}");
                                parameters.Add($"@Value{recordCount}_{property.Name}", dateTime.ToString("yyyy/MM/dd H:m:s"));
                            }
                            else
                            {
                                listColumnRow.Add("null");
                            }
                        }
                        else if (property.PropertyType == typeof(long?) || property.PropertyType == typeof(long))
                        {
                            if (value is null)
                            {
                                listColumnRow.Add("null");
                            }
                            else
                            {
                                listColumnRow.Add($"@Value{recordCount}_{property.Name}");
                                parameters.Add($"@Value{recordCount}_{property.Name}", value);
                            }
                        }
                        else
                        {
                            listColumnRow.Add($"@Value{recordCount}_{property.Name}");
                            parameters.Add($"@Value{recordCount}_{property.Name}", value?.ToString());
                        }
                    }

                    string queryItem = "(" + String.Join(", ", listColumnRow) + ")";
                    queryListItem.Add(queryItem);
                    recordCount++;
                }

                query += String.Join(",", queryListItem);

                if (!string.IsNullOrEmpty(queryCustom))
                {
                    query += "; ";
                    query += queryCustom;
                }

                // Mở kết nối
                // Open();
                // BeginTransaction();

                numberRecoredImportSuccess = _connection.Execute(query, parameters, _transaction);
                if (numberRecoredImportSuccess < 1)
                {
                    RollbackTransaction();
                }
                // CommitTransaction();

                // Đóng kết nối
                // Close();

                return numberRecoredImportSuccess;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public int UpdateEntity<T>(T entity)
        {
            try
            {
                // Lấy tên bảng dựa vào tên class
                string tableName = typeof(T).Name;

                // Lấy danh sách các thuộc tính không có [Key] và không có [NotMapped]
                var properties = typeof(T).GetProperties()
                    .Where(p => !Attribute.IsDefined(p, typeof(KeyAttribute)) && !Attribute.IsDefined(p, typeof(NotMappedAttribute))); // Bỏ qua thuộc tính có [Key] hoặc [NotMapped]

                // Tạo câu lệnh SQL UPDATE
                string updateQuery = $"UPDATE {tableName} SET ";

                // Lấy tên các thuộc tính và tạo cặp "PropertyName = @PropertyName"
                updateQuery += string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

                // Điều kiện WHERE dựa vào thuộc tính có [Key] (ví dụ Id)
                var keyProperty = typeof(T).GetProperties()
                    .FirstOrDefault(p => Attribute.IsDefined(p, typeof(KeyAttribute)));

                if (keyProperty == null)
                {
                    throw new Exception("No property with [Key] attribute found.");
                }

                updateQuery += $" WHERE {keyProperty.Name} = @{keyProperty.Name}";

                // Thực thi lệnh UPDATE với Dapper
                int rowsAffected = _connection.Execute(updateQuery, entity, _transaction);

                return rowsAffected;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
        #endregion
    }
}
