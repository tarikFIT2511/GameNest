using Market.Core.Entities.Identity;
using Market.Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

[ApiController]
[Route("[controller]")]
public sealed class AuthController(
    DatabaseContext ctx,
    IJwtTokenService tokens,
    ILogger<AuthController> logger) : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<TokenPairDto>> Login([FromBody] LoginRequestDto req, CancellationToken ct)
    {
        var user = await ctx.Users
            .FirstOrDefaultAsync(x => x.Email == req.Email && x.IsEnabled && !x.IsDeleted, ct);

        if (user is null)
            throw new MarketNotFoundException("User not found or is disabled.");

        var hasher = new PasswordHasher<UserEntity>();
        var vr = hasher.VerifyHashedPassword(user, user.PasswordHash, req.Password);
        if (vr == PasswordVerificationResult.Failed)
            throw new MarketConflictException("Invalid credentials.");

        // issuing token pair
        var pair = tokens.Issue(user);

        // save refresh hash
        var (_, hash, exp) = tokens.IssueRefreshToken(); // already called inside Issue; we issue a NEW one because we want the pair from the database == response
        var rt = new RefreshTokenEntity
        {
            TokenHash = tokens.HashRefreshToken(pair.RefreshToken),
            ExpiresAtUtc = DateTime.UtcNow.AddDays(14),
            UserId = user.Id,
            Fingerprint = req.Fingerprint
        };
        ctx.Add(rt);
        await ctx.SaveChangesAsync(ct);

        return Ok(pair);
    }

    [HttpPost("refresh")]
    [AllowAnonymous]
    public async Task<ActionResult<TokenPairDto>> Refresh([FromBody] RefreshRequestDto req, CancellationToken ct)
    {
        var hash = tokens.HashRefreshToken(req.RefreshToken);
        var rt = await ctx.RefreshTokens
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.TokenHash == hash && !x.IsRevoked && !x.IsDeleted, ct);

        if (rt is null || rt.ExpiresAtUtc < DateTime.UtcNow)
            throw new MarketConflictException("Refresh token is invalid.");

        // (optional) provjeri fingerprint:
        if (rt.Fingerprint != null && req.Fingerprint != null && rt.Fingerprint != req.Fingerprint)
            throw new MarketConflictException("Invalid client fingerprint.");

        // rotation of refresh tokens (revoke old, enter a new one)
        rt.IsRevoked = true;

        var user = rt.User;
        var pair = tokens.Issue(user);

        var newRt = new RefreshTokenEntity
        {
            TokenHash = tokens.HashRefreshToken(pair.RefreshToken),
            ExpiresAtUtc = DateTime.UtcNow.AddDays(14),
            UserId = user.Id,
            Fingerprint = req.Fingerprint
        };

        ctx.Add(newRt);
        await ctx.SaveChangesAsync(ct);

        return Ok(pair);
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] RefreshRequestDto req, CancellationToken ct)
    {
        var hash = tokens.HashRefreshToken(req.RefreshToken);
        var rt = await ctx.RefreshTokens
            .FirstOrDefaultAsync(x => x.TokenHash == hash && !x.IsRevoked && !x.IsDeleted, ct);

        if (rt != null)
        {
            rt.IsRevoked = true;
            await ctx.SaveChangesAsync(ct);
        }
        return NoContent();
    }
}
