namespace Market.Application.Modules.Identity.Users.Commands.Status.Disable;

public sealed class DisableUserCommandHandler(IAppDbContext ctx)
    : IRequestHandler<DisableUserCommand, Unit>
{
    public async Task<Unit> Handle(DisableUserCommand request, CancellationToken ct)
    {
        var user = await ctx.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (user == null)
        {
            throw new MarketNotFoundException($"User not found.");
        }

        if (!user.IsEnabled)
        {
            throw new MarketConflictException("User is already disabled.");
        }

        user.IsEnabled = false;
        user.ModifiedAtUtc = DateTime.UtcNow;
        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}