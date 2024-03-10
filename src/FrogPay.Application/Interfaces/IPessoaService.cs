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

        Task<PessoaResponse?> CreateAsync(PessoaRequest pessoaDTO, CancellationToken cancellationToken);

        Task<PessoaResponse?> UpdateAsync(Guid clinicaId, PessoaRequest pessoaDTO, CancellationToken cancellationToken);
        Task<PessoaResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
