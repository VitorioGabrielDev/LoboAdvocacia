using Lobo.Application.ProcessContext.Repositories;
using Lobo.Application.SharedContext.UseCases;
using Lobo.Domain.ProcessContext;

namespace Lobo.Application.ProcessContext.UseCases.GetProcessesByCustomerId;

public class GetProcessesByCustomerIdHandler(
    IProcessRepository processRepository    
) : HandlerAsync<GetProcessesByCustomerIdQuery, GetProcessesByCustomerIdResponse>
{
    public override async Task<Result<GetProcessesByCustomerIdResponse>> HandleAsync(GetProcessesByCustomerIdQuery request, CancellationToken cancellationToken = new CancellationToken())
    {
        Result<GetProcessesByCustomerIdResponse> result = new();
        
        try
        {
            if (!request.Validate())
            {
                result.AddError("");
                return result;
            }

            List<Process> processes = await processRepository.GetProcessesByCustomerIdAsync(request.CustomerId);        
            
            GetProcessesByCustomerIdResponse response = new();
            result.SetData(response);
            return result;
        }
        catch (Exception e)
        {
            result.AddError(e.Message);
            return result;
        }
    }
}