using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.ProcessContext.UseCases.CreateTodo;

public class CreateTodoCommand : Request<CreateTodoResponse>
{
    public int ProcessId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    
    public override bool Validate()
    {
        return IsValid;
    }
}