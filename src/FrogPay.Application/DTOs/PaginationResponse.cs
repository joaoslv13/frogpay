namespace FrogPay.Application.DTOs
{
    public class PaginationResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<T>? Items { get; set; }
    }
}
