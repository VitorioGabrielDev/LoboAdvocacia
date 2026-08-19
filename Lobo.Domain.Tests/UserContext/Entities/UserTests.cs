using Lobo.Domain.SharedContext.Settings;
using Lobo.Domain.Tests.UserContext.Factories;
using Lobo.Domain.UserContext.Entities;
using Lobo.Domain.UserContext.Exceptions.Name;
using Lobo.Domain.UserContext.ValueObjects;

namespace Lobo.Domain.Tests.UserContext.Entities;

public class UserTests
{
    private readonly CPF _validCPF;
    private readonly Password _validPassword;
    private readonly PasswordHashingConfiguration _configuration;
    private const string ValidName = "Iuri de Lima Vieira";

    public UserTests()
    {
        _configuration = PasswordHashingConfigurationFactory.Create();
        _validCPF = new CPF("11246558408");
        _validPassword = new Password("Strong@Password123", _configuration);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldThrowExceptionIfNameIsNullOrWhitespace(string invalidName)
    {
        
        Assert.Throws<InvalidNameException>(() => new User(invalidName, _validCPF, _validPassword));
    }
    
    [Fact]
    public void ShouldCreateWhenIsValid()
    {
       
        var user = new User(ValidName, _validCPF, _validPassword);
        
        Assert.Equal(ValidName, user.Name);
        Assert.Equal(_validCPF, user.CPF);
        Assert.Equal(_validPassword, user.Password);
        
    }
}