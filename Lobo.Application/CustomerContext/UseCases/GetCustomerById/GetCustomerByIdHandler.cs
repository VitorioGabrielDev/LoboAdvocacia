using Lobo.Application.CustomerContext.Repositories;
using Lobo.Application.SharedContext.UseCases;
using Lobo.Domain.CustomerContext;

namespace Lobo.Application.CustomerContext.UseCases.GetCustomerById;

public class GetCustomerByIdHandler(
    ICustomerRepository customerRepository    
) : HandlerAsync<GetCustomerByIdQuery, GetCustomerByIdResponse>
{
    public override async Task<Result<GetCustomerByIdResponse>> HandleAsync(GetCustomerByIdQuery request, CancellationToken cancellationToken = new CancellationToken())
    {
        Result<GetCustomerByIdResponse> result = new();

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
            
            GetCustomerByIdResponse response = new();
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