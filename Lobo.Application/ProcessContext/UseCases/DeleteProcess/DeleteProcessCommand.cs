using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.ProcessContext.UseCases.DeleteProcess;

public class DeleteProcessCommand : Request<DeleteProcessResponse>
{
    public int Id { get; private set; }
    
    public override bool Validate()
    {
        return IsValid;
    }
}