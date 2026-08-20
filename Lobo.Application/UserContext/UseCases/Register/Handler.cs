using Lobo.Application.SharedContext.Extensions;
using Lobo.Application.SharedContext.Repositories;
using Lobo.Application.SharedContext.UseCases;
using Lobo.Application.UserContext.Models;
using Lobo.Application.UserContext.Repositories;
using Lobo.Domain.SharedContext.Settings;
using Lobo.Domain.UserContext.Entities;
using Lobo.Domain.UserContext.ValueObjects;
using Microsoft.Extensions.Options;

namespace Lobo.Application.UserContext.UseCases.Register;

public class Handler(
    IUserRepository repository,
    IUnitOfWork unitOfWork,
    IOptions<PasswordHashingConfiguration> passwordConfig
) : HandlerAsync<Command, UserModel>
{
    public override async Task<Result<UserModel>> HandleAsync(Command request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            if (!request.Validate())
                return Result<UserModel>.Failure(request.GetNotificationsAsErrors());

            if (await repository.GetBySpecAsync(x => x.CPF == request.CPF) is User existingUser)
                return Result<UserModel>.BusinessRuleViolation("Já existe um usuário cadastrado com esse CPF.");
            
            var cpf = new CPF(request.CPF);
            var password = new Password(request.Password, passwordConfig.Value);
            var user = new User(request.Name, cpf, password);
            
            await repository.AddAsync(user);
            await unitOfWork.CommitAsync();

            var userModel = new UserModel(user.Id, user.Name);
            return Result.Success(userModel);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackAsync();
            return Result<UserModel>.InternalError(e.Message);
        }
    }
}