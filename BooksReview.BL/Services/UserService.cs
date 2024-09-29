using BooksReview.API.Common;
using BooksReview.BL.Interfaces;
using BooksReview.Common.Commons;
using BooksReview.Common.Enums;
using BooksReview.Common.Models;
using BooksReview.Common.Models.DTO;
using BooksReview.Common.Resources;
using BooksReview.DL.Interfaces;
using BooksReview.DL.Repository;
//using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace BooksReview.BL.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private IUserDL _userDL;
        private IUserTokenDL _UserTokenDL;
        public UserService(IUserDL userDL, IUserTokenDL userTokenDL) : base(userDL)
        {
            _userDL = userDL;
            _UserTokenDL = userTokenDL;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="enity">Đối tượng</param>
        /// <returns>Danh sách nhân viên</returns>
        public override ServiceResult Insert(User user)
        {
            dynamic result;
            var isValid = this.IsValidate(user);

            // Kiểm tra validate
            if (isValid)
            {
                user = AddProperties(user, true, null, out Guid id);

                bool response = _userDL.Insert(user);
                if (!response)
                    result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);

                UserToken userToken = CacheUserToken.CreateToken(user);

                response = _UserTokenDL.Insert(userToken);

                if (!response)
                    result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);

                user.password = "";

                result = new ServiceResult(new
                {
                    Token = userToken.token,
                    User = user
                });
            }
            else
            {
                // trả về lỗi validate
                result = new ServiceResult(EnumErrorCode.BADREQUEST, ResourceVI.ErrorValidate, ResourceVI.ErrorValidate, listErrorValidate);
            }

            return result;
        }

        public override void ValidateCustom(User entity, bool isInsert = true)
        {
            if (isInsert)
            {
                var user = _userDL.getByEmail(entity.email);
                if (user != null)
                {
                    listErrorValidate.Add("Email", "Email đã tồn tại");
                }
            }
        }

        public override User processPropertyCustom(User user, bool isInsert)
        {
            if(isInsert)
            {
                // mã hóa mật khẩu
                user.password = BooksReview.Commons.Commons.MD5Hash(user.password);
            }
            return user;
        }
    }
}
