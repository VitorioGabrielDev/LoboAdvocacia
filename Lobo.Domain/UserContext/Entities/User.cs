using Lobo.Domain.UserContext.Exceptions.Name;
using Lobo.Domain.UserContext.ValueObjects;

namespace Lobo.Domain.UserContext.Entities;

public class User
{
    public string Name { get; private set; } = string.Empty;
    public CPF CPF { get; private set; } = null!;
    public Password Password { get; private set; } = null!;

    public User(string name, CPF cpf, Password password)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidNameException("O Nome não pode ser vazio.");
        
        Name = name;
        CPF = cpf;
        Password = password;
    }
    private User() { }
}