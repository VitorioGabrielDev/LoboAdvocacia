using Lobo.Domain.SharedContext.Exceptions;

namespace Lobo.Domain.UserContext.Exceptions.Name;

public class InvalidNameException(string message) : DomainException(message, ErrorType.BusinessRule);