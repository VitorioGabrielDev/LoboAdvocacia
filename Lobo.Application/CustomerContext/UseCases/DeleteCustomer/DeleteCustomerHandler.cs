using Lobo.Application.CustomerContext.Repositories;
using Lobo.Application.SharedContext.UseCases;
using Lobo.Domain.CustomerContext;

namespace Lobo.Application.CustomerContext.UseCases.DeleteCustomer;

public class DeleteCustomerHandler(
    ICustomerRepository customerRepository    
) : HandlerAsync<DeleteCustomerCommand, DeleteCustomerResponse>
{
    public override async Task<Result<DeleteCustomerResponse>> HandleAsync(DeleteCustomerCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        Result<DeleteCustomerResponse> result = new();
        
        try
        {
            if (!request.Validate())
            {
                result.AddError("");
                return result;
            }

            Customer? customer = await customerRepository.GetCustomerByIdAsync(request.Id);

            if (customer is null)
            {
                result.AddError("O cliente não foi encontrado com o identificador informado!");
                return result;
            }
            
            await customerRepository.DeleteCustomerAsync(request.Id);
            
            DeleteCustomerResponse response = new();
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