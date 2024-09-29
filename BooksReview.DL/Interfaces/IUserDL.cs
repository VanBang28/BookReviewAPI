using BooksReview.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.DL.Interfaces
{
    public interface IUserDL : IBaseDL<User>
    {
        public User getByEmail(string email);

        public User getByEmailAndPassword(string email,string password);
    }
}
