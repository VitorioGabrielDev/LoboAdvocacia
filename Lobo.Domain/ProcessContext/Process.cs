using Lobo.Domain.ProcessContext.Enums;
using Lobo.Domain.SharedContext.Entities;

namespace Lobo.Domain.ProcessContext;

public class Process : Entity
{
    public int CustomerId { get; private set; }
    public ProcessStatus Status { get; private set; }
    public DateTime ProtocolDate { get; private set; }
    public string Action { get; private set; } = string.Empty;
    public int ChildProcessId { get; private set; }
    
    private Process() { }

    public Process(int customerId, ProcessStatus status, DateTime protocolDate, string action, int childProcessId)
    {
        CustomerId = customerId;
        Status = status;
        ProtocolDate = protocolDate;
        Action = action;
        ChildProcessId = childProcessId;
    }
}