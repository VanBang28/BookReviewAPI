using BooksReview.API.Hepers;
using BooksReview.BL.Interfaces;
using BooksReview.BL.Services;
using BooksReview.Common.Enums;
using BooksReview.Common.Models.DTO;
using BooksReview.Common;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;
using BooksReview.Common.Models;
using BooksReview.API.Helpers;

namespace BooksReview.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthenPermission]
    public class FileController : Authentication
    {
        #region Field
        protected IFileService _fileService;
        #endregion

        #region Contructor
        public FileController(IFileService fileService,IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) :base(httpContextAccessor, userTokenService)
        {
            _fileService = fileService;
        }
        #endregion

        /// <summary>
        /// Thêm 
        /// </summary>
        /// <param name="entity">Thông tin muốn thêm</param>
        /// <returns>Id mới</returns>
        [HttpPost]
        public IActionResult Insert([FromForm] FileModel fileModel)
        {
            try
            {
                // Gọi hàm xử lý
                ServiceResult result = _fileService.Insert(fileModel);

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
