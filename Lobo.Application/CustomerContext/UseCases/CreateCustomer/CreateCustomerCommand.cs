using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.CustomerContext.UseCases.CreateCustomer;

public class CreateCustomerCommand : Request<CreateCustomerResponse>
{
    public string FirstName { get; protected set; } = string.Empty;
    public string FullName { get; protected set; } = string.Empty;
    public string NationalId { get; protected set; } = string.Empty;
    public string Email { get; protected set; } = string.Empty;
    public string ContactPhone { get; protected set; } = string.Empty;
    public string Neighborhood { get; protected set; } = string.Empty;
    public string City { get; protected set; } = string.Empty;
    public string State { get; protected set; } = string.Empty;
    
    public override bool Validate()
    {
        return IsValid;
    }
}