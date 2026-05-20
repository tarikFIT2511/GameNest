namespace Market.Application.Modules.Catalog.ProductCategories.Commands.Update;

public sealed class UpdateUserCommandHandler(IAppDbContext ctx)
            : IRequestHandler<UpdateUserCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken ct)
    {
        var user = await ctx.Users
            .Where(x => x.Id == request.Id)  //not finished
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

        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}