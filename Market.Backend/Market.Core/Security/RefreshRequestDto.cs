namespace Market.Core.Security;

/// <summary>
/// Request for refreshing a JWT token using a refresh token.
/// </summary>
public sealed class RefreshRequestDto
{
    /// <summary>
    /// Refresh token previously issued to the user.
    /// </summary>
    public required string RefreshToken { get; set; }

    /// <summary>
    /// Client fingerprint (optional) — used to additionally verify that the refresh request
    /// is coming from the same device.
    /// </summary>
    public string? Fingerprint { get; set; }
}