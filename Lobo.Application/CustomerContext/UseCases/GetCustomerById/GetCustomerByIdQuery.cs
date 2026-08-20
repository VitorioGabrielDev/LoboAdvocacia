using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.CustomerContext.UseCases.GetCustomerById;

public class GetCustomerByIdQuery : Request<GetCustomerByIdResponse>
{
    public int Id { get; private set; }
    
    public override bool Validate()
    {
        return IsValid;
    }
}