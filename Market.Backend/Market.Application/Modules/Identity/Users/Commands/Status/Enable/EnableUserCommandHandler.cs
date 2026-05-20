namespace Market.Application.Modules.Catalog.ProductCategories.Commands.Status.Enable;

public sealed class EnableUserCommandHandler(IAppDbContext ctx)
    : IRequestHandler<EnableUserCommand, Unit>
{
    public async Task<Unit> Handle(EnableUserCommand request, CancellationToken ct)
    {
        var user = await ctx.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (user == null)
            throw new MarketNotFoundException("User not found.");

        if (user.IsEnabled)
        {
            throw new MarketConflictException("User is already enabled");
        }
        
        user.IsEnabled = true;
        user.ModifiedAtUtc = DateTime.UtcNow;
        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}