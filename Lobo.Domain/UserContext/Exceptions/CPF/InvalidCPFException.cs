using Lobo.Domain.SharedContext.Exceptions;

namespace Lobo.Domain.UserContext.Exceptions;

public class InvalidCPFException(string message) : DomainException(message, ErrorType.BusinessRule);