using Lobo.Application.SharedContext.UseCases;
using Lobo.Domain.ProcessContext.Enums;

namespace Lobo.Application.ProcessContext.UseCases.CreateProcess;

public class CreateProcessCommand : Request<CreateProcessResponse>
{
    public int CustomerId { get; private set; }
    public ProcessStatus Status { get; private set; }
    public DateTime ProtocolDate { get; private set; }
    public string Action { get; private set; } = string.Empty;
    public int ChildProcessId { get; private set; }
    
    public override bool Validate()
    {
        return IsValid;
    }
}