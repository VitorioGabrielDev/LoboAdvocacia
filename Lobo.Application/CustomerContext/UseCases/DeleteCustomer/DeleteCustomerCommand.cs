using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.CustomerContext.UseCases.DeleteCustomer;

public class DeleteCustomerCommand : Request<DeleteCustomerResponse>
{
    public int Id { get; private set; }
    
    public override bool Validate()
    {
        return IsValid;
    }
}