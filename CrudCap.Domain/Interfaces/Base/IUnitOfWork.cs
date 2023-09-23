namespace CrudCap.Domain.Interfaces.Base
{
    public interface IUnitOfWork
    {
        Task CommitarTransacaoAsync(CancellationToken cancellationToken = default);
    }
}
