namespace Market.Core.Security;

/// <summary>
/// Represents a token pair (access + refresh) issued to the client during login or refresh.
/// </summary>
public sealed class TokenPairDto
{
    /// <summary>
    /// JWT access token used for authorized API requests.
    /// </summary>
    public required string AccessToken { get; set; }

    /// <summary>
    /// Refresh token stored locally by the client and used to obtain a new access token.
    /// </summary>
    public required string RefreshToken { get; set; }

    /// <summary>
    /// Access token expiration time in UTC.
    /// </summary>
    public required DateTime ExpiresAtUtc { get; set; }
}