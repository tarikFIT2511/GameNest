namespace Market.Application.Modules.Identity.ModerationActions.Commands.Create;

public class CreateModerationActionCommandHandler(IAppDbContext ctx)
    : IRequestHandler<CreateModerationActionCommand, int>
{
    public async Task<int> Handle(CreateModerationActionCommand request, CancellationToken ct)
    {
        // TODO: Replace request.AdminUserId with the currently authenticated user's ID
        // using IAppCurrentUser. Verify admin authorization before allowing moderation.

        if (!Enum.IsDefined(request.ActionType))
        {
            throw new MarketBusinessRuleException("100", "Invalid moderation action");
        }

        var admin = await ctx.Users.FirstOrDefaultAsync(u => u.Id == request.AdminUserId, ct);

        if (admin == null)
        {
            throw new MarketNotFoundException("Admin user not found.");
        }

        var target = await ctx.Users.FirstOrDefaultAsync(u => u.Id == request.TargetUserId, ct);
        
        if (target == null)
        {
            throw new MarketNotFoundException("Target user not found.");
        }
        //check if target is already banned
        if (request.ActionType == ModerationActionType.Ban && !target.IsEnabled)
        {
            throw new MarketConflictException("User is already banned.");
        }
        //check if target is already unbanned
        if (request.ActionType == ModerationActionType.Unban && target.IsEnabled)
        {
            throw new MarketConflictException("User is not banned.");
        }

        var moderationAction = new ModerationActionEntity
        {
            AdminUserId = admin.Id,
            TargetUserId = target.Id,
            ActionType = request.ActionType,
            Reason = request.Reason?.Trim() ?? string.Empty
        };

        switch (request.ActionType)
        {
            case ModerationActionType.Ban:
                target.IsEnabled = false;
                break;

            case ModerationActionType.Unban:
                target.IsEnabled = true;
                break;

            case ModerationActionType.Warning:
                break;
        }

        ctx.ModerationActions.Add(moderationAction);
        await ctx.SaveChangesAsync(ct);

        return moderationAction.Id;
    }
}