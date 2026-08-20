using Lobo.Application.ProcessContext.Repositories;
using Lobo.Application.SharedContext.Repositories;
using Lobo.Application.SharedContext.UseCases;
using Lobo.Domain.ProcessContext;

namespace Lobo.Application.ProcessContext.UseCases.CreateTodo;

public class CreateTodoHandler(
    ITodoRepository todoRepository,
    IUnitOfWork unitOfWork
) : HandlerAsync<CreateTodoCommand, CreateTodoResponse>
{
    public override async Task<Result<CreateTodoResponse>> HandleAsync(CreateTodoCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        Result<CreateTodoResponse> result = new();
        
        try
        {
            if (!request.Validate())
            {
                result.AddError("");
                return result;
            }

            Todo todo = new(request.ProcessId, request.Title, request.Description);
            
            await todoRepository.CreateTodoAsync(todo);
            await unitOfWork.CommitAsync();
            
            CreateTodoResponse response = new();
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