using BooksReview.API.Common;
using BooksReview.API.Hepers;
using BooksReview.BL.Interfaces;
using BooksReview.BL.Services;
using BooksReview.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksReview.API.Helpers
{
    public class Authentication : MControllerBase
    {
        public UserToken userToken = null;
        public bool IsOke = false;
        private readonly IUserTokenService _userTokenService;

        public Authentication(IHttpContextAccessor httpContextAccessor,IUserTokenService userTokenService)
        {
            _userTokenService = userTokenService;

            // List api không cần token

            var request = httpContextAccessor.HttpContext.Request;
            
            if (!request.Path.Equals("/api/v1/User/"))
            {
                string token = CacheUserToken.GetTokenFromRequest(request);
                userToken = _userTokenService.GetUserByToken(token);
                return;
            }
            IsOke = true;
        }
    }
}
