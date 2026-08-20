using Lobo.Application.SharedContext.Repositories;

namespace Lobo.Application.Tests.SharedContext.Repositories;

public class FakeUnitOfWork : IUnitOfWork
{
    public Task RollbackAsync()
        => Task.CompletedTask;

    public Task CommitAsync()
        => Task.CompletedTask;

    public Task BeginTransactionAsync()
        => Task.CompletedTask;

    public Task FlushAsync()
        => Task.CompletedTask;

    public void Dispose() {}
}