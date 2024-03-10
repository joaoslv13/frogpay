using FrogPay.Application.DTOs;
using FrogPay.Application.DTOs.Loja;

namespace FrogPay.Application.Interfaces
{
    public interface ILojaService
    {
        Task<PaginationResponse<LojaResponse>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

        Task<LojaResponse?> CreateAsync(LojaRequest pessoaDTO, CancellationToken cancellationToken);

        Task<LojaResponse?> UpdateAsync(Guid lojaId, LojaRequest pessoaDTO, CancellationToken cancellationToken);
        Task<LojaResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
