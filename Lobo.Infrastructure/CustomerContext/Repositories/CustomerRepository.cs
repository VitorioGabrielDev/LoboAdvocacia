using Lobo.Application.CustomerContext.Repositories;
using Lobo.Domain.CustomerContext;
using Lobo.Infrastructure.SharedContext.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Lobo.Infrastructure.CustomerContext.Repositories;

public class CustomerRepository(
    AppDbContext dbContext
) : ICustomerRepository
{
    public async Task<Customer?> GetCustomerByIdAsync(int id) =>
        await dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

    public async Task CreateCustomerAsync(Customer customer) =>
        await dbContext.Customers.AddAsync(customer);

    public async Task<Customer?> UpdateCustomerAsync(Customer customer)
    {
        Customer? trackedEntity = await GetCustomerByIdAsync(customer.Id);
        if (trackedEntity is null) return trackedEntity;
        
        dbContext.Entry(trackedEntity).CurrentValues.SetValues(customer);
        return trackedEntity;
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        Customer? trackedEntity = await GetCustomerByIdAsync(id);
        if (trackedEntity is null) return false;
        
        dbContext.Customers.Remove(trackedEntity);
        return true;
    }
}