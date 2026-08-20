using Lobo.Application.ProcessContext.Repositories;
using Lobo.Application.SharedContext.Repositories;
using Lobo.Application.SharedContext.UseCases;
using Lobo.Domain.ProcessContext;

namespace Lobo.Application.ProcessContext.UseCases.CreateProcess;

public class CreateProcessHandler(
    IProcessRepository processRepository,
    IUnitOfWork unitOfWork
) : HandlerAsync<CreateProcessCommand, CreateProcessResponse>
{
    public override async Task<Result<CreateProcessResponse>> HandleAsync(CreateProcessCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        Result<CreateProcessResponse> result = new();
        
        try
        {
            if (!request.Validate())
            {
                result.AddError("");
                return result;
            }

            Process process = new(request.CustomerId, request.Status, request.ProtocolDate, request.Action, request.ChildProcessId);
            
            await processRepository.CreateProcessAsync(process);
            await unitOfWork.CommitAsync();
            
            CreateProcessResponse response = new();
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