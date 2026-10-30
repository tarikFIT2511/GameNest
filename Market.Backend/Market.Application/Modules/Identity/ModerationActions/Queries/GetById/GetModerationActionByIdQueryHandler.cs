namespace Market.Application.Modules.Identity.ModerationActions.Queries.GetById;

public class GetModerationActionByIdQueryHandler(IAppDbContext ctx) : IRequestHandler<GetModerationActionByIdQuery, GetModerationActionByIdQueryDto>
{
    public async Task<GetModerationActionByIdQueryDto> Handle(GetModerationActionByIdQuery request, CancellationToken ct)
    {
        var moderationAction = await ctx.ModerationActions
            .Where(ma => ma.Id == request.Id)
            .Select(x => new GetModerationActionByIdQueryDto
            {
                Id = x.Id,
                AdminUserId = x.AdminUserId,
                AdminUsername = x.AdminUser.Username,
                TargetUserId = x.TargetUserId,
                TargetUsername = x.TargetUser.Username,
                ActionType = x.ActionType,
                Reason = x.Reason ?? "Not specified.",
                CreatedAt = x.CreatedAtUtc
            }).FirstOrDefaultAsync(ct);

        if (moderationAction == null)
        {
            throw new MarketNotFoundException($"Moderation action with Id {request.Id} not found.");
        }

        return moderationAction;
    }
}