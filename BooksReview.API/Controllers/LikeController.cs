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
    public class LikeController : BaseController<Like>
    {
        public LikeController(IBaseService<Like> likeService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(likeService, httpContextAccessor, userTokenService)
        {
        }
    }
}
