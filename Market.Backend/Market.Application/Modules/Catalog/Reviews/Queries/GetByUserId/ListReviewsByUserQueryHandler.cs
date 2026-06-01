using static Market.Application.Modules.Catalog.Reviews.Queries.GetByUserId.ListReviewsByUserQueryDto;

namespace Market.Application.Modules.Catalog.Reviews.Queries.GetByUserId;

public sealed class ListReviewsByUserQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListReviewsByUserQuery, PageResult<ListReviewsByUserQueryDto>>
{
    public async Task<PageResult<ListReviewsByUserQueryDto>> Handle(
        ListReviewsByUserQuery request, CancellationToken ct)
    {
        var q = ctx.Reviews.AsNoTracking()
            .Where(x => x.UserId == request.UserId);

        var projectedQuery = q.OrderByDescending(x => x.CreatedAtUtc)
            .Select(x => new ListReviewsByUserQueryDto
            {
                Id = x.Id,
                Rating = x.Rating,
                Comment = x.Comment,
                CreatedAtUtc=x.CreatedAtUtc,
                Game = new ListReviewsByUserQueryGameDto
                {
                    Id = x.GameId,
                    Title = x.Game.Title
                }
            });

        return await PageResult<ListReviewsByUserQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
    }
}
