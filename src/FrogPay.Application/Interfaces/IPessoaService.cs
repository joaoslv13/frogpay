using FrogPay.Application.DTOs;
using FrogPay.Application.DTOs.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.Interfaces
{
    public interface IPessoaService
    {
        Task<PaginationResponse<PessoaResponse>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
