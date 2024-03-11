using FrogPay.Application.DTOs.DadosBancarios;
using FrogPay.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrogPay.Application.DTOs.Pessoa;

namespace FrogPay.Application.Interfaces
{
    public interface IDadosBancariosService
    {
        Task<PaginationResponse<DadosBancariosResponse>> GetByIdPessoaAsync(Guid idPessoa, int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<PaginationResponse<DadosBancariosResponse>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

        Task<DadosBancariosResponse?> CreateAsync(DadosBancariosRequest dadosbancariosDTO, CancellationToken cancellationToken);

        Task<DadosBancariosResponse?> UpdateAsync(Guid dadosbancariosId, DadosBancariosRequest dadosbancariosDTO, CancellationToken cancellationToken);
        Task<DadosBancariosResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
