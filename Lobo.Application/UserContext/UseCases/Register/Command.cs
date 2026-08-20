using Flunt.Validations;
using Lobo.Application.SharedContext.UseCases;
using Lobo.Application.UserContext.Models;

namespace Lobo.Application.UserContext.UseCases.Register;

public class Command : Request<UserModel>
{
    public string CPF { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }

    public Command(string cpf, string name, string password)
    {
        CPF = cpf;
        Name = name;
        Password = password;
    }

    public override bool Validate()
    {
        AddNotifications(
            new Contract<Command>()
                .Requires()
                .IsNotNullOrWhiteSpace(CPF, nameof(CPF), "O valor deve ser informado.")
                .IsNotNullOrWhiteSpace(Name, nameof(Name), "O valor deve ser informado.")
                .IsNotNullOrWhiteSpace(Password, nameof(Password), "O valor deve ser informado.")
        );
        return IsValid;
    }
}