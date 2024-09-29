using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksReview.Common.Models.DTO
{
    public class CustomData
    {
        //WantToRead = 1,
        //Reading = 2,
        //Read = 3
        public int WantToRead { get; set; }
        public int Reading { get; set; }
        public int Read { get; set; }
        public int AllRead { get; set; }
    }
}
