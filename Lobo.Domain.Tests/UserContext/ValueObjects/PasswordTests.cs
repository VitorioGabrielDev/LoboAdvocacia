using Lobo.Domain.SharedContext.Settings;
using Lobo.Domain.Tests.UserContext.Factories;
using Lobo.Domain.UserContext.Exceptions.Password;
using Lobo.Domain.UserContext.ValueObjects;

namespace Lobo.Domain.Tests.UserContext.ValueObjects;

public class PasswordTests
{
    private const string ValidPasswordText = "Strong@Pass123";
    private readonly PasswordHashingConfiguration _configuration;

    public PasswordTests()
    {
        _configuration = PasswordHashingConfigurationFactory.Create();
    }

    [Fact]
    public void ShouldCreatePasswordSuccessfullyWhenDataIsValid()
    {
        var password = new Password(ValidPasswordText, _configuration);
        
        Assert.NotNull(password);
        Assert.NotEmpty(password.Hash);
        Assert.True(password.CheckPassword(ValidPasswordText));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldThrowExceptionWhenPasswordIsEmptyOrWhitespace(string invalidPassword)
    {
        Action act = () => new Password(invalidPassword, _configuration);
        
        Assert.Throws<EmptyPasswordException>(act);
    }

    [Theory]
    [InlineData("weak")]
    [InlineData("StrongPass123")]
    [InlineData("Strong@Pass")]
    [InlineData("strong@pass123")]
    public void ShouldThrowExceptionWhenPasswordDoesNotMeetRequirements(string invalidPassword)
    {
        Action act = () => new Password(invalidPassword, _configuration);
        
        Assert.Throws<InvalidFormatPasswordException>(act);
    }

    [Fact]
    public void ShouldReturnTrueWhenCheckingCorrectPassword()
    {
        var password = new Password(ValidPasswordText, _configuration);
        
        bool isValid = password.CheckPassword(ValidPasswordText);
        
        Assert.True(isValid);
    }

    [Fact]
    public void ShouldReturnFalseWhenCheckingIncorrectPassword()
    {
        var password = new Password(ValidPasswordText, _configuration);
        
        bool isValid = password.CheckPassword("Wrong@Pass123");
        
        Assert.False(isValid);
    }
}