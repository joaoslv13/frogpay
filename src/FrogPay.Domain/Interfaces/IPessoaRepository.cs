using FrogPay.Domain.Entities;

namespace FrogPay.Domain.Interfaces
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        Task<bool> HasExist(string cpf);
    }
}
