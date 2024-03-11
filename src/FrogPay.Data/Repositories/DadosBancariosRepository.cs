using FrogPay.Data.Context;
using FrogPay.Domain.Entities;
using FrogPay.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Data.Repositories
{
    public class DadosBancariosRepository : BaseRepository<DadosBancarios>, IDadosBancariosRepository
    {
        public DadosBancariosRepository(AppDbContext context) : base(context)
        { }

        public async Task<List<DadosBancarios>> GetByIdPessoa(Guid IdPessoa, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var skip = (pageNumber - 1) * pageSize;

            return await Context.DadosBancarios
                .Where(w => w.PessoaId == IdPessoa)
                 .OrderBy(o => o.CreatedDate)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
