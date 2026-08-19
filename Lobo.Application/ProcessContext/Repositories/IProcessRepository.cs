using Lobo.Domain.ProcessContext;

namespace Lobo.Application.ProcessContext.Repositories;

public interface IProcessRepository
{
    public Task<Process?> GetProcessByIdAsync(int id);
    public Task<Process?> GetProcessByCustomerIdAsync(int customerId);
    public Task CreateProcessAsync(Process process);
    public Task<Process?> UpdateProcessAsync(Process process);
    public Task<bool> DeleteProcessAsync(int id);
}