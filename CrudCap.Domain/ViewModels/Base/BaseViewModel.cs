namespace CrudCap.Domain.ViewModels.Base
{
    public class BaseViewModel
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public string? OrderBy { get; set; }
        public bool Asc { get; set; } = true;

        public int Skip => (PageNumber - 1) * PageSize;
    }
}
