using BooksReview.Common.Enums;

namespace BooksReview.Common.Models.DTO
{
    /// <summary>
    /// Class pagging chung
    /// </summary>
    public class PagingModel
    {
        /// <summary>
        /// Số trang trên 1 page
        /// </summary>
        public int pageSize { get; set; } = 20;

        /// <summary>
        /// Vị trí page
        /// </summary>
        public int pageNumber { get; set; } = 1;

        /// <summary>
        /// Text tìm kiếm
        /// </summary>
        public string? textSearch { get; set; }

        public int listType { get; set; } = (int)ListType.None;
        public string? sortColumn { get; set; }
        public string? sortDirection { get; set; } = "ASC";
        public Guid? userId { get; set; }
        public EnumSearchType searchType { get; set; } = EnumSearchType.Book;

    }
    
}
