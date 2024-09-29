using BooksReview.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.DL.Interfaces
{
    public interface IBookListDL : IBaseDL<BookList>
    {

        public BookList GetBookListByListType(int listType, Guid userId);
    }
}
