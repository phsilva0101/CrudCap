using CrudCap.Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace CrudCap.Persistence.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly CrudCapContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(CrudCapContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _dbSet.Remove(obj);
        }

        public async Task AddAsync(TEntity obj, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(obj, cancellationToken);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
