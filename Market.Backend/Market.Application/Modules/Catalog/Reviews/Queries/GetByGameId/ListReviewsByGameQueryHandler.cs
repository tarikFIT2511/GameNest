namespace Market.Application.Modules.Catalog.Reviews.Queries.GetByGameId;

public sealed class ListReviewsByGameQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListReviewsByGameQuery, PageResult<ListReviewsByGameQueryDto>>
{
    public async Task<PageResult<ListReviewsByGameQueryDto>> Handle(
        ListReviewsByGameQuery request, CancellationToken ct)
    {
        var q = ctx.Reviews.AsNoTracking()
            .Where(x => x.GameId == request.GameId);

        var projectedQuery = q.OrderByDescending(x => x.CreatedAtUtc)
            .Select(x => new ListReviewsByGameQueryDto
            {
                Id = x.Id,
                Rating = x.Rating,
                Comment = x.Comment,
                CreatedAtUtc=x.CreatedAtUtc,
                User = new ListReviewsByGameQueryUserDto
                {
                    Id = x.UserId,
                    Username = x.User.Username,
                    Profile = new ListReviewsByGameQueryUserProfileDto
                    {
                        AvatarUrl = x.User.Profile.AvatarUrl
                    }
                }
            });

        return await PageResult<ListReviewsByGameQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
    }
}
