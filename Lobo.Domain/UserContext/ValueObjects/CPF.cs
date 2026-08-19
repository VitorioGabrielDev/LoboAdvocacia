using System.Text.RegularExpressions;
using Flunt.Validations;
using Lobo.Domain.SharedContext.Exceptions;
using Lobo.Domain.UserContext.Exceptions;

namespace Lobo.Domain.UserContext.ValueObjects;

public partial record CPF
{
    public string Value { get; }

    public CPF()
    {
        
    }
    
    public static bool Validate(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            throw new InvalidCPFException("CPF é obrigatório");
        
        cpf = CPFRegex().Replace(cpf, "");
        
        if (cpf.Length != 11)
            return false;
        
        if (cpf.Distinct().Count() == 1)
            return false;
        
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
        
        return cpf.EndsWith(digit);
    }

    [GeneratedRegex("[^0-9]")]
    private static partial Regex CPFRegex();
}