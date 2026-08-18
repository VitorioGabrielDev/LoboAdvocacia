namespace Lobo.Domain.SharedContext.Entities;

public class Todo : Entity
{
    public int ProcessId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public bool Completed { get; private set; }
    
    private Todo() { }

    public Todo(int processId, string title, string description, bool completed)
    {
        ProcessId = processId;
        Title = title;
        Description = description;
        Completed = completed;
    }
}