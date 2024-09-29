using BooksReview.BL.Interfaces;
using BooksReview.Common.Enums;
using BooksReview.Common;
using BooksReview.Common.Models;
using BooksReview.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;
using BooksReview.BL.Services;

namespace BooksReview.API.Controllers
{
    [AuthenPermission]
    public class BookController : BaseController<Book>
    {
        private IBookService _bookService;
        public BookController(IBookService bookService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(bookService, httpContextAccessor, userTokenService)
        {
            _bookService = bookService;
        }
        /// <summary>
        /// Sửa 
        /// </summary>
        /// <param name="id">ID muốn sửa</param>
        /// <param name="entity">Thông tin  muốn sửa</param>
        /// <returns>Thông tin đã sửa</returns>
        [HttpPost]
        [Route("get-book-detail")]
        public IActionResult GetBookDetail([FromBody] GetDetailParam detailParam)
        {
            try
            {
                // Gọi hàm xử lý
                var result = _bookService.GetBookDetail(detailParam.id, detailParam.user_id);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }
        [HttpPost]
        [Route("SearchBook")]
        public virtual IActionResult SearchBook([FromBody] PagingModel paramFilter)
        {
            try
            {
                // Xử lý
                var result = _bookService.SearchBook(paramFilter);

                // Trả về thông tin của employee muốn lấy
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }
        /// <summary>
        /// Sửa 
        /// </summary>
        /// <param name="id">ID muốn sửa</param>
        /// <param name="entity">Thông tin  muốn sửa</param>
        /// <returns>Thông tin đã sửa</returns>
        [HttpPut]
        [Route("update-status-read")]
        public IActionResult UpdateStatusRead([FromBody] Book entity)
        {
            try
            {
                // Gọi hàm xử lý
                var result = _bookService.UpdateStatusRead(entity);

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

        [HttpPost]
        [Route("AdminBook")]
        public virtual IActionResult AdminBook([FromBody] AdminReviewParam param)
        {
            try
            {
                // Xử lý
                var result = _bookService.AdminBook(param);

                // Trả về thông tin của employee muốn lấy
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }

        [HttpPut]
        [Route("update-status")]
        public IActionResult UpdateStatus([FromBody] Book entity)
        {
            try
            {
                // Gọi hàm xử lý
                var result = _bookService.UpdateStatus(entity);

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
        /// <summary>
        /// Lấy thông tin có bộ lọc
        /// </summary>
        /// <param name="paramFilter">Bộ lọc</param>
        /// <returns>Thông tin đối tượng</returns>
        [HttpPost]
        [Route("updateListType")]
        public virtual IActionResult UpdateListType([FromBody] PagingModel paramFilter)
        {
            try
            {
                // Xử lý
                var result = _baseService.GetByFilter(paramFilter);

                // Trả về thông tin của employee muốn lấy
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }

        /// <summary>
        /// Lấy thông tin có bộ lọc
        /// </summary>
        /// <param name="paramFilter">Bộ lọc</param>
        /// <returns>Thông tin đối tượng</returns>
        [HttpPost]
        [Route("userReviewStartBook")]
        public virtual IActionResult UserReviewStartBook([FromBody] ReviewBookUser reviewBookUser)
        {
            try
            {
                // Xử lý
                var result = _bookService.UserReviewStartBook(reviewBookUser);

                // Trả về thông tin của employee muốn lấy
                return StatusCode(StatusCodes.Status200OK, result);
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
