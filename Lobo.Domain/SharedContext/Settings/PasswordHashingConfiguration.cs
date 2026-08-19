namespace Lobo.Domain.SharedContext.Settings;

public class PasswordHashingConfiguration
{
    public short SaltSize { get; init; }
    public short KeySize { get; init; }
    public int Iterations { get; init; }
    public char SplitChar { get; init; }
    public string PasswordPepper { get; init; } = string.Empty;
}
