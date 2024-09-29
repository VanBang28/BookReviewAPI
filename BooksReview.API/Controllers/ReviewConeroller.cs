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
    public class ReviewController : BaseController<Review>
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(reviewService, httpContextAccessor, userTokenService)
        {
            _reviewService = reviewService;
        }

        
        [HttpPost]
        [Route("GetReviewPost")]
        public virtual IActionResult GetReviewPost([FromBody] PagingModel paramFilter)
        {
            try
            {
                // Xử lý
                var result = _reviewService.GetReviewPost(paramFilter);

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
        [Route("update-status")]
        public IActionResult UpdateStatus([FromBody] Review entity)
        {
            try
            {
                // Gọi hàm xử lý
                var result = _reviewService.UpdateStatus(entity);

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
        [Route("AdminReview")]
        public virtual IActionResult AdminReview([FromBody] AdminReviewParam param)
        {
            try
            {
                // Xử lý
                var result = _reviewService.AdminReview(param);

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
