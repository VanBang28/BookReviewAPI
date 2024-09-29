using BooksReview.BL.Interfaces;
using BooksReview.Common.Enums;
using BooksReview.Common;
using BooksReview.Common.Models;
using BooksReview.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace BooksReview.API.Controllers
{
    [AuthenPermission]
    public class UserController : BaseController<User>
    {
        private IUserService _userService;
        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(userService, httpContextAccessor, userTokenService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Thêm 
        /// </summary>
        /// <param name="entity">Thông tin muốn thêm</param>
        /// <returns>Id mới</returns>
        [HttpPost]
        public override IActionResult Insert([FromBody] User user)
        {
            try
            {
                // Gọi hàm xử lý
                ServiceResult result = _userService.Insert(user);

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

    }
}
