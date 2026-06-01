namespace Market.Application.Modules.Catalog.Games.Queries.List;

public sealed class ListGamesQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListGamesQuery, PageResult<ListGamesQueryDto>>
{
    public async Task<PageResult<ListGamesQueryDto>> Handle(
        ListGamesQuery request, CancellationToken ct)
    {
        var q = ctx.Games.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            q = q.Where(x => x.Title.Contains(request.Search!));
        }

        if (request.OnlyEnabled is not null)
            q = q.Where(x => x.IsEnabled == request.OnlyEnabled);

        var projectedQuery = q.OrderBy(x => x.Title)
            .Select(x => new ListGamesQueryDto
            {
                Id = x.Id,
                Title = x.Title,
                Price = x.Price,
                CoverImageUrl = x.CoverImageUrl

            });

        return await PageResult<ListGamesQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
    }
}
