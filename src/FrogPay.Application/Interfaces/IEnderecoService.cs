using FrogPay.Application.DTOs.Endereco;
using FrogPay.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<PaginationResponse<EnderecoResponse>> GetByIdPessoaAsync(Guid idPessoa, int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<PaginationResponse<EnderecoResponse>> GetByNomePessoaAsync(string nomePessoa, int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<PaginationResponse<EnderecoResponse>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

        Task<EnderecoResponse?> CreateAsync(EnderecoRequest enderecoDTO, CancellationToken cancellationToken);

        Task<EnderecoResponse?> UpdateAsync(Guid enderecoId, EnderecoRequest enderecoDTO, CancellationToken cancellationToken);
        Task<EnderecoResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
