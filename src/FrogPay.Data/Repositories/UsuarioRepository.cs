using FrogPay.Data.Context;
using FrogPay.Domain.Entities;
using FrogPay.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        { }

        public async Task<Usuario?> GetByLoginAsync(string login, CancellationToken cancellationToken)
        {
            return await Context.Usuarios.Where(w => w.Login == login).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
