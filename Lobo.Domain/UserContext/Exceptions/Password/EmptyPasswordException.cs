using Lobo.Domain.SharedContext.Exceptions;

namespace Lobo.Domain.UserContext.Exceptions.Password;

public class EmptyPasswordException() : DomainException("Empty password", ErrorType.ValidationError);