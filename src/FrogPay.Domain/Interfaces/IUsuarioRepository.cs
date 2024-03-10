using FrogPay.Domain.Entities;

namespace FrogPay.Domain.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario?> GetByLoginAsync(string login, CancellationToken cancellationToken);
    }
}
