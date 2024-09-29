using BooksReview.BL.Interfaces;
using BooksReview.Common.Models;
using BooksReview.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.BL.Services
{
    public class UserTokenService : IUserTokenService
    {
        private IUserTokenDL _userTokenDL;
        public UserTokenService(IUserTokenDL userTokenDL)
        {
            _userTokenDL = userTokenDL;
        }

        public UserToken GetUserByToken(string token)
        {
            return _userTokenDL.GetUserByToken(token);
        }
    }
}
