namespace Market.Application.Modules.Identity.Users.Commands.Update;

public sealed class UpdateUserEmailCommandHandler(IAppDbContext ctx)
            : IRequestHandler<UpdateUserEmailCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserEmailCommand request, CancellationToken ct)
    {
        var user = await ctx.Users
            .Where(x => x.Id == request.Id) 
            .FirstOrDefaultAsync(ct);

        if (user == null)
            throw new MarketNotFoundException($"User not found.");

        // Check for duplicate username 
        var exists = await ctx.Users
            .AnyAsync(x => x.Id != request.Id && x.Email == request.Email, ct);

        if (exists)
        {
            throw new MarketConflictException("User with this Email already exists.");
        }

        user.Email = request.Email.Trim();
        user.ModifiedAtUtc = DateTime.UtcNow;
        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}