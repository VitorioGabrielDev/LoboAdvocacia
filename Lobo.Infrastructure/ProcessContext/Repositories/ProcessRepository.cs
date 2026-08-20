using Lobo.Application.ProcessContext.Repositories;
using Lobo.Domain.ProcessContext;
using Lobo.Infrastructure.SharedContext.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Lobo.Infrastructure.ProcessContext.Repositories;

public class ProcessRepository(
    AppDbContext dbContext
) : IProcessRepository
{
    public async Task<Process?> GetProcessByIdAsync(int id) =>
        await dbContext.Processes.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Process>> GetProcessesByCustomerIdAsync(int customerId) =>
        await dbContext.Processes.Where(x => x.CustomerId == customerId).ToListAsync();

    public async Task CreateProcessAsync(Process process) =>
        await dbContext.Processes.AddAsync(process);

    public async Task<Process?> UpdateProcessAsync(Process process)
    {
        Process? trackedEntity = await GetProcessByIdAsync(process.Id);
        if (trackedEntity == null) return trackedEntity;
        
        dbContext.Entry(trackedEntity).CurrentValues.SetValues(process);
        return trackedEntity;
    }

    public async Task<bool> DeleteProcessAsync(int id)
    {
        Process? trackedEntity = await GetProcessByIdAsync(id);
        if (trackedEntity is null) return false;
        
        dbContext.Processes.Remove(trackedEntity);
        return true;
    }
}