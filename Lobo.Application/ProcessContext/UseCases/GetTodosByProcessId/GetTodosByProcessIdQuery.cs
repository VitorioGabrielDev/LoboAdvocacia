using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.ProcessContext.UseCases.GetTodosByProcessId;

public class GetTodosByProcessIdQuery : Request<GetTodosByProcessIdResponse>
{
    public int ProcessId { get; private set; }
    
    public override bool Validate()
    {
        return IsValid;
    }
}