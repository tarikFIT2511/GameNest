namespace Market.Application.Modules.Catalog.Games.Commands.Update;

public sealed class UpdateGameHandler(IAppDbContext ctx)
            : IRequestHandler<UpdateGameCommand, Unit>
{
    public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken ct)
    {
        var entity = await ctx.Games
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(ct);

        if (entity is null)
            throw new MarketNotFoundException($"Game (ID={request.Id}) not found.");

        // Check for duplicate name (case-insensitive, except for the same ID)
        var exists = await ctx.Games
            .AnyAsync(x => x.Id != request.Id && x.Title.ToLower() == request.Title.ToLower(), ct);

        if (exists)
        {
            throw new MarketConflictException("Name already exists.");
        }

        entity.Title = request.Title.Trim();
        entity.Description = request.Description?.Trim();
        entity.Price = request.Price;
        entity.ReleaseDate = request.ReleaseDate;
        entity.CoverImageUrl = request.CoverImageUrl?.Trim();
        

        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}