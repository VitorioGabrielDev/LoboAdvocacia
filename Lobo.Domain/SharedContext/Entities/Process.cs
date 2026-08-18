using Lobo.Domain.SharedContext.Enums;

namespace Lobo.Domain.SharedContext.Entities;

public class Process : Entity
{
    public int CustomerId { get; private set; }
    public ProcessStatus Status { get; private set; }
    public DateTime ProtocolDate { get; private set; }
    public string Action { get; private set; } = string.Empty;
    public int ChildProcessId { get; private set; }
    public List<Todo> Todos { get; private set; } = new();
    
    private Process() { }

    public Process(int customerId, ProcessStatus status, DateTime protocolDate, string action, int childProcessId, List<Todo> todos)
    {
        CustomerId = customerId;
        Status = status;
        ProtocolDate = protocolDate;
        Action = action;
        ChildProcessId = childProcessId;
        Todos = todos;
    }
}