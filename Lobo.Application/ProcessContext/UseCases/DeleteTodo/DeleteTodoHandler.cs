using Lobo.Application.ProcessContext.Repositories;
using Lobo.Application.SharedContext.Repositories;
using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.ProcessContext.UseCases.DeleteTodo;

public class DeleteTodoHandler(
    ITodoRepository todoRepository,
    IUnitOfWork unitOfWork
) : HandlerAsync<DeleteTodoCommand, DeleteTodoResponse>
{
    public override async Task<Result<DeleteTodoResponse>> HandleAsync(DeleteTodoCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        Result<DeleteTodoResponse> result = new();

        try
        {
            if (!request.Validate())
            {
                result.AddError("");
                return result;
            }

            await todoRepository.DeleteTodoAsync(request.Id);
            await unitOfWork.CommitAsync();
            
            DeleteTodoResponse response = new();
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