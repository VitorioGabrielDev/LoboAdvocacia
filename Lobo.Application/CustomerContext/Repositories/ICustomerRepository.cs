using Lobo.Domain.CustomerContext;

namespace Lobo.Application.CustomerContext.Repositories;

public interface ICustomerRepository
{
    public Task<Customer?> GetCustomerByIdAsync(int id);
    public Task CreateCustomerAsync(Customer customer);
    public Task<Customer?> UpdateCustomerAsync(Customer customer);
    public Task<bool> DeleteCustomerAsync(int id);
}