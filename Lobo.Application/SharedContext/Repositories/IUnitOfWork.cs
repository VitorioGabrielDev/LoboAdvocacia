namespace Lobo.Application.SharedContext.Repositories;

public interface IUnitOfWork
{
    Task RollbackAsync();
    Task CommitAsync();
    Task BeginTransactionAsync();
    Task FlushAsync();
    void Dispose();
}