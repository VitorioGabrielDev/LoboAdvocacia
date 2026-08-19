using Lobo.Domain.SharedContext.Settings;

namespace Lobo.Domain.Tests.UserContext.Factories;

public class PasswordHashingConfigurationFactory
{
    public static PasswordHashingConfiguration Create()
        => new PasswordHashingConfiguration
        {
            SaltSize = 16,
            Iterations = 10,
            KeySize =  32,
            SplitChar = '.',
            PasswordPepper = "mystrongandsecurePaSSwOrdPepper()!@@##$%"
        };
}