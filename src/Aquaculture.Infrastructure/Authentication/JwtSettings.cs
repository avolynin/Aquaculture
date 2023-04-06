namespace Aquaculture.Infrastructure.Authentication;

public class JwtSettings
{
    public static string SectionName { get; set; } = "JwtSettings";
    public string SecretKey { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}
