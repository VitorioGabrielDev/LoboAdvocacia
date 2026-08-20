using Lobo.Application.CustomerContext.Repositories;
using Lobo.Application.SharedContext.Repositories;
using Lobo.Application.SharedContext.UseCases;
using Lobo.Domain.CustomerContext;

namespace Lobo.Application.CustomerContext.UseCases.UpdateCustomer;

public class UpdateCustomerHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork
) : HandlerAsync<UpdateCustomerCommand, UpdateCustomerResponse>
{
    public override async Task<Result<UpdateCustomerResponse>> HandleAsync(UpdateCustomerCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        Result<UpdateCustomerResponse> result = new();

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
            
            customer.Update(
                firstName: request.FirstName,
                fullName: request.FullName,
                nationalId: request.NationalId,
                email: request.Email,
                contactPhone: request.ContactPhone,
                neighborhood: request.Neighborhood,
                city: request.City,
                state: request.State
            );
            
            await customerRepository.UpdateCustomerAsync(customer);
            await unitOfWork.CommitAsync();
            
            UpdateCustomerResponse response = new();
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