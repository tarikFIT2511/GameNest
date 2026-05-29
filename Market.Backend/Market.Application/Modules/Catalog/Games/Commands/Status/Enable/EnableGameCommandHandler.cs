namespace Market.Application.Modules.Catalog.Games.Commands.Status.Enable;

public sealed class EnableGameCommandHandler(IAppDbContext ctx)
    : IRequestHandler<EnableGameCommand, Unit>
{
    public async Task<Unit> Handle(EnableGameCommand request, CancellationToken ct)
    {
        var entity = await ctx.Games
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            throw new MarketNotFoundException($"Game (ID={request.Id}) not found.");

        if (!entity.IsEnabled)
        {
            entity.IsEnabled = true;
            await ctx.SaveChangesAsync(ct);
        }

        // If already enabled — nothing changes, idempotent
        return Unit.Value;
    }
}