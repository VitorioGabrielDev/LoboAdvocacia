using Lobo.Domain.UserContext.Exceptions;
using Lobo.Domain.UserContext.ValueObjects;

namespace Lobo.Domain.Tests.UserContext.ValueObjects;

public class CPFTests
{
    
    private const string ValidCPF = "11246558408";
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldThrowExceptionWhenIsNullOrWhitespace(string invalidCPF)
    { 
        Assert.Throws<InvalidCPFException>( () => new CPF(invalidCPF));
    }
    
    [Theory]
    [InlineData("1124")]
    [InlineData("112465584088")]
    public void ShouldThrowExceptionWhenLengthDifferent11(string invalidCPF)
    {
        Assert.Throws<InvalidCPFException>( () => new CPF(invalidCPF));
    }
    
    [Theory]
    [InlineData("11111111111")]
    [InlineData("22222222222")]
    [InlineData("33333333333")]
    public void ShouldThrowExceptionWhenAllDigitsAreTheSame(string invalidCPF)
    {
        Assert.Throws<InvalidCPFException>( () => new CPF(invalidCPF));
    }

    [Fact]
    public void ShouldThrowExceptionWhenIsInvalid()
    {
        Assert.Throws<InvalidCPFException>( () => new CPF("11246558403"));
    }

    [Fact]
    public void ShouldCreateSuccessWhenIsValid()
    {
        var cpf = new CPF(ValidCPF);
        
        Assert.Equal(ValidCPF, cpf.Value);
    }
}