using BooksReview.API.Common;
using BooksReview.BL.Interfaces;
using BooksReview.Common.Enums;
using BooksReview.Common.Models;
using BooksReview.Common.Models.DTO;
using BooksReview.Common.Resources;
using BooksReview.DL.Interfaces;
using BooksReview.DL.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace BooksReview.BL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserTokenDL _userTokenDL;
        private readonly IUserDL _userDL;
        public AuthService(IUserTokenDL userTokenDL, IUserDL userDL)
        {
            _userTokenDL = userTokenDL;
            _userDL = userDL;
        }
        public dynamic AuthenticateUser(LoginRequest loginRequest)
        {
            dynamic result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer); ;
            dynamic validationResults = null;
            var listErrorValidate = new Dictionary<string, string>();
            // Kiểm tra attribute hợp lệ của dữ liệu
            if (!Validator.TryValidateObject(loginRequest, new ValidationContext(loginRequest), validationResults, true))
            {
                foreach (var item in validationResults)
                {
                    listErrorValidate.Add(item.MemberNames.First(), item.ErrorMessage is null ? "" : item.ErrorMessage);
                }
            }

            var password = Commons.Commons.MD5Hash(loginRequest.Password);

            var user = _userDL.getByEmailAndPassword(loginRequest.Email, password);
            if (user == null)
            {
                listErrorValidate.Add("LoginError", "Tài khoản hoặc mật khẩu không chính xác.!");
                result = new ServiceResult(EnumErrorCode.BADREQUEST, ResourceVI.ErrorValidate, ResourceVI.ErrorValidate, listErrorValidate);
            }
            else
            {
                UserToken userToken = CacheUserToken.CreateToken(user);

                var response = _userTokenDL.Insert(userToken);
                if (!response)
                    result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);
                user.password = "";
                result = new ServiceResult(new
                {
                    Token = userToken.token,
                    User = user,
                });
            }

            return result;
        }
    }
}
