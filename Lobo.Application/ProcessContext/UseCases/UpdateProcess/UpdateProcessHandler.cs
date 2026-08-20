using Lobo.Application.ProcessContext.Repositories;
using Lobo.Application.SharedContext.Repositories;
using Lobo.Application.SharedContext.UseCases;
using Lobo.Domain.ProcessContext;

namespace Lobo.Application.ProcessContext.UseCases.UpdateProcess;

public class UpdateProcessHandler(
    IProcessRepository processRepository,
    IUnitOfWork unitOfWork
) : HandlerAsync<UpdateProcessCommand, UpdateProcessResponse>
{
    public override async Task<Result<UpdateProcessResponse>> HandleAsync(UpdateProcessCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        Result<UpdateProcessResponse> result = new();
        
        try
        {
            if (!request.Validate())
            {
                result.AddError("");
                return result;
            }

            Process? process = await processRepository.GetProcessByIdAsync(request.Id);

            if (process is null)
            {
                result.AddError("");
                return result;
            }

            process.Update(request.CustomerId, request.Status, request.ProtocolDate, request.Action, request.ChildProcessId);
            
            await processRepository.UpdateProcessAsync(process);
            await unitOfWork.CommitAsync();

            UpdateProcessResponse response = new();
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