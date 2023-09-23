namespace CrudCap.Domain.ViewModels.Base
{
    public class PaginationItemsResponse<T> where T : class
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public long Count { get; set; }
        public IEnumerable<T> Items { get; set; }

        public PaginationItemsResponse(int pageSize, int pageNumber, long count, IEnumerable<T> items)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            Count = count;
            Items = items;
        }

    }
}
