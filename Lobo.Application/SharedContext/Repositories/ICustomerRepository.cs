using Lobo.Domain.SharedContext.Entities;

namespace Lobo.Application.SharedContext.Repositories;

public interface ICustomerRepository
{
    public Task<Customer> GetCustomer(string nationalId);
    public Task AddCustomerAsync(Customer customer);
    public Task UpdateCustomerAsync(Customer customer);
    public Task DeleteCustomerAsync(Customer customer);
}