using Lobo.Application.SharedContext.UseCases;
using Lobo.Application.CustomerContext.Repositories;
using Lobo.Application.SharedContext.Repositories;
using Lobo.Domain.CustomerContext;

namespace Lobo.Application.CustomerContext.UseCases.CreateCustomer;

public class CreateCustomerHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork
) : HandlerAsync<CreateCustomerCommand, CreateCustomerResponse>
{
    public override async Task<Result<CreateCustomerResponse>> HandleAsync(CreateCustomerCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        Result<CreateCustomerResponse> result = new();

        try
        {
            if (!request.Validate())
            {
                result.AddError("Problema na validação do request.");
                return result;
            }

            Customer customer = new(
                firstName: request.FirstName,
                fullName: request.FullName,
                nationalId: request.NationalId,
                email: request.Email,
                contactPhone: request.ContactPhone,
                neighborhood: request.Neighborhood,
                state: request.State,
                city: request.City
            );
            
            await customerRepository.CreateCustomerAsync(customer);
            await unitOfWork.CommitAsync();
            
            CreateCustomerResponse response = new();
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