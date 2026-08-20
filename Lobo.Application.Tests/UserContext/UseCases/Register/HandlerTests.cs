using Lobo.Application.SharedContext.UseCases;
using Lobo.Application.Tests.SharedContext.Repositories;
using Lobo.Application.Tests.UserContext.Repositories;
using Lobo.Application.UserContext.Models;
using Lobo.Application.UserContext.UseCases.Register;
using Lobo.Domain.SharedContext.Exceptions;
using Lobo.Domain.SharedContext.Settings;
using Lobo.Domain.Tests.UserContext.Factories;
using Lobo.Domain.UserContext.Entities;
using Lobo.Domain.UserContext.ValueObjects;
using Microsoft.Extensions.Options;

namespace Lobo.Application.Tests.UserContext.UseCases.Register;

public class HandlerTests
{
 
    private readonly Handler _handler;
    private readonly FakeUserRepository _repository;
    private readonly PasswordHashingConfiguration _passwordConfig;
        
    public HandlerTests()
    {
        _repository = new FakeUserRepository();
        var unitOfWork = new FakeUnitOfWork();
        _passwordConfig = PasswordHashingConfigurationFactory.Create();
        IOptions<PasswordHashingConfiguration> passwordOptions = Options.Create(_passwordConfig);
        
        _handler = new Handler(_repository, unitOfWork, passwordOptions);
    }
    
    [Fact]
    public async Task ShouldReturnBusinessRuleViolationWhenCPFIsAlreadyRegistered()
    {
        var existingCPF = new CPF("11246558408");
        var existingPassword = new Password("Strong@Pass123", _passwordConfig);
        var existingUser = new User("Iuri de Lima", existingCPF, existingPassword);
        await _repository.AddAsync(existingUser);
        
        var cpf = new CPF("11246558408");
        var password = new Password("Strong@Pass123", _passwordConfig);
        var user = new User("Iuri de Lima", cpf, password);
        
        var command = new Command("11246558408", "João Davino", "Pass@Strong@Pass123");
        Result<UserModel> response = await _handler.HandleAsync(command);
        
        Assert.False(response.IsSuccess);
        Assert.Contains(response.Errors, e => e.Type == ErrorType.BusinessRule);
    }

    [Theory]
    [InlineData("", "Iuri", "SenhaSuperForte@1")]
    [InlineData("11246558408", "", "SenhaSuperForte@1")]
    [InlineData("11246558408", "Iuri", "")]
    public async Task ShouldReturnValidationErrorWhenCommandIsInvalid(string name, string cpf, string password)
    {
        var command = new Command(name, cpf, password);
        Result<UserModel> response = await _handler.HandleAsync(command);
        
        Assert.False(response.IsSuccess);
        Assert.Contains(response.Errors, e => e.Type == ErrorType.ValidationError);
    }

    [Fact]
    public async Task ShouldRegisterUserWhenAllDataIsValid()
    {
        var command = new Command("11246558408", "Iuri de Lima", "Pass@Strong@Pass123");
        Result<UserModel> response = await _handler.HandleAsync(command);
        
        Assert.True(response.IsSuccess);
        Assert.NotNull(response.Data);
        Assert.Equal(response.Data.Name, command.Name);
    }
}