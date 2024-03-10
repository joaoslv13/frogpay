using FrogPay.Domain.Entities;

namespace FrogPay.Domain.Interfaces
{
    public interface ILojaRepository : IBaseRepository<Loja>
    {
        Task<bool> HasExist(string cnpj);
    }
}
