using Lobo.Domain.SharedContext.ValueObjects;

namespace Lobo.Domain.SharedContext.Exceptions;

public record ErrorType : StringEnum
{
    private ErrorType(string code) : base(code) 
    { }
        
    public static readonly ErrorType BusinessRule = new(nameof(BusinessRule));
    public static readonly ErrorType InternalError = new(nameof(InternalError));
    public static readonly ErrorType ValidationError = new(nameof(ValidationError));
}