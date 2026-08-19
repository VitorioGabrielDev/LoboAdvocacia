using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Lobo.Domain.SharedContext;
using Lobo.Domain.SharedContext.Settings;
using Lobo.Domain.SharedContext.ValueObjects;
using Lobo.Domain.UserContext.Exceptions.Password;

namespace Lobo.Domain.UserContext.ValueObjects;

public partial record Password : ValueObject
{
    public string Hash { get; } = string.Empty;

    private const string Regex = "^(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{8,}$";
    private readonly PasswordHashingConfiguration _configuration;

    private Password(){ }
    
    public Password(string plainTextPassword, PasswordHashingConfiguration configuration)
    {
        if (string.IsNullOrWhiteSpace(plainTextPassword))
            throw new EmptyPasswordException();
        
        if (!PasswordRegex().IsMatch(plainTextPassword))
            throw new InvalidFormatPasswordException();
        
        _configuration = configuration;
        Hash = GenerateHash(plainTextPassword);
    }

    private string GenerateHash(string plainTextPassword)
    {
        int iterations = _configuration.Iterations;
        short saltSize = _configuration.SaltSize;
        short outputLength = _configuration.KeySize;
        char splitChar = _configuration.SplitChar;
        
        string password = plainTextPassword + _configuration.PasswordPepper;
        byte[] saltBytes = RandomNumberGenerator.GetBytes(saltSize);
        byte[] hashBytes = Rfc2898DeriveBytes.Pbkdf2(
            password,
            saltBytes,
            iterations,
            HashAlgorithmName.SHA256,
            outputLength
        );
        
        string hash = Convert.ToBase64String(hashBytes);
        string salt = Convert.ToBase64String(saltBytes);

        return $"{iterations}{splitChar}{salt}{splitChar}{hash}";
    }
    
    public bool CheckPassword(string plainTextPassword)
    {
        string password = plainTextPassword + _configuration.PasswordPepper;
        char splitChar = _configuration.SplitChar;
        int iterations = _configuration.Iterations;
        short outputLength = _configuration.KeySize;

        string[] parts = Hash.Split(splitChar, 3);
        if (parts.Length != 3)
            return false;

        var hashIterations = Convert.ToInt32(parts[0]);
        byte[] salt = Convert.FromBase64String(parts[1]);
        byte[] hash = Convert.FromBase64String(parts[2]);

        if (hashIterations != iterations)
            return false;

        byte[] hashToCheck = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            iterations,
            HashAlgorithmName.SHA256,
            outputLength
        );
        
        return hashToCheck.SequenceEqual(hash);
    }

    [GeneratedRegex(Regex)]
    private partial Regex PasswordRegex();

}