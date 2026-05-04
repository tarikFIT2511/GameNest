namespace Market.Core.Security;

/// <summary>
/// Request for user login into the system.
/// </summary>
public sealed class LoginRequestDto
{
    /// <summary>
    /// Email of the user attempting to log in.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// User password.
    /// </summary>
    public required string Password { get; set; }

    /// <summary>
    /// Client fingerprint (optional) — can be a hash of User-Agent + IP address.
    /// Used to identify the device and add extra security for refresh tokens.
    /// </summary>
    public string? Fingerprint { get; set; }
}