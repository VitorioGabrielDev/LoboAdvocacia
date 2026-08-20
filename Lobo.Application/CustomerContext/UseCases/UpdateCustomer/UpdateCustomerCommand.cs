using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.CustomerContext.UseCases.UpdateCustomer;

public class UpdateCustomerCommand : Request<UpdateCustomerResponse>
{
    public int Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string FullName { get; private set; } = string.Empty;
    public string NationalId { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string ContactPhone { get; private set; } = string.Empty;
    public string Neighborhood { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    
    public override bool Validate()
    {
        return IsValid;
    }
}