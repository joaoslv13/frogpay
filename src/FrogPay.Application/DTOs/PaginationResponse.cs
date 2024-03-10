namespace FrogPay.Application.DTOs
{
    public record PaginationResponse<T>(
       int PageNumber,
       int PageSize,
       List<T>? Items
   );
}
