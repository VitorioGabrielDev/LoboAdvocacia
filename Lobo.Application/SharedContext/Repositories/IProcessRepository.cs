using Lobo.Domain.SharedContext.Entities;

namespace Lobo.Application.SharedContext.Repositories;

public interface IProcessRepository
{
    public Task<Process> GetProcessByCustoemrId(int customerId);
    public Task AddProcessAsync(Process process);
    public Task UpdateProcessAsync(Process process);
    public Task DeleteProcessAsync(Process process);
}