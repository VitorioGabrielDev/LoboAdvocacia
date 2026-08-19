using Lobo.Domain.SharedContext.Exceptions;

namespace Lobo.Application.SharedContext.UseCases;

public class Error
{
    public ErrorType Type { get; }
    public string Message { get; }

    private Error(ErrorType errorType, string message)
    {
        Type = errorType;
        Message = message;
    }

    public static Error ValidationError(string message) => new( ErrorType.ValidationError, message);
    public static Error BusinessRule(string message) => new( ErrorType.BusinessRule, message);
    public static Error InternalError(string message) => new( ErrorType.InternalError, message);
    
}