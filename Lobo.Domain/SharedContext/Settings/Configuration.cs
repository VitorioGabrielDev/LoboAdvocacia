namespace Lobo.Domain.SharedContext.Settings;

public static partial class Configuration
{

    
   
    public static DatabaseConfiguration Database { get; private set; } = null!;
    public static JwtConfiguration Jwt { get; private set; } = null!;
    

    public class DatabaseConfiguration(string connectionString)
    {
        public string ConnectionString { get; } = connectionString;
    }


    public record JwtConfiguration(string PrivateKey, int ExpirySeconds, int RefreshTokenExpirySeconds);
    
    public static void AddDatabaseConfiguration(string connectionString)
        => Database = new DatabaseConfiguration(connectionString);
    
    public static void AddJwtConfiguration(string jwtPrivateKey, int expirySeconds, int refreshTokenExpirySeconds)
        => Jwt = new JwtConfiguration(jwtPrivateKey, expirySeconds, refreshTokenExpirySeconds);
    
    
}