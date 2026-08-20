using Lobo.Application.ProcessContext.Repositories;
using Lobo.Application.SharedContext.Repositories;
using Lobo.Application.SharedContext.UseCases;
using Lobo.Domain.ProcessContext;

namespace Lobo.Application.ProcessContext.UseCases.UpdateTodo;

public class UpdateTodoHandler(
    ITodoRepository todoRepository,
    IUnitOfWork unitOfWork
) : HandlerAsync<UpdateTodoCommand, UpdateTodoResponse>
{
    public override async Task<Result<UpdateTodoResponse>> HandleAsync(UpdateTodoCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        Result<UpdateTodoResponse> result = new();
        
        try
        {
            if (!request.Validate())
            {
                result.AddError("");
                return result;
            }

            Todo? todo = await todoRepository.GetTodoById(request.Id);

            if (todo is null)
            {
                result.AddError("");
                return result;
            }

            todo.Update(todo.ProcessId, todo.Title, request.Description);
            
            await todoRepository.UpdateTodoAsync(todo);
            await unitOfWork.CommitAsync();
            
            UpdateTodoResponse response = new();
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