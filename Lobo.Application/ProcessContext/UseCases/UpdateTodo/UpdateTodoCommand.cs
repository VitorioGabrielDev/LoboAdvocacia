using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.ProcessContext.UseCases.UpdateTodo;

public class UpdateTodoCommand : Request<UpdateTodoResponse>
{
    public int Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    
    public override bool Validate()
    {
        return IsValid;
    }
}