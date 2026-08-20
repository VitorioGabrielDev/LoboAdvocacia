using Lobo.Application.SharedContext.UseCases;
using Lobo.Application.Tests.SharedContext.Repositories;
using Lobo.Application.Tests.UserContext.Repositories;
using Lobo.Application.UserContext.Models;
using Lobo.Application.UserContext.UseCases.Register;
using Lobo.Domain.SharedContext.Exceptions;
using Lobo.Domain.SharedContext.Settings;
using Lobo.Domain.Tests.UserContext.Factories;
using Microsoft.Extensions.Options;

namespace Lobo.Application.Tests.UserContext.UseCases.Register;

public class CommandTests
{

    private const string ValidName = "Iuri";
    private const string ValidPassword = "Strong@Pass123";
    private const string ValidCPF = "112465558408";
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldReturnValidationErrorWhenNameIsNullOrWhiteSpace(string invalidName)
    {
        
        var command = new Command(ValidCPF, invalidName, ValidPassword);
        command.Validate();
        
        Assert.False(command.IsValid);
        Assert.Contains(command.Notifications, e => e.Key == nameof(command.Name));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldReturnValidationErrorWhenCPFIsNullOrWhiteSpace(string invalidCPF)
    {
        var command = new Command(invalidCPF, ValidName, ValidPassword);
        command.Validate();
        
        Assert.False(command.IsValid);
        Assert.Contains(command.Notifications, e => e.Key == nameof(command.CPF));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldReturnValidationErrorWhenPasswordIsNullOrWhiteSpace(string invalidPassword)
    {
        var command = new Command(ValidCPF, ValidName, invalidPassword);
        command.Validate();
        
        Assert.False(command.IsValid);
        Assert.Contains(command.Notifications, e => e.Key == nameof(command.Password));
    }
}