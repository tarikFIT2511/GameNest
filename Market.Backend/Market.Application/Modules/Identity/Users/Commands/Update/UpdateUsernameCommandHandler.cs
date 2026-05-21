namespace Market.Application.Modules.Identity.Users.Commands.Update;

public sealed class UpdateUsernameCommandHandler(IAppDbContext ctx)
            : IRequestHandler<UpdateUsernameCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUsernameCommand request, CancellationToken ct)
    {
        var user = await ctx.Users
            .Where(x => x.Id == request.Id) 
            .FirstOrDefaultAsync(ct);

        if (user == null)
            throw new MarketNotFoundException($"User not found.");

        // Check for duplicate username 
        var exists = await ctx.Users
            .AnyAsync(x => x.Id != request.Id && x.Username == request.Username, ct);

        if (exists)
        {
            throw new MarketConflictException("Username already exists.");
        }

        user.Username = request.Username.Trim();
        user.ModifiedAtUtc = DateTime.UtcNow;
        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}