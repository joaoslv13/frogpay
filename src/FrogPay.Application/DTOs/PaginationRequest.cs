using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.DTOs
{
    public record PaginationRequest(int PageNumber = 1, int PageSize = 10);
}
