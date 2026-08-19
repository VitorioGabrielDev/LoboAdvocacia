using Lobo.Domain.SharedContext.Exceptions;
using System.Reflection;
namespace Lobo.Domain.SharedContext.ValueObjects;

public abstract record StringEnum(string Code) : ValueObject
{
    public override string ToString() => Code;
    
    public static implicit operator string(StringEnum value) => value.Code;

    public static TEnum Parse<TEnum>(string code)
        where TEnum : StringEnum
    {
        Type type = typeof(TEnum);

        TEnum? matchEnum = type
            .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(prop => prop.PropertyType == type)
            .Select(prop => (TEnum)prop.GetValue(null)!)
            .FirstOrDefault( x => x.Code == code );
        
        return matchEnum ?? throw StringEnumExceptions.ParseFailException<TEnum>(code);
    }
}