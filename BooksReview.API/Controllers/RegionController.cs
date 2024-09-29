using BooksReview.Common.Models.DTO;
using BooksReview.Common;
using Microsoft.AspNetCore.Mvc;
using BooksReview.DL.Interfaces;
using BooksReview.BL.Interfaces;
using BooksReview.API.Hepers;
using BooksReview.API.Helpers;

namespace BooksReview.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthenPermission]
    public class RegionController : Authentication
    {
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(httpContextAccessor, userTokenService)
        {
            _regionService = regionService;
        }
        /// <summary>
        /// Lấy thông tin có bộ lọc
        /// </summary>
        /// <param name="paramFilter">Bộ lọc</param>
        /// <returns>Thông tin đối tượng</returns>
        [HttpPost]
        public virtual IActionResult GetByFilter(RegionRequest regionRequest)
        {
            try
            {
                // Xử lý
                var result = _regionService.getByParentId(regionRequest.parentId);

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
