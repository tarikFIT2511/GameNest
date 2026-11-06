namespace Market.Application.Modules.Identity.ModerationActions.Queries.List;

public sealed class ListModerationActionsQuery : BasePagedQuery<ListModerationActionsQueryDto>
{
    public string? Search { get; init; }
    public int? TargetUserId { get; init; }
    public ModerationActionType? ActionType { get; init; }
}
