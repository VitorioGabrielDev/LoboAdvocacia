using Lobo.Application.ProcessContext.Repositories;
using Lobo.Application.SharedContext.UseCases;
using Lobo.Domain.ProcessContext;

namespace Lobo.Application.ProcessContext.UseCases.GetTodosByProcessId;

public class GetTodosByProcessIdHandler(
    ITodoRepository todoRepository    
) : HandlerAsync<GetTodosByProcessIdQuery, GetTodosByProcessIdResponse>
{
    public override async Task<Result<GetTodosByProcessIdResponse>> HandleAsync(GetTodosByProcessIdQuery request, CancellationToken cancellationToken = new CancellationToken())
    {
        Result<GetTodosByProcessIdResponse> result = new();

        try
        {
            if (!request.Validate())
            {
                result.AddError("");
                return result;
            }

            List<Todo> todos = await todoRepository.GetTodosByProcessIdAsync(request.ProcessId);
            
            GetTodosByProcessIdResponse response = new();
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