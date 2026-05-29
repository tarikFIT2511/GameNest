namespace Market.Application.Modules.Catalog.Games.Commands.Status.Disable;

public sealed class DisableGameCommandHandler(IAppDbContext ctx)
    : IRequestHandler<DisableGameCommand, Unit>
{
    public async Task<Unit> Handle(DisableGameCommand request, CancellationToken ct)
    {
        var cat = await ctx.Games
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (cat is null)
        {
            throw new MarketNotFoundException($"Game (ID={request.Id}) not found.");
        }

        if (!cat.IsEnabled) return Unit.Value; // idempotent


        cat.IsEnabled = false;

        await ctx.SaveChangesAsync(ct);

        // await _bus.PublishAsync(new ProductCategoryDisabledV1IntegrationEvent(cat.Id, ...), ct);
        // await _cache.RemoveAsync(CacheKeys.CategoriesList, ct);

        return Unit.Value;
    }
}