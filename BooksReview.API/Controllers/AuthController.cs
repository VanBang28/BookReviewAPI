﻿using BooksReview.API.Hepers;
using BooksReview.BL.Interfaces;
using BooksReview.BL.Services;
using BooksReview.Common;
using BooksReview.Common.Enums;
using BooksReview.Common.Models.DTO;
using BooksReview.DL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksReview.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class AuthController : MControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserTokenDL _userTokenDL;
        public AuthController(IHttpContextAccessor httpContextAccessor, IAuthService authService, IUserTokenDL userTokenDL)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
            _userTokenDL = userTokenDL;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] LoginRequest loginRequest)
        {

            try
            {
                // Xử lý
                var result = _authService.AuthenticateUser(loginRequest);

                if (result.ErrorCode is null) return StatusCode(StatusCodes.Status200OK, result);
                else if (result.ErrorCode == EnumErrorCode.NOT_CONTENT) return StatusCode(StatusCodes.Status204NoContent, result);
                else if (result.ErrorCode == EnumErrorCode.BADREQUEST) return StatusCode(StatusCodes.Status400BadRequest, result);

                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }

        [HttpDelete]
        [Route("signout/{token}")]
        public IActionResult SignOut([FromRoute] string token)
        {

            bool response = _userTokenDL.DeleleToken(token);

            return StatusCode(StatusCodes.Status200OK);
        }

    }
}
