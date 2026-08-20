using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.ProcessContext.UseCases.GetProcessesByCustomerId;

public class GetProcessesByCustomerIdQuery : Request<GetProcessesByCustomerIdResponse>
{
    public int CustomerId { get; private set; }
    
    public override bool Validate()
    {
        return IsValid;
    }
}