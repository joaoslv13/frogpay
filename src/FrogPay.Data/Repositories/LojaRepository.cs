using FrogPay.Data.Context;
using FrogPay.Domain.Entities;
using FrogPay.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.Data.Repositories
{
    public class LojaRepository : BaseRepository<Loja>, ILojaRepository
    {
        public LojaRepository(AppDbContext context) : base(context)
        { }
        public async Task<bool> HasExist(string cnpj)
        {
            return await Context.Lojas.Where(w => w.Cnpj == cnpj).AnyAsync();
        }
    }
}
