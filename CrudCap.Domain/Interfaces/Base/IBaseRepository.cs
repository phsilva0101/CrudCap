namespace CrudCap.Domain.Interfaces.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        Task AddAsync(TEntity obj, CancellationToken cancellationToken);
        void Dispose();
    }
}
