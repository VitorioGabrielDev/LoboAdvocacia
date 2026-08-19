using Lobo.Domain.SharedContext.Exceptions;

namespace Lobo.Domain.UserContext.Exceptions.Password;

public class InvalidFormatPasswordException() : DomainException("Password is invalid.", ErrorType.ValidationError);