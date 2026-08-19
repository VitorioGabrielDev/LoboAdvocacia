using Lobo.Domain.SharedContext.ValueObjects;

namespace Lobo.Domain.SharedContext.Exceptions;

public class StringEnumExceptions : DomainException
{
    public static StringEnumExceptions ParseFailException<TEnum>(string rawValue) where TEnum : StringEnum
        => new($"Falha ao converter o valor: {rawValue} para o String Enum: {typeof(TEnum).Name}");

    public static StringEnumExceptions JsonReadingException<TEnum>() where TEnum : StringEnum
        => new("Falha ao ler valor do tipo stringEnum do banco de dados.");
    
    private StringEnumExceptions(string message) : base(message, ErrorType.ValidationError){}
}