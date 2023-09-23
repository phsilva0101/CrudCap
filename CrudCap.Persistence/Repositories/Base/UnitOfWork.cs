using CrudCap.Domain.Interfaces.Base;

namespace CrudCap.Persistence.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrudCapContext _context;

        public UnitOfWork(CrudCapContext context)
        {
            _context = context;
        }

        public async Task CommitarTransacaoAsync(CancellationToken cancellationToken = default)
        {
            if (_context.ChangeTracker.HasChanges())
                await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
