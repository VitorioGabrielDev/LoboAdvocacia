using Lobo.Application.ProcessContext.Repositories;
using Lobo.Application.SharedContext.Repositories;
using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.ProcessContext.UseCases.DeleteProcess;

public class DeleteProcessHandler(
    IProcessRepository processRepository,
    IUnitOfWork unitOfWork
) : HandlerAsync<DeleteProcessCommand, DeleteProcessResponse>
{
    public override async Task<Result<DeleteProcessResponse>> HandleAsync(DeleteProcessCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        Result<DeleteProcessResponse> result = new();
        
        try
        {
            if (!request.Validate())
            {
                result.AddError("");
                return result;
            }

            await processRepository.DeleteProcessAsync(request.Id);
            await unitOfWork.CommitAsync();
            
            DeleteProcessResponse response = new();
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