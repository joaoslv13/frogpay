using FrogPay.Data.Context;
using FrogPay.Domain.Entities;
using FrogPay.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.Data.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(AppDbContext context) : base(context)
        { }

        public async Task<bool> HasExist(string cpf)
        {
            return await Context.Pessoas.Where(w => w.Cpf == cpf).AnyAsync();
        }
    }
}
