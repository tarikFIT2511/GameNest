namespace Market.Application.Modules.Identity.ModerationActions.Queries.List;

public sealed class ListModerationActionsQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListModerationActionsQuery, PageResult<ListModerationActionsQueryDto>>
{
    public async Task<PageResult<ListModerationActionsQueryDto>> Handle(
        ListModerationActionsQuery request, CancellationToken ct)
    {
        var q = ctx.ModerationActions.AsNoTracking();

        if (request.TargetUserId.HasValue) //search by target user
        {
            q = q.Where(x => x.TargetUserId == request.TargetUserId.Value);
        }

        if (request.ActionType.HasValue) // search by action type
        {
            q = q.Where(x => x.ActionType == request.ActionType.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var search = request.Search.Trim();

            q = q.Where(x =>
                x.TargetUser.Username.Contains(search) ||
                x.AdminUser.Username.Contains(search) ||
                (x.Reason != null && x.Reason.Contains(search)));
        }

        var projectedQuery = q.OrderByDescending(x => x.CreatedAtUtc)
            .Select(x => new ListModerationActionsQueryDto
            {
                Id = x.Id,
                AdminUserId = x.AdminUserId,
                AdminUsername = x.AdminUser.Username,
                TargetUserId = x.TargetUserId,
                TargetUsername = x.TargetUser.Username,
                ActionType = x.ActionType,
                Reason = x.Reason ?? "Not specified.",
                CreatedAt = x.CreatedAtUtc
            });

        return await PageResult<ListModerationActionsQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
    }
}
