using FrogPay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Domain.Interfaces
{
    public interface IDadosBancariosRepository : IBaseRepository<DadosBancarios>
    {
        Task<List<DadosBancarios>> GetByIdPessoa(Guid IdPessoa, int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
