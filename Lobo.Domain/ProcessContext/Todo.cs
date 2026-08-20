using Lobo.Domain.SharedContext.Entities;

namespace Lobo.Domain.ProcessContext;

public class Todo : Entity
{
    public int ProcessId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public bool Completed { get; private set; }
    
    private Todo() { }

    public Todo(int processId, string title, string description)
    {
        ProcessId = processId;
        Title = title;
        Description = description;
        Completed = false;
    }

    public void Update(int processId, string title, string description)
    {
        ProcessId = processId;
        Title = title;
        Description = description;
    }
}