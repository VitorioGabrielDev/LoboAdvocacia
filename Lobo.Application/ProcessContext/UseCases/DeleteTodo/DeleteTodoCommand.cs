using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.ProcessContext.UseCases.DeleteTodo;

public class DeleteTodoCommand : Request<DeleteTodoResponse>
{
    public int Id { get; private set; }
    
    public override bool Validate()
    {
        return IsValid;
    }
}