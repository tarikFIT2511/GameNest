using Market.Application.Modules.Identity.UserProfiles.Commands.Update;

namespace Market.Application.Modules.Identity.Users.Commands.Update;

public sealed class UpdateUserProfileCommandHandler(IAppDbContext ctx)
            : IRequestHandler<UpdateUserProfileCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserProfileCommand request, CancellationToken ct)
    {
        var user = await ctx.Users
            .Include(x => x.Profile)
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(ct);

        if (user == null)
            throw new MarketNotFoundException($"User not found.");
        if (user.Profile == null)
            throw new MarketConflictException("User profile missing.");

        user.Profile.Country = request.Country;
        user.Profile.AvatarUrl = request.AvatarUrl;
        user.Profile.Bio = request.Bio?.Trim() ?? "";
        user.Profile.ModifiedAtUtc = DateTime.UtcNow;

        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}