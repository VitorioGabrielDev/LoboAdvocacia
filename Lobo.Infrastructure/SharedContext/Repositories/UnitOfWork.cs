using Lobo.Application.SharedContext.Repositories;
using Lobo.Domain.SharedContext.Entities;
using Lobo.Infrastructure.SharedContext.DataAccess;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lobo.Infrastructure.SharedContext.Repositories;

public class UnitOfWork(
    AppDbContext dbContext
) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    
    public Task RollbackAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CommitAsync()
    {
        try
        {
            await dbContext.SaveChangesAsync();
            
            if (_transaction is not null)
                await _transaction.CommitAsync();

            _transaction?.Dispose();
            _transaction = null;
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
    }

    public Task BeginTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public Task FlushAsync()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}