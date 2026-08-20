namespace Lobo.Domain.SharedContext.Exceptions;

public abstract class DomainException(string message, ErrorType errorType) : Exception(message)
{
    public ErrorType ErrorType = errorType;
}