using FrogPay.Data.Context;
using FrogPay.Domain.Entities;
using FrogPay.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;

        public BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.IsDeleted = false;
            Context.Add(entity);
        }

        public void Update(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Update(entity);
        }

        public void Enable(T entity)
        {
            entity.IsDeleted = false;
            Update(entity);
        }

        public void Disable(T entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<T>> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var skip = (pageNumber - 1) * pageSize;

            return await Context.Set<T>()
                .OrderBy(o => o.CreatedDate)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
