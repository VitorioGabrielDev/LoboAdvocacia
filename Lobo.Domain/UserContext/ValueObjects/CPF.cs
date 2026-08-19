using System.Text.RegularExpressions;
using Flunt.Validations;
using Lobo.Domain.SharedContext.Exceptions;
using Lobo.Domain.SharedContext.ValueObjects;
using Lobo.Domain.UserContext.Exceptions;

namespace Lobo.Domain.UserContext.ValueObjects;

public partial record CPF : ValueObject
{
    public string Value { get; }
    
    public static implicit operator string(CPF cpf) => cpf.Value;

    public CPF(string cpf)
    {
        EnsureCPFIsValid(cpf);
        Value = cpf;
    }
    
    private static void EnsureCPFIsValid(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            throw new InvalidCPFException("CPF é obrigatório");
        
        cpf = CPFRegex().Replace(cpf, "");
        
        if (cpf.Length != 11)
            throw new InvalidCPFException("O CPF deve possuir 11 caracteres");
        
        if (cpf.Distinct().Count() == 1)
            throw new InvalidCPFException("O CPF não pode ser formado por apenas um dígito.");
        
        int[] multiplier1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
        string tempCpf = cpf.Substring(0, 9);
        int sum = 0;

        for (int i = 0; i < 9; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
        
        int remainder = sum % 11;
        remainder = (remainder < 2) ? 0 : 11 - remainder;

        string digit = remainder.ToString();
        tempCpf += digit;
        
        int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        sum = 0;

        for (int i = 0; i < 10; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
        
        remainder = sum % 11;
        remainder = (remainder < 2) ? 0 : 11 - remainder;

        digit += remainder.ToString();

        if (!cpf.EndsWith(digit))
            throw new InvalidCPFException("O CPF informado é inválido.");
    }

    [GeneratedRegex("[^0-9]")]
    private static partial Regex CPFRegex();
}