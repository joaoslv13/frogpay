using FrogPay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Enable(T entity);
        void Disable(T entity);
        Task<T?> Get(Guid id, CancellationToken cancellationToken);
        Task<List<T>> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
