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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace BooksReview.BL.Services
{
    public class ReviewService : BaseService<Review>, IReviewService
    {
        private readonly IReviewDL _reviewDL;
        public ReviewService(IReviewDL reviewDL) : base(reviewDL)
        {
            _reviewDL = reviewDL;
        }

        public object AdminReview(AdminReviewParam param)
        {
            return _reviewDL.AdminReview(param);
        }

        public object GetReviewPost(PagingModel paramFilter)
        {
            return _reviewDL.GetReviewPost(paramFilter);
        }

        public ServiceResult UpdateStatus(Review review)
        {
            dynamic result;
            var res = _reviewDL.UpdateStatus(review.review_id, review.status);
            if (res > 0)
                result = new ServiceResult(res > 0);
            else result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);

            return result;
        }
    }
}
