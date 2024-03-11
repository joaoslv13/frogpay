using FrogPay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Domain.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        Task<List<Endereco>> GetByIdPessoa(Guid IdPessoa, int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<List<Endereco>> GetByNomePessoa(string nomePessoa, int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
